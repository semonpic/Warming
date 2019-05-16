using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;
using WiseTech.Log;
using ATS.Models;
using System.Threading;


namespace ATS.UI.CST.Controls
{
    public partial class MatchImformationPanel : UserControl
    {

        //private BarcoReader BarcoReader = new BarcoReader();
        private string NowSlotID;
        private string NowShelfTime;
        private static bool MatchResult = false;
        internal static bool TaskStart = false;
        public static bool InformationSendSuccess = false;
       

        public MatchImformationPanel()
        {
            InitializeComponent();
            BarcoReader.ResinEvent += ShowImformation;
           // PLCconnect.WriteInClod.BarcoReaderEvent += ShowBarcoInfo;
            PLCconnect.WriteInClod.SendInformation += ShowBarcoInfo;
        }

        private void MatchImformationPanel_Load(object sender, EventArgs e)
        {
            this.Left = (Parent.Width - Width) >> 1;
            this.Top = 42;
        }
        internal void IniMatchPanel()
        {

            PbBarco.Image.Dispose();
            PbSlotID.Image.Dispose();
            PbShelfLife.Image.Dispose();

            PbBarco.Image = Properties.Resources.Error;
            PbSlotID.Image = Properties.Resources.Error;
            PbShelfLife.Image =  Properties.Resources.Error;

            LbReaderBarco.Text = "";
            LbReaderShelf.Text = "";
            LbReaderSlotID.Text = "";
            BtnStart.Visible = false;
            InformationSendSuccess = false;
            MatchResult = false;

        }
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            try
            {
                bool isClose = true;
                if (MatchResult == true)
                {
                    if (MessageBox.Show("確認要取消此次入庫嗎?", "入庫取消提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        isClose = false;
                    }
                }
                if (isClose == true)
                {
                    NowSlotID = "";
                    NowShelfTime = "";
                    Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 點擊 " + BtnCancle.Text);
                    PLCconnect.WriteSystem.WriteSystemStop();
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                    ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    Parent.Controls.Remove(this);
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
           
        }

        private void ShowImformation(string Imformation)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                //"1801930101;;8088X78;1.4;20190224;20180825\r";
                string[] ImformationArray = Imformation.Split(';');

                LbPdaBarco.Text = ImformationArray[0];
                LbPdaSlotID.Text = ImformationArray[2];
                LbPdaShelf.Text = ImformationArray[4];

                PbBarco.Image.Dispose();
                PbSlotID.Image.Dispose();
                PbShelfLife.Image.Dispose();

                PbBarco.Image = LbPdaBarco.Text == LbReaderBarco.Text ? Properties.Resources.MatchSuccess1 : Properties.Resources.Error;
                PbSlotID.Image = LbPdaSlotID.Text == LbReaderSlotID.Text ? Properties.Resources.MatchSuccess1 : Properties.Resources.Error;
                PbShelfLife.Image = LbPdaShelf.Text == LbReaderShelf.Text ? Properties.Resources.MatchSuccess1 : Properties.Resources.Error;
                if (LbPdaSlotID.Text == LbReaderSlotID.Text && LbPdaShelf.Text == LbReaderShelf.Text)
                {
                    //BtnStart.Visible = true;
                    //NowSlotID = ImformationArray[2];
                    //NowShelfTime = ImformationArray[4];
                    //MatchResult = true;
                    //Start();
                }
                else
                {
                    BtnStart.Visible = false;
                }
            });
        }


        private void ShowBarcoInfo(string Info)
        {
            string[] ImformationArray = Info.Split(';');

            ThreadSafeHelper.UIThread(this, () =>
            {
                LbReaderBarco.Text = ImformationArray[0];
                LbReaderSlotID.Text = ImformationArray[2];
                LbReaderShelf.Text = ImformationArray[4];

                PbBarco.Image.Dispose();
                PbSlotID.Image.Dispose();
                PbShelfLife.Image.Dispose();


                PbBarco.Image = (LbPdaBarco.Text == LbReaderBarco.Text) ? Properties.Resources.MatchSuccess1 : Properties.Resources.Error;
                PbSlotID.Image = LbPdaSlotID.Text == LbReaderSlotID.Text ? Properties.Resources.MatchSuccess1 : Properties.Resources.Error;
                PbShelfLife.Image = LbPdaShelf.Text == LbReaderShelf.Text ? Properties.Resources.MatchSuccess1 : Properties.Resources.Error;
                MatchResult = true;
            });





            ThreadSafeHelper.UIThread(this, () =>
            {
            if (LbPdaSlotID.Text == LbReaderSlotID.Text && LbPdaShelf.Text == LbReaderShelf.Text)
                {
                    if (SystemConfig.TempCheck == "1")
                    {
                        if (PLCconnect.ReadSystemStatus.PlcStatus[7])
                        {
                            if (InformationSendSuccess == false)
                            {
                                PLCconnect.WriteInClod.GetBarcoImformation = true;
                                InformationSendSuccess = true;
                                NowSlotID = ImformationArray[2];
                                NowShelfTime = ImformationArray[4];
                                
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("膠材溫度過高，無法進行入庫，請將膠材取出", "膠材溫度過高提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                Logger.Log(ATSData.SystemLog, UserData.Instance.Now.Name + "將膠材進行取出：膠材溫度過高");
                            }
                        }
                    }
                    else
                    {
                        if (InformationSendSuccess == false)
                        {
                            InformationSendSuccess = true;
                            NowSlotID = ImformationArray[2];
                            NowShelfTime = ImformationArray[4];
                            //Start();
                        }
                    }
                }
                else
                {
                    BtnStart.Visible = false;
                    MessageBox.Show("條碼比對錯誤，請確認是否為正確膠材，並重新 進行入料");
                }
            });


            SpinWait.SpinUntil(() => { return false; }, 2000);

            if (InformationSendSuccess)
            {
                Start();
            }
        }

        private void BtnRetry_Click(object sender, EventArgs e)
        {
            try
            {
                ParentForm.Controls.Add(ControlPanel.BarcoReaderFrm);
                ParentForm.Controls.SetChildIndex(ControlPanel.BarcoReaderFrm, 0);
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                TaskStart = true;
                ParentForm.Controls.Remove(this);
                PLCconnect.WriteInClod.MatchDataWithBarco(NowSlotID, NowShelfTime);
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }


        private void Start()
        {
            ThreadSafeHelper.UIThread(this, () => { 
            TaskStart = true;
            PLCconnect.WriteInClod.MatchDataWithBarco(NowSlotID, NowShelfTime);
            ParentForm.Controls.Remove(BarcoReader.MatchImformationPanel1);
            });

        }

        private void BtnReread_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認要重新讀取瓶身條碼?", "重新讀取提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1740", "0", "1");
                PLCconnect.PLCCommon.PLC_WRITE("1741", "0", "1");
                System.Threading.Thread.Sleep(1000);
                PLCconnect.WriteInClod.WriteInColdSaveTime(LbPdaShelf.Text);
                PLCconnect.PLCCommon.PLC_WRITE("1703", "1", "1");
                PLCconnect.PLCCommon.PLC_WRITE("1703", "0", "1");
            }
            
        }
    }
}
