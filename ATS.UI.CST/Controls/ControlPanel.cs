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
using ATS.Data;
using ATS.UI.CST.Forms;
using System.Threading;
using WiseTech.Log;
using PLCconnect;
using PLCCommon;
using JackDataManager;

namespace ATS.UI.CST.Controls
{
	public partial class ControlPanel : UserControl
	{
		public static bool startButtonFlashMode = false;
		public static bool resetButtonFlashMode = true;
        public static BarcoReader BarcoReaderFrm = new BarcoReader();
        public static OPRProgress opr = new OPRProgress();
        int ColdWarmSaveNumber = 0;
        string[] ColdTemp = new string[5];
        string[] WarmTemp = new string[5];
        public Action<string,string,MessageBoxButtons,MessageBoxIcon> MessageHelper = null;
        public static Action ChangeIoName = null;



        private static System.Windows.Forms.Timer flashTimer = new System.Windows.Forms.Timer();
		public class LEDButton
		{
			public int In = 0;
			public int Out = 0;
			public bool Status = false;
			public bool Led = false;

		}
		private bool moving = false;
		public ControlPanel()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{

				//Language.Bind("ControlPanel.Start", buttonStart);
				Language.OnRefreshed += Language_OnRefreshed;
				AlarmManager.AlarmReset += AlarmManager_AlarmReset;
				CSTForm.OnAnimationUpdate += CSTForm_OnAnimationUpdate;
                WriteInClod.Update += new Action<string,string,string>(TaskSuccessUpdate);
                WriteInClod.UpdateEvent += InColdTaskSuccessUpdate;
                WriteOutCold.TaskOverEvent += WarmTaskSuccessUpdate;
                WriteOutWarm.UpdateEvent += WarmTaskSuccessUpdate;
                PLCconnect.PLCCommon.StopEventStart += StopStsk;
                ReadSystemStatus.DoorGateEvent += DoorGateSystemPauseEvent;
                ReadSystemStatus.PauseReturnEvent += PauseReturnEvent;
                BarcoReader.StopTask += StopStsk;
				flashTimer.Tick += FlashTimer_Tick;
				flashTimer.Interval = 1000;
				flashTimer.Start();
            }
            Load += ControlPanel_Load;
            //CSTForm.OnAnimationUpdate += CSTForm_OnAnimationUpdate1;

        }

        void ControlPanel_Load(object sender, EventArgs e)
        {
            Language.Bind("ControlPanel.LangurageIcon", buttonLanguage);
            Language.Bind("ControlPanel.Language", labelLanguage);
            Language.Bind("ControlPanel.Alarm", labelAlarm);

            Language.Bind("ControlPanel.Stop", buttonStop);
            Language.Bind("ControlPanel.Init", buttonReset);
            Language.Bind("ControlPanel.LoadStop", buttonLoadStop);
            MainTabsPanel.TaskStart += UpdateButtonText;
            TaskNumberSelect.TaskStart += UpdateButtonText;
        }

        private void CSTForm_OnAnimationUpdate1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FlashTimer_Tick(object sender, EventArgs e)
		{
            startButtonFlashMode = ReadSystemStatus.PlcStatus[2];
			if (startButtonFlashMode)
			{
				labelGreenLight.BackColor = (labelGreenLight.BackColor == Color.Green) ? Color.Lime : Color.Green;
				//IO.Out(yellowButton.Out, (labelYellowLight.BackColor == Color.Yellow));
			}
			else { }
			if (resetButtonFlashMode)
			{
				labelYellowLight.BackColor = (labelYellowLight.BackColor == Color.Yellow) ? Color.Gold : Color.Yellow;
				///IO.Out(yellowButton.Out, (labelYellowLight.BackColor == Color.Yellow));
			}
			else { }


            if (ColdWarmSaveNumber < 20)
            {

                for (int i = 0; i < ColdTemp.Length; i++)
                {
                    ColdTemp[i] += ReadSystemStatus.ColdTemp[i].ToString() + "-";
                    WarmTemp[i] += ReadSystemStatus.WarmTemp[i].ToString() + "-";
                }
                ColdWarmSaveNumber++;
            }
            else
            {
                JackDataManager.TempManager.Setup();
                JackDataManager.TempManager.SaveTemp(ColdTemp, WarmTemp);
                ColdWarmSaveNumber = 0;
                for (int i = 0; i < 5; i++)
                {
                    ColdTemp[i] = "";
                    WarmTemp[i] = "";
                }
            }


		}

		private async void CSTForm_OnAnimationUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{

				var statusKey = Enum.GetName(typeof(ATSData.AutomaticModeStatusType), ATSData.AutomaticModeStatus);
				labelStatus.Text = Language.Text(statusKey);
				switch (ATSData.AutomaticModeStatus)
				{
					case ATSData.AutomaticModeStatusType.Reset:
						labelStatus.BackColor = Color.Yellow;
						break;
					case ATSData.AutomaticModeStatusType.Pause:
						labelStatus.BackColor = Color.LightGray;
						break;
					case ATSData.AutomaticModeStatusType.Run:
						labelStatus.BackColor = Color.LightSeaGreen;
						break;
					case ATSData.AutomaticModeStatusType.Stop:
						labelStatus.BackColor = Color.LightGray;
                        TaskNumberSelect.Moving= false;
						break;
					case ATSData.AutomaticModeStatusType.Error:
						labelStatus.BackColor = Color.FromArgb(237,28,36);
						break;
				}
			});
			
		}

		private void AlarmManager_AlarmReset(object sender, EventArgs e)
		{
			UpdateButtonText();
		}

		private void Instance_OnSystemModeChenged(object sender, EventArgs e)
		{
			UpdateButtonText();
		}

		private void Language_OnRefreshed(object sender, EventArgs e)
		{
			UpdateButtonText();
		}

		private void buttonLanguage_Click(object sender, EventArgs e)
		{
			switch (Language.UseLanguage)
			{
				case Language.En:
					Language.UseLanguage = Language.Zh_tw;
					break;
				case Language.Zh_tw:
					Language.UseLanguage = Language.En;
					break;
			}
			Language.Refresh();
            if (ChangeIoName != null)
            {
                ChangeIoName();
            }
		}


		private void buttonStart_Click(object sender, EventArgs e)
		{
            SystemPause();

        }


        private void DoorGateSystemPauseEvent()
        {
            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
            PLCconnect.PLCCommon.PLC_WRITE("1701", "1", "1");
            startButtonFlashMode = false;
            ReadSystemStatus.PauseType = true;
            UpdateButtonText();
        }


        private void PauseReturnEvent()
        {


            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;
            startButtonFlashMode = true;
            ReadSystemStatus.PauseType = false;

            UpdateButtonText();
        }

        private void SystemPause()
        {
            Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 點擊 " + buttonLoadStop.Text);
            if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Run)
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                SystemPauseOn();
                startButtonFlashMode = false;
                ReadSystemStatus.PauseType = true;

            }
            else if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Pause)
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;
                SystemPauseOff();
                startButtonFlashMode = true;
                ReadSystemStatus.PauseType = false;
            }

            UpdateButtonText();
            //buttonStart_Click1();
        }

        private static void SystemPauseOff()
        {
            PLCconnect.PLCCommon.PLC_WRITE("1701", "0", "1");
        }

        private static void SystemPauseOn()
        {
            PLCconnect.PLCCommon.PLC_WRITE("1701", "1", "1");
        }

        internal void buttonStart_Click1()
        {
            if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop || ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Pause)
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;



            }
            else
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                PLCconnect.PLCCommon.PLC_WRITE("1701", "0", "1");
                startButtonFlashMode = false;
            }


            if (FormManager.IsResetFormOpen)
            {
                
                Task.Run(() => { MessageBox.Show("請先關閉視窗後再按啟動"); });

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                startButtonFlashMode = false;
                return;
            }
            if (!moving)
            {
                moving = true;
                StartButtonClick();
            }
            moving = false;
        }
		internal void StartButtonClick()
		{
            try
            {
                StartButtonClick0();
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }
        private void StartButtonClick0()
        {

			Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 點擊 " + buttonStart.Text);

			if (!ATSData.ResetOK)
			{
				MessageBox.Show("尚未初始化完成 請先初始化", "尚未初始化完成 請先初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                startButtonFlashMode = false;
                return;
			}

			if (!CheckIO())
			{
				//檢查IO沒過
				return;
			}

			//要確定所有設備Reset完成沒有Alarm才能開始
			if (AlarmManager.IsAlarm)
			{
				MessageBox.Show("設備仍有錯誤未清除請先排除錯誤後再按開始", "設備仍有錯誤未清除請先排除錯誤後再按開始", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Error;
                startButtonFlashMode = false;
                return;
			}
			
			switch (ATSData.SystemMode)
			{
				case ATSData.SystemModeType.Maintain:
					moving = false;
					//Maintain模式不能按Start
					MessageBox.Show("請先切換為Auto模式後才能啟動", "請先切換為Auto模式後才能啟動", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                    ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    startButtonFlashMode = false;
                    SpinWait.SpinUntil(() => { return false; }, 2000);
					//System.Threading.Thread.Sleep(2000);
					break;
				default:

					if (AppData.Debug)
					{
						ATSData.AutomaticModeStatus = (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Run) ? ATSData.AutomaticModeStatusType.Pause :
													(ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Pause) ? ATSData.AutomaticModeStatusType.Run :
													ATSData.AutomaticModeStatusType.Run;
						UpdateButtonText();
						moving = false;
						return;
					}

                    if (ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Busy)
                    {
                        switch (ATSData.AutomaticModeStatus)
                        {
                            case ATSData.AutomaticModeStatusType.Pause:
                                PLCconnect.WriteSystem.WriteSystemPause();
                                UpdateButtonText();
                                break;
                            case ATSData.AutomaticModeStatusType.Run:
                                PLCconnect.WriteSystem.WriteSystemPause();
                                UpdateButtonText();
                                break;
                            case ATSData.AutomaticModeStatusType.Stop:
                                PLCconnect.WriteSystem.WriteSystemStop();
                                UpdateButtonText();
                                break;
                            default:
                                moving = false;
                                MessageBox.Show("異常中/初始化中不可開始", "異常中/初始化中不可開始", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SpinWait.SpinUntil(() => { return false; }, 2000);
                                //System.Threading.Thread.Sleep(2000);
                                break;
                        }
                    }

                    //只有系統目前是暫停、執行、停止 這三種狀態才能按開始
                    else if (ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Init || ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Idle)
                    {
                        switch (ATSData.AutomaticModeStatus)
                        {
                            case ATSData.AutomaticModeStatusType.Pause:

                                break;
                            case ATSData.AutomaticModeStatusType.Run:
                                switch (ATSData.TaskMode)
                                {
                                    case ATSData.SystemTaskMode.Incold:
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Busy;
                                        startButtonFlashMode = true;
                                        BarcoReaderFrm.BarcoFrmClear();
                                        ParentForm.Controls.Add(BarcoReaderFrm);
                                        ParentForm.Controls.SetChildIndex(BarcoReaderFrm, 0);
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                        break;
                                    case ATSData.SystemTaskMode.Inwarm:
                                        startButtonFlashMode = true;
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Busy;
                                        PLCconnect.WriteOutCold.InwarmTask();
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                        break;
                                    case ATSData.SystemTaskMode.Outwarm:
                                        if (PLCconnect.ReadSystemStatus.WarmStandBy > 0)
                                        {
                                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Busy;
                                            startButtonFlashMode = true;
                                            PLCconnect.WriteOutWarm.OutWarmTask();
                                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                            
                                        }
                                        else
                                        {
                                            MessageBox.Show("回溫庫存不足，請確認是否有足夠的膠材，或等待膠材回溫完成", "Error Information");
                                           
                                        }
                                        break;
                                }
                                break;
                            case ATSData.AutomaticModeStatusType.Stop:
                                break;
                            default:
                                moving = false;
                                MessageBox.Show("異常中/初始化中不可開始", "異常中/初始化中不可開始", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SpinWait.SpinUntil(() => { return false; }, 2000);
                                //System.Threading.Thread.Sleep(2000);
                                break;
                        }
                    }

					break;
			}
			UpdateButtonText();
		}
		public  void UpdateButtonText()
		{
			ThreadSafeHelper.UIThread(this, () =>
			{


                switch (ATSData.AutomaticModeStatus)
                {
                    case ATSData.AutomaticModeStatusType.Run:
                        buttonStart.Text = Language.Text("ControlPanel.Pause");
                        startButtonFlashMode = false;
                        buttonLoadStop.Text = Language.Text("ControlPanel.LoadStop");
                        buttonStop.Text = Language.Text("ControlPanel.Stop");
                        buttonReset.Text = Language.Text("ControlPanel.Init");
                        break;
                    default:
                        buttonStart.Text = Language.Text("ControlPanel.Start");
                        buttonLoadStop.Text = Language.Text("ControlPanel.LoadStop");
                        buttonStop.Text = Language.Text("ControlPanel.Stop");
                        buttonReset.Text = Language.Text("ControlPanel.Init");
                        break;

                }
			});
		}


		private void buttonStop_Click(object sender, EventArgs e)
		{

			if (FormManager.IsResetFormOpen)
			{
				Task.Run(() => { MessageBox.Show("請先關閉視窗後再按停止"); });
				return;
			}
			if (!moving)
			{
				moving = true;
				StopButtonClick();
			}
			moving = false;
		}
		private void StopButtonClick()
		{
            try
            {
                Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 點擊 " + buttonStop.Text);
                PLCconnect.WriteSystem.WriteSystemStop();
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                PLCconnect.WriteOutCold.TaskStop = true;
                PLCconnect.WriteOutWarm.TaskStop = true;
                startButtonFlashMode = false;


                UpdateButtonText();
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
		}
		private async void buttonReset_Click(object sender, EventArgs e)
		{
            try
            {
                if (FormManager.IsResetFormOpen)
                {
                    await Task.Run(() => { MessageBox.Show("請先關閉視窗後再按初始化"); });
                    return;
                }
                if (UserData.Instance.Now.Level < 3)
                {
                    await Task.Run(() => { MessageBox.Show("請先登入更高權限的使用者以進行初始化"); });
                    return;
                }
                if (!moving)
                {
                    moving = true;
                    await ResetButtonClick();
                }
                moving = false;
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
		}
		private bool CheckIO()
		{

			//if (!IO.In(IO.IN_SAFETY_DOOR_B))
			//{
			//	moving = false;
			//	MessageBox.Show("安全門開啟 請先關閉", "安全門開啟 請先關閉", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	SpinWait.SpinUntil(() => { return false; }, 2000);
			//	return false;
			//}
			//if (!IO.In(IO.IN_MAINTAIN_DOOR_B))
			//{
			//	moving = false;
			//	MessageBox.Show("維護門開啟 請先關閉", "安全門開啟 請先關閉", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	SpinWait.SpinUntil(() => { return false; }, 2000);
			//	return false;
			//}

			return true;
		}
		private async Task ResetButtonClick()
		{ 
			Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 點擊 " + buttonReset.Text);
            
			if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Reset)
			{
				return;
			}
			if (!CheckIO())
			{
				//檢查IO沒過
				return;
			}
			
			startButtonFlashMode = false;
			resetButtonFlashMode = false;
            try
            {
                if (PLCconnect.ReadSystemStatus.PlcStatus[2] == true)
                {
                    moving = false;
                    //if (MessageHelper != null)
                    //{
                    //    MessageHelper("運行時無法使用復歸", "運行時無法使用復歸", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    MessageBox.Show("運行時無法使用復歸", "運行時無法使用復歸", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SpinWait.SpinUntil(() => { return false; }, 2000);
                    return;
                }

                //只有在Maintain可以按復歸按鈕
                //if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
                //{
                    FormManager.IsResetFormOpen = true;

                    
                    
                    if (!PLCconnect.ReadSystemStatus.PlcStatus[1])
                    {
                        PLCconnect.WriteSystem.WriteInitialize();
                    }
                    opr.StartReset();
                    ParentForm.Controls.Add(opr);
                    ParentForm.Controls.SetChildIndex(opr, 0);

                    //MessageBox.Show("復歸");
                    //ATSData.ResetOK = true;

                    FormManager.IsResetFormOpen = false;
                //}
                //else
                //{
                //    moving = false;
                //    if (MessageHelper != null)
                //    {
                //        MessageHelper("只有在手動模式下才可以按復歸按鈕", "只有在手動模式下才可以按復歸按鈕", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    MessageBox.Show("只有在手動模式下才可以按復歸按鈕", "只有在手動模式下才可以按復歸按鈕", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    SpinWait.SpinUntil(() => { return false; }, 2000);
                //    //System.Threading.Thread.Sleep(2000);
                //}
            }
            catch (Exception ex)
            {
                moving = false;
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Error;
                MessageBox.Show("復歸動作異常:" + ex.Message, " 復歸動作中斷", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

		}
		private void ViewResetProcess(int viewID)
		{
		}
		private void buttonBuzzer_Click(object sender, EventArgs e)
		{
            if (!PLCconnect.ReadSystemStatus.BuzzerOnOff)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1861", "0", "1");
                buttonBuzzer.Image.Dispose();
                buttonBuzzer.Image = Properties.Resources.Icon_WarningOn;
            }
            else
            {
                PLCconnect.PLCCommon.PLC_WRITE("1861", "1", "1");
                buttonBuzzer.Image.Dispose();
                buttonBuzzer.Image = Properties.Resources.Icon_WarningOff;
            }
		}

		private void buttonLoadStop_Click(object sender, EventArgs e)
		{
  
            try
            {
                Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 點擊 " + buttonLoadStop.Text);

                if (PLCconnect.ReadSystemStatus.PlcStatus[2])
                {
                    PLCconnect.PLCCommon.PLC_WRITE("1701", "1", "1");
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                }

                else
                {
                    PLCconnect.PLCCommon.PLC_WRITE("1701", "0", "1");
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;
                }
            }

            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }


		}


        public  void StaticUpdateButtonText()
        {
            UpdateButtonText();
        }

        private void TaskSuccessUpdate(string ColdLocation,string WarmLocation,string t)
        {
            Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 完成入庫作業 " );
            //PLCconnect.WriteSystem.WriteSystemStop();
            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
            startButtonFlashMode = false;


            UpdateButtonText();
        }


        private void InColdTaskSuccessUpdate(string ColdLocation, string LotID)
        {
            Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 完成冷藏入庫作業 ,位置: " + ColdLocation+ " ID: " + LotID);
            //PLCconnect.WriteSystem.WriteSystemStop();
            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
            startButtonFlashMode = false;
            UpdateButtonText();
        }

        private void WarmTaskSuccessUpdate(string ColdLocation, string WarmLocation)
        {
            Logger.Log(ATSData.RunLog, UserData.Instance.Now.Name + " 完成出庫作業 ");;
            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
            startButtonFlashMode = false;


            UpdateButtonText();
        }
        


        private void StopStsk()
        {
            if (FormManager.IsResetFormOpen)
            {
                Task.Run(() => { MessageBox.Show("請先關閉視窗後再按停止"); });
                return;
            }
            if (!moving)
            {
                moving = true;
                StopButtonClick();
            }
            moving = false;
        }

        private void labelStatus_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("倒料失敗,膠材剩餘量過多(剩餘量超過設定值),請人員進行確認");
        }


    }
}
