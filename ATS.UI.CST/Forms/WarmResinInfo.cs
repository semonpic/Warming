using ATS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;

namespace ATS.UI.CST.Forms
{
    public partial class WarmResinInfo : UserFormBase
    {
        CST.Controls.WarmResinInfo LocalWR;
        int LocalLocation;
        DateTime InWarmTime;
        Timer WarmTimeClick = new Timer();
        public WarmResinInfo()
        {
            InitializeComponent();
            Load += WarmResinInfo_Load;
            Language.SetText("WarmResinInfoTitle", "ResinInfo", "回溫膠材資訊");
            Language.SetText("WarmResinLocation", "Location", "庫位");
            Language.SetText("WarmResinInfo.Warmed", "Warmed", "回溫完成");
            Language.SetText("WarmResinInfo.Warming", "Warming", "回溫中");
            Language.SetText("WarmResinInfo.OverTime1", "Expired 1st", "逾時階段(一)");
            Language.SetText("WarmResinInfo.OverTime2", "Expired 2rd", "逾時階段(二)");


        }

        private void WarmTimeClick_Tick(object sender, EventArgs e)
        {
            try
            {
                WarmTimeClick.Enabled = false;
                if (LocalWR != null)
                {
                    InWarmTime = Convert.ToDateTime(LocalWR.InWarmTime);
                    TimeSpan TS = DateTime.Now - InWarmTime;
                    TbWarmTime.Text = String.Format("{0}時 {1}分 {2}秒", (TS.Days * 24) + TS.Hours, TS.Minutes, TS.Seconds);

                }
            }
            catch (Exception err)
            {
                return;
            }

            finally
            {
                WarmTimeClick.Enabled = true;
            }
        }
        private void WarmResinInfo_Load(object Sebder, EventArgs e)
        {
            if (ATS.Models.UserData.Instance.Now.Level > 3)
            {
                BtDelect.Visible = true;
            }
            SetTitle(Language.Text("WarmResinInfoTitle"));

            
            WarmTimeClick.Tick += WarmTimeClick_Tick;
            WarmTimeClick.Interval = 1000;
            WarmTimeClick.Enabled = true;
        }

        private void BtDelect_Click(object sender, EventArgs e)
        {
            if (UserData.Instance.Now.Level < 3)
            { return; }
            if ((MessageBox.Show("確認要刪除這個庫位的資訊嗎?", "提醒資訊", MessageBoxButtons.OKCancel)) == DialogResult.OK)
            {
                Models.UserData.Instance.HandRemoveWarmResin(LocalLocation);
                DeleteDataAtPLC();
                WiseTech.Log.Logger.DeleteResinInfo(LocalLocation.ToString(), 2);
            }
        }

        private void DeleteDataAtPLC()
        {
            PLCconnect.PLCCommon.PLC_WRITE((1799 + LocalLocation).ToString(), "1", "1");
            PLCconnect.PLCCommon.PLC_WRITE((1799 + LocalLocation).ToString(), "0", "1");
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {

        }


        public void SetInfo(int Location, CST.Controls.WarmResinInfo Rs)
        {
            LocalLocation = Location;
            TbLotNo.Text = Rs.SlotID;
            TbLocation.Text = Language.Text("WarmResinLocation") + Location.ToString();
            TbWarmType.Text = Rs.WarmType == 0 ? Language.Text("WarmResinInfo.Warming") :
                (Rs.WarmType == 1 ? Language.Text("WarmResinInfo.Warmed") :
                (Rs.WarmType == 2 ? Language.Text("WarmResinInfo.OverTime1") : Language.Text("WarmResinInfo.OverTime2")));
                
            TbExpiredTime.Text = Rs.ExpiredTime;
            TbInWarmOperator.Text = Rs.InWarmOperator;
            TbInWarmTime.Text = Convert.ToDateTime(Rs.InWarmTime).ToString("yyyy/MM/dd HH:mm:ss");
            LocalWR = Rs;
        }

        private void BtConfirm_Click_1(object sender, EventArgs e)
        {
            WarmTimeClick.Stop();
            Close();
        }


    }
}
