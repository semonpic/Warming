using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.UI.CST.Controls
{
    public partial class IO : UserControl
    {
        public IO()
        {
            InitializeComponent();
        }
        bool OnoffStatus = false;

        IOInfo ActualIOInfo = null;
        public IOInfo Actual{
            get
            {
                return ActualIOInfo;
            }
            set
            {
                ActualIOInfo = value;
            }
        }

        public string IOName {
            
            get
            {
                return this.LbIoName.Text;
            }
            set
            {
                this.LbIoName.Text = value;
            }
        }
        public bool OnOff
        {
            get
            {
                return OnoffStatus;
            }
        
            set
            {
                OnoffStatus = value;
                try
                {
                    if (value)
                    {
                        this.PbIoOnOff.Image.Dispose();
                        this.PbIoOnOff.Image = Properties.Resources.IOon;
                        
                      
                    }
                    else
                    {
                        this.PbIoOnOff.Image.Dispose();
                        this.PbIoOnOff.Image = Properties.Resources.IOoff;
                    }

                }
                catch (Exception err)
                { 
                
                }
            }
        
        }

        private void IO_Load(object sender, EventArgs e)
        {

        }

        private void LbIoName_Click(object sender, EventArgs e)
        {
            OnOff = OnOff ? false : true;
        }
        
    }
}
