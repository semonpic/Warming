using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace ATS.UI.CST.Controls
{
    public partial class OPRProgress : UserControl
    {
        public OPRProgress()
        {
            InitializeComponent();
            Load += OPRProgress_Load;
        }

        private void OPRProgress_Load(object sender, EventArgs e)
        {
            this.Left = (Parent.Width - Width) >> 1;
            this.Top = 42;

            IniLable();
            if (ATSData.ResetOK == true)
            {
                //OPRUDStatus.Text = "已完成";
                //OPRRTStatus.Text = "已完成";
                //OPRBTStatus.Text = "已完成";
                //OPRCTStatus.Text = "已完成";
                //OPRTRStatus.Text = "已完成";
            }
        }

        private void IniLable()
        {
            OPRUDStatus.Text = "未完成";
            OPRRTStatus.Text = "未完成";
            OPRBTStatus.Text = "未完成";
            OPRCTStatus.Text = "未完成";
            OPRTRStatus.Text = "未完成";
        }
        Task Task;
        CancellationTokenSource CTS;

        public void StartReset()
        {
            OPRUDStatus.Text = "未完成";
            OPRRTStatus.Text = "未完成";
            OPRBTStatus.Text = "未完成";
            OPRCTStatus.Text = "未完成";
            OPRTRStatus.Text = "未完成";

            OPRUDStatus.BackColor = Color.White;
            OPRRTStatus.BackColor = Color.White;
            OPRBTStatus.BackColor = Color.White;
            OPRCTStatus.BackColor = Color.White;
            OPRTRStatus.BackColor = Color.White;
            BtnConfirm.Visible = false;



            CTS = new CancellationTokenSource();
            Task = Task.Factory.StartNew(() => Start(CTS.Token), CTS.Token);
            Task.ContinueWith(TaskEnded);

        }


        private void Start(CancellationToken ct)
        {
            SpinWait.SpinUntil(() => { return false; }, 2000); ;
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    string Status = PLCconnect.ReadSystemStatus.MachineStatus[0];
                    //Status = "111011111111111";
                    string ReverseStatus = String.Join("", Status.Select(s => s).Reverse());
                    WiseTech.ThreadSafeHelper.UIThreadInvoke(this, () =>
                    {
                        UpdateOPRStatus(OPRUDStatus, ResetAxisUD(ReverseStatus));
                        UpdateOPRStatus(OPRRTStatus, ResetAxisRot(ReverseStatus));
                        UpdateOPRStatus(OPRBTStatus, ResetBT(ReverseStatus));
                        UpdateOPRStatus(OPRCTStatus, ResetAxisCT(ReverseStatus));
                        UpdateOPRStatus(OPRTRStatus, ResetAxisTransfer(ReverseStatus));

                    });
                    if (ResetAxisUD(ReverseStatus) &&
                     ResetAxisRot(ReverseStatus) &&
                     ResetBT(ReverseStatus) &&
                     ResetAxisCT(ReverseStatus) &&
                     ResetAxisTransfer(ReverseStatus))
                    {

                        CTS.Cancel();
                    }
                    Thread.Sleep(1000);
                }
                catch (Exception err)
                { }


            }


            return;
        }

        private void UpdateOPRStatus(Label label, bool state)
        {
            label.Text = state ? "已完成" : "未完成";
            label.BackColor = state ? Color.FromArgb(239, 228, 176) : Color.White;
        }

        private static bool ResetAxisTransfer(string ReverseStatus)
        {
            return ReverseStatus[9] == '1';
        }

        private static bool ResetAxisCT(string ReverseStatus)
        {
            return ReverseStatus[12] == '1';
        }

        private static bool ResetBT(string ReverseStatus)
        {
            return ReverseStatus[10] == '1';
        }

        private static bool ResetAxisRot(string ReverseStatus)
        {
            return ReverseStatus[11] == '1';
        }

        private static bool ResetAxisUD(string ReverseStatus)
        {
            return ReverseStatus[8] == '1';
        }

        private void TaskEnded(Task task)
        {
            if (OPRUDStatus.Text == "已完成" &&
            OPRRTStatus.Text == "已完成" &&
            OPRBTStatus.Text == "已完成" &&
            OPRCTStatus.Text == "已完成" &&
            OPRTRStatus.Text == "已完成")
            {
                WiseTech.ThreadSafeHelper.UIThread(this, () =>
                {
                    Console.WriteLine("asdfasf");
                    ATSData.ResetOK = true;
                    BtnConfirm.Visible = true;
                });
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {

            if (Parent != null)
            {
                Parent.Controls.Remove(this);
            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            CTS.Cancel();
            if (Parent != null)
            {
                Parent.Controls.Remove(this);
            }
        }
    }
}
