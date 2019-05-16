using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;
using ATS.Data;
using ATS.Models;
using WiseTech.Data;
using WiseTech;
using ATS.Events;

namespace ATS
{
    public partial class ATSCore
    {

        public event EventHandler<ATSCorePageChangeEventArgs> OnPageChange;//UI分頁切換事件

        public static bool View1MachineEnable { get { return Properties.Settings.Default.View1Enable; } }
        public static bool View2MachineEnable { get { return Properties.Settings.Default.View2Enable; } }

        public enum PageName { Main, MaintainCommandTabPanel }
        private System.Windows.Forms.Form ui;
        public string CurrentPage = "";

 
		//1秒觸發1次的計時器
		const int timerIntervalSec = 1000;

		Timer secTimer = new Timer();

		public event EventHandler OnSecUpdate;//UI每秒更新事件



        //DataManager DM = DataManager.Instance;

        public List<string> TabsKey
		{
			get
			{
				//var tabString = DM.Load("Tabs.Key");
				//暫不從資料庫存取分頁名稱，改用常數值
				var tabs = ATSData.TabsString.Split(',').ToList();
				return tabs;
			}
		}

		private void SetupSecTimer()
		{
			secTimer.Interval = timerIntervalSec;
			secTimer.Elapsed += SecTimer_Elapsed;
			secTimer.Start();
		}
		private void StopTimer()
		{
			Console.WriteLine("StopSecTimer");
			secTimer.Elapsed -= SecTimer_Elapsed;
			secTimer.Stop();
			secTimer.Close();
		}

		private void SecTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			OnSecUpdate.Invoke(this, e);
		}

		public void PageChange(string tabName)
		{
            if (OnPageChange != null)
            {
                OnPageChange.Invoke(this, new ATSCorePageChangeEventArgs { Page = tabName });
            }
		}

	}
}
