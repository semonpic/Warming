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
			connection.ConnectionString = "Data source = " + dataSource;

			//  建立SQLite連線
			connection.Open();

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
		}

		public static void Dispose()
		{
			connection.Close();
			connection.Dispose();
		}
		public static void LogStart() { BeginWrite(); }
		public static void LogEnd() { CommitWrite(); }

		public static void Log(string level, string text)
		{
			Write(level, text);
			var eventArgs = new LoggerLogEventArgs { Level = level, Message = text };
			OnLog?.Invoke(eventArgs, eventArgs);
		}
		public static void Info(string text)
		{
			Write("Info", text);
			var eventArgs = new LoggerLogEventArgs { Level = "Info", Message = text };
			OnInfo?.Invoke(eventArgs, eventArgs);
		}
		public static void Warning(string text)
		{
			Write("Warning", text);
			var eventArgs = new LoggerLogEventArgs { Level = "Warning", Message = text };
			OnWarning?.Invoke(eventArgs, eventArgs);
		}
		public static void Error(string text)
		{
			Write("Error", text);
			var eventArgs = new LoggerLogEventArgs { Level = "Error", Message = text };
			OnError?.Invoke(eventArgs, eventArgs);
		}

		public static List<LogMessage> Select(string level, int offset, int limit)
		{
			return Read(level, offset, limit);
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
			lock (dbLock)
			{
				if (!dbExists)
				{
					Setup(consoleDisplay);
				}
				List<LogMessage> result = new List<LogMessage>();

				string SqlCommand = "SELECT * FROM `Log` WHERE `Level` = '" + level + "' ORDER BY _AI DESC LIMIT " + offset + ", " + limit + " ;";
				if (level.Length == 0)
				{
					SqlCommand = "SELECT * FROM `Log` ORDER BY _AI DESC LIMIT " + offset + ", " + limit + " ;";
				}

				using (var command = new SQLiteCommand(SqlCommand, connection))
				{
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

				return result;
			}
		}
		private static void BeginWrite()
		{
			lock (dbLock)
			{
				if (!mutiWrite)
				{
					mutiWrite = true;
					var SqlCommand = "BEGIN;";
					using (var command = new SQLiteCommand(SqlCommand, connection))
					{
						command.ExecuteNonQuery();
					}
				}
			}
		}
		private static void CommitWrite()
		{
			lock (dbLock)
			{
				if (mutiWrite)
				{
					mutiWrite = false;
					var SqlCommand = "COMMIT;";
					using (var command = new SQLiteCommand(SqlCommand, connection))
					{
						command.ExecuteNonQuery();
					}

				}
			}
		}
		private static void Write(string level, string text)
		{
			lock (dbLock)
			{
				if (!dbExists)
				{
					Setup(consoleDisplay);
				}
				if (consoleDisplay)
				{
					Console.WriteLine(level + " : " + text);
				}
				addCounter++;
				var SqlCommand = "INSERT OR IGNORE INTO `" + tableName + "` VALUES (null ,datetime('now', 'localtime') ,'" + level + "','" + text + "')";
				using (var command = new SQLiteCommand(SqlCommand, connection))
				{
					command.ExecuteNonQuery();
				}
				if (addCounter == cleanOldLog)
				{
					DeleteOldLog(6);
					addCounter = 0;
				}
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

		//private static void ExecuteNonQuery(string sqlString)
		//{
		//	using (var connection = new SQLiteConnection())
		//	{
		//		//  SQLiteConnection實體化
		//		connection.ConnectionString = "Data source =" + dataSource;

		//		//  建立SQLite連線
		//		connection.Open();

		//		//  SQLiteCommand實體化
		//		var sqlCommand = connection.CreateCommand();

		//		//  將變數更新
		//		sqlCommand.CommandText = sqlString;

		//		sqlCommand.ExecuteNonQuery();
		//	}
		//}

		//private static SQLiteDataReader ExecuteReader(SQLiteConnection connection, string sqlString)
		//{

		//	//  SQLiteConnection實體化
		//	connection.ConnectionString = "Data source=" + dataSource;
		//	//  建立SQLite連線
		//	connection.Open();
		//	//  SQLiteCommand實體化
		//	command = connection.CreateCommand();
		//	//  將變數插入指令
		//	command.CommandText = sqlString;
		//	return command.ExecuteReader();
		//}
	}
}
