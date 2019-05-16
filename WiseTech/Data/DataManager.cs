using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiseTech.Data
{
	public class DataManager
	{
		public static event EventHandler OnRefreshed;
		private Dictionary<string, string> datas = new Dictionary<string, string>();
		private Queue<string> saveCommands = new Queue<string>();
		//  SQLite物件
		private SQLiteConnection connection; //SQLite 連線
		private SQLiteCommand command; //SQLite 命令
		private string initString = @"CREATE TABLE IF NOT EXISTS `DataManager` (Key TEXT PRIMARY KEY, Value TEXT);";
		//  檔案路徑
		private string dataBasePath = "";
		//  資料庫名稱
		private string dataBaseName = "AppData.db";
		//  資料表名稱
		private string tableName = "DataManager";

		private string dataSource
		{
			get { return AppData.exePath + "AppData.db"; }
		}//  資料庫完整名稱
		public static DataManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DataManager();
				}
				return instance;
			}
		}
		private static DataManager instance;
		private DataManager(string dataBasePath = "./")
		{
		}
		public DataManager Setup(string dataBasePath = "./")
		{
			this.dataBasePath = dataBasePath;

			if (AppData.IsRuntime)
			{
				InitializeTable();
			}
			Refresh();
			return this;
		}
		public void Refresh()
		{
			using (connection = new SQLiteConnection())
			{
				string SqlCommand = "SELECT * FROM `DataManager`;";

				//  建立SQLiteDataReader物件
				using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
				{
					while (reader.Read())
					{
						var key = reader["Key"].ToString();
						var value = reader["Value"].ToString();
						if (datas.ContainsKey(key))
						{
							datas[key] = value;
						}
						else
						{
							datas.Add(key, value);
						}
					}
                    if(OnRefreshed != null)
                    {
                        OnRefreshed.Invoke(this, new EventArgs());
                    }
					
				}
			}
		}

		public DataManager InitializeTable()
		{
			string _dbPath = dataBasePath + dataBaseName;
			//  檢查db是否存在
			if (!File.Exists(_dbPath))
			{
				//  不存在就建立一個
				SQLiteConnection.CreateFile(_dbPath);
			}

			//確認有資料表
			//  嘗試執行
			using (connection = new SQLiteConnection())
			{
				//  SQLiteConnection實體化
				connection.ConnectionString = "Data source = " + _dbPath;

				//  建立SQLite連線
				connection.Open();

				//  SQLiteCommand實體化
				command = connection.CreateCommand();

				//  建立Table
				command.CommandText = initString;

				//  Trigger指令
				command.ExecuteNonQuery();

			}
			return this;
		}
		public DataManager Save(string key, string value)
		{
			if (!datas.ContainsKey(key))
			{
				saveCommands.Enqueue("INSERT OR IGNORE INTO `" + tableName + "` VALUES ('" + key + "','" + value + "');");
			}
			saveCommands.Enqueue("UPDATE `" + tableName + "` SET `Value` = '" + value + "' WHERE `Key` = '" + key + "';");

			return this;
		}
		public void SaveApply()
		{
			var query = "";
			while (saveCommands.Count > 0)
			{
				query += saveCommands.Dequeue();
			}
			ExecuteNonQuery(query);

			Refresh();
		}
		public string Load(string key, string defaultValue = "")
		{
			if (datas.ContainsKey(key))
			{
				return datas[key];
			}
			else
			{
				return defaultValue;
			}
		}

		private static void ExecuteNonQuery(string sqlString)
		{
			using (instance.connection = new SQLiteConnection())
			{
				//  SQLiteConnection實體化
				instance.connection.ConnectionString = "Data source =" + instance.dataSource;

				//  建立SQLite連線
				instance.connection.Open();

				//  SQLiteCommand實體化
				var sqlCommand = instance.connection.CreateCommand();

				//  將變數更新
				sqlCommand.CommandText = sqlString;

				sqlCommand.ExecuteNonQuery();
			}
		}
		private static SQLiteDataReader ExecuteReader(string sqlString)
		{

			//  SQLiteConnection實體化
			instance.connection.ConnectionString = "Data source=" + instance.dataSource;
			//  建立SQLite連線
			instance.connection.Open();
			//  SQLiteCommand實體化
			instance.command = instance.connection.CreateCommand();
			//  將變數插入指令
			instance.command.CommandText = sqlString;
			return instance.command.ExecuteReader();
		}
	}
}
