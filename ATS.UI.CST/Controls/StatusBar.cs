using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using WiseTech;
using WiseTech.Log;

namespace ATS.UI.CST.Controls
{
	public partial class StatusBar : UserControl
	{
		[DllImport("user32.dll")]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
		const UInt32 SWP_NOSIZE = 0x0001;
		const UInt32 SWP_NOMOVE = 0x0002;
		const UInt32 SWP_NOACTIVATE = 0x0010;
		
		private int fps = 0;
		private Timer fpsSecTimer = new Timer();
		public StatusBar()
		{
			InitializeComponent();
			labelVer.Text = "Ver. " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			if (AppData.IsRuntime)
			{
				CSTForm.OnAnimationUpdate += CSTForm_OnAnimationUpdate;
				//ATSCore.Instance.OnSecUpdate += Core_OnSecUpdate;
                CSTForm.OnAnimationUpdate += Core_OnSecUpdate;
                Logger.OnLog += Logger_OnLog;

				fpsSecTimer.Interval = 1000;
				fpsSecTimer.Tick += FpsSecTimer_Tick;
				fpsSecTimer.Start();
			}
		}

		private void FpsSecTimer_Tick(object sender, EventArgs e)
		{
			labelFps.Text = fps.ToString();
			fps = 0;
		}

		private void CSTForm_OnAnimationUpdate(object sender, EventArgs e)
		{
			fps++;
		}

		private void Logger_OnLog(object sender, LoggerLogEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelLog.ForeColor = Color.White;
				labelLog.Text = e.Level + " : " + e.Message;
			});
		}
		private void Logger_OnInfo(object sender, LoggerLogEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelLog.ForeColor = Color.Blue;
				labelLog.Text = e.Level + " : " + e.Message;
			});
		}
		private void Logger_OnWarning(object sender, LoggerLogEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelLog.ForeColor = Color.Orange;
				labelLog.Text = e.Level + " : " + e.Message;
			});
		}

		private void Logger_OnError(object sender, LoggerLogEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelLog.ForeColor = Color.FromArgb(237,28,36);
				labelLog.Text = e.Level + " : " + e.Message;
			});
		}
		

		private void Core_OnSecUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
			});
		}

		private void buttonScreenshot_Click(object sender, EventArgs e)
		{
			SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);

			buttonScreenshot.Enabled = false;

			//Console.WriteLine(e.ToString());
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			DateTime CurrTime = DateTime.Now;
			String format = "yyyy-MM-dd-hh-mm-ss";

			// Converts the local DateTime to a string 
			// using the custom format string and display.
			string saveFilePath = desktopPath + "/" + CurrTime.ToString(format) + ".jpg";
			Console.Write(saveFilePath);
			Screen s = Screen.FromControl(this);
			//取得目前應用程式所在的螢幕
			int x = ParentForm.Location.X; //應用程式所在位置
			int y = ParentForm.Location.Y;
			int w = ParentForm.Width;//應用程式寬高
			int h = ParentForm.Height;

			Bitmap b = new Bitmap(w, h);
			Graphics g = Graphics.FromImage(b);
			g.CopyFromScreen(x, y, 0, 0, new Size(w, h));
			b.Save(saveFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

			buttonScreenshot.Enabled = true;
		}

		private void buttonMin_Click(object sender, EventArgs e)
		{
			ParentForm.WindowState = FormWindowState.Minimized;
		}

		AboutForm aboutForm = new AboutForm();
		private void labelVer_Click(object sender, EventArgs e)
		{
			aboutForm.Show();
		}
	}
}
