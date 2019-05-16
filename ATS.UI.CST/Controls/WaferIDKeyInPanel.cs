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
using ATS.Data;

namespace ATS.UI.CST.Controls
{
	public partial class WaferIDKeyInPanel : UserControlBase
	{
		private int waferIndex;
		private Image waferImage;
		public WaferIDKeyInPanel(int waferIndex)
		{
			this.waferIndex = waferIndex;

			InitializeComponent();
			if (AppData.IsRuntime)
			{

			}
			textBoxWaferID.KeyPress += TextBoxFoupID_KeyPress;
			Load += FoupIDKeyInPanel_Load;
			OnClose += WaferIDKeyInPanel_OnClose;
		}

		private void FoupIDKeyInPanel_Load(object sender, EventArgs e)
		{
			labelTitle.Text = "Wafer " + waferIndex + " ID Key In";
			labelWaferN1.Text = "Wafer " + waferIndex;
			labelWaferN2.Text = "Wafer " + waferIndex;

			textBoxWaferID.Text = "";
			textBoxWaferID.Focus();

			var wafer = WaferManager.Wafers[waferIndex];
			waferImage = Image.FromFile(wafer.OCRImagePath);
			pictureBox1.Image = waferImage;
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
		}

		private void TextBoxFoupID_KeyPress(object sender, KeyPressEventArgs e)
		{
			//過濾字元
			if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !(e.KeyChar == '-'))
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
			if (textBoxWaferID.Text.Length != 0)
			{
				if (ATS.Utility.WaferIDChecker.Check(textBoxWaferID.Text))
				{
					try
					{
						var wafer = WaferManager.Wafers[waferIndex];
						wafer.WaferID = textBoxWaferID.Text;
						Close();
					}
					catch (Exception)
					{
						MessageBox.Show("設定失敗");
					}
				}
				else
				{
					MessageBox.Show("WaferID 不正確");

				}
			}
			else
			{
				MessageBox.Show("請輸入WaferID");
			}
		}
		public void Close()
		{
			TweenHide(true);
		}

		private void WaferIDKeyInPanel_OnClose(object sender, EventArgs e)
		{			
			Dispose();
		}
	}
}
