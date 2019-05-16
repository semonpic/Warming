using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ATS
{
    public class SystemConfig
    {

        private IniFile iniFile;

        public void IniFile()
        {
            
            //读取配置信息
            string fileName = System.Windows.Forms.Application.StartupPath  + "\\System.ini";
            iniFile = new IniFile(fileName);
            
            BarcoCom = iniFile.Read("Default", "BarcoCom").Trim();
            WeightCom = iniFile.Read("Default", "WeightCom").Trim();
            WeightSetting = iniFile.Read("Default", "WeightSetting").Trim();
            ColdSettingTemp = iniFile.Read("Default", "ColdSettingTemp").Trim();
            WarmSettingTemp = iniFile.Read("Default", "WarmSettingTemp").Trim();
            WeightCheck = iniFile.Read("Default", "WeightCheck").Trim();
            WarmTime = iniFile.Read("Default", "WarmTime").Trim();
            WarmOutTime1 = iniFile.Read("Default", "WarmOutTime1").Trim();
            WarmOutTime2 = iniFile.Read("Default", "WarmOutTime2").Trim();
            WeightUpLimit = iniFile.Read("Default", "WeightUpLimit").Trim();
            WeightDownLimit = iniFile.Read("Default", "WeightDownLimit").Trim();
            UpDownValues = iniFile.Read("Default", "UpDownValues").Trim();
            TransferValues = iniFile.Read("Default", "TransferValues").Trim();
            TempCheck = iniFile.Read("Default", "TempCheck").Trim();
            ColdWarmCom = iniFile.Read("Default", "ColdWarmCom").Trim();
            DelayTime = iniFile.Read("Default", "DelayTime").Trim();
            ShakeTime = iniFile.Read("Default", "ShakeTime").Trim();
            RecycleBottle = iniFile.Read("Info", "RecycleBottle").Trim();

            

            //iniFile.Write("Default","WeightSetting","1.4");

         }

        public void SaveIniFile(string WarmTime, string WarmOutTime1, string WarmOutTime2, string WeightUpLimit, string WeightDownLimit, string WeightCheck,
            string UpDownValues1, string TransferValues1, string ColdSettingTemp1, string WarmSettingTemp1, string TempCheck1,string DelayTime,string ShakeTime)
        {
            string fileName = System.Windows.Forms.Application.StartupPath + "\\System.ini";
            iniFile = new IniFile(fileName);
            try
            {
                iniFile.Write("Default", "WarmTime", WarmTime);
                iniFile.Write("Default", "WarmOutTime1", WarmOutTime1);
                iniFile.Write("Default", "WarmOutTime2", WarmOutTime2);
                iniFile.Write("Default", "WeightUpLimit", WeightUpLimit);
                iniFile.Write("Default", "WeightDownLimit", WeightDownLimit);

                iniFile.Write("Default", "UpDownValues", UpDownValues1);
                iniFile.Write("Default", "TransferValues", TransferValues1);
                iniFile.Write("Default", "ColdSettingTemp", ColdSettingTemp1);
                iniFile.Write("Default", "WarmSettingTemp", WarmSettingTemp1);
                iniFile.Write("Default", "DelayTime", DelayTime);
                iniFile.Write("Default", "ShakeTime", ShakeTime);

                #region 啟用或禁用
                if (WeightCheck == "啟用")
                {
                    iniFile.Write("Default", "WeightCheck", "1");
                }
                else
                {
                    iniFile.Write("Default", "WeightCheck", "0");
                }
                if (TempCheck1 == "啟用")
                {
                    iniFile.Write("Default", "TempCheck", "1");
                }
                else
                {
                    iniFile.Write("Default", "TempCheck", "0");
                }
                #endregion

                IniFile();
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }

        }
        public void SaveRecycleBottle(string Num)
        {
            string fileName = System.Windows.Forms.Application.StartupPath + "\\System.ini";
            iniFile = new IniFile(fileName);
            try
            {
                iniFile.Write("Info", "RecycleBottle", Num);
                IniFile();
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteAppErrorLog(err.Message);
            }
        }

        public static  string BarcoCom { get; set; }
        public static string WeightCom { get; set; }
        public static string WeightSetting { get; set; }
        public static string WeightCheck { get; set; } 
        public static string WarmTime { get; set; } 
        public static string WarmOutTime1 { get; set; } 
        public static string WarmOutTime2 { get; set; }
        public static string WeightUpLimit { get; set; } 
        public static string WeightDownLimit { get; set; }
        public static string UpDownValues { get; set; }
        public static string TransferValues { get; set; }
        public static string ColdSettingTemp { get; set; }
        public static string WarmSettingTemp { get; set; }
        public static string TempCheck { get; set; }
        public static string ColdWarmCom { get; set; }
        public static string DelayTime { get; set; }

        public static string RecycleBottle { get; set; }

        public static string ShakeTime { get; set; }
    }

    


    internal class IniFile
    {
        internal string iniFilePath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
       string section, string key, string val, string filePath);
        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(
       string section, string key,
       string def, StringBuilder retVal,
       int size, string filePath);
        internal IniFile(string filePath)
        {
            iniFilePath = filePath;
        }
        internal void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.iniFilePath);
        }
        internal string Read(string Section, string Key)
        {
            StringBuilder value = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", value, 500, this.iniFilePath);
            return value.ToString().Trim();
        }

    }
}
