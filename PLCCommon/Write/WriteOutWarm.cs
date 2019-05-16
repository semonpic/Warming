using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ATS;
using System.IO.Ports;

namespace PLCconnect
{
    public class WriteOutWarm
    {
        static Thread WarmThread;
        public static event WriteOutCold.Update UpdateEvent;
        public delegate void OutWamrRecycleBottle(int Number);
        public static event OutWamrRecycleBottle RecycleBottleChange = null;

        public static Action<string> WeightEvent = null;
        public static Action<string> EmptyWeightEvent = null;

        static SerialPort Sp;
        static SystemConfig sc = new SystemConfig();
        static string WeightGet = "";
        static bool WeightStatus = false; //False -> 實瓶   True -> 空瓶
        static bool OutWarmSuccess = false;
        static bool GetWeight = false;
        static bool GetLocation = false;
        public static  bool TaskStop = false;
        static bool CheckOnSite = false;

        #region 出回溫命令時間
        public static void WriteOutWarmTime()
        {
            DateTime dt = DateTime.Now;
            string TotalSendString = PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Year.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Month.ToString()))
                + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Hour.ToString()))
                + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString()));
            //PLCCommon.PLC_WRITE("1760", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Year.ToString())),"5");
            PLCCommon.PLC_WRITE("1761", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Month.ToString())),"1");
            PLCCommon.PLC_WRITE("1762", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())), "1");
            PLCCommon.PLC_WRITE("1763", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Hour.ToString())), "1");
            PLCCommon.PLC_WRITE("1764", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())), "1");
        }
        #endregion
        #region 出冷藏指定庫位
        public void WriteOutCold(string No) //NO => 1~8
        {
            PLCCommon.PLC_WRITE("1765", PLCCommon.TransLengthToString(No),"1");
        }
        #endregion
        #region 出冷藏指定目的地 1=> 入口  2=> 供料區
        public void WriteOutColdSeat(string OneorTwo)
        {
            PLCCommon.PLC_WRITE("1766", PLCCommon.TransLengthToString(OneorTwo),"1");
        }
        #endregion
        private static void WriteOutWarmReplyLocation(string Location)
        {
            PLCconnect.PLCCommon.PLC_WRITE("1813",Location,"1");
        }

        public static void WriteWeight(string Weight) //NO => 1~8
        {
            if (WeightStatus == false)
            {
                PLCCommon.PLC_WRITE("1770", Weight,"2");
            }
            else
            {
                PLCCommon.PLC_WRITE("1772", Weight, "2");
            }
        }

        public static void OutWarmTask()
        {

            WarmThread = new Thread(new ThreadStart(WarmTaskStart));
            WarmThread.IsBackground = true;
            WarmThread.SetApartmentState(ApartmentState.STA);
            WarmThread.Priority = ThreadPriority.AboveNormal;
            WarmThread.Start();

        }

        private static void WarmTaskStart()
        {
            TaskStop = false;
            for (int i = 1; i < PLCconnect.WriteOutCold.TsakNumber+1; i++)
            {
                try
                {
                    WriteOutWarmTime();
                    GetWeight = false;
                    WeightStatus = false;
                    GetLocation = false;

                    string Location = "";
                    string FillBottle = "";
                    string EmptyBottle = "";
                    string SlotID = "";
                    CheckOnSite = false;
                    int WarmType  =0;

                    DateTime dt = DateTime.Now;

                    do
                    {
                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskStop = true;
                        }
                        if (ReadSystemStatus.TaskLocation[3] != "0")
                        {
                            Location = ReadSystemStatus.TaskLocation[3];
                            WarmType = ReadSystemStatus.WarmType[int.Parse(Location) - 1];
                            WriteOutWarmReplyLocation(Location);
                            GetLocation = true;
                            SlotID = ATS.Models.UserData.Instance.SelectSlotID(Location);
                        }
                        System.Threading.Thread.Sleep(100);
                        if ((DateTime.Now - dt).TotalSeconds > 3000)
                        {
                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                            PLCCommon.ShowErrorInformation("回溫庫位對未失敗，請確認是否有機故", "超時提醒");
                            TaskStop = true;
                            WarmThread.Abort();
                            break;
                        }
                    }
                    while (GetLocation == false && TaskStop == false);



                    do
                    {

                        if (ReadSystemStatus.PlcStatus[6])
                        {
                            if (SystemConfig.WeightCheck == "1")
                            {
                                if (Convert.ToInt32(ReadSystemStatus.BottleWeight) == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    FillBottle = ReadSystemStatus.BottleWeight;
                                    StartSendWeight(FillBottle);
                                    GetWeight = true;
                                    ATS.Models.UserData.Instance.OutWarmFillWeight(Location, FillBottle);
                                    if (WeightEvent != null)
                                    {
                                        WeightEvent(FillBottle);
                                    }
                                }
                            }
                            else
                            {
                                FillBottle = "100";
                                StartSendWeight("100");
                                GetWeight = true;
                                ATS.Models.UserData.Instance.OutWarmFillWeight(Location, FillBottle);
                                if (WeightEvent != null)
                                {
                                    WeightEvent(FillBottle);
                                }
                            }
                        }

                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskStop = true;
                        }


                        Thread.Sleep(100);
                        if ((DateTime.Now - dt).TotalSeconds > 3000)
                        {
                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                            PLCCommon.ShowErrorInformation("超過時間沒有讀取到磅秤重量，請確認是否有機故", "超時提醒");
                            TaskStop = true;
                            WarmThread.Abort();
                            break;
                        }
                    }
                    while (GetWeight == false && TaskStop == false);


                    GetWeight = false;
                    dt = DateTime.Now;
                    WeightStatus = true;
                    do
                    {

                        if (ReadSystemStatus.PlcStatus[7])
                        {
                            if (SystemConfig.WeightCheck == "1")
                            {

                                Thread.Sleep(2000);
                                if (Convert.ToInt32(ReadSystemStatus.BottleWeight) == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    EmptyBottle = ReadSystemStatus.BottleWeight;
                                    if (Convert.ToInt32(EmptyBottle)/1000 > Convert.ToInt32(SystemConfig.WeightDownLimit))
                                    {
                                        PLCCommon.PLC_WRITE("1840","1","1");
                                        PLCCommon.PLC_WRITE("1840", "0", "1");
                                        System.Windows.Forms.MessageBox.Show("倒料失敗,膠材剩餘量過多(剩餘量超過設定值)");
                                        WiseTech.Log.Logger.SystemLog("倒料失敗,膠材剩餘量過多(剩餘量超過設定值)");
                                        TaskStop = true;
                                    }
                                    else
                                    {
                                        StartSendWeight(EmptyBottle);
                                        GetWeight = true;
                                        ATS.Models.UserData.Instance.OutWarmEmptyWeight(Location, EmptyBottle, FillBottle);
                                        ATS.Models.UserData.Instance.CreatCSVFile(Convert.ToInt32(Location),WarmType);
                                        if (EmptyWeightEvent != null)
                                        {
                                            EmptyWeightEvent(EmptyBottle);
                                        }
                                    }
                                }
                            }

                            else
                            {
                                EmptyBottle = "100";
                                StartSendWeight("100");
                                GetWeight = true;
                                ATS.Models.UserData.Instance.OutWarmEmptyWeight(Location, EmptyBottle, FillBottle);
                                ATS.Models.UserData.Instance.CreatCSVFile(Convert.ToInt32(Location), WarmType);
                                if (EmptyWeightEvent != null)
                                {
                                    EmptyWeightEvent("100");
                                }

                            }
                        }

                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskStop = true;
                        }

                        System.Threading.Thread.Sleep(100);
                        if ((DateTime.Now - dt).TotalSeconds > 3000)
                        {
                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                            PLCCommon.ShowErrorInformation("超過時間沒有讀取到磅秤重量，請確認是否有機故", "超時提醒");
                            TaskStop = true;
                            WarmThread.Abort();
                            break;
                        }
                    }
                    while (GetWeight == false && TaskStop == false);



                    do
                    {

               
                        if (PLCconnect.ReadSystemStatus.PlcStatus[1] && (!PLCconnect.ReadSystemStatus.PlcStatus[2]))
                        {
                            OutWarmSuccess = true;
                            ATS.Models.UserData.Instance.OutWarmSuccess(Location);
                        }
                        System.Threading.Thread.Sleep(1000);
                        if ((DateTime.Now - dt).TotalSeconds > 3000)
                        {
                            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                            PLCCommon.ShowErrorInformation("丟料失敗，請確認是否有機故", "超時提醒");
                            TaskStop = true;
                            WarmThread.Abort();
                            break;
                        }

                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskStop = true;
                        }
                    }
                    while (OutWarmSuccess == false && TaskStop == false);

                    //ATS.Models.UserData.Instance.OutWarmSuccess(Location, FillBottle, EmptyBottle);

                    if (OutWarmSuccess == true || PLCconnect.WriteOutCold.TsakNumber == i)
                    {
                        PLCconnect.ReadSystemStatus.RecycleBottleNum += i;
                        sc.SaveRecycleBottle(ReadSystemStatus.RecycleBottleNum.ToString());
                        if (RecycleBottleChange != null)
                        {
                            RecycleBottleChange(PLCconnect.ReadSystemStatus.RecycleBottleNum);
                        }
                        
                        if (UpdateEvent != null)
                        {
                            UpdateEvent("", "");
                        }
                        WarmSuccess success = new WarmSuccess();
                        success.TitleChange("批號 : " + SlotID + "\r\n 倒料完成 \r\n 完成時間 : "+ DateTime.Now.ToString());
                        success.ShowDialog();
                        WeightStatus = false;
                        OutWarmSuccess = false;
                        GetWeight = false;
                    }


                }

                catch (Exception err)
                {
                    ATS.LCSCommon.WriteAppErrorLog(err);
                }
            }
        }


        public static void StartSendWeight(string Weight)
        {
            WeightGet = PLCCommon.Trans16(Weight);
            while (WeightGet.Length < 9)
            {
                WeightGet = "0" + WeightGet;
            }
            WeightGet = WeightGet.Substring(4,4) + WeightGet.Substring(0, 4);
            WriteWeight(WeightGet);
            GetWeight = true;
          

        }


        
    }
}
