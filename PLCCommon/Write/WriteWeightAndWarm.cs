using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLCconnect
{
    public class WriteWeightAndWarm
    {
        #region PLC寫入重量(實)
        public void WriteFullWeight(double Weight)
        {
            string num =PLCCommon.Trans16((int)(Weight));
            string AfterPoint = PLCCommon.Trans16((int)(Weight * 1000) - (((int)(Weight)) * 1000));

            num =PLCCommon.TransLengthToString(num);
            AfterPoint = PLCCommon.TransLengthToString(AfterPoint);


            string TotalSendWeight = AfterPoint + num;
            PLCCommon.PLC_WRITE("1770", TotalSendWeight,"2");
            //PLCCommon.PLC_WRITE("1770", AfterPoint);
            //PLCCommon.PLC_WRITE("1771", num);
        }
        #endregion
        #region PLC寫入重量(空)
        public void WriteWeight(double Weight)
        {
            string num = PLCCommon.Trans16((int)(Weight));
            string AfterPoint = PLCCommon.Trans16((int)(Weight * 1000) - (((int)(Weight)) * 1000));

            num = PLCCommon.TransLengthToString(num);
            AfterPoint = PLCCommon.TransLengthToString(AfterPoint);
            string TotalSendWeight = AfterPoint + num;
            PLCCommon.PLC_WRITE("1772", TotalSendWeight, "2");

            //PLCCommon.PLC_WRITE("1772", AfterPoint);
            //PLCCommon.PLC_WRITE("1773", num);
        }
        #endregion
        #region 寫入溫度 冷藏及回溫
        public static void  WriteColdC(double num)
        {
            string ReadNumber = PLCCommon.Trans16((int)num);
            ReadNumber = PLCCommon.TransLengthToString(ReadNumber);
            PLCCommon.PLC_WRITE("1774",ReadNumber,"1");
        }
        public static void WriteWarmC(double num)
        {
            string ReadNumber = PLCCommon.Trans16((int)num);
            ReadNumber = PLCCommon.TransLengthToString(ReadNumber);
            PLCCommon.PLC_WRITE("1775", ReadNumber,"1");
        }
        #endregion
    }
}
