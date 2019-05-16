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
    public partial class AlarmInformation : UserControl
    {
        public static bool FormOpen = false;
        public static bool Once = false;
        public static int Time = 0;
        public AlarmInformation()
        {
            InitializeComponent();
            Load += AlarmInformation_load;
        }



        private void AlarmInformation_load(object sender, EventArgs e)
        {
            Left = (Parent.Width - Width) >> 1;
            Top = 32;
        }
        public void AddInfo(string Message)
        {
            this.SuspendLayout();
            string M = Message;
            if (Message == "安全門開啟")
            {
                M += "(";
                M += ForstDoorGate() != '1' ? "前," : "";
                M += SideDoorGate() != '1' ? "側," : "";
                M += WarmDoorGate() != '1' ? "回溫," : "";
                M += ColdDoorGate() != '1' ? "冷藏," : "";
                M = M.Substring(0, M.Length - 1);
                M += ")";
            }

            M += "\r\n";
            
            ThreadSafeHelper.UIThread(this,()=>{
            TbInfo.AppendText(M);
            });
            this.ResumeLayout(false);
            Once = true;
        }

        private static char ColdDoorGate()
        {
            return ReadSystemStatus.IOInputStatus[6][12];
        }

        private static char WarmDoorGate()
        {
            return ReadSystemStatus.IOInputStatus[6][13];
        }

        private static char SideDoorGate()
        {
            return ReadSystemStatus.IOInputStatus[6][14];
        }

        private static char ForstDoorGate()
        {
            return ReadSystemStatus.IOInputStatus[6][15];
        }
        
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Time = DateTime.Now.Minute;
            Once = false;
            Parent.Controls.Remove(this);
            TbInfo.Text = "";
            FormOpen = false;
        }
    }
}
