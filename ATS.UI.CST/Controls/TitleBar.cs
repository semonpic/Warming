using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Models;
using WiseTech;
using System.IO;

namespace ATS.UI.CST.Controls
{
	public partial class TitleBar : UserControl
	{
		ATSCore core;
		UserData userData;
		public TitleBar()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{
				//core = ATSCore.Instance;
				userData = UserData.Instance;
				userData.OnLogin += UserData_OnPowerChange;
				userData.OnLoginFailed += UserData_OnPowerChange;
				Load += TitleBar_Load;
				Language.Bind("SystemName", labelSystemName);

			}
		}

		private void TitleBar_Load(object sender, EventArgs e)
		{
			//core.OnPowerChange += Core_OnPowerChange;
			//core.OnPageChange += Core_OnPageChange;


		}


		//private void Core_OnPageChange(object sender, Events.PageChangeEventArgs e)
		//{
		//	labelTitle.Text = e.Page as string;
		//}

		private void UserData_OnPowerChange(object sender, EventArgs e)
		{
			if (userData.IsLogin)
			{
				labelUser.Text = userData.Now.Name + " [ " + userData.Now.Power + " ]";
			}
			else
			{
				labelUser.Text = Language.Text("User");
			}
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
            
			var result = MessageBox.Show("確定關閉?", "確定關閉?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				Application.Exit();
			}
		}

        private void Secret_Click(object sender, EventArgs e)
        {
            //string DirectoryName = "SendInfo";
            //string DataName = DirectoryName + "\\"+DateTime.Now.ToString("yyyyMMdd-HHmmss") +".csv";

            //if (!Directory.Exists(AppData.exePath + DirectoryName))
            //{
            //    Directory.CreateDirectory(DirectoryName);
                
            //}

            ////if (!File.Exists(DataName))
            ////{
            ////    //  不存在就建立一個
            ////    File.Create(DataName);
            ////}

            ////FileInfo FileSetting = new FileInfo(DataName);
            ////FileSetting.Attributes = FileAttributes.Normal;

            //FileStream Fs = new FileStream(DataName, FileMode.Create, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(Fs, Encoding.Default);

            //sw.Write("1,Message,3,4,5" + "\n" + "6,7,8,9,0" + "\n" + "11,12,13,14,15");
            //sw.Close();

        }
	}
}
