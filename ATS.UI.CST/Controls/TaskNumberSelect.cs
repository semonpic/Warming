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


namespace ATS.UI.CST.Controls
{
    public partial class TaskNumberSelect : UserControl
    {
        ControlPanel control = new ControlPanel();
        public static Action TaskStart = null;
        List<string> num = new List<string>();
        string[] Number = new string[] { };
        private static System.Windows.Forms.Timer TaskNumTimer = new System.Windows.Forms.Timer();
        private BarcoReader BarcoReaderFrm = new BarcoReader();
        public static bool HaveTask = false;
        public static bool Moving = false;
        private int TaskNum = 0;

        public TaskNumberSelect()
        {
            InitializeComponent();
            Load += TaskNumberSelect_Load;
            PLCconnect.WriteInClod.Success += Success;
        }
        private void TaskNumberSelect_Load(object sender, EventArgs e)
        {

            this.Left = (Parent.Width - Width) >> 1;
            this.Top = 42;


        }


        private void Success(bool B)
        {
            if (B)
            {
                HaveTask = false;
            }
            else
            {
                HaveTask = true;
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            ParentForm.Controls.Remove(this);
        }

        internal void IniUserControl(string Name)
        {
            CBNumberSelect.Items.Clear();
            num.Clear();
            LbInformation.Text = "";
            


            if (ATSData.TaskMode == ATSData.SystemTaskMode.Incold)
            {
                
                
                byte Num = PLCconnect.ReadSystemStatus.ColdBottleNum;
                byte WarmLocationNum =Convert.ToByte(8- (int)PLCconnect.ReadSystemStatus.WarmBottleNum);
                if (Num == 8)
                {
                    LbInformation.Text = "目前數量已滿瓶,請先將膠材移出或進行回溫";
                }
                else
                {
                    if (Num > WarmLocationNum)
                    {
                        for (byte i = 1; i < Num; i++)
                        {
                            num.Add(i.ToString());
                        }
                        Number = num.ToArray();
                        CBNumberSelect.Items.AddRange(Number);
                    }
                    else
                    {
                        for (byte i = 1; i < WarmLocationNum; i++)
                        {
                            num.Add(i.ToString());
                        }
                        Number = num.ToArray();
                        CBNumberSelect.Items.AddRange(Number);
                    }
                }
            }

            else if (ATSData.TaskMode == ATSData.SystemTaskMode.Inwarm)
            {


                byte Num = Convert.ToByte(8 - (int)PLCconnect.ReadSystemStatus.WarmBottleNum);
                byte ColdNum = PLCconnect.ReadSystemStatus.ColdBottleNum;

                if (ColdNum == 0)
                {
                    LbInformation.Text = "目前冷藏區未有膠材，請先進行入冷藏作業";
                }
                else
                {
                    if (Num != 0)
                    {
                        if (ColdNum < Num)
                        {
                            for (int i = 1; i < ColdNum + 1; i++)
                            {
                                num.Add(i.ToString());
                            }
                        }
                        else
                        {
                            for (byte i = 1; i < Num + 1; i++)
                            {
                                num.Add(i.ToString());
                            }
                        }
                        Number = num.ToArray();
                        CBNumberSelect.Items.AddRange(Number);
                    }
                    else
                    {
                        LbInformation.Text = "目前數量已滿瓶,請先將膠材移出或進行到料";
                    }
                }
            }


            else if (ATSData.TaskMode == ATSData.SystemTaskMode.Outwarm)
            {
                byte Num = PLCconnect.ReadSystemStatus.WarmBottleNum;
                if (Num != 0)
                {
             
                        for (byte i = 1; i < Num+1; i++)
                        {
                            num.Add(i.ToString());
                        }
                    
                    Number = num.ToArray();
                    CBNumberSelect.Items.AddRange(Number);
                }
                else
                {
                    LbInformation.Text = "目前回溫膠材數量為0,請先將膠材進行回溫";
                }

            }
            labelTitle.Text = Name + "作業數量選擇";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!Moving)
            {
                buttonStart_Click1();
                Moving = true;
                ParentForm.Controls.Remove(this);
            }
        }

        public void StartIncold()
        {
            buttonStart_Click1();
        }

        public void buttonStart_Click1()
        {
            if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop || ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Pause)
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;
            }
            else
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                PLCconnect.PLCCommon.PLC_WRITE("1701", "0", "1");
            }


            if (FormManager.IsResetFormOpen)
            {
                Task.Run(() => { MessageBox.Show("請先關閉視窗後再按啟動"); });

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                return;
            }
   
            
                StartButtonClick();
       
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


            if (!ATSData.ResetOK)
            {
                MessageBox.Show("尚未初始化完成 請先初始化", "尚未初始化完成 請先初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                return;
            }

            if (PLCconnect.ReadSystemStatus.CheckIOSafty() == false)
            {
                MessageBox.Show("請先確認各手臂是否有物品或在席是否正常", "確認請求", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                System.Threading.SpinWait.SpinUntil(() => { return false; }, 2000);
            }

            //要確定所有設備Reset完成沒有Alarm才能開始
            if (AlarmManager.IsAlarm)
            {
                MessageBox.Show("設備仍有錯誤未清除請先排除錯誤後再按開始", "設備仍有錯誤未清除請先排除錯誤後再按開始", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Error;
                return;
            }

            switch (ATSData.SystemMode)
            {
                case ATSData.SystemModeType.Handmode:
                    //Maintain模式不能按Start
                    MessageBox.Show("請先切換為Auto模式後才能啟動", "請先切換為Auto模式後才能啟動", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                    ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    SpinWait.SpinUntil(() => { return false; }, 2000);
                    //System.Threading.Thread.Sleep(2000);
                    break;
                default:

                    if (AppData.Debug)
                    {
                        ATSData.AutomaticModeStatus = (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Run) ? ATSData.AutomaticModeStatusType.Pause :
                                                    (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Pause) ? ATSData.AutomaticModeStatusType.Run :
                                                    ATSData.AutomaticModeStatusType.Run;
            
                        return;
                    }

                    if (ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Busy)
                    {
                        switch (ATSData.AutomaticModeStatus)
                        {
                            case ATSData.AutomaticModeStatusType.Pause:
                                PLCconnect.WriteSystem.WriteSystemPause();
                                break;
                            case ATSData.AutomaticModeStatusType.Run:
                                PLCconnect.WriteSystem.WriteSystemPause();
                                break;
                            case ATSData.AutomaticModeStatusType.Stop:
                                PLCconnect.WriteSystem.WriteSystemStop();
                                break;
                            default:
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
                                        BarcoReader BarcoReaderFrm1 = new BarcoReader();
                                        BarcoReaderFrm1.BarcoFrmClear();
                                        
                                        this.Parent.Controls.Add(BarcoReaderFrm1);
                                        this.Parent.Controls.SetChildIndex(BarcoReaderFrm1, 0);
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                        break;
                                    case ATSData.SystemTaskMode.Inwarm:
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Busy;
                                        PLCconnect.WriteOutCold.TsakNumber = Convert.ToInt32(CBNumberSelect.Text);
                                        PLCconnect.WriteOutCold.InwarmTask();
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                        if (TaskStart != null)
                                        {
                                            TaskStart();
                                        }
                                        break;
                                    case ATSData.SystemTaskMode.Outwarm:
                                        if (PLCconnect.ReadSystemStatus.WarmStandBy > 0)
                                        {
                                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Busy;
                                            PLCconnect.WriteOutCold.TsakNumber = Convert.ToInt32(CBNumberSelect.Text);
                                            PLCconnect.WriteOutWarm.OutWarmTask();
                                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                            if (TaskStart != null)
                                            {
                                                TaskStart();
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("回溫庫存不足，請確認是否有足夠的膠材，或等待膠材回溫完成", "Error Information");
                                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                        }
                                        break;
                                }
                                break;
                            case ATSData.AutomaticModeStatusType.Stop:
                                break;
                            default:
                                MessageBox.Show("異常中/初始化中不可開始", "異常中/初始化中不可開始", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                SpinWait.SpinUntil(() => { return false; }, 2000);
                                //System.Threading.Thread.Sleep(2000);
                                break;
                        }
                    }

                    break;
            }
           
        }


    }
}
