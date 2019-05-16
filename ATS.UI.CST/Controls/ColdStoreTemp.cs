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
    public partial class ColdStoreTemp : UserControl
    {
        public ColdStoreTemp()
        {
            InitializeComponent();
            Load += ColdStoreTemp_Load;
        }

        private void ColdStoreTemp_Load(object Sender, EventArgs e)
        {
            PLCconnect.ReadSystemStatus.ColdTempEvent += new Action<int[]>(ColdTempEvent);
        }

        private void ColdTempEvent(int[] ColdTemp)
        {

            ThreadSafeHelper.UIThread(this, () =>
            {

                LBColdTemp1.Text = ColdTemp[0] < 0 && ColdTemp[0] > -10 ? (Convert.ToDouble(ColdTemp[0]) / 10).ToString() : ColdTemp[0] < 10 && ColdTemp[0] > 0 ? "0." + ColdTemp[0].ToString()[ColdTemp[0].ToString().Length - 1] + " C" : ColdTemp[0].ToString().Substring(0, ColdTemp[0].ToString().Length - 1) + "." + ColdTemp[0].ToString()[ColdTemp[0].ToString().Length - 1] + " C";
                LBColdTemp2.Text = ColdTemp[1] < 0 && ColdTemp[1] > -10 ? (Convert.ToDouble(ColdTemp[1]) / 10).ToString() : ColdTemp[1] < 10 && ColdTemp[1] > 0 ? "0." + ColdTemp[1].ToString()[ColdTemp[1].ToString().Length - 1] + " C" : ColdTemp[1].ToString().Substring(0, ColdTemp[1].ToString().Length - 1) + "." + ColdTemp[1].ToString()[ColdTemp[1].ToString().Length - 1] + " C";
                LBColdTemp3.Text = ColdTemp[2] < 0 && ColdTemp[2] > -10 ? (Convert.ToDouble(ColdTemp[2]) / 10).ToString() : ColdTemp[2] < 10 && ColdTemp[2] > 0 ? "0." + ColdTemp[2].ToString()[ColdTemp[2].ToString().Length - 1] + " C" : ColdTemp[2].ToString().Substring(0, ColdTemp[2].ToString().Length - 1) + "." + ColdTemp[2].ToString()[ColdTemp[2].ToString().Length - 1] + " C";
                LBColdTemp4.Text = ColdTemp[3] < 0 && ColdTemp[3] > -10 ? (Convert.ToDouble(ColdTemp[3]) / 10).ToString() : ColdTemp[3] < 10 && ColdTemp[3] > 0 ? "0." + ColdTemp[3].ToString()[ColdTemp[3].ToString().Length - 1] + " C" : ColdTemp[3].ToString().Substring(0, ColdTemp[3].ToString().Length - 1) + "." + ColdTemp[3].ToString()[ColdTemp[3].ToString().Length - 1] + " C";
                LBColdTemp5.Text = ColdTemp[4] < 0 && ColdTemp[4] > -10 ? (Convert.ToDouble(ColdTemp[4]) / 10).ToString() : ColdTemp[4] < 10 && ColdTemp[4] > 0 ? "0." + ColdTemp[4].ToString()[ColdTemp[4].ToString().Length - 1] + " C" : ColdTemp[4].ToString().Substring(0, ColdTemp[4].ToString().Length - 1) + "." + ColdTemp[4].ToString()[ColdTemp[4].ToString().Length - 1] + " C";


                double Num = Convert.ToDouble(SystemConfig.ColdSettingTemp);

                if  (Convert.ToDouble(ColdTemp[0]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[1]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[2]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[3]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[4]) / 10 > Num)
                {
                    ColdTempAlarm();
                }

            });
        }

        private static void ColdTempAlarm()
        {
            MainTabsPanel Mp = new MainTabsPanel();
            Mp.AlarmEvent(1545, 14);
        }
    }
}
