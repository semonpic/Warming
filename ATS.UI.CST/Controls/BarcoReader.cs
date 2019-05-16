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
using PLCconnect;

namespace ATS.UI.CST.Controls
{
    public partial class BarcoReader : UserControl
    {
        private string BarcoReaderIn = "";
        public delegate void ResinImformation(string Message);
        public static event ResinImformation ResinEvent;
        public static MatchImformationPanel MatchImformationPanel1 = new MatchImformationPanel();
        public static Action StopTask = null;
        


        public BarcoReader()
        {
            InitializeComponent();
            Language.Bind("BarcoReader.labelTitle", this.labelTitle);
            Language.Bind("BarcoReader.LblBarcoLable", LblBarcoLable);
            Language.Bind("BarcoReader.BtnConfirm", BtnConfirm);
            Language.Bind("BarcoReader.BtnCancel", BtnCancel);
            Load += Load_BarcoReader;
        }

        private void Load_BarcoReader(object sender,EventArgs e)
        {
            this.Left = (Parent.Width - Width) >> 1;
            this.Top = 42;
            
        }

        public void BarcoFrmClear()
        {
            BarcoText.Text = "";
            //this.Focus();
            this.BarcoText.Focus();
        }


        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            
            BtnConfirm_Click1();
        }


        private void BtnConfirm_Click1()
        {
            try
            {
                if (!(BarcoText.Text.Length < 10))
                {
                    //"1801930101;;8088X78;1.4;20190224;20180825\r";
                    if (!(BarcoText.Text.Split(';').Length < 6))
                    {
                        
                        ParentForm.Controls.Add(MatchImformationPanel1);
                        ParentForm.Controls.SetChildIndex(MatchImformationPanel1, 0);
                        MatchImformationPanel1.IniMatchPanel();

                        BarcoReaderIn = BarcoText.Text;

                        if (ResinEvent != null)
                        {
                            ResinEvent(BarcoReaderIn);
                        }

                        ControlPanel.startButtonFlashMode = true;
                        WriteInClod.IncoldTask(BarcoReaderIn);
                        ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;

                        if (Parent != null)
                        {
                            Parent.Controls.Remove(this);
                        }
                    }
                    else
                    {
                        ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                        MessageBox.Show("請確認條碼輸入是否正確,或讀取資料是否正確", "錯誤提示訊息");
                        WiseTech.Log.Logger.SystemLog("條碼輸入失敗,請確認條碼輸入是否正確");
                    }
                }
                else
                {
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                    MessageBox.Show("請確認條碼輸入是否正確,或讀取資料是否正確", "錯誤提示訊息");
                    WiseTech.Log.Logger.SystemLog("條碼輸入失敗,請確認條碼輸入是否正確");
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            } 
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (StopTask != null)
            {
                StopTask();
            }
            Parent.Controls.Remove(this);
        }
    }
}
