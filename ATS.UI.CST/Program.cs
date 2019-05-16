using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS.UI.CST
{
	static class Program
	{
		/// <summary>
		/// 應用程式的主要進入點。
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool ret;
			System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);

			if (ret)
			{

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
                LCSCommon.AppPath = Application.StartupPath + @"\Log";
				try
				{
					var coreInstance = ATSCore.Instance;
					Application.Run(new CSTForm());
				}
				catch (Exception ex)
				{
					MessageBox.Show(null, "主程式於初始化失敗 請檢查設備連線與在席\n\n程式即將退出。" + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					Application.Exit();//退出程序   
				}

				mutex.ReleaseMutex();
			}
			else
			{
				MessageBox.Show(null, "有一個和本程序相同的應用程序已經在運行，請不要同時運行多個本程序。\n\n這個程序即將退出。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//   提示信息，可以刪除。   
				Application.Exit();//退出程序   
			}
		}



	}
}
