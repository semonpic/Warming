using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;
using PLCconnect;
using System.Data.SQLite;

namespace ATS.UI.CST.Controls
{
    public partial class IOTable : UserControl
    {

        SQLiteConnection connection;
        SQLiteCommand command;
        List<IOInfo> IOList = new List<IOInfo>();
        Timer IOTimer = new Timer();
        public static int StartLocation = 1560;

        public IOTable()
        {
            InitializeComponent();
            Load += IOTable_Load;        
        }
        private void IOTable_Load(object sender, EventArgs e)
        {

            Models.UserData.Instance.IOTableIni();
            IniIOTable();
            IOTimer.Tick += IOTimer_Tick;
            IOTimer.Interval = 500;
            IOTimer.Enabled = true;

            ControlPanel.ChangeIoName += IOinfoChange;

        }

        public void StopTimer()
        {
            IOTimer.Tick -= IOTimer_Tick;
            IOTimer.Stop();
            
        }

 
        private void IOTimer_Tick(object sender, EventArgs e)
        {
            IOTimer.Enabled = false;

            if (StartLocation == 1560)
            {
                for (int i = 0; i < ReadSystemStatus.IOInputStatus.Length; i++)
                {
                    if (ReadSystemStatus.IOInputStatus[i] == null)
                    {
                        ReadSystemStatus.IOInputStatus[i] = "0000000000000000";
                    }
                    //ReadSystemStatus.IOInputStatus[i] = "1100110011001100";
                    string ReverseIOPoint = String.Join("", ReadSystemStatus.IOInputStatus[i].Select(s => s).Reverse());
                    for (int x = 0; x < ReverseIOPoint.Length; x++)
                    {
                        IOInfo info = IOList.Single(s => s.Address == (StartLocation + i).ToString() && s.Point == x.ToString());
                        IO io = info.IO;
                        if (io != null)
                        {
                            if (ReverseIOPoint[x] == '1')
                            {
                                io.OnOff = true;
                            }
                            else
                            {
                                io.OnOff = false;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < ReadSystemStatus.IOOutputStatus.Length; i++)
                {
                    if (ReadSystemStatus.IOOutputStatus[i] == null)
                    {
                        ReadSystemStatus.IOOutputStatus[i] = "0000000000000000";
                    }
                    //ReadSystemStatus.IOInputStatus[i] = "1100110011001100";
                    string ReverseIOPoint = String.Join("", ReadSystemStatus.IOOutputStatus[i].Select(s => s).Reverse());
                    for (int x = 0; x < ReverseIOPoint.Length; x++)
                    {
                        IOInfo info = IOList.Single(s => s.Address == (StartLocation + i).ToString() && s.Point == x.ToString());
                        IO io = info.IO;

                        if (io != null)
                        {
                            if (ReverseIOPoint[x] == '1')
                            {
                                io.OnOff = true;
                            }
                            else
                            {
                                io.OnOff = false;
                            }
                        }
                    }
                }
            }


            IOTimer.Enabled = true;
        }

        public void IniIOTable()
        {
            int point = 0;
            int address = 0;
            string infomation = "";
            IOList.Clear();
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
                            Info = reader["Info"].ToString(),
                            Info_en = reader["Info_Eng"].ToString()
                        };

                        IOList.Add(IO);
                    }
                }
            }
                foreach (Control Col in this.Controls)
                {
                    if (Col is IO)
                    {
                        IO io = Col as IO;


                        point = (Convert.ToInt32(Col.Name.Substring(2, Col.Name.Length - 2))) % 16;
                        address = StartLocation + (Convert.ToInt32(Col.Name.Substring(2, Col.Name.Length - 2))) / 16;
                        IOInfo info = IOList.Single(s => s.Address == address.ToString() && s.Point == point.ToString());
                        io.Actual = info;
                        infomation = info.Info;
                        if (infomation == null || infomation == "" )
                        {
                            infomation = "待用";
                        }
                        io.IOName = infomation;
                        info.IO = io;
                    }
                }
                
            
            
        }

       internal  void IOinfoChange()
        {
            try
            {
                foreach (Control col in this.Controls)
                {
                    if (col is IO)
                    {
                        IO io = col as IO;
                        if (Language.UseLanguage == Language.Zh_tw)
                        {
                            if (io.Actual.Info == "" || io.Actual.Info == null)
                            {
                                io.IOName = "待用";
                                continue;
                            }
                            io.IOName = io.Actual.Info;
                        }
                        else
                        {
                            if (io.Actual.Info_en == "" || io.Actual.Info_en == null)
                            {
                                io.IOName = "inactive";
                                continue;
                            }
                            io.IOName = io.Actual.Info_en;
                        }
                        //io.IOName = Language.UseLanguage == Language.Zh_tw ? io.Actual.Info : io.Actual.Info_en;
                        
                    }
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }

            private SQLiteDataReader ExecuteReader(string sqlString)
            {
                string str = "Data source =" + Application.StartupPath + "\\AppData.db";
                //  SQLiteConnection實體化
                connection.ConnectionString = "Data source =" + Application.StartupPath + "\\AppData.db";
                //  建立SQLite連線
                connection.Open();
                //  SQLiteCommand實體化
                command = connection.CreateCommand();
                //  將變數插入指令
                command.CommandText = sqlString;
                return command.ExecuteReader();
            }


        }

    public  class IOInfo
    {
        internal string Address;
        internal string Point;
        internal string Location;
        internal string Info;
        internal IO IO;
        internal string Info_en;
    }
}
