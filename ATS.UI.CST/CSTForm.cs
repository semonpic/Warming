using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Data;
using ATS.Events;
using ATS.Models;
using ATS.UI.CST.Controls;
using ATS.UI.CST.Forms;
using WiseTech;
using WiseTech.Log;
using System.IO;
using PLCconnect;
using System.IO.Ports;

namespace ATS.UI.CST
{
	public partial class CSTForm : Form
	{
		private const bool cleanLanguage = true;


		public static event EventHandler OnAnimationUpdate;                     //UI動畫更新事件
		private System.Timers.Timer animationTimer = new System.Timers.Timer(); //UI動畫計時器
		const int timerInterval = 30;                                           //用來處理UI動畫更新事件的時間間隔(每30ms更新一次)
		private PLCconnect.WriteInClod plccold= new PLCconnect.WriteInClod();
        public static event PLCconnect.WriteOutWarm.OutWamrRecycleBottle RecycleBottleChange = null;
        
        


		public CSTForm()
		{
            //AppData.Debug = false;
           // str = "";
			InitializeComponent();


            SystemConfig s = new SystemConfig();
            s.IniFile();

            FormClosing += CSTForm_FormClosing;
            

			if (AppData.IsRuntime)
			{
				Languages.Init(cleanLanguage);//初始化語言檔
			}

            //Forms.WeightHistory WH = new WeightHistory();
            //WH.ShowDialog();

            


			AlarmManager.SafetyDoorAlarm += (sender, e) => FormManager.OpenSafetyDoorAlarmForm(this, e.Data);//安全門開關

			Shown += CSTForm_Shown;

			SetupAnimationTimer();
            //TopMost = true;
            Load += CSTForm_Load;

            

        }

        void CSTForm_Load(object sender, EventArgs e)
        {

            WriteInClod.IniSerialPort();
            ReadSystemStatus.IniSerialPort();
            UserData.Instance.ErrorReset();
            ReadSystemStatus.RecycleBottleNum = Convert.ToInt32(SystemConfig.RecycleBottle);
            RecycleBottleChange(ReadSystemStatus.RecycleBottleNum);
        }




		private void CSTForm_Shown(object sender, EventArgs e)
		{
			Language.Refresh();
			UserData.Instance.Logout();
		}

		private void CSTForm_FormClosing(object sender, FormClosingEventArgs e)
		{
            ;

            Application.Exit();
		}

		private void SetupAnimationTimer()
		{
			animationTimer.Interval = timerInterval;
			animationTimer.Elapsed += AnimationTimer_Elapsed;
			animationTimer.Start();
		}
		private void StopTimer()
		{
			Console.WriteLine("StopAnimationTimer");
			animationTimer.Elapsed -= AnimationTimer_Elapsed;
			animationTimer.Stop();
			animationTimer.Close();
		}
		private void AnimationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
            if (OnAnimationUpdate != null)
            {
                OnAnimationUpdate.Invoke(this, e);
            }
		}

        private void MessageBoxHelper(string Message,string Title,MessageBoxButtons Btn,MessageBoxIcon Icon)
        {
            WiseTech.ThreadSafeHelper.UIThread(this, () => {

                if (Title == "")
                {
                    MessageBox.Show(Message);
                }
                else
                {
                    MessageBox.Show(Message, Title);
                }
            
            
            });
        }
    }
}
