using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLCconnect
{
    class ReadManagerStatus
    {
        #region CheckCold
        public string ReadClod1()
        {
            return PLCCommon.PLC_READ("1590");
        }
        public string ReadClod2()
        {
            return PLCCommon.PLC_READ("1591");
        }
        public string ReadClod3()
        {
            return PLCCommon.PLC_READ("1592");
        }
        public string ReadClod4()
        {
            return PLCCommon.PLC_READ("1593");
        }
        public string ReadClod5()
        {
            return PLCCommon.PLC_READ("1594");
        }
        public string ReadClod6()
        {
            return PLCCommon.PLC_READ("1595");
        }
        public string ReadClod7()
        {
            return PLCCommon.PLC_READ("1596");
        }
        public string ReadClod8()
        {
            return PLCCommon.PLC_READ("1597");
        }
        #endregion

        #region CheckWarm
        public string ReadWarm1()
        {
            return PLCCommon.PLC_READ("1600");
        }
        public string ReadWarm2()
        {
            return PLCCommon.PLC_READ("1601");
        }
        public string ReadWarm3()
        {
            return PLCCommon.PLC_READ("1602");
        }
        public string ReadWarm4()
        {
            return PLCCommon.PLC_READ("1603");
        }
        public string ReadWarm5()
        {
            return PLCCommon.PLC_READ("1604");
        }
        public string ReadWarm6()
        {
            return PLCCommon.PLC_READ("1605");
        }
        public string ReadWarm7()
        {
            return PLCCommon.PLC_READ("1606");
        }
        public string ReadWarm8()
        {
            return PLCCommon.PLC_READ("1607");
        }

        #endregion
    }
}
