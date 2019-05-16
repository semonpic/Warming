using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Devices;
using WiseTech;
using Sanwa;
using System.Threading;

namespace ATS.UI.CST.Controls
{
    public partial class MaintainPrealignerTabPanel : UserControl
    {
        private Aligner preAligner;


        public MaintainPrealignerTabPanel()
        {
            InitializeComponent();
            comboBoxMode.DataSource = System.Enum.GetValues(typeof(AlignerCommand.MainTainMovingMode));

            if (AppData.IsRuntime)
            {
                preAligner = ATSCore.Instance.Aligner;
            }
        }

      

        private void buttonResetError_Click(object sender, EventArgs e)
        {
            preAligner.ResetError();
        }

        private void buttonSetSpeed1_Click(object sender, EventArgs e)
        {
            try
            {
                preAligner.Speed = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSetSpeed5_Click(object sender, EventArgs e)
        {
            try
            {
                preAligner.Speed = 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonAlign_Click(object sender, EventArgs e)
        {

            preAligner.ResetError();
                                    
            Thread.Sleep(1000);
            //string ORG = AlignerCommand.ORG;

            preAligner.ORGsearch();
                        
            Thread.Sleep(100);

            preAligner.WaferSetSize();

            preAligner.Speed = 0;

            preAligner.ArmRetract();

            preAligner.WaferHold();
            
            Thread.Sleep(1000);

            preAligner.Angle = AlignerCommand.angle;

            preAligner.WaferRelease();

            preAligner.Home();
            
            }

        private void buttonSetSpeed100_Click(object sender, EventArgs e)
        {
            try
            {
                preAligner.Speed = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSetSpeed25_Click(object sender, EventArgs e)
        {
            try
            {
                preAligner.Speed = 25;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSetSpeed50_Click(object sender, EventArgs e)
        {
            try
            {
                preAligner.Speed = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSetSpeed75_Click(object sender, EventArgs e)
        {
            try
            {
                preAligner.Speed = 75;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonHold_Click(object sender, EventArgs e)
        {
            preAligner.WaferHold();
        }

        private void buttonRelease_Click(object sender, EventArgs e)
        {
            preAligner.WaferRelease();
        }

        private void buttonORG_Click(object sender, EventArgs e)
        {
            preAligner.ORGsearch();
        }

        private void buttonRetract_Click(object sender, EventArgs e)
        {
            preAligner.ArmRetract();
        }

        private void buttonNormalHome_Click(object sender, EventArgs e)
        {
            preAligner.Home();
        }

        private void buttonSetMode_Click(object sender, EventArgs e)
        {
            int mode = (int)comboBoxMode.SelectedValue;
            try
            {
                preAligner.Mode = mode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonGetError_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                int no = i;
                try
                {
                    preAligner.ErrorNo = no;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

         
            try
            {
                preAligner.ErrorNo = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonOrgHome_Click(object sender, EventArgs e)
        {

        }
    }
}
