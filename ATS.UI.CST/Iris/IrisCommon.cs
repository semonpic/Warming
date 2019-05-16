using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using R100ManagerSDKLib;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace R100Test
{
    public partial class frmIrisOperator
    {
        public static event Action<string> OnIrisLoginSuccess = null;
        public static event Action OnIrisLoginFail = null;
        internal R100DeviceControl control = new R100DeviceControl(); //R100 Control
        private CapturedImages _capturedImage = new CapturedImages();
        private readonly string _TempImagesDirectory = "Temp"; // 虹膜儲存的資料夾
        CHostDBCtrl m_HostDBControl = new CHostDBCtrl();
        string strValue;
        public byte[] m_pLeftIrisImage;  //左眼球圖片
        public byte[] m_pRightIrisImage; //右眼球圖片
        int m_nEYE;
        int nResult;
        bool IsEnroll = false;
        string UserID = "";
        string UserName = "";
        int UserLevel = 0;

        private bool LoadEnrolledUserInfo(string SendUserID)
        {

            int nNumOfUser;
            string[,] strUserDB;
            int nResult = m_HostDBControl.LoadEnrolledUserInfo(out nNumOfUser, out strUserDB);

            if (nResult == Constants.IS_ERROR_NONE)
            {
                
                for (int i = 0; i < nNumOfUser; i++)
                {
                   if (strUserDB[i, 1] == SendUserID)
                    {
                        return true;
                    }
                }
            }
            return false;
        } // 查看目前用戶有無虹膜眼球
        public void inicontrol()
        {
            control.OnGetIrisImage += new _IR100DeviceControlEvents_OnGetIrisImageEventHandler(OnGetIrisImage);
            control.OnEnrollReport += new _IR100DeviceControlEvents_OnEnrollReportEventHandler(OnEnrollReport);
            control.OnMatchReport += new _IR100DeviceControlEvents_OnMatchReportEventHandler(OnMatchReport);
            //if (!Directory.Exists(_TempImagesDirectory))  // 如果沒有Temp創建一個
            //{
            //    Directory.CreateDirectory(_TempImagesDirectory);
            //}

            try
            {
                nResult = control.Close();
                nResult = control.Open();
                if (nResult != 0)
                {
                    TbMessage.AppendText("虹膜開啟失敗\r\n");
                }
                nResult = control.GetSerialNumber(out strValue);
                if (nResult != Constants.IS_ERROR_NONE)
                {
                    TbMessage.AppendText("虹膜開啟發生錯誤\r\n");
                }
                nResult = m_HostDBControl.Open(strValue);
                //LoadEnrolledUserInfo(); // 開啟時載入用戶資訊使用
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        } // 開啟時設定虹膜Control
        private class CapturedImages
        {
            public byte[] RawLeftIris;
            public byte[] RawRightIris;
        } //放眼球資料使用
        public string ConvertToString(sbyte[] arr)
        {
            string returnStr;

            unsafe
            {

                fixed (sbyte* fixedPtr = arr)
                {
                    returnStr = new string(fixedPtr);
                }
            }

            return (returnStr);
        }
        private int SaveIrisImage(string strDirectory, string strFileName, byte[] pBuff, out string strPath)
        {
            strPath = string.Empty;

            if (!Directory.Exists(strDirectory))
                Directory.CreateDirectory(strDirectory);


            if (pBuff != null && pBuff.Length != 0)
            {
                Image imageIris = Helper.RawToBitmap(pBuff, 640, 480, PixelFormat.Format8bppIndexed);
                strPath = strDirectory + @"\" + strFileName + ".bmp";

                imageIris.Save(strPath, ImageFormat.Bmp);

                return Constants.IS_RST_SUCCESS;
            }

            return Constants.IS_RST_FAILURE;
        } // 儲存眼球資料
        
        //顯示用戶眼球照片
        private void OnGetIrisImage(int nRightIrisFEDStatus, int nRightIrisLensStatus, int nRightIrisImageSize, object objRightIrisImage, int nLeftIrisFEDStatus, int nLeftIrisLensStatus, int nLeftIrisImageSize, object objLeftIrisImage)
        {

            try
            {

                m_nEYE = 0;

                if (nRightIrisImageSize != 0)
                {
                    m_nEYE += 1;
                    picRightEye.Image = Helper.RawToBitmap((byte[])objRightIrisImage, 640, 480, PixelFormat.Format8bppIndexed);


                    picLeftEye.Image = Helper.RawToBitmap((byte[])objLeftIrisImage, 640, 480, PixelFormat.Format8bppIndexed);
                    _capturedImage.RawRightIris = (byte[])objRightIrisImage;
                    //_capturedImage.RawLeftIris = (byte[])objLeftIrisImage;
                }

                if (nLeftIrisImageSize != 0)
                {
                    m_nEYE += 2;
                    _capturedImage.RawLeftIris = (byte[])objLeftIrisImage;
                }



            }
            finally
            {

                m_pRightIrisImage = (byte[])objRightIrisImage;
                m_pLeftIrisImage = (byte[])objLeftIrisImage;
                IsEnroll = false;


            }

        }
        private void OnEnrollReport(int nReportResult, int nFailureCode, int nRightIrisQualityValue, int nLeftIrisQualityValue, string strMatchedUserID) //註冊眼球用事件
        {

            int nResult;
            stUSERINFO stEnrolledUserInfo;
            string[] strUserInfo;
            string strRPath = string.Empty;
            string strLPath = string.Empty;
            string strFacePath = string.Empty;
            string m_strUserID = UserID;

            if (nReportResult == Constants.IS_RST_SUCCESS)
            {

                control.ControlIndicator(Constants.IS_SND_FINISH_IRIS_CAPTURE, Constants.IS_IND_SUCCESS);

                stEnrolledUserInfo = new stUSERINFO();

                nResult = control.GetUserInfo(m_strUserID, out stEnrolledUserInfo);

                if (nResult == Constants.IS_ERROR_NONE)
                {
                    string guid = Guid.NewGuid().ToString();

                    if (m_nEYE != Constants.IS_EYE_LEFT)
                    {
                        nResult = SaveIrisImage(_TempImagesDirectory, "R" + m_strUserID + "_" + guid, _capturedImage.RawRightIris, out strRPath);

                        if (nResult != Constants.IS_RST_SUCCESS)
                        {

                            return;
                        }
                    }
                    if (m_nEYE != Constants.IS_EYE_RIGHT)
                    {
                        nResult = SaveIrisImage(_TempImagesDirectory, "L" + m_strUserID + "_" + guid, _capturedImage.RawLeftIris, out strLPath);

                        if (nResult != Constants.IS_RST_SUCCESS)
                        {

                            return;
                        }
                    }



                    if (m_HostDBControl.IsAvailable())
                    {
                        m_HostDBControl.InsertUserInfo(m_strUserID, nRightIrisQualityValue, nLeftIrisQualityValue, strFacePath, strRPath, strLPath, ConvertToString(stEnrolledUserInfo.pInsertDate), ConvertToString(stEnrolledUserInfo.pUpdateDate), UserName,UserLevel);

                        m_HostDBControl.SelectEnrolledUserInfo(m_strUserID, out strUserInfo);

                        //ListViewItem item = new ListViewItem(strUserInfo[0]);
                        //item.SubItems.Add(strUserInfo[1]);
                        //item.SubItems.Add(strUserInfo[2]);
                        //MessageBox.Show("User ID :" + strUserInfo[1]);
                        //MessageBox.Show("User Name :" + strUserInfo[2]);
                        //lstUserInfo.Items.Add(item);
                        if (this.Visible)
                        {
                            //cmdIdentify.Visible = true;
                        }
                        TbMessage.AppendText("新增用戶 => UserID :" + strUserInfo[1] + "成功\r\n");
                       // TbMessgae.AppendText("新增用戶 => UserID :" + strUserInfo[1] + "成功");
                    } 

                }
            }
            else
            {

                if (nFailureCode == Constants.IS_FAIL_ALREADY_EXIST)
                {
                    string sure = "確定要重新註冊用戶虹膜 ? (舊有資料會先刪除)";
                    nResult = 1;
                    try
                    {
                        if (MessageBox.Show(sure, "註冊提醒", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            nResult = control.DeleteUserInfo(userID.ToString());
                            if (nResult == 0)
                            {
                                m_HostDBControl.DeleteUserInfo(userID.ToString());
                                try
                                {
                                    EnrollUser(userID.ToString(), userName,UserLevel);
                                }

                                catch (Exception err)
                                {
                                    TbMessage.AppendText("重新註冊用戶時發生錯誤,錯誤階段->註冊用戶\r\n");
                                    ATS.LCSCommon.WriteAppErrorLog(err);
                                }

                            }

                        }
                    }
                    catch (Exception err)
                    {
                        TbMessage.AppendText("註冊用戶時發生錯誤,錯誤階段->刪除用戶\r\n");
                        ATS.LCSCommon.WriteAppErrorLog(err);
                    }


                    if (nResult == Constants.IS_ERROR_NONE)
                    {
                        TbMessage.AppendText("新增用戶失敗 => 已有用戶\r\n");
                    }
                   //TbMessgae.Text = ("新增用戶失敗 => 已有用戶");
                }

                if (nFailureCode == Constants.IS_FAIL_LOW_QUALITY)
                {
                    TbMessage.AppendText("新增用戶失敗 => 辨識率過低\r\n");
                    //TbMessgae.Text = ("新增用戶失敗 => 辨識率過低");
                }
                control.ControlIndicator(Constants.IS_SND_NONE, Constants.IS_IND_FAILURE);
                //cmdReEnroll.Visible = true;

            }
           // LoadEnrolledUserInfo();
        }   
        private void OnMatchReport(int nMatchType, int nReportResult, int nFailureCode, string strMatchedUserID)
        {
            try
            {
                int nResult;

                string[] strUserInfo;

                //initFrameIrisCamera();



                if (nReportResult == Constants.IS_ERROR_NONE)
                {
                    if (nMatchType == Constants.IS_REP_IDENTIFY)
                    {
                        TbMessage.AppendText("驗證成功\r\n");
                    }
                    else if (nMatchType == Constants.IS_REP_VERIFY_ID)
                    {
                        TbMessage.AppendText("驗證成功\r\n");
                    }
                    else if (nMatchType == Constants.IS_REP_VERIFY_TEMPLATE)
                    {
                        TbMessage.AppendText("驗證成功\r\n");
                    }

                    control.ControlIndicator(Constants.IS_SND_IDENTIFIED, Constants.IS_IND_SUCCESS);

                    if (nMatchType != Constants.IS_REP_VERIFY_TEMPLATE)
                    {
                        nResult = m_HostDBControl.SelectEnrolledUserInfo(strMatchedUserID, out strUserInfo);

                        if (nResult == Constants.IS_ERROR_NONE)
                        {
                            //MessageBox.Show("User ID : " + strUserInfo[1] + "User Name : " + strUserInfo[2]);
                            TbMessage.AppendText("User ID : " + strUserInfo[1] + "\r\n");
                            TbMessage.AppendText("User Name : " + strUserInfo[2] + "\r\n");
                            //txtUser_ID.Text = strUserInfo[1];
                            //txtUserName.Text = strUserInfo[2];
                            //txtCardName.Text = strUserInfo[8];
                            //txtCardID.Text = strUserInfo[9];


                            //labRQuality.Text = strUserInfo[6];
                            //labLQuality.Text = strUserInfo[7];

                            //txtInsertDate.Text = strUserInfo[10];

                            //picEnrolledAudit.ImageLocation = strUserInfo[3];
                            //picEnrolledREye.ImageLocation = strUserInfo[4];
                            //picEnrolledLEye.ImageLocation = strUserInfo[5];

                            //顯示用戶ID與Name使用
                            //frmLogin frm = new frmLogin();
                            //frm.IrisDoLogin(strUserInfo[1], strUserInfo[2]);
                            TBUserName.Text = strUserInfo[2];
                            if (this.Visible)
                            {
                              //  cmdIdentify.Visible = true;
                            }
                            if (OnIrisLoginSuccess != null)
                            {
                                OnIrisLoginSuccess(strUserInfo[2]);
                            }
                        }
                    }


                }
                else
                {
                    if (IsEnroll == false)
                    {
                        control.ControlIndicator(Constants.IS_SND_NOT_IDENTIFY, Constants.IS_IND_FAILURE);
                        TbMessage.AppendText("查無此用戶\r\n");
                        if (OnIrisLoginFail != null)
                        {
                            OnIrisLoginFail();
                            if (this.Visible)
                            {
                                //cmdIdentify.Visible = false;
                            }
                        }
                    }

                    //ProcessError(nFailureCode);

                }

            }
            finally
            {
                //if (IsEnroll == false)
                //{
                //    nResult = control.IdentifyUser(3, 0, 0, 0, 0, 0);
                //}
            }
        } //辨識眼球用事件


        public void EnrollUser(string SendUserID ,string SendUserName,int LV) // 註冊用戶使用
        {
            int nResultTest = control.AbortCapture();
            IsEnroll = true;
            int nResult = 0;
            int nWhichEye = 3;
            int nCounterMeasureLevel = 0;
            int nLensDetectionLevel = 0;
            int nIsLive = 0;
            int nIsAuditFace = 0;
            int nIsRetry = 0;
            int nIsVerify = 0;
            int nTimeOut = 20;
            UserID = SendUserID;
            UserName = SendUserName;
            UserLevel = LV;
            nResult = control.EnrollUser(UserID, nWhichEye, nCounterMeasureLevel, nLensDetectionLevel, nTimeOut, nIsAuditFace, nIsLive, nIsRetry, nIsVerify);
            if (nResult != 0)
            {
                TbMessage.AppendText("新增用戶失敗!請確認虹膜辨識機器是否開啟!\r\n");
            }
            control.ControlIndicator(4, 0);
        }
        public void Identify()
        {
            picLeftEye.Image = null;
            picRightEye.Image = null;
            goidentify();
        }
        public void goidentify()
        {
            control.AbortCapture();
            nResult = control.IdentifyUser(3, 0, 1, 20, 0, 0);
            if (nResult != 0)
            {
                TbMessage.AppendText("識別用戶發生 錯誤\r\n");
            }
        }

    }
}