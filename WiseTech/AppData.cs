using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiseTech
{
	public static class AppData
	{
		public static bool Debug
		{
			get { return Properties.Settings.Default.Debug; }
			set
			{
				Properties.Settings.Default.Debug = value;
				Properties.Settings.Default.Save();
			}
		}
		public static string exePath
		{
			get
			{
				return Application.StartupPath + "\\";
			}
		}
		//回傳 true 如果現在是執行模式
		//回傳 false 如果現在是編輯模式
		public static bool IsRuntime
		{
			get
			{
				return !(Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1);
			}
		}

	}
}
