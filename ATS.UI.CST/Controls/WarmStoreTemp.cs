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

namespace ATS.UI.CST.Controls
{
    public partial class WarmStoreTemp : UserControl
    {
        public WarmStoreTemp()
        {
            InitializeComponent();
            Load += WarmStoreTemp_Load;
        }

        private void WarmStoreTemp_Load(object Sender, EventArgs e)
        {

            PLCconnect.ReadSystemStatus.WarmTempEvent += new Action<int[]>(WarmTempEvent);
        }


        private void WarmTempEvent(int[] WarmTemp)
        {
            //ThreadSafeHelper.UIThread(this, () =>
            //{

            //    LBWarmTemp1.Text = WarmTemp[0].ToString().Substring(0, WarmTemp[0].ToString().Length - 1) + "." + WarmTemp[0].ToString()[WarmTemp[0].ToString().Length - 1] + " C";
            //    LBWarmTemp2.Text = WarmTemp[1].ToString().Substring(0, WarmTemp[1].ToString().Length - 1) + "." + WarmTemp[1].ToString()[WarmTemp[1].ToString().Length - 1] + " C";
            //    LBWarmTemp3.Text = WarmTemp[2].ToString().Substring(0, WarmTemp[2].ToString().Length - 1) + "." + WarmTemp[2].ToString()[WarmTemp[2].ToString().Length - 1] + " C";
            //    LBWarmTemp4.Text = WarmTemp[3].ToString().Substring(0, WarmTemp[3].ToString().Length - 1) + "." + WarmTemp[3].ToString()[WarmTemp[3].ToString().Length - 1] + " C";
            //    LBWarmTemp5.Text = WarmTemp[4].ToString().Substring(0, WarmTemp[4].ToString().Length - 1) + "." + WarmTemp[4].ToString()[WarmTemp[4].ToString().Length - 1] + " C";
            //});
        }


    }
}
