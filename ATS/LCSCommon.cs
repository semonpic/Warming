using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pinsoft.Common.Log;
namespace ATS
{

    public class LCSCommon
    {
      

        internal static TextLog appErrorLog, runLog, mPIORunLog, mMCPSSLog, mSTSSLog,mLIMSPCLog,mCIMLog;
        internal static TextLog mTestRunLog, runLogIOCard, workSheetLog, mHostPLCLog, mJiaJuPLCLog,mM4100Log;
          internal static int[] maryConfig = new int[18];
          internal static int[] maryConfig2 = new int[19];
        private delegate void WriteLogDelete(string log);
        static LCSCommon()
        {
            maryConfig[0]=59;
            maryConfig[1]=85;
            maryConfig[2]=92;
            maryConfig[3]=87;
            maryConfig[4]=89;
            maryConfig[5]=64;
            maryConfig[6]=74;
            maryConfig[7]=87;
            maryConfig[8]=87;
            maryConfig[9]=80;
            maryConfig[10]=69;
            maryConfig[11]=79;
            maryConfig[12]=92;
            maryConfig[13]=91;
            maryConfig[14]=92;
            maryConfig[15]=48;
            maryConfig[16]=96;
            maryConfig[17] = 96;

            maryConfig2[0] = 59;
            maryConfig2[1] = 85;
            maryConfig2[2] = 92;
            maryConfig2[3] = 87;
            maryConfig2[4] = 89;
            maryConfig2[5] = 64;
            maryConfig2[6] = 74;
            maryConfig2[7] = 87;
            maryConfig2[8] = 87;
            maryConfig2[9] = 80;
            maryConfig2[10] = 69;
            maryConfig2[11] = 79;
            maryConfig2[12] = 92;
            maryConfig2[13] = 91;
            maryConfig2[14] = 92;
            maryConfig2[15] = 48;
            maryConfig2[16] = 96;
            maryConfig2[17] = 88;
            maryConfig2[18] = 89;

        }
        public static string AppPath
        {
            set
            {
                if (appErrorLog == null)
                {
                    appErrorLog = new TextLog();
                    appErrorLog.AppPath = value;// Application.StartupPath;
                }
                if (runLog == null)
                {
                    runLog = new TextLog();
                    runLog.AppPath = value;//
                    runLog.LogFileName = "RunLog.txt";
                    runLog.IsUseHour = true;
                }
                if (runLogIOCard == null)
                {
                    runLogIOCard = new TextLog();
                    runLogIOCard.AppPath = value;// Application.StartupPath;
                    runLogIOCard.LogFileName = "PLCRunLog.txt";
                }

            }
        }
        public static void WriteAppErrorLog(String logMessage)
        {
           appErrorLog.Write(logMessage);//+ Environment.NewLine
        }

        public static void WriteAppErrorLog(Exception err)
        {
            appErrorLog.Write(err);
        }
        public static void WriteRunLog(String logMessage)
        {
            runLog.Write( logMessage);
        }

       
        internal static bool CheckPasswordIsPass()
        {
            bool isPass = false;
            return isPass;
        }
        internal static DataTable CloneTable(DataTable dt0)
        {
            
            DataTable dt1 = dt0.Clone();

            int columnsCount = dt0.Columns.Count;
            foreach (DataRow dr in dt0.Rows)
            {
                DataRow dr2 = dt1.NewRow();
                for (int i = 0; i < columnsCount; i++)
                {
                    dr2[i] = dr[i];
                }
                dt1.Rows.Add(dr2);
            }
            return dt1;
        }
    }
}
