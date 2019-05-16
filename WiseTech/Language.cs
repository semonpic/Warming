using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiseTech
{
	public class Language
	{
		class words
		{
			public string En = "";
			public string Zh_tw = "";
		}
		public static event EventHandler OnRefreshed;

		public const string Zh_tw = "Zh"; // 中文語系
		public const string En = "En"; // 英文語系
		public static string UseLanguage = Zh_tw; //預設中文 Zh 中文，En 英文

		private static Dictionary<string, words> languageTable = new Dictionary<string, words>();

		private static Dictionary<string, Control> controls = new Dictionary<string, Control>();

		//  SQLite物件
		private static SQLiteConnection connection; //SQLite 連線
		private static SQLiteCommand command; //SQLite 命令
		private static string initString = @"CREATE TABLE IF NOT EXISTS Language(
											AI INTEGER PRIMARY KEY AUTOINCREMENT,
											[Key] TEXT (100) UNIQUE NOT NULL,
											En TEXT(200) NOT NULL,
											Zh TEXT(200) NOT NULL
										);";
		private static string dataSource
		{
			get { return AppData.exePath + "AppLanguage.db"; }
		}//  資料庫完整名稱
		private static string tableName = "Language";//  資料表名稱
		private static bool dbExists = false;
		private static Object dbLock = new Object();

		public static void Setup(bool clear = false)
		{
			if (clear)
			{
				ExecuteNonQuery("DROP TABLE IF EXISTS " + tableName);
			}
			//  檢查log Db是否存在
			if (!File.Exists(dataSource))
			{
				//  不存在就建立一個
				SQLiteConnection.CreateFile(dataSource);
			}

			//確認資料庫存在
			using (var connection = new SQLiteConnection())
			{
				//  SQLiteConnection實體化
				connection.ConnectionString = "Data source = " + dataSource;

				//  建立SQLite連線
				connection.Open();

				//  SQLiteCommand實體化
				command = connection.CreateCommand();

				//  建立Table
				command.CommandText = initString;

				//  Trigger指令
				command.ExecuteNonQuery();

			}
			dbExists = true;
		}

		public static void Refresh()
		{
			lock (dbLock)
			{
				using (connection = new SQLiteConnection())
				{
					//  建立SQLiteDataReader物件
					using (SQLiteDataReader reader = ExecuteReader("SELECT * FROM `" + tableName + "`;"))
					{
						//					languageTable.Clear();
						while (reader.Read())
						{
							var key = reader["Key"].ToString();
							if (languageTable.ContainsKey(key))
							{

							}
							else
							{
								languageTable.Add(
										reader["Key"].ToString(),
										new words
										{
											En = reader[En].ToString(),
											Zh_tw = reader[Zh_tw].ToString(),
										}
									);
							}
						}
						UpdateControlsLanguage();
						OnRefreshed.Invoke(languageTable, new EventArgs());
					}
				}
			}
		}

		private static void UpdateControlsLanguage()
		{
			foreach (var item in controls)
			{
				item.Value.Text = Text(item.Key);
			}
		}
		public static void SetText(string key, string en = "", string zh_tw = "")
		{
			if (languageTable.ContainsKey(key))
			{
				return;
			}
			try
			{
				languageTable.Add(key, new words { En = en, Zh_tw = zh_tw });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		public static void Save()
		{
			lock (dbLock)
			{
				if (!dbExists)
				{
					Setup();
				}
				var queryString = "";
				foreach (var item in languageTable)
				{
					queryString += "INSERT OR IGNORE INTO `" + tableName + "` VALUES (null ,'" + item.Key + "' ,'" + item.Value.En + "','" + item.Value.Zh_tw + "');";
				}
				ExecuteNonQuery(queryString);
			}
		}

		private static void ExecuteNonQuery(string sqlString)
		{
			using (var connection = new SQLiteConnection())
			{
				//  SQLiteConnection實體化
				connection.ConnectionString = "Data source =" + dataSource;

				//  建立SQLite連線
				connection.Open();

				//  SQLiteCommand實體化
				var sqlCommand = connection.CreateCommand();

				//  將變數更新
				sqlCommand.CommandText = sqlString;

				sqlCommand.ExecuteNonQuery();
			}
		}
		public static string Text(string key)
		{
			return Text(key, UseLanguage);
		}
		public static string Text(string key, string langurage)
		{
			string text = "";

			if (languageTable.ContainsKey(key))
			{
				switch (langurage)
				{
					case En:
						text = languageTable[key].En;
						break;
					case Zh_tw:
						text = languageTable[key].Zh_tw;
						break;
				}
			}

			return text;
		}

		public static void Bind(string key, Control control)
		{
			if (!controls.ContainsKey(key))
			{
				controls[key] = control;
			}
		}


		private static SQLiteDataReader ExecuteReader(string sqlString)
		{
			//  SQLiteConnection實體化
			connection.ConnectionString = "Data source=" + dataSource;
			//  建立SQLite連線
			connection.Open();
			//  SQLiteCommand實體化
			command = connection.CreateCommand();
			//  將變數插入指令
			command.CommandText = sqlString;
			return command.ExecuteReader();
		}
	}
}
