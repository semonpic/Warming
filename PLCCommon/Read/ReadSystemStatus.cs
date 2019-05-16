using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using ATS;
using System.Threading.Tasks;
using System.Threading;
namespace PLCconnect
{
    public class ReadSystemStatus
    {
        static List<string> ReadFromPLC = new List<string>();
        static List<string> Status = new List<string>();
        public static bool[] PlcStatus = new bool[8];
        public static string[] IOInputStatus = new string[7];
        public static string[] IOOutputStatus = new string[7];
        public static string[] MachineStatus = new string[7];
        public static string[] ColdStatusScan = new string[8];
        public static string[] WarmStatusScan = new string[8];
        public static DateTime[] InColdTime = new DateTime[8];
        public static string[] WarmTime = new string[8];
        public static int[] WarmType = new int[8]{-2,-2,-2,-2,-2,-2,-2,-2};
        public static string[] AlarmCode = new string[15];
        public static string[] TaskLocation = new string[4];
        public static string[] ColdResinID = new string[8];
        public static string[] WarmResinID = new string[8];
        public static int[] WarmExpiredStatus = new int[8];
        public static int[] ColdTemp = new int[5];
        public static int[] WarmTemp = new int[5];
          
        public static Action<int, string> ColdStoreChange = null;
        public static Action<int, string> WarmStoreChange = null;
        public static Action<int, string,int> WarmTimeEvent = null;
        public static Action<int, string, string, int> WarmTimeShowEvent = null;
        public static Action<int, string> PlcAlarmEvent = null;
        public static Action<string> BottleWeightEvent = null;
        public static Action<byte> ColdBottleChangeNum = null;
        public static Action<byte> WarmBottleChangeNum = null;
        public static Action<int,string> ColdInformationChange = null;
        public static Action<bool>PLCStatusChange = null;
        public static Action<string,string> DoorOpenEvent = null;
        public static Action<string> MachineStatusEvent = null;
        public static Action<int, string> MachineLocationEvent = null;
        public static Action<int[]> ColdTempEvent = null;
        public static Action<int[]> WarmTempEvent = null;
        public static Action<int,string>IOInputEvent = null;
        public static Action IOInputAutoOrMaintain = null;
        public static Action DoorGateEvent = null;
        public static Action PauseReturnEvent = null;

        public static bool SystemPause = false;
        public static bool PauseType = false;
        public static bool BuzzerOnOff = false;
        public static string BottleWeight = "";
        public static string RobotResinID = "";
        public static int WarmStandBy = 0;
        static byte[] ColdMessage = new byte[] {0x01,0x03,0x22,0xFF,0x00,0x05,0xBF,0x81 };
        static byte[] WarmMessage = new byte[] {0x02, 0x03,0x22,0xFF, 0x00, 0x05, 0xBF, 0xB2  };
        static string WarmHour = "";
        static string WarmMinute = "";
        public static byte ColdBottleNum = 0;
        public static byte WarmBottleNum = 0;
        static byte PLCConnectStatus = 0;
        static SerialPort WeightSp ;
        static SerialPort ColdWarmTempSp;
        static int ScanStandByNum = 0;
        public static int RecycleBottleNum = 0;

        static string RobotNow = "";
        static string resin = "";
        static string Resin = "";
        
        



        public static void ScanStatus()
        {
            CheckPLC();
            CheckDoorGate();
            CheckOnline();
            CheckColdStore();
            CheckWarmTime();
            CheckIOOutput();
            CheckIOInput();
            CheckPlcAlarm();
            GetBottleWeight();
            CheckTaskLocation();
            CheckStoreID();
            CheckMachineStatus();
            //CheckBuzzer();
            
      


        }

        private static void CheckPLC()
        {
            //ReadFromPLC = PLCCommon.ScanPLC_READ("1500", "200");
            ReadFromPLC = new List<string>();
            for (int i = 0; i < 200; i++)
            {
                ReadFromPLC.Add("0");
            }
        }

        private static void CheckOnline()
        {
            
            try
            {
                //List<string> Status = PLCCommon.ScanPLC_READ("1500", "8");
                Status = ReadFromPLC.Take(8).Skip(0).ToList();
                for (int i = 0; i < Status.Count(); i++)
                {
                    PlcStatus[i] = Status[i] == "1" ? true : false;
                }

                if ( Status[0] == "1")
                {
                    PLCConnectStatus = 0;
                    if (PLCConnectStatus > 15)
                    {
                        PLCStatusChange(true);
                    }
                }
                else
                {
                    PLCConnectStatus++;
                    if (PLCConnectStatus > 15)
                    {
                        PLCStatusChange(false);
                    }
                }

            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }

        private static void CheckDoorGate()
        {
            Status = ReadFromPLC.Take(28).Skip(26).ToList();
            if (Status[1] != "1")
            {
                if (Status[0] == "1")
                {
                    if (PauseType == false)
                    {
                        if (DoorGateEvent != null)
                        {
                            DoorGateEvent();
                        }
                    }
                }
            }
            

            
        }
        private static void CheckColdStore()
        {
            try
            {
                //List<string> Status = PLCCommon.ScanPLC_READ("1590", "8");
                Status = ReadFromPLC.Take(98).Skip(90).ToList();
                byte NowColdBottleNum = 0;
                for (int i = 0; i < Status.Count(); i++)
                {
                    if (Status[i] != "0")
                    {
                        NowColdBottleNum++;
                    }
                    if (ColdStatusScan[i] != Status[i])
                    {
                        ColdStatusScan[i] = Status[i];
                        if (ColdStoreChange != null)
                        {
                            ColdStoreChange(i, ColdStatusScan[i]);
                        }
                    }

                }
                if (NowColdBottleNum != ColdBottleNum)
                {
                    ColdBottleNum = NowColdBottleNum;
                    if (ColdBottleChangeNum != null)
                    {
                        ColdBottleChangeNum(NowColdBottleNum);
                    }
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }

        private static void CheckWarmStore()
        {
            try
            {
                //List<string> Status = PLCCommon.ScanPLC_READ("1600", "8");
                Status = ReadFromPLC.Take(108).Skip(100).ToList();
                byte NowWarmBottleNum = 0;
                for (int i = 0; i < Status.Count(); i++)
                {
                    if (Status[i] != "0")
                    {
                        NowWarmBottleNum++;
                    }
                    if (WarmStatusScan[i] != Status[i])
                    {
                        WarmStatusScan[i] = Status[i];
                        if (WarmStoreChange != null)
                        {
                            WarmStoreChange(i, WarmStatusScan[i]);
                        }
                    }
                }
                if (NowWarmBottleNum != WarmBottleNum)
                {
                    WarmBottleNum = NowWarmBottleNum;
                    if (WarmBottleChangeNum != null)
                    {
                        WarmBottleChangeNum(NowWarmBottleNum);
                    }
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }



            //List<string> Status2 = PLCCommon.ScanPLC_READ("1500", "200");
        }


        static int Over = 0;
        private static void CheckWarmTime()
        {
            try
            {
           
                //List<string> Status = PLCCommon.ScanPLC_READ("1510", "16");
                Status = ReadFromPLC.Take(26).Skip(10).ToList();
                
                for (int i = 0; i < (Status.Count()); i = i + 2)
                {
                    WarmHour = "";
                    string StoreWarmTime = Status[i + 1] + Status[i];
                    int Num = Convert.ToInt32(StoreWarmTime);
                    if (Num >Convert.ToInt32(SystemConfig.WarmTime))
                    { 
                    
                    }
                    if (WarmTime[i / 2] != StoreWarmTime)
                    {
                        WarmTime[i / 2] = StoreWarmTime;
                        if (WarmTimeEvent != null)
                        {

                            Over = 0;
                            if (StoreWarmTime == "00")
                            {
                                Over = -1;

                                if (WarmType[i / 2] != Over)
                                {
                                    WarmType[i / 2] = Over;
                                    WriteSystem.WriteSystemWarmStatus(i / 2, Over);
                                }

                                //WriteSystem.WriteSystemWarmStatus(i / 2, Over);
                            }
                            else
                            {
                                WarmHour = (Convert.ToInt32(StoreWarmTime) / 60).ToString();
                                WarmMinute = (Convert.ToInt32(StoreWarmTime) % 60).ToString();
                                if (Convert.ToInt32(StoreWarmTime) > Convert.ToInt32(SystemConfig.WarmTime))
                                {
                                    Over = 1;
                                    if (Convert.ToInt32(StoreWarmTime) > Convert.ToInt32(SystemConfig.WarmOutTime1))
                                    {
                                        Over = Convert.ToInt32(StoreWarmTime) > Convert.ToInt32(SystemConfig.WarmOutTime2) ? 3 : 2;
                                    }
                                }

                                if (Over != 0 && Over != -1)
                                {
                                    //WriteSystem.WriteSystemWarmStatus(i / 2, Over);
                                    ScanStandByNum++;
                                    
                                    
                                }
                                else
                                {
                                    //WriteSystem.WriteSystemWarmStatus(i / 2, Over);
                                    
                                }

                                if (WarmType[i / 2] != Over)
                                {
                                    WarmType[i / 2] = Over;
                                    WriteSystem.WriteSystemWarmStatus(i / 2, Over);
                                }

                                

                            }

                            string  WarmedTime = WarmHour != "0" ? WarmHour + "h " + WarmMinute + "m" : WarmMinute + "m";
                            if (WriteOutCold.OutColdSuccess == true)
                            {
                                WarmTimeEvent(i / 2, WarmedTime, Over);
                                WarmTimeShowEvent(i / 2, WarmHour, WarmMinute, Over);
                            }

                            WarmExpiredStatus[i / 2] = Over;

                        }

                    }

                }
 
                if (WarmStandBy != ScanStandByNum)
                {
                    WarmStandBy = ScanStandByNum;
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }

        private static void CheckPlcAlarm()
        {
            try
            {
                //List<string> Status = PLCCommon.ScanPLC_READ("1530", "15");
                Status = ReadFromPLC.Take(45).Skip(30).ToList();
                for (int i = 0; i < Status.Count(); i++)
                {

                    if (Status[i] != "0")
                    {
                        if (Status[i] != "0" || AlarmCode[i] != "0")
                        {
                            if (AlarmCode[i] != Status[i])
                            {
                                AlarmCode[i] = Status[i];
                                if (PlcAlarmEvent != null)
                                {
                                    PlcAlarmEvent(i, AlarmCode[i]);
                                }
                            }
                        }
                    }


  
               
                        if (Status[i] != AlarmCode[i])
                        {
                            AlarmCode[i] = Status[i];
                            if (PlcAlarmEvent != null)
                            {
                                PlcAlarmEvent(i, AlarmCode[i]);
                            }
                        }

                    
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }



        private static void GetBottleWeight()
        {
            try
            {
                int Bytes = WeightSp.BytesToRead;
                if (Bytes > 0)
                {
                    byte[] buffer = new byte[Bytes];
                    WeightSp.Read(buffer, 0, Bytes);
                    BottleWeight = Encoding.Default.GetString(buffer);
                    if (BottleWeight.IndexOf("!") != -1 && BottleWeight.IndexOf("0000\r") != -1)
                    {
                        BottleWeight = StartSendWeight(BottleWeight);

                        if (BottleWeightEvent != null)
                        {
                            if (BottleWeight.Length > 5)
                            {
                                BottleWeightEvent(BottleWeight.Insert(BottleWeight.Length - 2, "."));
                            }
                            else
                            {
                                BottleWeightEvent(BottleWeight.Insert(BottleWeight.Length - 3, "."));
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }

        }

        private static void CheckTaskLocation()
        {
            try
            {
                //List<string> Status = PLCCommon.ScanPLC_READ("1610", "4");
                Status = ReadFromPLC.Take(114).Skip(110).ToList();
                for (int i = 0; i < Status.Count(); i++)
                {
                    TaskLocation[i] = Status[i];
                }

                
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }


        private static void CheckStoreID()
        {
            try
            {
                
                //List<string> Status = PLCCommon.ScanPLC_READ("1615", "85");
                Status = ReadFromPLC.Take(200).Skip(115).ToList();
                RobotNow = "";
                for (int i = 0; i < 5; i++)
                {
                    string Word = Convert.ToString(Convert.ToInt32(Status[i]), 16);
                    if (Word == "0")
                    { RobotNow = ""; }
                    else
                    {
                        if (Status[i].Length > 3)
                        {
                            RobotNow += Convert.ToChar(Convert.ToInt32(Word.Substring(2, 2), 16));
                        }

                        RobotNow += Convert.ToChar(Convert.ToInt32(Word.Substring(0, 2), 16));
                    }
                }
                if (RobotResinID != RobotNow)
                {
                    RobotResinID = RobotNow;
                }
               

                for (int i = 1; i < 9; i++) //5~44
                {
                    resin = "";
                    for (int j = 0; j < 5; j++)
                    {
                        if (Status[(5 * i) + j].Length > 1)
                        {
                            string Word = Convert.ToString(Convert.ToInt32(Status[(5 * i) + j]), 16);
                            if (Status[(5 * i) + j].Length > 3)
                            {
                                resin += Convert.ToChar(Convert.ToInt32(Word.Substring(2, 2), 16));
                            }

                            resin += Convert.ToChar(Convert.ToInt32(Word.Substring(0, 2), 16));

                            //resin += Convert.ToChar(PLCCommon.Trans16To10((Status[(5 * i) + j])).Substring(0, 2));
                        }
                        //else
                        //{
                        //    resin = "0";
                        //}


              
                    }
                    if (resin != ColdResinID[i - 1] && WriteInClod.TaskSuccess)
                    {
                        ColdResinID[i - 1] = resin;
                        InColdTime[i - 1] = ATS.Models.UserData.Instance.SelectIncoldTime(resin);
  
                        if (ColdInformationChange != null)
                        {
                            ColdInformationChange(i, ColdResinID[i - 1]);
                        }
                    }
                }
                byte NowWarmBottleNum = 0;
                for (int i = 0; i < 8; i++)//45~85
                {
                    Resin = "";
                    for (int j = 0; j < 5; j++)
                    {
                        if (Status[5 * (i + 9) + j].Length > 0)
                        {
                            if (Status[5 * (i + 9) + j] != "0")
                            {
                                string Word = Convert.ToString(Convert.ToInt32(Status[(5 * (i + 9)) + j]), 16);
                                if (Status[(5 *( i + 9)) + j].Length > 3)
                                {
                                    Resin += Convert.ToChar(Convert.ToInt32(Word.Substring(2, 2), 16));
                                }

                                Resin += Convert.ToChar(Convert.ToInt32(Word.Substring(0, 2), 16));
                            }

                        }






                        //Resin += Convert.ToChar(Convert.ToInt32(Status[(5 * (i+9)) + j]));
                    }

                    if (Resin != "")
                    {
                        NowWarmBottleNum++;
                    }
                    if (Resin != WarmResinID[i])
                    {
                        WarmResinID[i] = Resin;
                    }
                }

                if (NowWarmBottleNum != WarmBottleNum)
                {
                    WarmBottleNum = NowWarmBottleNum;
                    if (WarmBottleChangeNum != null)
                    {
                        WarmBottleChangeNum(NowWarmBottleNum);
                    }
                }

            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }


        private static string StartSendWeight(string SendWeight)
        {
            int Start = SendWeight.IndexOf("!") + 1;
            SendWeight = SendWeight.Substring(Start, SendWeight.Length - Start).Trim();
            int End = SendWeight.IndexOf("0000\r");
            return (SendWeight.Substring(0, End)).Trim();
        }


        private static void CheckIOInput()
        {
            //List<string> Status = PLCCommon.ScanPLC_READ("1560", "7");
            Status = ReadFromPLC.Take(67).Skip(60).ToList();
            for (int i = 0; i < Status.Count(); i++)
            {   

                string Two = GetBinary(Status[i]);
                if (IOInputStatus[i] != Two)
                {
                    IOInputStatus[i] = Two;

                    if (i == 1 || i == 0 || i ==3)
                    {
                        if (IOInputEvent != null)
                        {
                            IOInputEvent(i, IOInputStatus[i]);
                        }
                    }


                    if (i == 0)
                    {
                        if (IOInputAutoOrMaintain != null)
                        {
                            IOInputAutoOrMaintain();
                        }
                    }
                }
            }

        }

        private static void CheckIOOutput()
        {
            //List<string> Status = PLCCommon.ScanPLC_READ("1567","7");
            Status = ReadFromPLC.Take(74).Skip(67).ToList();
            for (int i = 0; i < Status.Count(); i++)
            {
                string Two = GetBinary(Status[i]);
                if (IOOutputStatus[i] != Two)
                {
                    IOOutputStatus[i] = Two;

                    if (i == 0)
                    { 
                        
                    }
                }
            }
        }


        public static void IniSerialPort()
        {
            try
            {
                WeightSp = new SerialPort(SystemConfig.WeightCom, 19200, Parity.None, 8, StopBits.One);
                if (!WeightSp.IsOpen)
                {
                    WeightSp.Open();
                }
                ColdWarmTempSp = new SerialPort(SystemConfig.ColdWarmCom, 9600, Parity.Even, 8, StopBits.One);//
                if (!ColdWarmTempSp.IsOpen)
                {
                    ColdWarmTempSp.Open();
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }

        public static void WriteCommon(string Common)
        {
            //for (int i = 0; i < BarcoNumber.Length; i++)
            //{
            //    PLCCommon.PLC_WRITE((1730 + i).ToString(), PLCCommon.TransLengthToString(PLCCommon.Trans16(BarcoNumber[i])), "1");
            //}
            //8088X78 7
            if (Common.Length % 2 == 0)
            {
                for (int i = 0; i < Common.Length / 2; i++)
                {
                    PLCCommon.PLC_WRITE((1730 + i).ToString(),PLCCommon.Trans16(Common[(i * 2) + 1]) + PLCCommon.Trans16(Common[(i * 2)]),"2");
                }
            }
            else
            {
                for (int i = 0; i < Common.Length / 2; i++)
                {
                    PLCCommon.PLC_WRITE((1730 + i).ToString(), PLCCommon.Trans16(Common[(i * 2) + 1]) + PLCCommon.Trans16(Common[(i * 2)]), "2");
                }
                PLCCommon.PLC_WRITE((1730 +( Common.Length / 2)).ToString(), PLCCommon.TransLengthToString(PLCCommon.Trans16(Common[Common.Length - 1])), "1");
            }

        }


        private static string GetBinary(string IntergerWord)
        {
            
            string ReturnMessage =  Convert.ToString(Convert.ToInt32(IntergerWord), 2);
            int Num = ReturnMessage.Length;
            for (int i = 0; i < 16 -Num ; i++)
            {
                ReturnMessage = "0" + ReturnMessage;
            }
            return ReturnMessage;
        }

        private static void CheckMachineStatus()
        {
            //List<string> Status = PLCCommon.ScanPLC_READ("1550", "7");
            Status = ReadFromPLC.Take(57).Skip(50).ToList();
            for (int i = 0; i < Status.Count(); i++)
            {
                string Two = GetBinary(Status[i]);
                if (Two != MachineStatus[i])
                {
                    MachineStatus[i] = Two;
                    if (MachineStatusEvent != null)
                    {
                        if (i == 0)
                        {
                            MachineStatusEvent(Two);
                        }
                        else
                        {
                            MachineLocationEvent(i, Two);
                        }
                        
                    }
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                ColdTemp[i] = new Random().Next(100);
                WarmTemp[i] = new Random().Next(300, 400);
            }
            ColdTempEvent?.Invoke(ColdTemp);
            SpinWait.SpinUntil(() => { return false; }, 200);
            WarmTempEvent?.Invoke(WarmTemp);
            SpinWait.SpinUntil(() => { return false; }, 200);

            /*
            ColdWarmTempSp.Write(ColdMessage, 0, ColdMessage.Length);
            Thread.Sleep(200);
            int bytes = ColdWarmTempSp.BytesToRead;
            while (bytes > 8)
            {
                Byte[] ColdReciveBuffer = new byte[bytes];
                
                ColdWarmTempSp.Read(ColdReciveBuffer, 0, ColdReciveBuffer.Length);
                for (int i = 3; i < 13; i = i + 2)
                {
                    string str = ColdReciveBuffer[i].ToString();
                    string str1 = ColdReciveBuffer[i + 1].ToString();
                    str = Convert.ToString(ColdReciveBuffer[i], 16);
                    str1 = Convert.ToString(ColdReciveBuffer[i + 1], 16);
                    ColdTemp[(i - 3) / 2] = Convert.ToInt32(str + str1, 16) > 10000 ? Convert.ToInt32(str + str1, 16) - 65536 : Convert.ToInt32(str + str1, 16);
                }
                bytes = 0;
                ColdWarmTempSp.DiscardInBuffer();
                if (ColdTempEvent != null)
                {
                    ColdTempEvent(ColdTemp);
                }
            }



            ColdWarmTempSp.Write(WarmMessage, 0, WarmMessage.Length);
            Thread.Sleep(200);
            bytes = ColdWarmTempSp.BytesToRead;
            while (bytes > 8)
            {
                
                Byte[] WarmReciveBuffer = new byte[bytes];
                ColdWarmTempSp.Read(WarmReciveBuffer, 0, WarmReciveBuffer.Length);
                int[] temp = new int[5];
                for (int i = 3; i < 13; i = i + 2)
                {
                    string str = WarmReciveBuffer[i].ToString();
                    string str1 = WarmReciveBuffer[i + 1].ToString();
                    str = Convert.ToString(WarmReciveBuffer[i], 16);
                    str1 = Convert.ToString(WarmReciveBuffer[i + 1], 16);
                    if (str1.Length == 1)
                    {
                        str1 = "0" + str1;
                    }
                    WarmTemp[(i - 3) / 2] = Convert.ToInt32(str + str1, 16);
                }
                if (WarmTempEvent != null)
                {
                    WarmTempEvent(WarmTemp);
                }
                bytes = 0;
            }

    */



        }
        static CancellationTokenSource CTS  = new System.Threading.CancellationTokenSource();

        private static void Start()
        {

            while (true)
            {
                try
                {
                    ColdWarmTempSp.Write(ColdMessage, 0, ColdMessage.Length);
                    int bytes = ColdWarmTempSp.BytesToRead;
                    while (bytes > 8)
                    {
                        Byte[] ColdReciveBuffer = new byte[bytes];
                        Thread.Sleep(200);
                        ColdWarmTempSp.Read(ColdReciveBuffer, 0, ColdReciveBuffer.Length);
                        for (int i = 3; i < 13; i = i + 2)
                        {
                            string str = ColdReciveBuffer[i].ToString();
                            string str1 = ColdReciveBuffer[i + 1].ToString();
                            str = Convert.ToString(ColdReciveBuffer[i], 16);
                            str1 = Convert.ToString(ColdReciveBuffer[i + 1], 16);
                            ColdTemp[(i - 3) / 2] = Convert.ToInt32(str + str1, 16);
                        }
                        // ColdWarmTempSp.DiscardInBuffer();
                        bytes = 0;
                        ColdWarmTempSp.DiscardInBuffer();
                    }

                    if (ColdTempEvent != null)
                    {
                        ColdTempEvent(ColdTemp);
                    }

                    ColdWarmTempSp.Write(WarmMessage, 0, WarmMessage.Length);
                    bytes = ColdWarmTempSp.BytesToRead;
                    while (bytes > 8)
                    {
                        Thread.Sleep(200);
                        Byte[] WarmReciveBuffer = new byte[bytes];
                        ColdWarmTempSp.Read(WarmReciveBuffer, 0, WarmReciveBuffer.Length);
                        int[] temp = new int[5];
                        for (int i = 3; i < 13; i = i + 2)
                        {
                            string str = WarmReciveBuffer[i].ToString();
                            string str1 = WarmReciveBuffer[i + 1].ToString();
                            str = Convert.ToString(WarmReciveBuffer[i], 16);
                            str1 = Convert.ToString(WarmReciveBuffer[i + 1], 16);
                            WarmTemp[(i - 3) / 2] = Convert.ToInt32(str + str1, 16);
                        }
                        bytes = 0;

                        if (WarmTempEvent != null)
                        {
                            WarmTempEvent(WarmTemp);
                        }
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception err)
                { }


            }



        }


        private static void CheckBuzzer()
        {
            //List<string> Status = PLCCommon.ScanPLC_READ("1861", "1");
            Status = PLCCommon.ScanPLC_READ("1861", "1");
            if (Status[0] == "1")
            {
                BuzzerOnOff = false;
            }
            else
            {
                BuzzerOnOff = true;
            }
        }


        public static bool CheckIOSafty()
        {
            
            if (IOInputStatus[1][4] == '1')
            {
                return false;
            }
            if (IOInputStatus[3][1] == '1')
            {
                return false;
            }
            if (IOInputStatus[5][5] == '1')
            {
                return false;
            }
            if (IOInputStatus[5][4] == '1')
            {
                return false;
            }


            return true;
        }


       
       


    }
}
