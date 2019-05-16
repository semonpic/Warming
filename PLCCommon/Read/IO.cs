using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCCommon.Read
{
    public  class IO
    {
        //********************************************//
        //IoInput 由PLC讀出->位址1560->1566 讀取出為16字string e.g 0010001100110000
        //解析須由最後開始解析 e.g 字串最後一碼為以下第一碼
        //*******************************************//


        #region 1560
        public const int Auto = 15;
        public const int AutoStart = 14;
        public const int Reset = 13;
        public const int Stop = 12;
        public const int TempLimitUp = 9;
        public const int TempLimitDown = 8;
        public const int MainRobotFront = 7;
        public const int MainRobotBack = 6;
        public const int MainRobotOpen = 5;
        public const int MainRobotLock = 4;
        public const int OpenBottleRobotFront = 3;
        public const int OpenBottleRobotBack = 2;
        public const int OpenBottleRobotOpen = 1;
        public const int OpenBottleRobotLock = 0;

        #endregion

        #region 1561
        public const int TransferRobotTurn = 15;
        public const int TransferRobotBack = 14;
        public const int TransferRobotOpen = 13;
        public const int TransferRobotClose = 12;
        public const int HeatOpen = 11;
        public const int HeatClose = 10;
        public const int ColdOpen = 9;
        public const int ColdClose = 8;
        //public const int ColdOpen = 7;
        //public const int ColdClose = 6;
        public const int AreaSafe = 5;
        public const int LoadPortHave = 4;
        public const int UpDownAxisOverUpLimit = 3;
        public const int UpDownAxisDog = 2;
        public const int UpDownAxisOverDownLimit = 1;
        public const int TrasnfetAxisOverFrontLimit = 0;
        #endregion

        #region 1562
        public const int TrasnfetAxisDog = 15;
        public const int TrasnfetAxisOverBackLimit = 14;
        public const int RotageMotorAlarm = 13;
        public const int RotageAdapaterAlarm = 12;
        public const int HeatHave = 11;
        public const int ColdHave = 10;
        public const int UpDownAsixServerAlarm = 9;
        public const int UpDownAsixServerReady = 8;
        public const int UpDownAsixServerOK = 7;
        public const int TransferAsixServerAlarm = 6;
        public const int TransferAsixServerReady = 5;
        public const int TransferAsixServerOK = 4;
        public const int OpenBottleAsixServerAlarm = 3;
        public const int OpenBottleAsixServerReady = 2;
        public const int OpenBottleAsixServerOK = 1;
        //public const int TrasnfetAxisOverFrontLimit = 0;
        #endregion

        #region 1563
        public const int InCoder1 = 15;
        public const int InCoder2 = 14;
        public const int InCoder3 = 13;
        public const int InCoder4 = 12;
        public const int InCoder5 = 11;
        public const int InCoder6 = 10;
        public const int InCoder7 = 9;
        public const int InCoder8 = 8;
        public const int InCoder9 = 7;
        public const int InCoder10 = 6;
        public const int CatchAsixAtUp = 5;
        public const int CatchAsixAtDown = 4;
        public const int CatchRobotOpen = 3;
        public const int CatchRobotClose = 2;
        public const int CatchRobotHave = 1;
        public const int WaterSensor = 0;
        #endregion

        #region 1564
        public const int RotageAsixIDRIVING = 15;
        public const int RotageAsixCWLS = 14;
        public const int RotageAsixCCWLS = 13;
        public const int RotageAsixORG = 12;
        public const int SpareAsixIDRIVING = 11;
        public const int SpareAsixICWLS = 10;
        public const int SpareAsixICCWLS = 9;
        public const int SpareAsixORG = 8;
        public const int RotageAsixReady = 7;
        //public const int InCoder10 = 6;
        public const int RotageAsixEms = 5;
        public const int RotageAsixMoving = 4;
        //public const int CatchRobotOpen = 3;
        //public const int CatchRobotClose = 2;
        //public const int CatchRobotHave = 1;
        //public const int WaterSensor = 0;
        #endregion

        #region 1565
        public const int UpDownAsixORGS = 15;
        public const int UpDownAsixINP = 14;
        public const int UpDownAsixReady = 13;
        public const int UpDownAsixSerVo_S = 12;
        public const int UpDownAsixPro_0_S = 11;
        public const int UpDownAsixPro_1_S = 10;
        public const int UpDownAsixPro_2_S = 9;
        public const int UpDownAsixPro_3_S = 8;
        public const int UpDownAsixPro_4_S = 7;
        public const int UpDownAsixPro_5_S = 6;
        public const int MainRobotHave = 5;
        public const int TransferRobotHave = 4;
        public const int FrontDoorOpen = 3;
        public const int FrontDoorOpenFinish = 2;
        public const int SideDoorOpen = 1;
        public const int SideDoorOpenFinish = 0;
        #endregion

        #region 1566
        //public const int UpDownAsixORGS = 15;
        //public const int UpDownAsixINP = 14;
        //public const int UpDownAsixReady = 13;
        //public const int UpDownAsixSerVo_S = 12;
        //public const int UpDownAsixPro_0_S = 11;
        //public const int UpDownAsixPro_1_S = 10;
        //public const int UpDownAsixPro_2_S = 9;
        //public const int UpDownAsixPro_3_S = 8;
        public const int YAMADA_Input1 = 7;
        public const int YAMADA_Input2 = 6;
        public const int YAMADA_Input3 = 5;
        public const int YAMADA_Input4 = 4;
        public const int YAMADA_Input5 = 3;
        public const int YAMADA_Input6 = 2;
        public const int YAMADA_Input7 = 1;
        public const int YAMADA_Input8 = 0;
        #endregion



        //********************************************//
        //IoOutput 由PLC讀出->位址1567->1573 讀取出為16字string e.g 0010001100110000
        //解析須由最後開始解析 e.g 字串最後一碼為以下第一碼
        //*******************************************//

        #region 1567
        public const int MainRobotFonst = 15;
        public const int MainRobotBackOut = 14;
        public const int MainRobotOpenOut = 13;
        public const int MainRobotClose = 12;
        public const int OpenBottleRobotBackOut = 11;
        public const int OpenBottleRobotFrontOut = 10;
        public const int OpenBottleRobotLockOut = 9;
        public const int OpenBottleRobotOpenOut = 8;
        public const int TransferRobotRev = 7;
        public const int TransferRobotTurnOut = 6;
        public const int TransferRobotOpenOut = 5;
        public const int TransferRobotLock = 4;
        public const int HeatOpenOut = 3;
        public const int HeatCloseOut = 2;
        public const int ColdOpenOut = 1;
        public const int ColdCloseOut = 0;
        #endregion

        #region 1568
        public const int UpDownServoPower = 15;
        public const int TrasnferServoPower = 14;
        public const int OpenBottleServoPower = 13;
        public const int AdataperServoPower = 12;
        public const int AdataperServoRun = 11;
        public const int AdataperServoBreak = 10;
        public const int AdataperServoLowPower = 9;
        //public const int OpenBottleRobotOpen = 8;
        //public const int TransferRobotRev = 7;
        //public const int TransferRobotTurn = 6;
        //public const int TransferRobotOpen = 5;
        //public const int TransferRobotLock = 4;
        //public const int HeatOpen = 3;
        //public const int HeatClose = 2;
        public const int CoolingPower = 1;
        public const int UpDownBreaky = 0;
        #endregion

        #region 1569
        public const int BarcoReaderStart = 15;
        public const int AutoLight = 14;
        public const int ErrorLight = 13;
        public const int ErrorInfo = 12;
        public const int GreenLight = 11;
        public const int YellowLight = 10;
        public const int RedLight = 9;
        //public const int OpenBottleRobotOpen = 8;
        public const int UpDownServoOn = 7;
        public const int UpDownServoReset = 6;
        public const int TransferServoOn = 5;
        public const int TransferServoReset = 4;
        public const int OpenBottleServoOn = 3;
        public const int OpenBottleServoReset = 2;
        //public const int CoolingPower = 1;
        //public const int UpDownBreaky = 0;
        #endregion

        #region 1570
        public const int UpDownAsixOverLimit_Up = 15;
        public const int UpDownAsixOverLimit_Down = 14;
        public const int UpDownAsixDog = 13;
        public const int UpDownAsixStop = 12;
        public const int TransferAsixOverLimit_Fonst = 11;
        public const int TransferAsixOverLimit_Back = 10;
        public const int TransferAsixDog = 9;
        public const int TransferAsixStop = 8;
        public const int OpenBottleAsixOverLimit_Fonst = 7;
        public const int OpenBottleAsixOverLimit_Back = 6;
        public const int OpenBottleAsixDog = 5;
        public const int OpenBottleAsixStop = 4;
        //public const int OpenBottleServoOn = 3;
        //public const int OpenBottleServoReset = 2;
        //public const int CoolingPower = 1;
        //public const int UpDownBreaky = 0;
        #endregion

        #region 1571
        public const int RotageBIT0 = 15;
        public const int RotageBIT1 = 14;
        public const int RotageBIT2 = 13;
        public const int RotageBIT3 = 12;
        public const int RotageBIT4 = 11;
        public const int RotageBIT5 = 10;
        public const int RotageBITStart = 9;
        public const int RotageStop = 8;
        public const int RotagePTChange = 7;
        public const int FrontDoor_Light_Green = 6;
        public const int FrontDoor_Light_Red = 5;
        public const int SideDoor_Light_Green = 4;
        public const int SideDoor_Light_Red = 3;
        //public const int OpenBottleServoReset = 2;
        //public const int CoolingPower = 1;
        //public const int UpDownBreaky = 0;
        #endregion

        #region 1572
        public const int LifitingORG = 15;
        public const int LifitingServoOn = 14;
        public const int LifitingReset = 13;
        public const int LifitingStart = 12;
        public const int LifitingBit0 = 11;
        public const int LifitingBit1 = 10;
        public const int LifitingBit2 = 9;
        public const int LifitingBit3 = 8;
        public const int LifitingBit4 = 7;
        public const int LifitingBit5 = 6;
        public const int LifitingBit6 = 5;
        public const int LifitingORG_S = 4;
        //public const int SideDoor_Light_Red = 3;
        //public const int OpenBottleServoReset = 2;
        //public const int CoolingPower = 1;
        //public const int UpDownBreaky = 0;
        #endregion

        #region 1573
        public const int CatchAsixDown = 15;
        public const int CatchAsixLock = 14;
        public const int UnLoadBlow = 13;
        //public const int LifitingStart = 12;
        //public const int LifitingBit0 = 11;
        //public const int LifitingBit1 = 10;
        //public const int LifitingBit2 = 9;
        //public const int LifitingBit3 = 8;
        public const int YAMADA_Output1 = 7;
        public const int YAMADA_Output2 = 6;
        public const int YAMADA_Output3 = 5;
        public const int YAMADA_Output4 = 4;
        public const int YAMADA_Output5 = 3;
        public const int YAMADA_Output6 = 2;
        public const int YAMADA_Output7 = 1;
        public const int YAMADA_Output8 = 0;
        #endregion


    }

    public class AxisStatus
    {
        //********************************************//
        //AxisStatus 由PLC讀出->位址1550->1556 讀取出為16字string e.g 0010001100110000
        //解析須由最後開始解析 e.g 字串最後一碼為以下第一碼
        //*******************************************//

        #region 1550
        public const int UpDownAxisReady = 15;
        public const int TransferAxisReady = 14;
        public const int OpenBottleAxisReady = 13;
        public const int RotageAxisReady = 12;
        public const int LifitingAxisReady = 11;
        //public const int LifitingAxisReady = 10;
        //public const int LifitingAxisReady = 9;
        //public const int TempLimitDown = 8;
        public const int UpDownAxisOPRFinish = 7;
        public const int TransferAxisOPRFinish = 6;
        public const int OpenBottleAxisOPRFinish = 5;
        public const int RotageAxisOPRFinish = 4;
        public const int LifitingAxisORPFinish = 3;
        //public const int RotageAxisOPRFinish = 2;
        //public const int RotageAxisOPRFinish = 1;
        //public const int OpenBottleRobotLock = 0;
        #endregion

        #region 1551
        public const int UpDownAxisToMz0 = 15; // 出冷藏低點位
        public const int UpDownAxisToMz1 = 14; // 入料口取膠材低點位
        public const int UpDownAxisToMz2 = 13; // 入料口取膠材高點位
        public const int UpDownAxisToMz3 = 12; // 入冷藏高點位
        public const int UpDownAxisToMz4 = 11; // 入冷藏低點位
        public const int UpDownAxisToMz5 = 10; // 入回溫低點位
        public const int UpDownAxisToMz6 = 9;  // 入回溫低點位
        public const int UpDownAxisToMz7 = 8;  // 置磅秤高點位
        public const int UpDownAxisToMz8 = 7;  // 置磅秤低點位
        public const int UpDownAxisToMz9 = 6;  // 開蓋上點位
        public const int UpDownAxisToMz10 = 5; // 出冷藏上點位
        public const int UpDownAxisToMz11 = 4; // 開蓋下點位
        public const int UpDownAxisToMz12 = 3; // 上接至移載機上點位
        public const int UpDownAxisToMz13 = 2; // 上接至移載機下點位
        public const int UpDownAxisToMz14 = 1; // 上蓋下點位
        public const int UpDownAxisToMz15 = 0; // None
        #endregion

        #region 1552
        public const int UpDownAxisToMz16 = 15; // 待機點位
        public const int UpDownAxisToMz17 = 14; // None
        public const int UpDownAxisToMz18 = 13; // 開蓋移動開始點位
        public const int UpDownAxisToMz19 = 12; // 上蓋上點位
        //public const int UpDownAxisToMz4 = 11;
        //public const int UpDownAxisToMz5 = 10;
        //public const int UpDownAxisToMz6 = 9;
        //public const int UpDownAxisToMz7 = 8;
        //public const int UpDownAxisToMz8 = 7;
        //public const int UpDownAxisToMz9 = 6;
        //public const int UpDownAxisToMz10 = 5;
        //public const int UpDownAxisToMz11 = 4;
        //public const int UpDownAxisToMz12 = 3;
        //public const int UpDownAxisToMz13 = 2;
        //public const int UpDownAxisToMz14 = 1;
        //public const int UpDownAxisToMz15 = 0;
        #endregion

        #region 1553
        public const int TransferAxisToTR0 = 15; // None
        public const int TransferAxisToTR1 = 14; // 取料位置(靠近機台)
        public const int TransferAxisToTR2 = 13; // 到料位置(靠近YAMADA)
        //public const int UpDownAxisToMz19 = 12;
        //public const int UpDownAxisToMz4 = 11;
        //public const int UpDownAxisToMz5 = 10;
        //public const int UpDownAxisToMz6 = 9;
        //public const int UpDownAxisToMz7 = 8;
        //public const int UpDownAxisToMz8 = 7;
        //public const int UpDownAxisToMz9 = 6;
        //public const int UpDownAxisToMz10 = 5;
        //public const int UpDownAxisToMz11 = 4;
        //public const int UpDownAxisToMz12 = 3;
        //public const int UpDownAxisToMz13 = 2;
        //public const int UpDownAxisToMz14 = 1;
        //public const int UpDownAxisToMz15 = 0;
        #endregion

        #region 1554
        public const int OpenBottleAxisTo0 = 15;
        public const int OpenBottleAxisTo18 = 14;
        public const int OpenBottleAxisTo19 = 13;
        //public const int UpDownAxisToMz19 = 12;
        //public const int UpDownAxisToMz4 = 11;
        //public const int UpDownAxisToMz5 = 10;
        //public const int UpDownAxisToMz6 = 9;
        //public const int UpDownAxisToMz7 = 8;
        //public const int UpDownAxisToMz8 = 7;
        //public const int UpDownAxisToMz9 = 6;
        //public const int UpDownAxisToMz10 = 5;
        //public const int UpDownAxisToMz11 = 4;
        //public const int UpDownAxisToMz12 = 3;
        //public const int UpDownAxisToMz13 = 2;
        //public const int UpDownAxisToMz14 = 1;
        //public const int UpDownAxisToMz15 = 0;
        #endregion

        #region 1555
        public const int RotageAxisToMR0 = 15; //None
        public const int RotageAxisToMR1 = 14; //入料口位置
        public const int RotageAxisToMR2 = 13; //儲存區位置
        public const int RotageAxisToMR3 = 12; //磅秤區位置
        public const int RotageAxisToMR4 = 11; //回收區位置
        //public const int UpDownAxisToMz5 = 10;
        //public const int UpDownAxisToMz6 = 9;
        //public const int UpDownAxisToMz7 = 8;
        //public const int UpDownAxisToMz8 = 7;
        //public const int UpDownAxisToMz9 = 6;
        //public const int UpDownAxisToMz10 = 5;
        //public const int UpDownAxisToMz11 = 4;
        //public const int UpDownAxisToMz12 = 3;
        //public const int UpDownAxisToMz13 = 2;
        //public const int UpDownAxisToMz14 = 1;
        //public const int UpDownAxisToMz15 = 0;
        #endregion

        #region 1556
        public const int LifitingAxisToLF0 = 15;
        public const int LifitingAxisToLF1 = 14; //上位接料位置
        public const int LifitingAxisToLF2 = 13; //下位接料位置
        public const int LifitingAxisToLF3 = 12;
        //public const int RotageAxisToMR4 = 11;
        //public const int UpDownAxisToMz5 = 10;
        //public const int UpDownAxisToMz6 = 9;
        //public const int UpDownAxisToMz7 = 8;
        //public const int UpDownAxisToMz8 = 7;
        //public const int UpDownAxisToMz9 = 6;
        //public const int UpDownAxisToMz10 = 5;
        //public const int UpDownAxisToMz11 = 4;
        //public const int UpDownAxisToMz12 = 3;
        //public const int UpDownAxisToMz13 = 2;
        //public const int UpDownAxisToMz14 = 1;
        //public const int UpDownAxisToMz15 = 0;
        #endregion


    }
}
