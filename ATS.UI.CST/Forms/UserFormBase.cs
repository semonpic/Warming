using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.UI.CST.Forms
{
	public partial class UserFormBase : Form
	{
		protected bool UseCloseIcon { set { buttonClose.Visible = value; } }
		private Point lastPoint;
		public UserFormBase()
		{
			InitializeComponent();
			labelTitle.Text = Text;
			labelTitle.MouseDown += LabelTitle_MouseDown;
			labelTitle.MouseMove += LabelTitle_MouseMove;
			buttonClose.Click += ButtonClose_Click;
			Load += UserFormBase_Load;
		}

		private void UserFormBase_Load(object sender, EventArgs e)
		{
			TopMost = false;
			panel1.Width = Width;
            panel2.Height = Height;
            panel3.Location = new Point(Width-1, 0);
            panel3.Height = Height;
            panel4.Location = new Point(0, Height-1);
            panel4.Width = Width;
		}

		protected void SetTitle(string title)
		{
			labelTitle.Text = title;
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LabelTitle_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}

		private void LabelTitle_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Left += e.X - lastPoint.X;
				Top += e.Y - lastPoint.Y;
			}
		}

        private void buttonClose_Click_1(object sender, EventArgs e)
        {

        }
	}
}
