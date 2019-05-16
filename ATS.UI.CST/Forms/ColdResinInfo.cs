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
    public partial class ColdResinInfo : UserFormBase
    {
        public ColdResinInfo()
        {
            InitializeComponent();
            Load += ColdResinInfo_Load;

            Language.SetText("Have", "Have", "有膠材");
            Language.SetText("Expired", "Expired", "過期膠材");
            Language.SetText("ColdResinInfoTitle", "ResinInfo", "冷藏膠材資訊");
            Language.SetText("ColdResinLocation", "Location", "庫位");
        }
        private void ColdResinInfo_Load(object Sender, EventArgs e)
        {
            if (ATS.Models.UserData.Instance.Now.Level > 3)
            {
                BtDelect.Visible = true;
            }
            SetTitle(Language.Text("ColdResinInfoTitle"));
        }



        public void SetInfo(int Location,CST.Controls.ColdResinInfo Rs)
        {
            TbLotNo.Text = Rs.SlotID;
            TbLocation.Text =Language.Text("ColdResinLocation") +  Location.ToString();
            TbColdType.Text = Rs.ColdType == 1 ? Language.Text("Have") : Language.Text("Expired");
            TbExpiredTime.Text = Rs.ExpiredTime;
            TbInColdOperator.Text = Rs.InColdOperator;
            TbInColdTime.Text =Convert.ToDateTime(Rs.InColdTime).ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtDelect_Click(object sender, EventArgs e)
        {

            try
            {
                int l = TbLocation.Text.Length;
                int i = int.Parse(TbLocation.Text.Substring(l - 1, 1));

                DeleteDataAtPLC(i);
            }
            catch (Exception err)
            { ATS.LCSCommon.WriteAppErrorLog(err.Message); }
        }

        private static void DeleteDataAtPLC(int i)
        {
            PLCconnect.PLCCommon.PLC_WRITE((1789 + i).ToString(), "1", "1");
            PLCconnect.PLCCommon.PLC_WRITE((1789 + i).ToString(), "0", "1");
        }
    }
}
