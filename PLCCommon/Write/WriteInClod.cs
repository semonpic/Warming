using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using ATS;
using ATS.Models;

namespace PLCconnect
{
    public class WriteInClod
    {
        public delegate void ResinImformation(string Message);
        //public static event ResinImformation BarcoReaderEvent;
        public static Action<string> SendInformation = null;
        public static Action<bool> Success = null;
        public static event WriteOutCold.Update UpdateEvent;
        
        private static SerialPort Sp;
        delegate void Display(Byte[] buffer);
        //static bool GetInformation = false;
        public static bool TaskSuccess = true;
        static Thread CommonThread;
        static string data = "";
        static string BarcoReader = "";
        private ATS.Models.UserData userData;
        public static event Action<string,string,string> Update = null;
        public  static bool GetBarcoImformation = false;
        public static string NowLv = "";
        public static string NowName = "";
        static bool TaskFail = false;
        public WriteInClod()
        {
            userData = UserData.Instance;
            userData.LoginEvent += new UserData.EventUserLogin(WriteOperator);
            //Sp = new SerialPort(SystemConfig.BarcoCom, 19200, Parity.None, 8, StopBits.One);

        }

        public static void IniSerialPort()
        {
            try
            {
                Sp = new SerialPort(SystemConfig.BarcoCom, 19200, Parity.None, 8, StopBits.One);
                Sp.Open();
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }

        #region 寫入操作人員
        public static void WriteOperator(string Lv, string Name)
        {
            NowLv = Lv;
            NowName = Name;
            string TotalSendName = "";
            PLCCommon.PLC_WRITE("1710", Lv,"1");
            
            for (int i = 0; i < Name.Length; i++)
            {
                TotalSendName += PLCCommon.TransLengthToString(PLCCommon.Trans16((int)Name[i]));
                //PLCCommon.PLC_WRITE((1711 + i).ToString(), PLCCommon.TransLengthToString(PLCCommon.Trans16((int)Name[i])));
            }
            PLCCommon.PLC_WRITE("1711", TotalSendName, Name.Length.ToString());
  
           
        
        }
        #endregion
        #region 入冷藏膠材條碼編號
        public static void WriteBarcoNo(string BarcoNumber)
        {
            if (BarcoNumber.Length % 2 == 0)
            {
                for (int i = 0; i < BarcoNumber.Length / 2; i++)
                {
                    PLCCommon.PLC_WRITE((1730 + i).ToString(), PLCCommon.Trans16(BarcoNumber[(i * 2) + 1]) + PLCCommon.Trans16(BarcoNumber[(i * 2)]), "1");
                }
            }
            else
            {
                for (int i = 0; i < BarcoNumber.Length / 2; i++)
                {
                    PLCCommon.PLC_WRITE((1730 + i).ToString(), PLCCommon.Trans16(BarcoNumber[(i * 2) + 1]) + PLCCommon.Trans16(BarcoNumber[(i * 2)]), "1");
                }
                PLCCommon.PLC_WRITE((1730 + (BarcoNumber.Length / 2)).ToString(), PLCCommon.TransLengthToString(PLCCommon.Trans16(BarcoNumber[BarcoNumber.Length - 1])), "1");
            }
            //上下顛倒 Ex.8088X78
            //for (int i = 0; i < BarcoNumber.Length; i++)
            //{
            //    PLCCommon.PLC_WRITE((1730 + i).ToString(), PLCCommon.TransLengthToString(PLCCommon.Trans16(BarcoNumber[i])), "1");
            //}
        }
        #endregion
        #region 入冷藏保存期限
        public static void WriteInColdSaveTime(string dt)
        {
            string Year =PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Substring(0,4)));
            string Month = PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Substring(4, 2)));
            string Day = PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Substring(6, 2)));
            string TotalSendDate = Year + Month + Day;

            //PLCCommon.PLC_WRITE("1740", TotalSendDate,"3");

            PLCCommon.PLC_WRITE("1740", Year,"1");
            PLCCommon.PLC_WRITE("1741", Month,"1");
            PLCCommon.PLC_WRITE("1742", Day,"1");

        }
        #endregion
        #region 入冷藏命令時間
        public static void WriteStartTaskTime()
        {
            DateTime dt = DateTime.Now;
            string SendTotalStartTime = PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Year.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Month.ToString()))
                + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Hour.ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Minute.ToString()));

            //PLCCommon.PLC_WRITE("1743", SendTotalStartTime,"5");

            PLCCommon.PLC_WRITE("1743", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Year.ToString())),"1");
            PLCCommon.PLC_WRITE("1744", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Month.ToString())), "1");
            PLCCommon.PLC_WRITE("1745", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Day.ToString())), "1");
            PLCCommon.PLC_WRITE("1746", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Hour.ToString())), "1");
            PLCCommon.PLC_WRITE("1747", PLCCommon.TransLengthToString(PLCCommon.Trans16(dt.Minute.ToString())), "1");
        }
        #endregion

        public static void WriteIncoldCheckGetInformation(string Location)
        {
            PLCconnect.PLCCommon.PLC_WRITE("1810", Location, "1");
        }

        public static void WriteIncoldStartFinally()
        {
            PLCCommon.PLC_WRITE("1001", "1","1");
        }


        #region 開啟執行續
        public static void IncoldTask(string BarcoReaderIn )
        {
            BarcoReader = BarcoReaderIn;
            CommonThread = new Thread(new ThreadStart(TaskStart));
            CommonThread.IsBackground = true;
            CommonThread.SetApartmentState(ApartmentState.STA);
            CommonThread.Priority = ThreadPriority.AboveNormal;
            CommonThread.Start();

        }
        #endregion
        #region 執行比對 成功->寫入作業 失敗->回傳MessageBox 目前以等待收到訊息來製作
        private static void TaskStart()
        {

            TaskFail = false;
            TaskSuccess = false;
            GetBarcoImformation = false;
            
            string[] BarcoReaderList = BarcoReader.Split(';');
            string Num = WiseTech.Log.Logger.TodayTaskNumber(BarcoReaderList[2]);
            WriteBarcoNo(BarcoReaderList[2] +"-" + Num);
            WriteInColdSaveTime(BarcoReaderList[4]);

            if (PLCconnect.ReadSystemStatus.PlcStatus[1])
            {
                
                ATSData.AutomaticModeStatusType t = ATSData.AutomaticModeStatus;
                int bytes = 0;
                DateTime dt = DateTime.Now;
                do
                {
                    if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                    {
                        TaskFail = true;
                    }


                    bytes = Sp.BytesToRead;
                    if (bytes > 0)
                    {

                    }

                    if (bytes > 30)
                    {
                        byte[] buffer = new byte[bytes];
                        Sp.Read(buffer, 0, bytes);
                        data = Encoding.Default.GetString(buffer);
                        GetBarcoImformation = true; //20190318 Add
                        Invokesend(data);
                    }




                    Thread.Sleep(100);
                    if ((DateTime.Now - dt).TotalSeconds > 30)
                    {
                        ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                        PLCCommon.ShowErrorInformation("超過時間沒有讀取到BarcoReader資訊,請確認罐子是否擺放正確", "超時提醒");
                        WiseTech.Log.Logger.SystemLog("超過時間沒有讀取到BarcoReader資訊，設定時間為 30 秒");
                    
                        CommonThread.Abort();
                        break;
                    }
                }
                while (GetBarcoImformation == false && !TaskFail);


                //}
            }
            else
            {
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Pause;
                MessageBox.Show("請先等待作業完成,或確認目前是否為連線狀態", "作業運行提示");
                WiseTech.Log.Logger.SystemLog("請先等待作業完成,或確認目前是否為連線狀態");
   
            }

        }
        private static void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /*
             *1801930101;   -> P/N
             * ;            
             * 8088X78;     -> LotNo
             * 1.4;         -> Qty
             * 20190224;    -> Exp Date
             * 20180825\r"  -> Dom(ProDuction Date)
             */
        }

        private static void Invokesend(string data)
        {
            if (SendInformation != null)
            {
                SendInformation(data);
            }
        }


        public static string SlotThread = "";
        private static string OverTimeThread = "";
        private static Thread MatchThread;

        public static void MatchDataWithBarco(string Slot,string Overtime)
        {
            SlotThread = Slot;
            OverTimeThread = Overtime;

            MatchThread = new Thread(new ThreadStart(MatchDataWithBarcoThread));
            MatchThread.IsBackground = true;
            MatchThread.SetApartmentState(ApartmentState.STA);
            MatchThread.Priority = ThreadPriority.AboveNormal;
            MatchThread.Start();

            
        }
        #endregion

        public static void MatchDataWithBarcoThread()
        {
            try
            {
                TaskFail = false;
                //BarcoReader = "1801930101;;8088X78;1.4;20190224;20180825";
                string[] BarcoReaderList = BarcoReader.Split(';');
                if (BarcoReaderList[2] == SlotThread && BarcoReaderList[4] == OverTimeThread)
                {

                    SlotThread = SlotThread + "-" + WiseTech.Log.Logger.TodayTaskNumber(SlotThread);
                    WriteStartTaskTime();
                    string Location = "0";
                    DateTime dt = DateTime.Now;
                    bool CheckLocation = false;
                    UserData.Instance.InColdStart(SlotThread, OverTimeThread, Location);
                    UserData.Instance.InColdWriteLotBottleInfo(SlotThread, BarcoReader);

                    do
                    {
                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskFail = true;
                        }
                        if (ReadSystemStatus.TaskLocation[0] != "0")
                        {
                            Location = ReadSystemStatus.TaskLocation[0];
                            UserData.Instance.InColdLocationUpdate(SlotThread, Location);
                            Thread.Sleep(1000);
                            WriteIncoldCheckGetInformation(ReadSystemStatus.TaskLocation[0]);
                            CheckLocation = true;

                            SpinWait.SpinUntil(() => { return false; }, 5000);
                            if (ReadSystemStatus.TaskLocation[0] != "0")
                            {
                                CheckLocation = false;
                            }
                            
                        }

                        if ((DateTime.Now - dt).TotalSeconds > 300)
                        {
                            MessageBox.Show("入庫失敗:冷藏庫開啟逾時，請確認是否有機故");
                            WiseTech.Log.Logger.SystemLog("入冷藏失敗: 冷藏庫開啟逾時，請確認是否有機故");
                            CheckLocation = true;
                            TaskSuccess = true;
                            TaskFail = true;
                        }


                    }
                    while (CheckLocation == false && !TaskFail);



                    do
                    {

                        if (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Stop)
                        {
                            TaskFail = true;
                        }

                        if (ReadSystemStatus.PlcStatus[2] == false)
                        {
                            if (Update != null)
                            {
                                Update.Invoke(Location, SlotThread, OverTimeThread);
                            }
                            if (Success != null)
                            {
                                Success.Invoke(true);
                            }
                            TaskSuccess = true;
                             //ATS.Models.UserData.Instance.InColdSuccess(Slot, Overtime, Location);
                        }

                        if ((DateTime.Now - dt).TotalSeconds > 500)
                        {
                            MessageBox.Show("入庫失敗:完成流程未回到定位，請確認是否有機故");
                            WiseTech.Log.Logger.SystemLog("入庫失敗:完成流程未回到定位，請確認是否有機故");
                            TaskSuccess = true;
                            TaskFail = true;
                        }
                    }
                    while (TaskSuccess == false || !TaskFail);




                    if (TaskSuccess && !TaskFail)
                    {
                        if (UpdateEvent != null)
                        {
                            UpdateEvent(Location, SlotThread);
                        }
                        WarmSuccess success = new WarmSuccess();
                        success.TitleChange("入冷藏完成");

                        success.Location = new System.Drawing.Point(940, 500);
                        success.ShowDialog();
                    }



                }
                else
                {
                    MessageBox.Show("條碼比對錯誤比對錯誤", "訊息錯誤警告");
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }




    }
}
