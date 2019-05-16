using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATS;

namespace PLCconnect
{
    public class WriteSystem
    {
        public static void CheckTime()
        {
            DateTime dt = DateTime.Now;
            string TotalSendTime = PLCCommon.TransLengthToString(PLCCommon.Trans16((dt.Year).ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16((dt.Month).ToString()))
                + PLCCommon.TransLengthToString(PLCCommon.Trans16((dt.Day).ToString())) + PLCCommon.TransLengthToString(PLCCommon.Trans16((dt.Minute).ToString()))
                + PLCCommon.TransLengthToString(PLCCommon.Trans16((dt.Second).ToString()));

            PLCCommon.PLC_WRITE("1780", TotalSendTime,"5");
            
        }

        public static void WriteInitialize()
        {
            PLCCommon.PLC_WRITE("1700", "1", "1");
            PLCCommon.PLC_WRITE("1700", "0", "1");
        }

        public static void WriteSystemPause()
        {
            switch (ATSData.AutomaticModeStatus)
            {
                case ATSData.AutomaticModeStatusType.Run:
                    PLCCommon.PLC_WRITE("1701", "1", "1");
                    break;
                case ATSData.AutomaticModeStatusType.Pause:
                    PLCCommon.PLC_WRITE("1701", "0", "1");
                    break;
            }
            
        }

        public static void WriteSystemStop()
        {
            PLCCommon.PLC_WRITE("1702", "1", "1");
            
            System.Threading.Thread.Sleep(200);
            PLCCommon.PLC_WRITE("1702", "0", "1");
            PLCCommon.PLC_WRITE("1701", "0", "1");
        }


        public static void WriteSystemWarmStatus(int Location,int status)
        {
            string Commond = "0";
            if (status == -1)
            {
                Commond = "0";
            }
            if (status == 0)
            {
                Commond = "1";
            }

            if (status == 1)
            {
                Commond = "2";
            }
            else if (status == 2)
            {
                Commond = "3";
            }
            else if (status == 3)
            {
                Commond = "4";
            }


            PLCconnect.PLCCommon.PLC_WRITE((1820 + Location).ToString(),Commond,"1");
        }

        public static void WriteMachineValues(string UpDownMachine, string TransferValues,string DelayTime)
        {
            PLCconnect.PLCCommon.PLC_WRITE("1830",PLCCommon.Trans16(UpDownMachine),"1");
            PLCconnect.PLCCommon.PLC_WRITE("1832", PLCCommon.Trans16(TransferValues), "1");
            PLCconnect.PLCCommon.PLC_WRITE("1860", PLCCommon.Trans16(DelayTime), "1");
        }

        #region
        //恭喜你來到這裡
        //軟體百分之99只有我和上帝懂
        //現在只剩下上帝了
        //願世界沒有紛擾
        //你也是
        //LASCIATE OGNI SPERANZA, VOI CH'ENTRATE
        #endregion
    }
}
/**
 *　　　　　　　　┏┓　   ┏┓+ +
 *　　　　　　　┏┛┻━━━┛┻┓ + +
 *　　　　　　　┃　　　　　　　┃
 *　　　　　　　┃　　　━　　　┃ ++ + + +
 *　　　　　　 ████━████ ┃+  |
 *　　　　　　　┃　　　　　　　┃ +
 *　　　　　　　┃　　　┻　　　┃
 *　　　　　　　┃　　　　　　　┃ + +
 *　　　　　　　┗━┓　　　┏━┛
 *　　　　　　　　　┃　　　┃
 *　　　　　　　　　┃　　　┃ + + + +
 *　　　　　　　　　┃　　　┃　　　　Code is far away from bug with the animal protecting
 *　　　　　　　　　┃　　　┃ + 　　　　神獸保佑,程式無bug
 *　　　　　　　　　┃　　　┃
 *　　　　　　　　　┃　　　┃　　+
 *　　　　　　　　　┃　 　　┗━━━┓ + +
 *　　　　　　　　　┃ 　　　　　　　┣┓
 *　　　　　　　　　┃ 　　　　　　　┏┛
 *　　　　　　　　　┗┓┓┏━┳┓┏┛ + + + +
 *　　　　　　　　　　┃┫┫　┃┫┫
 *　　　　　　　　　　┗┻┛　┗┻┛+ + + +
 *
 */
