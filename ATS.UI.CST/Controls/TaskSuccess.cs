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
    public partial class TaskSuccess : UserControl
    {
        public TaskSuccess()
        {
            InitializeComponent();
            Load += Load_TaskSuccess;
        }
        private void Load_TaskSuccess(object sender, EventArgs e)
        {
            this.Left = (Parent.Width - Width) >> 1;
            this.Top = 42;

        }
        internal void TitleChange(string Task)
        {
            labelTitle.Text = Task;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
    }
}
