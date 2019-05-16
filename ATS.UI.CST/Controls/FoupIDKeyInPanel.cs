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
using ATS.Devices;
using ViewMM;

namespace ATS.UI.CST.Controls
{
	public partial class FoupIDKeyInPanel : UserControlBase
	{
		private int loadportID;
		public FoupIDKeyInPanel(int loadportID)
		{
			this.loadportID = loadportID;

			InitializeComponent();
			if (AppData.IsRuntime)
			{

			}
			textBoxFoupID.KeyPress += TextBoxFoupID_KeyPress;
			Load += FoupIDKeyInPanel_Load;
		}

		private void FoupIDKeyInPanel_Load(object sender, EventArgs e)
		{
			labelTitle.Text = "Loadport " + loadportID + " Foup ID Key In";
			labelLoadportN1.Text = "Loadport " + loadportID;
			labelLoadportN2.Text = "Loadport " + loadportID;
			
			textBoxFoupID.Text = "";
			textBoxFoupID.Focus();
		}

		private void TextBoxFoupID_KeyPress(object sender, KeyPressEventArgs e)
		{
			//過濾字元
			if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		public void Open(Control parent)
		{
			var width = Width;
			var height = Height;

			var locationX = (parent.Width - width) >> 1;
			var locationY = (parent.Height) >> 1;
			var toLocationX = (parent.Width - width) >> 1;
			var toLocationY = (parent.Height - height) >> 1;

			TweenOut(new Point(locationX, locationY), new Size(width, 0));
			TweenIn(new Point(toLocationX, toLocationY), new Size(width, height));
			TweenShow();

			parent.Controls.Add(this);
			parent.Controls.SetChildIndex(this, 0);
		}


		private void buttonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (textBoxFoupID.Text.Length != 0)
			{
				try
				{
					ATSCore.Instance.Loadports[loadportID].CassetteID = textBoxFoupID.Text;
					ATSCore.Instance.Loadports[loadportID].KeyInOK = true;
					Close();
				}
				catch (Exception)
				{
					MessageBox.Show("設定失敗");
				}
			}
			else
			{
				MessageBox.Show("請輸入FoupID");
			}
		}
		public void Close()
		{
			if (AppData.IsRuntime)
			{

			}

			TweenHide(true);
		}


	}
}
