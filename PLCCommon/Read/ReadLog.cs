using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLCconnect
{
    public class ReadLog
    {
        #region 讀取條碼器Log
        public string ReadBarcoNo()
        {
            string Result = "";
            for (int i = 0; i < 20; i++)
            {
                Result += PLCCommon.PLC_READ((1610+i).ToString());
            }
            return Result;
        }
        #endregion
        #region 保存期限Log
        public string ReadSaveTime()
        {
            string Result = "";
            for (int i = 0; i < 3; i++)
            {
                Result +=PLCCommon.Trans16To10(PLCCommon.PLC_READ((1620 + i).ToString())) + ":";
            }
            return Result;
        }
        #endregion

        #region 入冷藏Log
        public string ReadOperatorLVColdIn()
        {
            return PLCCommon.PLC_READ("1630");
        }
        
        public string ReadOperatorColdIn()
        {
            string Result = "";
            for (int i = 0; i < 9; i++)
            {
               Result += PLCCommon.PLC_READ((1631+i).ToString());
            }
            return Result;
        }

        #endregion
        #region 出冷藏 進回溫Log
        public string ReadOperatorLVColdOut()
        {
            return PLCCommon.PLC_READ("1640");
        }

        public string ReadOperatorColdOut()
        {
            string Result = "";
            for (int i = 0; i < 9; i++)
            {
                Result += PLCCommon.PLC_READ((1641 + i).ToString());
            }
            return Result;
        }
        #endregion
        #region 出回溫區Log
        public string ReadOperatorLVWarmOut()
        {
            return PLCCommon.PLC_READ("1651");
        }

        public string ReadOperatorWarmOut()
        {
            string Result = "";
            for (int i = 0; i < 9; i++)
            {
                Result += PLCCommon.PLC_READ((1651 + i).ToString());
            }
            return Result;
        }
        #endregion

        #region 入冷藏派工時間Log
        public string ReadTaskStartTime()
        {
            string Result = "";
            for (int i = 0; i < 5; i++)
            {
                string Word = PLCCommon.PLC_READ((1660+i).ToString());
                if (Word != "")
                {
                    Result += Word + ":";
                }
                else
                {
                    Result += "0";
                }
            }
            return Result;
        }
        #endregion
        #region 入冷藏時間Log
        public string ReadInColdTime()
        {
            string Result = "";
            for (int i = 0; i < 5; i++)
            {
                string Word = PLCCommon.PLC_READ((1665 + i).ToString());
                if (Word != "")
                {
                    Result += Word + ":";
                }
                else
                {
                    Result += "0";
                }
            }
            return Result;
        }

        #endregion
        #region 出冷藏時間Log
        public string ReadOurColdTime()
        {
            string Result = "";
            for (int i = 0; i < 5; i++)
            {
                string Word = PLCCommon.PLC_READ((1670 + i).ToString());
                if (Word != "")
                {
                    Result += Word + ":";
                }
                else
                {
                    Result += "0";
                }
            }
            return Result;
        }

        #endregion
        #region 入回溫時間Log
        public string ReadInWarmTime()
        {
            string Result = "";
            for (int i = 0; i < 5; i++)
            {
                string Word = PLCCommon.PLC_READ((1675 + i).ToString());
                if (Word != "")
                {
                    Result += Word + ":";
                }
                else
                {
                    Result += "0";
                }
            }
            return Result;
        }

        #endregion
        #region 出回溫時間Log
        public string ReadOutWarmTime()
        {
            string Result = "";
            for (int i = 0; i < 5; i++)
            {
                string Word = PLCCommon.PLC_READ((1680 + i).ToString());
                if (Word != "")
                {
                    Result += Word + ":";
                }
                else
                {
                    Result += "0";
                }
            }
            return Result;
        }

        #endregion
        #region 到料時間Log
        public string ReadDoTaskTime()
        {
            string Result = "";
            for (int i = 0; i < 5; i++)
            {
                string Word = PLCCommon.PLC_READ((1685 + i).ToString());
                if (Word != "")
                {
                    Result += Word + ":";
                }
                else
                {
                    Result += "0";
                }
            }
            return Result;
        }

        #endregion
        #region 重量(實)Log
        public string ReadTotalWeight()
        {
            string Result = "";
            for (int i = 0; i < 2; i++)
            {
                string Word = PLCCommon.PLC_READ((1690 + i).ToString());
                Result += Word;
            }
            return Result;
        }

        #endregion
        #region 重量(空)Log
        public string ReadWeight()
        {
            string Result = "";
            for (int i = 0; i < 2; i++)
            {
                string Word = PLCCommon.PLC_READ((1692 + i).ToString());
                Result += Word;
            }
            return Result;
        }

        #endregion




    }
}
