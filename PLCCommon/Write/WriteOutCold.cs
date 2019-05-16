using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ATS;

namespace PLCconnect
{
    public class WriteOutCold
    {

        public delegate void Update(string ColdLocation, string WarmLocation);
        public static event Update UpdateEvent;
        public static Action<int, string, string, int> UpdateWarmEvent = null;
        public static Action<int> OutColdFirstSendInfo = null;
        public static event Update TaskOverEvent;
        public static bool OutColdSuccess = true;
        static bool GetColdLocation = false;
        static bool GetWarmLocation = false;
        static Thread WarmThread;
        public static int TsakNumber = 1;
        public static bool TaskStop = false;
        public static string LotID = "";




        #region 出冷藏命令時間
        public static void WriteOutColdTime()
        {
            //PLCCommon.PLC_WRITE("1755", "2", "1");
            //PLCCommon.PLC_WRITE("1756", "1", "1");
            DateTime dt = DateTime.Now;
            string SendWord = PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Year.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Month.ToString()))
                + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Hour.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Minute.ToString()));
            //PLCCommon.PLC_WRITE("1750", SendWord, "5");
            PLCCommon.PLC_WRITE("1750", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Year.ToString())),"1");
            PLCCommon.PLC_WRITE("1751", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Month.ToString())), "1");
            PLCCommon.PLC_WRITE("1752", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())), "1");
            PLCCommon.PLC_WRITE("1753", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Hour.ToString())), "1");
            PLCCommon.PLC_WRITE("1754", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Minute.ToString())), "1");
        }
        #endregion
        #region 出冷藏指定庫位
        public static void WriteOutColdChoose(string No)
        {
            PLCCommon.PLC_WRITE("1754",PLCCommon.TransLengthToString(No),"1");
        }
        #endregion
        #region 出冷藏指定目的地 1=> 入口  2=> 回溫區
        public static void WriteOutColdSeat(string OneorTwo)
        {
            PLCCommon.PLC_WRITE("1755", PLCCommon.TransLengthToString(OneorTwo),"1");
        }
        #endregion
        private static void WriteOutColdReplyColdLocation(string Location)
        {
            PLCCommon.PLC_WRITE("1811", Location, "1");
        }
        private static void WriteOutColdReplyWarmLocation(string Location)
        {
            PLCCommon.PLC_WRITE("1812", Location, "1");
        }


        public static void WriteOperator()
        {
            PLCCommon.PLC_WRITE("1710", WriteInClod.NowLv,"1");

           

            for (int i = 0; i < WriteInClod.NowName.Length; i++)
            {
                //SendTotlaWord += PLCCommon.TransLengthToString(PLCCommon.Trans16((int)WriteInClod.NowName[i]));
                PLCCommon.PLC_WRITE((1711 + i).ToString(), PLCCommon.TransLengthToString(PLCCommon.Trans16((int)WriteInClod.NowName[i])),"1");
            }
            //PLCCommon.PLC_WRITE("1711", SendTotlaWord, WriteInClod.NowName.Length.ToString());



        }

        public static void InwarmTask()
        {
     
            WarmThread = new Thread(new ThreadStart(InWarmTaskStart));
            WarmThread.IsBackground = true;
            WarmThread.SetApartmentState(ApartmentState.STA);
            WarmThread.Priority = ThreadPriority.AboveNormal;
            WarmThread.Start();
            
            
         }

        private static void InWarmTaskStart()
        {
            TaskStop = false;
            for (int i = 1; i < TsakNumber+1; i++)
            {
                string ColdLocation = "0";
                string WarmLocation = "0";
                GetColdLocation = false;
                OutColdSuccess = false;
                GetWarmLocation = false;
                WriteOperator();
                WriteOutColdTime();
                //PLCCommon.PLC_WRITE("1766", "1");
                DateTime dt = DateTime.Now;

                do
                {
                    if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                    {
                        TaskStop = true;
                    }
                    Thread.Sleep(500);
                    if (ReadSystemStatus.TaskLocation[1] != "0")
                    {
                        ColdLocation = ReadSystemStatus.TaskLocation[1];
                        WriteOutColdReplyColdLocation(ColdLocation);
                        
                        GetColdLocation = true;

                        SpinWait.SpinUntil(() => { return false; }, 5000);

                        if (ReadSystemStatus.TaskLocation[1] != "0")
                        {
                            GetColdLocation = false;
                        }
                    }


                    if ((DateTime.Now - dt).TotalSeconds > 300)
                    {
                        System.Windows.Forms.MessageBox.Show("入回溫作業逾時,請確認機台是否有機故", "訊息提醒");
                        TaskStop = true;
                        PLCconnect.WriteSystem.WriteSystemStop();
                        ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    }
                }
                while (GetColdLocation == false && !TaskStop);

                if (TaskStop != true)
                {
                    do
                    {

                        if (ReadSystemStatus.RobotResinID != "")
                        {
                            LotID = ReadSystemStatus.RobotResinID;
                        }

                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskStop = true;
                        }

                        Thread.Sleep(500);
                        if (ReadSystemStatus.TaskLocation[2] != "0")
                        {
                            WarmLocation = ReadSystemStatus.TaskLocation[2];
                            WriteOutColdReplyWarmLocation(WarmLocation);
                            GetWarmLocation = true;
                            OutColdFirstSendInfo(int.Parse(WarmLocation));
                            ATS.Models.UserData.Instance.InWarmSuccess(ColdLocation, WarmLocation);
                            SpinWait.SpinUntil(() => { return false; }, 5000);

                            if (ReadSystemStatus.TaskLocation[2] != "0")
                            {
                                GetWarmLocation = false;
                            }

                        }


                        if ((DateTime.Now - dt).TotalSeconds > 300)
                        {
                            System.Windows.Forms.MessageBox.Show("入回溫作業逾時,請確認機台是否有機故", "訊息提醒");
                            PLCconnect.WriteSystem.WriteSystemStop();
                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                            TaskStop = true;
                            GetWarmLocation = true;
                            WarmThread.Abort();
                        }
                    }
                    while (GetWarmLocation == false && !TaskStop);

                }


                if (TaskStop != true)
                {
                    do
                    {
                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskStop = true;
                        }
                        Thread.Sleep(2000);
                        if (!PLCconnect.ReadSystemStatus.PlcStatus[2])
                        {
                            OutColdSuccess = true;
                        }
                        if ((DateTime.Now - dt).TotalSeconds > 300)
                        {
                            System.Windows.Forms.MessageBox.Show("入回溫作業逾時,請確認機台是否有機故", "訊息提醒");
                            PLCconnect.WriteSystem.WriteSystemStop();
                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                            ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                            TaskStop = true;
                            OutColdSuccess = true;
                        }
                    }
                    while (OutColdSuccess == false && !TaskStop);

                }
                if (OutColdSuccess == true)
                {
                    if (UpdateEvent != null)
                    {
                        UpdateEvent.Invoke(ColdLocation, WarmLocation);
                        UpdateWarmEvent.Invoke(Convert.ToInt32(WarmLocation)-1, "0", "0", 0);
                    }

                    
                    if (i == TsakNumber)
                    {
                        if (TaskOverEvent != null)
                        {
                       TaskOverEvent.Invoke(ColdLocation,WarmLocation);
                        }
                        PLCconnect.WarmSuccess success = new WarmSuccess();
                        success.TitleChange("入回溫完成");

                        success.Location = new System.Drawing.Point(940, 500);
                        success.ShowDialog();
                    }
                }
            }
        }
    }
}
