using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using WiseTech;
using ATS.Models;
using System.Threading;

namespace ATS.UI.CST.Controls.Store
{
    public partial class Store : UserControl
    {
        private static Object dbLock = new Object();
        static SQLiteConnection connection;
        public static Action<object, EventArgs> InWarmEvent = null;
        public static Action<object, EventArgs> OutWarmEvent = null;
        List<ColdResinInfo> ColdResins = new List<ColdResinInfo>(8);
        List<WarmResinInfo> WarmResins = new List<WarmResinInfo>(8);

        public Store()
        {
            InitializeComponent();
            PLCconnect.WriteInClod.Update += new Action<string, string, string>(IncoldUpdate);
            PLCconnect.ReadSystemStatus.ColdStoreChange += new Action<int, string>(ColdStoreChange);
            PLCconnect.ReadSystemStatus.WarmStoreChange += new Action<int, string>(WarmStoreChange);
            PLCconnect.ReadSystemStatus.WarmTimeEvent += new Action<int, string, int>(WarmTimeEvent);
            PLCconnect.ReadSystemStatus.ColdInformationChange += new Action<int, string>(ColdInformationChange);
            PLCconnect.WriteOutCold.UpdateEvent += WarmTaskSuccessUpdate;
            MainTabsPanel.OnStatusChange += MainTabsPanel_OnStatusChange;
            connection = new SQLiteConnection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void IncoldUpdate(string Location, string SlotID, string Overtime)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                ColdResins[int.Parse(Location)].SlotID = SlotID;
                ColdResins[int.Parse(Location)].InColdTime = DateTime.Now.ToString("yyyy-MM-dd");
                ColdResins[int.Parse(Location)].ExpiredTime = Overtime;
                ColdResins[int.Parse(Location)].InColdOperator = UserData.Instance.Now.Name;
               
            });
        }

        private void ColdStoreChange(int Store, string Imformation)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                switch ((Store + 1))
                {
                    case 1: // 機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                         
                                ColdResins[0].SlotID = "";
                                ColdResins[0].InColdTime = "";
                                ColdResins[0].ExpiredTime = "";
                                ColdResins[0].InColdOperator = "";
                                ColdResins[0].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[0].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[0].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 2: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                
                                ColdResins[1].SlotID = "";
                                ColdResins[1].InColdTime = "";
                                ColdResins[1].ExpiredTime = "";
                                ColdResins[1].InColdOperator = "";
                                ColdResins[1].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[1].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[1].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 3: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                ColdResins[2].SlotID = "";
                                ColdResins[2].InColdTime = "";
                                ColdResins[2].ExpiredTime = "";
                                ColdResins[2].InColdOperator = "";
                                ColdResins[2].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[2].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[2].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 4: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                ColdResins[3].SlotID = "";
                                ColdResins[3].InColdTime = "";
                                ColdResins[3].ExpiredTime = "";
                                ColdResins[3].InColdOperator = "";
                                ColdResins[3].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[3].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[3].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 5: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                ColdResins[4].SlotID = "";
                                ColdResins[4].InColdTime = "";
                                ColdResins[4].ExpiredTime = "";
                                ColdResins[4].InColdOperator = "";
                                ColdResins[4].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[4].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[4].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 6: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                ColdResins[5].SlotID = "";
                                ColdResins[5].InColdTime = "";
                                ColdResins[5].ExpiredTime = "";
                                ColdResins[5].InColdOperator = "";
                                ColdResins[5].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[5].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[5].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 7: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                ColdResins[6].SlotID = "";
                                ColdResins[6].InColdTime = "";
                                ColdResins[6].ExpiredTime = "";
                                ColdResins[6].InColdOperator = "";
                                ColdResins[6].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[6].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[6].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                    case 8: //機台別
                        #region 更換資訊
                        switch (Imformation)
                        {
                            case "0":
                                ColdResins[7].SlotID = "";
                                ColdResins[7].InColdTime = "";
                                ColdResins[7].ExpiredTime = "";
                                ColdResins[7].InColdOperator = "";
                                ColdResins[7].ColdType = 0;
                                break;
                            case "1":
                                ColdResins[7].ColdType = 1;
                                break;
                            case "2":
                                ColdResins[7].ColdType = 2;
                                break;
                        }
                        #endregion
                        break;
                }
            });
        }
        private void WarmStoreChange(int Store, string Imformation)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {

                switch ((Store + 1))
                {
                   
                }
            });
        }

        private void WarmTaskSuccessUpdate(string ColdLocation, string WarmLocation)
        {

            ThreadSafeHelper.UIThread(this, () =>
            {
                StoreMessage Message = Read(Convert.ToInt32(WarmLocation), "", 2);
                switch (Convert.ToInt32(WarmLocation))
                {
                }
            });
        }

        private void WarmTimeEvent(int Store, string Time, int Expired) //0->Warming , 1->Success, 2->Expired 1st, 3->Expired 2rd
        {


            ThreadSafeHelper.UIThread(this, () =>
            {
                #region 無資料
                if (Expired == -1)
                {
                    switch ((Store + 1))
                    {
                       
                    }
                }
                #endregion
                else
                {
                    StoreMessage Message = Read(Store + 1, "", 2);
                    switch ((Store + 1))
                    {
                       
                    }
                }
            });
        }

        private void ColdInformationChange(int Location, string SlotID)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                if (SlotID == "")
                {
                    switch (Location)
                    {
                        //case 1:
                        //    TbSlot1.Text = "";
                        //    TbInstoreTime1.Text = "";
                        //    TBExpiredTime1.Text = "";
                        //    break;

                        //case 2:
                        //    TbSlot2.Text = "";
                        //    TbInstoreTime2.Text = "";
                        //    TBExpiredTime2.Text = "";
                        //    break;

                        //case 3:
                        //    TbSlot3.Text = "";
                        //    TbInstoreTime3.Text = "";
                        //    TBExpiredTime3.Text = "";
                        //    break;

                        //case 4:
                        //    TbSlot4.Text = "";
                        //    TbInstoreTime4.Text = "";
                        //    TBExpiredTime4.Text = "";
                        //    break;

                        //case 5:
                        //    TbSlot5.Text = "";
                        //    TbInstoreTime5.Text = "";
                        //    TBExpiredTime5.Text = "";
                        //    break;
                        //case 6:
                        //    TbSlot6.Text = "";
                        //    TbInstoreTime6.Text = "";
                        //    TBExpiredTime6.Text = "";
                        //    break;

                        //case 7:
                        //    TbSlot7.Text = "";
                        //    TbInstoreTime7.Text = "";
                        //    TBExpiredTime7.Text = "";
                        //    break;

                        //case 8:
                        //    TbSlot8.Text = "";
                        //    TbInstoreTime8.Text = "";
                        //    TBExpiredTime8.Text = "";
                        //    break;
                    }
                    return;
                }
                else
                {
                    StoreMessage NewStoreMessage = Read(Location, SlotID, 1);
                    if (NewStoreMessage == null)
                    {
                        return;
                    }
                    switch (Location)
                    {
                        //case 1:
                        //    TbSlot1.Text = SlotID;
                        //    TbInstoreTime1.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime1.Text = NewStoreMessage.ExpiredTime;
                        //    break;

                        //case 2:
                        //    TbSlot2.Text = SlotID;
                        //    TbInstoreTime2.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime2.Text = NewStoreMessage.ExpiredTime;
                        //    break;

                        //case 3:
                        //    TbSlot3.Text = SlotID;
                        //    TbInstoreTime3.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime3.Text = NewStoreMessage.ExpiredTime;
                        //    break;

                        //case 4:
                        //    TbSlot4.Text = SlotID;
                        //    TbInstoreTime4.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime4.Text = NewStoreMessage.ExpiredTime;
                        //    break;

                        //case 5:
                        //    TbSlot5.Text = SlotID;
                        //    TbInstoreTime5.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime5.Text = NewStoreMessage.ExpiredTime;
                        //    break;
                        //case 6:
                        //    TbSlot6.Text = SlotID;
                        //    TbInstoreTime6.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime6.Text = NewStoreMessage.ExpiredTime;
                        //    break;

                        //case 7:
                        //    TbSlot7.Text = SlotID;
                        //    TbInstoreTime7.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime7.Text = NewStoreMessage.ExpiredTime;
                        //    break;

                        //case 8:
                        //    TbSlot8.Text = SlotID;
                        //    TbInstoreTime8.Text = Convert.ToDateTime(NewStoreMessage.InColdTime).ToString("yyyy-MM-dd");
                        //    TBExpiredTime8.Text = NewStoreMessage.ExpiredTime;
                        //    break;
                    }
                }
            });

        }


        private static void Write()
        {
            connection.ConnectionString = "Data source = " + Application.StartupPath + "/" + "AppData.db";
            string SqlCommand = "Insert Into Store (location,SlotID,InstoreTime,ExpiredTime) Values";

            using (var command = new SQLiteCommand(SqlCommand, connection))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
        }


        private static StoreMessage Read(int Location, string SlotID, int TaskSelect) // 1-> Cold   2->Warm   3->Finally
        {
            lock (dbLock)
            {
                if (TaskSelect == 1)
                {
                    List<StoreMessage> result = new List<StoreMessage>();

                    //using (var connection = new SQLiteConnection())
                    //{
                    connection.ConnectionString = "Data source = " + Application.StartupPath + "\\" + "AppData.db";
                    string SqlCommand =
                        "SELECT ExpiredTime, InColdTime" +
                        " FROM ResinInfo" +
                        "  Where ColdLocation = '" + Location.ToString() + "' And SlotID Like '" + SlotID + "%'  And TaskSuccess = '0';";

                    using (var command = new SQLiteCommand(SqlCommand, connection))
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        //  建立SQLiteDataReader物件
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                result.Add(
                                    new StoreMessage
                                    {
                                        Location = Location.ToString(),
                                        SlotID = SlotID,
                                        InColdTime = reader["InColdTime"].ToString(),
                                        //ExpiredTime = reader["ExpiredTime"].ToString(),
                                        ExpiredTime = reader["ExpiredTime"].ToString().Substring(0, 4) + "-" + reader["ExpiredTime"].ToString().Substring(4, 2)
                                        + "-" + reader["ExpiredTime"].ToString().Substring(6, 2)

                                    }
                                );
                            }
                        }
                    }
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    if (result.Count() == 0)
                    {
                        return null;
                    }
                    return result[0];
                }
                else if (TaskSelect == 2)
                {
                    List<StoreMessage> result = new List<StoreMessage>();

                    connection.ConnectionString = "Data source = " + Application.StartupPath + "\\" + "AppData.db";
                    string SqlCommand =
                        "SELECT SlotID, InWarmTime" +
                        " FROM ResinInfo" +
                        "  Where WarmLocation = '" + Location.ToString() + "' And TaskSuccess = '0';";

                    using (var command = new SQLiteCommand(SqlCommand, connection))
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        //  建立SQLiteDataReader物件
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                result.Add(
                                    new StoreMessage
                                    {

                                        SlotID = reader["SlotID"].ToString(),
                                        InWarmTime = reader["InWarmTime"].ToString(),
                                        Location = Location.ToString()

                                    }
                                );
                            }
                        }
                    }
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    if (result.Count() == 0)
                    {
                        return null;
                    }
                    return result[0];
                }

                return null;
            }
        }

        private void TbWarmSlot7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ColdBottleClear_Click(object sender, EventArgs e)
        {
            if (UserData.Instance.Now.Level < 3)
            { return; }
            if ((MessageBox.Show("確認要刪除這個庫位的資訊嗎?", "提醒資訊", MessageBoxButtons.OKCancel)) == DialogResult.OK)
            {
                PictureBox Pb = (PictureBox)sender;
                int Location = Convert.ToInt32(Pb.Name.Substring(10, Pb.Name.Length - 10));
                Models.UserData.Instance.HandRemoveColdResin(Location);
                PLCconnect.PLCCommon.PLC_WRITE((1789 + Location).ToString(), "1", "1");
                WiseTech.Log.Logger.DeleteResinInfo(Location.ToString(), 1);
                switch (Location)
                {
                    //case 1:
                    //    TbSlot1.Text = "";
                    //    TbInstoreTime1.Text = "";
                    //    TBExpiredTime1.Text = "";
                    //    break;
                    //case 2:
                    //    TbSlot2.Text = "";
                    //    TbInstoreTime2.Text = "";
                    //    TBExpiredTime2.Text = "";
                    //    break;
                    //case 3:
                    //    TbSlot3.Text = "";
                    //    TbInstoreTime3.Text = "";
                    //    TBExpiredTime3.Text = "";
                    //    break;
                    //case 4:
                    //    TbSlot4.Text = "";
                    //    TbInstoreTime4.Text = "";
                    //    TBExpiredTime4.Text = "";
                    //    break;
                    //case 5:
                    //    TbSlot5.Text = "";
                    //    TbInstoreTime5.Text = "";
                    //    TBExpiredTime5.Text = "";
                    //    break;
                    //case 6:
                    //    TbSlot6.Text = "";
                    //    TbInstoreTime6.Text = "";
                    //    TBExpiredTime6.Text = "";
                    //    break;
                    //case 7:
                    //    TbSlot7.Text = "";
                    //    TbInstoreTime7.Text = "";
                    //    TBExpiredTime7.Text = "";
                    //    break;
                    //case 8:
                    //    TbSlot8.Text = "";
                    //    TbInstoreTime8.Text = "";
                    //    TBExpiredTime8.Text = "";
                    //    break;


                }

            }

        }

        private void WarmBottleClear_Click(object sender, EventArgs e)
        {
            if (UserData.Instance.Now.Level < 3)
            { return; }
            if ((MessageBox.Show("確認要刪除這個庫位的資訊嗎?", "提醒資訊", MessageBoxButtons.OKCancel)) == DialogResult.OK)
            {
                PictureBox Pb = (PictureBox)sender;
                int Location = Convert.ToInt32(Pb.Name.Substring(10, Pb.Name.Length - 10));
                Models.UserData.Instance.HandRemoveWarmResin(Location);
                PLCconnect.PLCCommon.PLC_WRITE((1799 + Location).ToString(), "1", "1");
                WiseTech.Log.Logger.DeleteResinInfo(Location.ToString(), 2);


                switch (Location)
                {
                    //case 1:
                    //    TBWarmExpiredTime1.Text = "";
                    //    TbWarmInstoreTime1.Text = "";
                    //    TbWarmSlot1.Text = "";
                    //    TbWarmTime1.Text = "";
                    //    break;
                    //case 2:
                    //    TBWarmExpiredTime2.Text = "";
                    //    TbWarmInstoreTime2.Text = "";
                    //    TbWarmSlot2.Text = "";
                    //    TbWarmTime2.Text = "";
                    //    break;
                    //case 3:
                    //    TBWarmExpiredTime3.Text = "";
                    //    TbWarmInstoreTime3.Text = "";
                    //    TbWarmSlot3.Text = "";
                    //    TbWarmTime3.Text = "";
                    //    break;
                    //case 4:
                    //    TBWarmExpiredTime4.Text = "";
                    //    TbWarmInstoreTime4.Text = "";
                    //    TbWarmSlot4.Text = "";
                    //    TbWarmTime4.Text = "";
                    //    break;
                    //case 5:
                    //    TBWarmExpiredTime5.Text = "";
                    //    TbWarmInstoreTime5.Text = "";
                    //    TbWarmSlot5.Text = "";
                    //    TbWarmTime5.Text = "";
                    //    break;
                    //case 6:
                    //    TBWarmExpiredTime6.Text = "";
                    //    TbWarmInstoreTime6.Text = "";
                    //    TbWarmSlot6.Text = "";
                    //    TbWarmTime6.Text = "";
                    //    break;
                    //case 7:
                    //    TBWarmExpiredTime7.Text = "";
                    //    TbWarmInstoreTime7.Text = "";
                    //    TbWarmSlot7.Text = "";
                    //    TbWarmTime7.Text = "";
                    //    break;
                    //case 8:
                    //    TBWarmExpiredTime8.Text = "";
                    //    TbWarmInstoreTime8.Text = "";
                    //    TbWarmSlot8.Text = "";
                    //    TbWarmTime8.Text = "";
                    //    break;


                }

            }
        }

        private void BtnInwarm1_Click(object sender, EventArgs e)
        {

            switch (ATSData.SystemMode)
            {
                case ATSData.SystemModeType.Handmode:
                    //Maintain模式不能按Start
                    MessageBox.Show("請先切換為Auto模式後才能啟動", "請先切換為Auto模式後才能啟動", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                    ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    SpinWait.SpinUntil(() => { return false; }, 2000);
                    //System.Threading.Thread.Sleep(2000);
                    break;
                case ATSData.SystemModeType.Automatic:
                    if (InWarmEvent != null)
                    {
                        InWarmEvent(sender, e);
                    }
                    break;
            }

        }

        private void BtnOutwarm_Click(object sender, EventArgs e)
        {
            switch (ATSData.SystemMode)
            {
                case ATSData.SystemModeType.Handmode:
                    //Maintain模式不能按Start
                    MessageBox.Show("請先切換為Auto模式後才能啟動", "請先切換為Auto模式後才能啟動", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                    ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    SpinWait.SpinUntil(() => { return false; }, 2000);
                    //System.Threading.Thread.Sleep(2000);
                    break;
                case ATSData.SystemModeType.Automatic:
                    if (OutWarmEvent != null)
                    {
                        OutWarmEvent(sender, e);
                    }
                    break;
            }
        }


        private void MainTabsPanel_OnStatusChange()
        {
            switch (ATSData.SystemMode)
            {
                //case ATSData.SystemModeType.Automatic:
                //    BtnInwarm1.BackColor = Color.SpringGreen;
                //    BtnOutwarm.BackColor = Color.SpringGreen;
                //    break;
                //case ATSData.SystemModeType.Handmode:
                //    BtnInwarm1.BackColor = Color.White;
                //    BtnOutwarm.BackColor = Color.White;
                //    break;
            }
        }
    }


    public class StoreMessage
    {
        public string Location = "";
        public string SlotID = "";
        public string InColdTime = "";
        public string ExpiredTime = "";
        public string InWarmTime = "";
    }

    public class StoreWarmInformation
    {
        public string SlotID = "";
        public string WarmLocation = "";
    }

    public class ColdResinInfo
    {
        public string SlotID;
        public string InColdTime;
        public string ExpiredTime;
        public string InColdOperator;
        public int ColdType;
    }

    public class WarmResinInfo
    {
        public string SlotID;
        public string InColdTime;
        public string ExpiredTime;
        public string InColdOperator;
        public string InWarmTime;
        public string InWarmOperator;
        public int WarmType;
    }
}

