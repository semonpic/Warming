using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WiseTech;
using WiseTech.Log;
namespace ATS.Models
{
    //使用者群組資訊
    public class UserGroup
    {
        private static Image defaultGroup = Image.FromFile(AppData.exePath + "images/DefaultGroup/DefaultGroup_128.png");
        private static Image operatorGroup = Image.FromFile(AppData.exePath + "images/Operator/Operator_128.png");
        private static Image engineerGroup = Image.FromFile(AppData.exePath + "images/Engineer/Engineer_128.png");
        private static Image aministratorGroup = Image.FromFile(AppData.exePath + "images/Administrator/Administrator_128.png");
        private static Image developerGroup = Image.FromFile(AppData.exePath + "images/Developer/Developer_128.png");



        public static Dictionary<int, Image> Icons = new Dictionary<int, Image>() {
			//{1 ,Image.FromFile(AppData.exePath + "images/DefaultGroup/DefaultGroup_128.png")},
			//{2 ,Image.FromFile(AppData.exePath + "images/Operator/Operator_128.png")},
			//{3 ,Image.FromFile(AppData.exePath + "images/Engineer/Engineer_128.png")},
			//{4 ,Image.FromFile(AppData.exePath + "images/Administrator/Administrator_128.png")},
			//{5 ,Image.FromFile(AppData.exePath + "images/Developer/Developer_128.png")},
			{1 ,defaultGroup},
            {2 ,operatorGroup},
            {3 ,engineerGroup},
            {4 ,aministratorGroup},
            {5 ,developerGroup},
        };
        public static int Operator = 2;
        public static int Developer = 5;

        public int ID { get { return id; } set { id = value; } }
        public string Name { get; set; }
        public List<string> TabsAvailable = new List<string> { "Main" };
        private int id = 1;
    }
    //使用者資訊
    public class User
    {
        public string Name = "DefaultUser";
        public string Password = "";
        public UserGroup Group = new UserGroup();
        public string GroupName { get { return Group.Name; } set { Group.Name = value; } }
        public List<string> TabsAvailable { get { return Group.TabsAvailable; } }
        public int Power { get { return Group.TabsAvailable.Count; } }
        public bool CanDelete { get { return (Group.ID != UserGroup.Developer); } }
        public int Level { get { return Group.ID; } }
    }


    public class ErrorInformation
    {
        public string Location = "";
        public string Point = "";
        public string Info = "";


    }

    //使用者資料
    public class UserData
    {
        private static User DefaultUser = new User() { Name = "DefaultUser", };
        private static User FailedUser = new User() { Name = "Failed", };
        private static UserGroup FailedGroup = new UserGroup() { ID = 1, Name = "Failed", };

        //使用者事件
        public event EventHandler OnRefreshed;
        public event EventHandler OnLoginFailed;
        public event EventHandler OnLogin;

        public delegate void EventUserLogin(string LV, string Name);
        public event EventUserLogin LoginEvent;

        //目前登入的使用者
        private User now = new User();
        public User Now { get { return now; } }
        public bool IsLogin { get { return isLogin; } private set { isLogin = value; } }
        private bool isLogin = false;
        private List<UserGroup> groups = new List<UserGroup>();
        private List<User> users = new List<User>();
        public List<ErrorInformation> ErrorInfo = new List<ErrorInformation>();


        public List<User> Users { get { return users; } }
        public List<UserGroup> Groups { get { return groups; } }

        public List<string> UserNames { get { return users.Select(u => u.Name).ToList(); } }
        public List<string> UserGroups { get { return groups.Select(u => u.Name).ToList(); } }

        //SQLite物件
        private SQLiteConnection connection; //SQLite 連線
        private SQLiteCommand command; //SQLite 命令
        private string dataSource
        {
            get { return AppData.exePath + "AppData.db"; }
        }//  資料庫完整名稱
        private string tableName = "Users";//  資料表名稱
        private string ResinTableName = "ResinInfo";

        //單例模式
        private static UserData instance = new UserData();
        public static UserData Instance
        {
            get
            {
                return instance;
            }
        }
        private UserData()
        {

        }

        public int Login(string userName = "", string userPassword = "")
        {
            try
            {
                now = users.Single(u => u.Name == userName && u.Password == userPassword);
                IsLogin = true;
                if (LoginEvent != null)
                {
                    LoginEvent(now.Level.ToString(), now.Name);
                }
                Logger.Log(ATSData.RunLog, now.Name + " 登入");
                OnLogin.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                now = DefaultUser;
                IsLogin = false;
                OnLoginFailed.Invoke(this, new EventArgs());
            }

            return now.Power;
        }
        public void Logout()
        {
            if (now.Name != "DefaultUser")
            {
                Logger.Log(ATSData.RunLog, now.Name + " 登出");
            }
            now = DefaultUser;
            IsLogin = false;
            OnLogin.Invoke(this, new EventArgs());
        }

        public void Refresh()
        {
            users.Clear();

            using (connection = new SQLiteConnection())
            {
                string SqlCommand = "SELECT * FROM `Users`,`UserGroups` WHERE `Users`.`GroupID` = `UserGroups`.`GroupID` ORDER BY `GroupID`;";

                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        //讀取成功
                        UserGroup _group = new UserGroup
                        {
                            ID = int.Parse(reader["GroupID"].ToString()),
                            Name = reader["GroupName"].ToString(),
                            TabsAvailable = reader["TabsAvailable"].ToString().Split(',').ToList(),
                        };
                        User _user = new User
                        {
                            Name = reader["Name"].ToString(),
                            Password = reader["Password"].ToString(),
                            Group = _group,
                        };

                        users.Add(_user);
                    }

                    OnRefreshed.Invoke(this, new EventArgs());
                }
            }
        }

        public void RefreshGroups()
        {
            groups.Clear();
            using (connection = new SQLiteConnection())
            {
                string SqlCommand = "SELECT * FROM `UserGroups`;";

                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        groups.Add(
                            new UserGroup
                            {
                                ID = int.Parse(reader["GroupID"].ToString()),
                                Name = reader["GroupName"].ToString(),
                                TabsAvailable = reader["TabsAvailable"].ToString().Split(',').ToList(),
                            });
                    }
                    if (OnRefreshed != null)
                    {
                        OnRefreshed.Invoke(this, new EventArgs());
                    }
                }
            }
        }



        public User UserInfo(string userName)
        {
            try
            {
               
                return users.Single<User>(u => u.Name == userName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return FailedUser;
            }
        }
        public UserGroup GroupInfo(string groupName)
        {
            try
            {
                return groups.Single<UserGroup>(g => g.Name == groupName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return FailedGroup;
            }
        }


        public void NewUser(string name, string password, string groupId)
        {
            ExecuteNonQuery("INSERT OR IGNORE INTO `" + tableName + "` VALUES (null , '" + name + "','" + password + "','" + groupId + "');");

            Refresh();
        }
        public bool DeleteUser(string name)
        {
            var deleteUser = false;
            var user = UserInfo(name);
            if (user.CanDelete)
            {
                ExecuteNonQuery("DELETE FROM `" + tableName + "` WHERE `Name` = '" + name + "';");

                Refresh();
                deleteUser = true;
            }
            return deleteUser;
        }
        public void UpdateUser(string name, string groupId)
        {
            ExecuteNonQuery("UPDATE `" + tableName + "` SET `GroupID` = '" + groupId + "' WHERE `Name` = '" + name + "';");

            Refresh();
        }

        public void UpdateGroup(string groupName, string tabsAvaliable)
        {
            ExecuteNonQuery("UPDATE `UserGroups` SET `TabsAvailable` = '" + tabsAvaliable + "' WHERE `GroupName` = '" + groupName + "';");

            RefreshGroups();
            Refresh();
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
                instance.connection.Close();
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


        private static SQLiteDataReader ResinExecuteReader(string sqlString)
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


        public int IrisLogin(string userName = "", string userPassword = "")
        {
            try
            {
                now = users.Single(u => u.Name == userName);
                IsLogin = true;
                if (LoginEvent != null)
                {
                    LoginEvent(now.Level.ToString(), now.Name);
                }
                Logger.Log(ATSData.RunLog, now.Name + " 登入");
                OnLogin.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                now = DefaultUser;
                IsLogin = false;
                OnLoginFailed.Invoke(this, new EventArgs());
            }

            return now.Power;
        }


        public void ErrorReset()
        {
            using (connection = new SQLiteConnection())
            {
                string SqlCommand = "SELECT * FROM `ErrorInfo`;";

                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        ErrorInformation _group = new ErrorInformation
                        {
                            Location = reader["Address"].ToString(),
                            Point = reader["Point"].ToString(),
                            Info = reader["Information"].ToString(),
                        };
                        ErrorInfo.Add(_group);
                    }

                }

            }
        }

        int[] PointInfo = new int[] { 8000, 4000, 2000, 1000, 800, 400, 200, 100, 80, 40, 20, 10, 8, 4, 2, 1 };
        public string GetErrorInformation(string Address, int Point)
        {
            try
            {

                //40ac
                string Index = Convert.ToString(Convert.ToInt32(Point), 16);
                //for (int i = 0; i < Index.Length; i++)
                //{
                //    string d= Convert.ToString(Index[i], 2);
                //}


                ErrorInformation Err = ErrorInfo.Single(u => u.Location == Address && u.Point == PointInfo[Point].ToString());
                return Err.Info;
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }




        public void InColdStart(string LotID, string ExpiredTime, string ColdLocation)
        {
            ExecuteNonQuery("INSERT INTO " + ResinTableName + " (SlotID,ExpiredTime,InColdTime,TaskSuccess,HandMode,InColdOperator) Values ('"
                + LotID + "','" + ExpiredTime + "','" + DateTime.Now.ToString() + "' , '0' , '0' ,'" + now.Name + "')");
        }

        public void InColdWriteLotBottleInfo(string LotID, string Info)
        {
            string SqlCommand = "Update ResinInfo Set  LotBottleInfo= '"
            + Info + "'  Where  SlotID  = '" + LotID + "' And TaskSuccess = '0';";
            ExecuteNonQuery(SqlCommand);

            Step1CreatCsv(LotID, Info);
        }

        public void InColdLocationUpdate(string LotID, string ColdLocation)
        {
            string SqlCommand = "Update ResinInfo Set  ColdLocation= '"
                   + ColdLocation + "'  Where  SlotID  = '" + LotID + "' And TaskSuccess = '0';";
            ExecuteNonQuery(SqlCommand);
            AppendCsvInfo(LotID,

                                "InColdTime,入冷藏時間," + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\n" +
                                "InColdOperator,入冷藏人員," + now.Name + "\n"
                                );

        }


        public void InWarmSuccess(string ColdLocation, string WarmLocation)
        {
            DateTime Dt = DateTime.Now;
            string SqlCommand = "Update ResinInfo Set WarmLocation = '"
               + WarmLocation + "' , InWarmTime  = '" + Dt.ToString() + "' , InWarmOperator = '" + now.Name + "'  Where  ColdLocation  = '" + ColdLocation + "' And TaskSuccess = '0';";
            ExecuteNonQuery(SqlCommand);
            AppendCsvInfo(SelectSlotID(WarmLocation),

                    "InWarmTime,入回溫時間," + Dt.ToString("yyyy/MM/dd HH:mm:ss") + "\n" +
                    "InWarmOperator,入回溫人員," + now.Name + "\n"+
                    "InWarmCompletedTime,回溫完成時間," + Dt.AddMinutes(Convert.ToDouble(SystemConfig.WarmTime)).ToString("yyyy/MM/dd HH:mm:ss") + "\n"
                    );
            
        }


        public void OutWarmSuccess(string Location, string FillWeight, string EmptyWeight)
        {
            using (connection = new SQLiteConnection())
            {
                string SqlCommand = "Update ResinInfo Set OutWarmOperator = '" + now.Name + "',TotalWeight = '"
                   + FillWeight + "' , EmptyWeight  = '" + EmptyWeight + "' , WarmedTime = '" + DateTime.Now.ToString() + "'  , TaskSuccess = '1'  Where  WarmLocation  = '"
                   + Location + "' And TaskSuccess = '0';";
                ExecuteNonQuery(SqlCommand);
            }
        }

        public string SelectSlotID(string Location)
        {
            string SlotID = "";
            string SqlCommand = "Select SlotID From ResinInfo Where WarmLocation = '" + Location + "' And TaskSuccess = '0';";
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        SlotID = reader["SlotID"].ToString();
                    }
                }
            }
            return SlotID;
        }

        public DateTime SelectIncoldTime(string LotID)
        {
            DateTime dt = new DateTime();
            string SqlCommand = "Select InColdTime From ResinInfo Where SlotID = '" + LotID + "' And TaskSuccess = '0';";
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        dt =Convert.ToDateTime(reader["InColdTime"].ToString());
                    }
                }
            }
            return dt;
        }

        public string SelectColdSlotID(string Location)
        {
            string SlotID = "";
            string SqlCommand = "Select SlotID From ResinInfo Where ColdLocation = '" + Location + "' And TaskSuccess = '0' Order By Rid;";
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        SlotID = reader["SlotID"].ToString();
                    }
                }
            }
            return SlotID;
        }

        public DateTime SelectClotInColdTime(string Location)
        {
            DateTime InColdTime = new DateTime();
            string SqlCommand = "Select InColdTime From ResinInfo Where ColdLocation = '" + Location + "' And TaskSuccess = '0';";
            Thread.Sleep(2000);
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        InColdTime =Convert.ToDateTime(reader["InColdTime"].ToString());
                    }
                }
            }
            return InColdTime;
        }


        public void OutWarmFillWeight(string Location, string FillWeight)
        {
            var Weight = FillWeight.Insert(FillWeight.Length - 2, ".");
            string SqlCommand = "Update ResinInfo Set OutWarmOperator = '" + now.Name + "',TotalWeight = '"
                       + Weight + "', WarmedTime = '" + DateTime.Now.ToString() + "'  Where  WarmLocation  = '"
                       + Location + "' And TaskSuccess = '0';";
            ExecuteNonQuery(SqlCommand);
        }


        public void OutWarmEmptyWeight(string Location, string EmptyWeight, string FillWeight)
        {
            double NetWeight = Convert.ToDouble(FillWeight) - (Convert.ToDouble(EmptyWeight) / 10);
            var Weight = EmptyWeight.Insert(EmptyWeight.Length - 3, ".");
            string SqlCommand = "Update ResinInfo Set OutWarmOperator = '" + now.Name +
                "', WarmedTime = '" + DateTime.Now.ToString() + "', EmptyWeight = '" + Weight + "'  , NetWeight = '" + NetWeight.ToString() + "' Where  WarmLocation  = '"
                          + Location + "' And TaskSuccess = '0';";
            ExecuteNonQuery(SqlCommand);
        }


        public void OutWarmSuccess(string Location)
        {
            string SqlCommand = "Update ResinInfo Set  TaskSuccess = '1'  Where  WarmLocation  = '"
                          + Location + "' And TaskSuccess = '0';";
            ExecuteNonQuery(SqlCommand);
        }

        public void HandRemoveColdResin(int Location)
        {
            using (connection = new SQLiteConnection())
            {
                string SqlCommand = "Update ResinInfo Set  TaskSuccess = '1'  And HandMode = '1'  Where  ColdLocation  = '"
                   + Location.ToString() + "' And TaskSuccess = '0';";
                ExecuteNonQuery(SqlCommand);
            }
        }

        public void HandRemoveWarmResin(int Location)
        {
            using (connection = new SQLiteConnection())
            {
                string SqlCommand = "Update ResinInfo Set  TaskSuccess = '1'  And HandMode = '1'  Where  WarmLocation  = '"
                   + Location.ToString() + "' And TaskSuccess = '0';";
                ExecuteNonQuery(SqlCommand);
            }
        }



        public void CreatCSVFile(int Location,int WarmType)
        {
            string SqlCommand = "Select * From ResinInfo Where WarmLocation = '" + Location + "' And TaskSuccess = '0';";
            ResinInfo resininfo = new ResinInfo() ;
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        ResinInfo ResinInfoCopy = new ResinInfo
                            {
                                LotID = reader["SlotID"].ToString(),
                                LotBottleInfo = reader["LotBottleInfo"].ToString(),
                                ExpiredTime = reader["ExpiredTime"].ToString(),
                                InColdTime = reader["InColdTime"].ToString(),
                                InColdOperator = reader["InColdOperator"].ToString(),
                                InWarmTime = reader["InWarmTime"].ToString(),
                                InWarmOperator = reader["InWarmOperator"].ToString(),
                                TotalWarmTime =Convert.ToInt32((Convert.ToDateTime(reader["WarmedTime"].ToString()) - Convert.ToDateTime(reader["InWarmTime"].ToString())).TotalMinutes).ToString(),
                                TotalWeight = reader["TotalWeight"].ToString(),
                                EmptyWeight = reader["EmptyWeight"].ToString(),
                                OutWarmedTime = Convert.ToDateTime(reader["WarmedTime"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"),
                                OutWarmOperator = reader["OutWarmOperator"].ToString()
                            };
                        resininfo = ResinInfoCopy;
                    }
                    
                }
            }

            CreatCsv1(resininfo,WarmType);

            
        }

        public  List<IOInfo> IOList = new List<IOInfo>();
        public void IOTableIni()
        {
            string SqlCommand = "SELECT * FROM IO;";
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        //讀取成功
                        IOInfo IO = new IOInfo
                        {
                            Address = reader["Address"].ToString(),
                            Point = reader["Point"].ToString(),
                            Location = reader["Location"].ToString(),
                            Info = reader["Info"].ToString()
                        };

                        IOList.Add(IO);
                    }
                }
            }
        }


        public void CreatCsv1(ResinInfo Resin,int WarmType)
        {
            DateTime InWarmTime = Convert.ToDateTime(Resin.InWarmTime).AddMinutes(Convert.ToDouble(SystemConfig.WarmTime));
            string ResinWeight = (Convert.ToDouble(Resin.TotalWeight) - Convert.ToDouble(Resin.EmptyWeight)).ToString();
            string Message = WarmType == 0 ? "回溫中" :
                (WarmType == 1 ? "回溫正常" :
                (WarmType == 2 ? "逾時階段(一)" : "逾時階段(二)"));

            AppendCsvInfo(Resin.LotID,
                "TotalWarmTime,總回溫時間(m)," + Resin.TotalWarmTime + "(m)\n" +
                "WarmType,回溫狀況,"+Message + "\n"+
                "TotalWeight,膠材總重(g),"+ Resin.TotalWeight + "(g)\n"+
                "EmptyWeight,空膠材重量(g)," + Resin.EmptyWeight + "(g)\n" +

                "ResinWeight,膠材淨重(g)," + ResinWeight + "(g)\n" + 

                "OutWarmedTime,倒料時間," + Resin.OutWarmedTime + "\n" +
                "OutWarmOperator,倒料人員," + Resin.OutWarmOperator + "\n"
                );
        }
        public void CreatCsv(ResinInfo Resin)
        {
            string DirectoryName = "SendInfo\\" + DateTime.Now.ToString("yyyyMMdd");
            string DataName = AppData.exePath + DirectoryName + "\\" + Resin.LotID + ".csv";

            if (!Directory.Exists(AppData.exePath + DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);

            }

            string[] ResinBottleInfo = Resin.LotBottleInfo.Split(';');
            DateTime InWarmTime = Convert.ToDateTime(Resin.InWarmTime).AddMinutes(Convert.ToDouble(SystemConfig.WarmTime));
            string ResinWeight = (Convert.ToDouble(Resin.TotalWeight) - Convert.ToDouble(Resin.EmptyWeight)).ToString();
            FileStream Fs = new FileStream(DataName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(Fs, Encoding.Default);

            sw.Write(
                "膠材資訊\n" +
                "LotNO:,批號," + Resin.LotID + "\n" +
                "P/N:,," + ResinBottleInfo[0] + "\n" +
                "Qty(kg):,," + ResinBottleInfo[3] + "\n" +
                "EXP Date:,過期時間," + Resin.ExpiredTime + "\n" +
                "DOM:,," + ResinBottleInfo[5] + "\n" +
                "\n" +
                "設備資訊\n" +
                "InColdTime,入冷藏時間," + Resin.InColdTime + "\n" +
                "InColdOperator,入冷藏人員," + Resin.InColdOperator + "\n" +
                "InWarmTime,入回溫時間," + Resin.InWarmTime + "\n" +
                "InWarmOperator,入回溫人員," + Resin.InWarmOperator + "\n" +

                "InWarmCompletedTime,回溫完成時間," + InWarmTime.ToString("yyyyMMdd hh:mm:ss") + "\n" +

                "TotalWarmTime,總回溫時間(m)," + Resin.TotalWarmTime + "(m)\n" +
                "TotalWeight,膠材總重(g)," + Resin.TotalWeight + "(g)\n" +
                "EmptyWeight,空膠材重量(g)," + Resin.EmptyWeight + "(g)\n" +

                "ResinWeight,膠材淨重(g)," + ResinWeight + "(g)\n" +

                "OutWarmedTime,倒料時間," + Resin.OutWarmedTime + "\n" +
                "OutWarmOperator,倒料人員," + Resin.OutWarmOperator + "\n"
                );
            sw.Close();
        }


        public void Step1CreatCsv(string ResinLot,string ResinBottleInfo)
        { 
                  
        
            string DirectoryName = "SendInfo\\";
            string[] ResinBottleInfoSpilt = ResinBottleInfo.Split(';');
            string DataName = AppData.exePath + DirectoryName + "\\" + ResinLot+ ".csv";

            if (!Directory.Exists(AppData.exePath + DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);

            }
            using (FileStream Fs = new FileStream(DataName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(Fs, Encoding.Default))
                {

                    sw.Write(
                        "膠材資訊\n" +
                        "LotNO:,批號," + ResinBottleInfoSpilt[2] + "\n" +
                        "P/N:,," + ResinBottleInfoSpilt[0] + "\n" +
                        "Qty(kg):,," + ResinBottleInfoSpilt[3] + "\n" +
                        "EXP Date:,過期時間," + ResinBottleInfoSpilt[4] + "\n" +
                        "DOM:,," + ResinBottleInfoSpilt[5] + "\n" +
                        "\n"+
                        "設備資訊\n"
                        );
                }
            }
        }


        public void AppendCsvInfo(string FileName, string Info)
        {
            string DirectoryName = "SendInfo\\";
            if (!Directory.Exists(AppData.exePath + DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);

            }
            if (!File.Exists(AppData.exePath + DirectoryName + "\\" + FileName + ".csv"))
            {

            }
            string DataName = AppData.exePath + DirectoryName + "\\" + FileName + ".csv";
            using (FileStream FS = new FileStream(DataName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(FS, Encoding.Default))
                {
                    sw.Write(Info);
                }
            }


        }

        public List<WeightInfo> GetWeightHistory()
        {

            
            string SqlCommand = "SELECT RID,SlotID,TotalWeight,EmptyWeight "+ 
                                "FROM ResinInfo "+
                                "Where EmptyWeight is not null " +
                                "Order by RID Desc;";
            List<WeightInfo> WIList = new List<WeightInfo>();
            using (connection = new SQLiteConnection())
            {
                //  建立SQLiteDataReader物件
                using (SQLiteDataReader reader = ExecuteReader(SqlCommand))
                {
                    while (reader.Read())
                    {
                        WeightInfo WI= new WeightInfo()
                        {
                            LotID = reader["SlotID"].ToString(),
                            TotalWeight = reader["TotalWeight"].ToString(),
                            EmptyWeight = reader["EmptyWeight"].ToString()
                        };

                        WIList.Add(WI);
                    }
                }
            }
            return WIList;
        }

        public DataTable  GetWeightHistoryDatatable()
        {
            DataTable dt = new DataTable();

            string SqlCommand = "SELECT RID,SlotID as 'LotID',TotalWeight as '總重 ',EmptyWeight as '空瓶重量'  , NetWeight as '淨重'" +
                                "FROM ResinInfo " +
                                "Where EmptyWeight is not null " +
                                "Order by RID Desc;";
            List<WeightInfo> WIList = new List<WeightInfo>();
            using (connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data source=" + instance.dataSource;
                connection.Open();
                //  建立SQLiteDataReader物件
                using (SQLiteDataAdapter da =new SQLiteDataAdapter(SqlCommand,connection))
                {
                    da.Fill(dt);
                }
                connection.Close();
            }
            return dt;
        }



        public class WeightInfo
        {
            public string LotID;
            public string TotalWeight;
            public string EmptyWeight;
        }
        public class IOInfo
        {
            public string Address;
            public string Point;
            public string Location;
            public string Info;
            //internal IO IO;
        }

        public class ResinInfo
        {
            public string LotID;
            public string LotBottleInfo;
            public string ExpiredTime;
            public string InColdTime;
            public string InColdOperator;
            public string InWarmTime;
            public string InWarmOperator;
            public string TotalWarmTime;
            public string TotalWeight;
            public string EmptyWeight;
            public string OutWarmedTime;
            public string OutWarmOperator;

        }
    }
}
    
