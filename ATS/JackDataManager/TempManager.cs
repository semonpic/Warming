using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace JackDataManager
{
    public class TempManager
    {
        static DateTime Dt = DateTime.Now;
        private static string DirectoryName = "Temp";
        private static string Temp = "Temp.db";
        private static Object dbLock = new Object();
        private static SQLiteConnection Connect = new SQLiteConnection();
        private static SQLiteConnection ExecuteConnect = new SQLiteConnection();
        static bool IsWorking = false;

        public static List<ColdTemp> ColdTempHistory = new List<ColdTemp>();
        public static List<WarmTemp> WarmTempHistory = new List<WarmTemp>();



        
        public class ColdTemp
        {
            public string ColdReader1 ;
            public string ColdReader2;
            public string ColdReader3;
            public string ColdReader4;
            public string ColdReader5;
            public string Time;
        }

        public  class WarmTemp
        {
            public string WarmReader1;
            public string WarmReader2;
            public string WarmReader3;
            public string WarmReader4;
            public string WarmReader5;
            public string Time;
        }

        static string exePath 
        {
            get {return  Application.StartupPath + "\\";}
        }
        static string IniSQLTable = @"CREATE TABLE IF NOT EXISTS 'CWT" + Dt.ToString("yyyyMMdd") + @"' (
											RID      INTEGER  PRIMARY KEY AUTOINCREMENT,
											DateTime DATETIME,
											ColdTemp0    TEXT,
                                            ColdTemp1    TEXT,
                                            ColdTemp2    TEXT,
                                            ColdTemp3    TEXT,
                                            ColdTemp4    TEXT,
											WarmTemp0    TEXT,
                                            WarmTemp1    TEXT,
                                            WarmTemp2    TEXT,
                                            WarmTemp3    TEXT,
                                            WarmTemp4    TEXT,
                                            Time         TEXT
										);";


        private static string dataSource
        {
            get { return exePath + DirectoryName + "/" + Temp; }
        }


        public static void Setup()
        {

            if (!IsWorking)
            {

                if (!Directory.Exists(exePath + DirectoryName))
                {
                    Directory.CreateDirectory(exePath + DirectoryName);
                }

                if (!File.Exists(dataSource))
                {
                    SQLiteConnection.CreateFile(dataSource);
                }

                if (Connect.State == System.Data.ConnectionState.Closed)
                {
                    Connect.ConnectionString = "Data source = " + dataSource;
                    Connect.Open();
                }
                Dt = DateTime.Now;
                IniSQLTable = @"CREATE TABLE IF NOT EXISTS 'CWT" + Dt.ToString("yyyyMMdd") + @"' (
											RID      INTEGER  PRIMARY KEY AUTOINCREMENT,
											DateTime DATETIME,
											ColdTemp0    TEXT,
                                            ColdTemp1    TEXT,
                                            ColdTemp2    TEXT,
                                            ColdTemp3    TEXT,
                                            ColdTemp4    TEXT,
											WarmTemp0    TEXT,
                                            WarmTemp1    TEXT,
                                            WarmTemp2    TEXT,
                                            WarmTemp3    TEXT,
                                            WarmTemp4    TEXT,
                                            Time         TEXT
										);";

                using (SQLiteCommand Commond = new SQLiteCommand(IniSQLTable, Connect))
                {
                    Commond.ExecuteNonQuery();
                    Connect.Close();
                }
            }
        }

        public static void SelectTemp(DateTime SelectTime)
        {

            IsWorking = true;
            ColdTempHistory.Clear();
            WarmTempHistory.Clear();
            var TempTime = "CWT" + SelectTime.ToString("yyyyMMdd");
            var SqlCommand = "Select * From " + TempTime;

            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data source=" + dataSource;
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SqlCommand, connection))
                {
                    using (SQLiteDataReader Reader = command.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            ColdTemp CT = new ColdTemp
                            {
                                ColdReader1 = Reader["ColdTemp0"].ToString(),
                                ColdReader2 = Reader["ColdTemp1"].ToString(),
                                ColdReader3 = Reader["ColdTemp2"].ToString(),
                                ColdReader4 = Reader["ColdTemp3"].ToString(),
                                ColdReader5 = Reader["ColdTemp4"].ToString(),
                                Time = Reader["Time"].ToString()
                            };

                            WarmTemp WT = new WarmTemp
                            {
                                WarmReader1 = Reader["WarmTemp0"].ToString(),
                                WarmReader2 = Reader["WarmTemp1"].ToString(),
                                WarmReader3 = Reader["WarmTemp2"].ToString(),
                                WarmReader4 = Reader["WarmTemp3"].ToString(),
                                WarmReader5 = Reader["WarmTemp4"].ToString(),
                                Time = Reader["Time"].ToString()
                            };

                            ColdTempHistory.Add(CT);
                            WarmTempHistory.Add(WT);
                        }
                    }
                    connection.Close();
                }
            }
            IsWorking = false;
        }

        public static void SaveTemp(string[] Cold, string[] WarmTemp)
        {
            string SqlCommond = "Insert Into CWT" + Dt.ToString("yyyyMMdd") +
                " (ColdTemp0,ColdTemp1,ColdTemp2,ColdTemp3,ColdTemp4,WarmTemp0,WarmTemp1,WarmTemp2,WarmTemp3,WarmTemp4,Time)"+
        " Values ('" + Cold[0] + "','" + Cold[1] + "','" + Cold[2] + "','" + Cold[3] + "','" + Cold[4] + "','" + WarmTemp[0] + "','" + WarmTemp[1] + "','" + WarmTemp[2] + "','" + WarmTemp[3] + "','" + WarmTemp[4] + "' , '" +DateTime.Now.ToString("HH:mm") +"')";

            if (!IsWorking)
            {
                ExecuteNonQuery(SqlCommond);
            }
        }

        
        private static void ExecuteNonQuery(string SqlString )
        {
            try
            {
                lock (dbLock)
                {
                    using (ExecuteConnect = new SQLiteConnection())
                    {
                        //  SQLiteConnection實體化
                        ExecuteConnect.ConnectionString = "Data source =" + dataSource;

                        //  建立SQLite連線
                        if (ExecuteConnect.State == System.Data.ConnectionState.Closed)
                        {
                            ExecuteConnect.Open();
                        }

                        //  SQLiteCommand實體化
                        var sqlCommand = ExecuteConnect.CreateCommand();

                        //  將變數更新
                        sqlCommand.CommandText = SqlString;

                        sqlCommand.ExecuteNonQuery();
                        ExecuteConnect.Close();
                    }
                }
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteAppErrorLog(err.Message);
            }
            
        }


        
    }
}
