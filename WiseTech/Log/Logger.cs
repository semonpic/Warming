using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiseTech.Log
{
	public class Logger
	{
		private class LogMessageParammeter
		{
			public string Level = "";
			public string Message = "";
		}
		public static event EventHandler<LoggerLogEventArgs> OnLog;
		public static event EventHandler<LoggerLogEventArgs> OnInfo;
		public static event EventHandler<LoggerLogEventArgs> OnError;
		public static event EventHandler<LoggerLogEventArgs> OnWarning;
		private static int addCounter = 0;
		private static int cleanOldLog = 100;

		private static string DirectoryName = "Log";
		private static string logDb = "Log.db";
		public static string initString = @"CREATE TABLE IF NOT EXISTS Log (
											_AI      INTEGER  PRIMARY KEY AUTOINCREMENT,
											DateTime DATETIME,
											Level    TEXT,
											Message  TEXT
										);";

		//SQLite物件

		private static string dataSource
		{
			get { return AppData.exePath + DirectoryName + "/" + logDb; }
		}
		//  資料庫完整名稱
		private static string tableName = "Log";
		//  資料表名稱

		private static List<LogMessage> Logs = new List<LogMessage>();
		private static List<LogMessage> Infos = new List<LogMessage>();
		private static List<LogMessage> Warnings = new List<LogMessage>();
		private static List<LogMessage> Errors = new List<LogMessage>();
		private static bool consoleDisplay = false;
		private static bool dbExists = false;
		private static Object dbLock = new Object();

		private static SQLiteConnection connection = new SQLiteConnection();
		private static bool mutiWrite = false;

		private static Task core;
		private static Queue<LogMessageParammeter> buffer = new Queue<LogMessageParammeter>();
		private static bool end = false;
		private static bool endFinish = false;

		public static void Setup(bool console = false)
		{
			consoleDisplay = console;
			//檢查資料夾是否存在
			if (!Directory.Exists(AppData.exePath + DirectoryName))
			{
				Directory.CreateDirectory(DirectoryName);
			}

			//  檢查log Db是否存在
			if (!File.Exists(dataSource))
			{
				//  不存在就建立一個
				SQLiteConnection.CreateFile(dataSource);
			}

            //  SQLiteConnection實體化

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.ConnectionString = "Data source = " + dataSource;


                //  建立SQLite連線
                connection.Open();
            }

			//確認資料庫存在 可以初始化資料表
			using (var command = new SQLiteCommand(initString, connection))
			{
				//  Trigger指令
				command.ExecuteNonQuery();
			}

			//using (var connection = new SQLiteConnection())
			//{
			//	//  SQLiteConnection實體化
			//	connection.ConnectionString = "Data source = " + dataSource;

			//	//  建立SQLite連線
			//	connection.Open();

			//	//  SQLiteCommand實體化
			//	command = connection.CreateCommand();

			//	//  建立Table
			//	command.CommandText = initString;

			//	//  Trigger指令
			//	command.ExecuteNonQuery();

			//}
			dbExists = true;

			core = new Task(() => LoggerProcess(), TaskCreationOptions.LongRunning);
			core.Start();//邏輯執行緒執行
		}

		private static void LoggerProcess()
		{
			while (true)
			{
				try
				{
					if (buffer.Count > 0)
					{
						lock (dbLock)
						{

							BeginWrite();

							while (buffer.Count > 0)
							{
								var message = buffer.Dequeue();
								if (message != null)
								{
									Write(message.Level, message.Message);
								}
								if (end)
								{
									break;
								}
							}

							CommitWrite();


							if (addCounter > cleanOldLog)
							{
								DeleteOldLog(6);
								addCounter = 0;
							}
						}
					}
					if (end)
					{
						break;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("DB Error" + ex.ToString());
					break;
					throw;
				}
				//0.1秒存1次Logger資料庫
				SpinWait.SpinUntil(() => { return false; }, 100);
				//Thread.Sleep(100);
			}

			connection.Close();
			//connection.Dispose();
			Console.WriteLine("End Logger");
			endFinish = true;
		}

		public static void Dispose()
		{
			end = true;
			while (!endFinish)
			{
				SpinWait.SpinUntil(() => { return false; }, 100);
				//Thread.Sleep(100);
			}
		}
		//public static void LogStart() { BeginWrite(); }
		//public static void LogEnd() { CommitWrite(); }

		public static void Log(string level, string text)
		{
			lock (dbLock)
			{
				buffer.Enqueue(new LogMessageParammeter { Level = level, Message = text });
			}
			//Write(level, text);
			var eventArgs = new LoggerLogEventArgs { Level = level, Message = text };
            if(OnLog != null)
            {
              OnLog.Invoke(eventArgs, eventArgs);  
            }
			

		}

        public static void AlarmLog(string text)
        {
            Write("AlarmLog", text);
            var eventArgs = new LoggerLogEventArgs { Level = "Info", Message = text };
            if (OnInfo != null)
            {
                OnInfo.Invoke(eventArgs, eventArgs);
            }

        }
        public static void  SystemLog(string text)
        {
            Write("SystemLog", text);
            var eventArgs = new LoggerLogEventArgs { Level = "Info", Message = text };
            if (OnInfo != null)
            {
                OnInfo.Invoke(eventArgs, eventArgs);
            }
        }

		public static void Info(string text)
		{
			Write("Info", text);
			var eventArgs = new LoggerLogEventArgs { Level = "Info", Message = text };
            if (OnInfo != null)
            {
                OnInfo.Invoke(eventArgs, eventArgs);
            }
		}
		public static void Warning(string text)
		{
			Write("Warning", text);
			var eventArgs = new LoggerLogEventArgs { Level = "Warning", Message = text };
            if (OnWarning != null)
            {
                OnWarning.Invoke(eventArgs, eventArgs);
            }
		}
		public static void Error(string text)
		{
			Write("Error", text);
			var eventArgs = new LoggerLogEventArgs { Level = "Error", Message = text };
            if (OnError != null)
            {
                OnError.Invoke(eventArgs, eventArgs);
            }
		}

		public static List<LogMessage> Select(string level, int offset, int limit)
		{
			return Read(level, offset, limit);
		}

        public static List<LogResinMessage> SelectResin(string level, int offset, int limit)
        {
            return ReadResin(level, offset, limit);
        }

        public static List<LogMessage> Log(int offset, int limit)
		{
			Logs.Clear();
			Logs.AddRange(Read("", offset, limit));
			return Logs;
		}
		public static List<LogMessage> Info(int offset, int limit)
		{
			Infos.Clear();
			Infos.AddRange(Read("Info", offset, limit));
			return Infos;
		}
		public static List<LogMessage> Warning(int offset, int limit)
		{
			Warnings.Clear();
			Warnings.AddRange(Read("Warning", offset, limit));
			return Warnings;
		}
		public static List<LogMessage> Error(int offset, int limit)
		{
			Errors.Clear();
			Errors.AddRange(Read("Error", offset, limit));
			return Errors;
		}

		private static List<LogMessage> Read(string level, int offset, int limit)
		{
            Setup();
			lock (dbLock)
			{
				List<LogMessage> result = new List<LogMessage>();
				//using (var connection = new SQLiteConnection())
				//{

				string SqlCommand = "SELECT * FROM `Log` WHERE `Level` = '" + level + "' ORDER BY _AI DESC LIMIT " + offset + ", " + limit + " ;";
				if (level.Length == 0)
				{
					SqlCommand = "SELECT * FROM `Log` ORDER BY _AI DESC LIMIT " + offset + ", " + limit + " ;";
				}

				using (var command = new SQLiteCommand(SqlCommand, connection))
				{
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
					//  建立SQLiteDataReader物件
					using (SQLiteDataReader reader = command.ExecuteReader())
					{

						while (reader.Read())
						{
							result.Add(
								new LogMessage
								{
									LogDateTime = reader["DateTime"].ToString(),
									LogData = reader["Message"].ToString(),
								}
							);
						}
					}
				}
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return result;
			}
		}
		private static void BeginWrite()
		{
			//lock (dbLock)
			//{
			if (!mutiWrite)
			{
				mutiWrite = true;
				var SqlCommand = "BEGIN;";
				using (var command = new SQLiteCommand(SqlCommand, connection))
				{
					command.ExecuteNonQuery();
				}
			}
			//}
		}
		private static void CommitWrite()
		{
			//lock (dbLock)
			//{
			if (mutiWrite)
			{
				mutiWrite = false;
				var SqlCommand = "COMMIT;";
				using (var command = new SQLiteCommand(SqlCommand, connection))
				{
					command.ExecuteNonQuery();
				}

			}
			//}
		}
		private static void Write(string level, string text)
		{
            if (text != "序列未包含符合的項目")
            {
                Setup();
                //lock (dbLock)
                //{

                if (consoleDisplay)
                {
                    Console.WriteLine(level + " : " + text);
                }
                addCounter++;
                level = level.Replace("'", "");
                text = text.Replace("'", "");
                var SqlCommand = "INSERT OR IGNORE INTO `" + tableName + "` VALUES (null ,datetime('now', 'localtime') ,'" + level + "','" + text + "')";
                //Console.WriteLine(SqlCommand);
                using (var command = new SQLiteCommand(SqlCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
                //if (addCounter == cleanOldLog)
                //{
                //	DeleteOldLog(6);
                //	addCounter = 0;
                //}
                //}
            }
		}

		private static void DeleteOldLog(int months)
		{
			var SqlCommand = "DELETE FROM `Log` WHERE DateTime < date('now', '-" + months + " months')";
			using (var command = new SQLiteCommand(SqlCommand, connection))
			{
				command.ExecuteNonQuery();
			}
		}

        public static string TodayTaskNumber(string LotID)
        {
            lock (dbLock)
            {
                string SqlCommand = "SELECT count(RID) as Number FROM `ResinInfo` Where SlotID Like '"+LotID +"%' ;";
                SQLiteConnection ResinConnect = new SQLiteConnection();
                ResinConnect.ConnectionString = "Data source =" + Application.StartupPath + "\\"  + "AppData.db";
                string Number = "0";
                using (var command = new SQLiteCommand(SqlCommand, ResinConnect))
                {
                    if (ResinConnect.State == System.Data.ConnectionState.Closed)
                    {
                        ResinConnect.Open();
                    }
                    //  建立SQLiteDataReader物件
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Number = reader["Number"].ToString();
                        }
                    }
                }
                return Number;
            }
        }


        public static void DeleteResinInfo(string Location, int ColdOrWarm)
        {
            if (ColdOrWarm == 1)
            {
                string commond = "Update ResinInfo Set  HandMode= '1' , TaskSuccess = '1'  Where  ColdLocation  = '" + Location + "' And TaskSuccess = '0';";
                SQLiteConnection ResinConnect = new SQLiteConnection();
                ResinConnect.ConnectionString = "Data source =" + Application.StartupPath + "\\" + "AppData.db";
                using (var command = new SQLiteCommand(commond, ResinConnect))
                {
                    if (ResinConnect.State == System.Data.ConnectionState.Closed)
                    {
                        ResinConnect.Open();
                    }
                    command.ExecuteReader();
                }
            }
            else if (ColdOrWarm == 2)
            {
                string commond = "Update ResinInfo Set  HandMode= '1' , TaskSuccess = '1'  Where  WarmLocation  = '" + Location + "' And TaskSuccess = '0';";
                SQLiteConnection ResinConnect = new SQLiteConnection();
                ResinConnect.ConnectionString = "Data source =" + Application.StartupPath + "\\" + "AppData.db";
                using (var command = new SQLiteCommand(commond, ResinConnect))
                {
                    if (ResinConnect.State == System.Data.ConnectionState.Closed)
                    {
                        ResinConnect.Open();
                    }
                    command.ExecuteReader();
                }
            }
        }


        private static List<LogResinMessage> ReadResin(string level, int offset, int limit)
        {
            Setup();
            lock (dbLock)
            {
                List<LogResinMessage> result = new List<LogResinMessage>();
       

                string SqlCommand = "SELECT * FROM `ResinInfo`  ORDER BY RID DESC LIMIT " + offset + ", " + limit + " ;";
                if (level.Length == 0)
                {
                    SqlCommand = "SELECT * FROM `ResinInfo` ORDER BY RID DESC LIMIT " + offset + ", " + limit + " ;";
                }
                
                SQLiteConnection ResinConnect = new SQLiteConnection();
                ResinConnect.ConnectionString = "Data source =" + Application.StartupPath + "\\"  + "AppData.db"; 
                using (var command = new SQLiteCommand(SqlCommand, ResinConnect))
                {
                    if (ResinConnect.State == System.Data.ConnectionState.Closed)
                    {
                        ResinConnect.Open();
                    }
                    //  建立SQLiteDataReader物件
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            
                            result.Add(
                                new LogResinMessage
                                {
                                    SlotID = reader["SlotID"].ToString(),
                                    ExpiredTime = reader["ExpiredTime"].ToString(),
                                    ColdLocation = reader["ColdLocation"].ToString(),
                                    IncoldTime =reader["InColdTime"].ToString(),
                                    InColdOperator = reader["InColdOperator"].ToString(),
                                    WarmLocation = reader["WarmLocation"].ToString(),
                                    InWarmTime = reader["InWarmTime"].ToString(),
                                    InWarmOperator = reader["InWarmOperator"].ToString(),
                                    TotalWeight = reader["TotalWeight"].ToString(),
                                    EmptyWeight = reader["EmptyWeight"].ToString(),
                                    WarmedTime=reader["WarmedTime"].ToString(),
                                    OutWarmOperator = reader["OutWarmOperator"].ToString()

                                }
                            );
                        }
                    }
                }
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return result;
            }
        }
    }


}
