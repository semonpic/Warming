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
using PLCconnect;


namespace ATS.UI.CST.Controls
{


    public partial class ResinStore : UserControl
    {
        private static Object dbLock = new Object();
        static SQLiteConnection connection;
        public static Action<object,EventArgs>InWarmEvent = null;
        public static Action<object, EventArgs> OutWarmEvent = null;
        List<ColdResinInfo> ColdResins = new List<ColdResinInfo>(8);
        List<WarmResinInfo> WarmResins = new List<WarmResinInfo>(8);
        Forms.ColdResinInfo ColdInfo = new Forms.ColdResinInfo();
        Forms.WarmResinInfo WarmInfo = new Forms.WarmResinInfo();
        AlarmInformation AlarmInfo = new AlarmInformation();
        

        public ResinStore()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                ColdResins.Add(new ColdResinInfo());
                WarmResins.Add(new WarmResinInfo());
            }
            WriteInClod.Update += new Action<string, string, string>(IncoldUpdate);
            ReadSystemStatus.ColdStoreChange += new Action<int, string>(ColdStoreChange);
            ReadSystemStatus.WarmStoreChange += new Action<int, string>(WarmStoreChange);
            ReadSystemStatus.WarmTimeEvent += new Action<int, string,int>(WarmTimeEvent);
            ReadSystemStatus.ColdInformationChange += new Action<int,string>(ColdInformationChange);
            WriteOutCold.UpdateEvent += WarmTaskSuccessUpdate;
            MainTabsPanel.OnStatusChange += MainTabsPanel_OnStatusChange;
            ReadSystemStatus.ColdTempEvent += new Action<int[]>(ColdTempEvent);
            ReadSystemStatus.WarmTempEvent += new Action<int[]>(WarmTempEvent);
            WriteOutCold.OutColdFirstSendInfo += OutColdFirstSendInfo;
            connection = new SQLiteConnection();

            Language.Bind("ResinStore.labelCold", labelCold);
            Language.Bind("ResinStore.labelWarm", labelWarm);
            Language.Bind("ResinStore.LBMemo", LBMemo);
            Language.Bind("ResinStore.groupBox3", groupBox3);
            Language.Bind("ResinStore.groupBox4", groupBox4);
            Language.Bind("ResinStore.label5", label5);
            Language.Bind("ResinStore.label7", label7);
            Language.Bind("ResinStore.label6", label6);
            Language.Bind("ResinStore.BtnInwarm1", BtnInwarm1);
            Language.Bind("ResinStore.label12", label12);
            Language.Bind("ResinStore.label10", label10);
            Language.Bind("ResinStore.label11", label11);
            Language.Bind("ResinStore.label8", label8);
            Language.Bind("ResinStore.label9", label9);
            Language.Bind("ResinStore.BtnOutwarm", BtnOutwarm);
            Language.Bind("ResinStore.labelColdTemp1", labelColdTemp1);
            Language.Bind("ResinStore.labelColdTemp2", labelColdTemp2);
            Language.Bind("ResinStore.labelColdTemp3", labelColdTemp3);
            Language.Bind("ResinStore.labelColdTemp4", labelColdTemp4);
            Language.Bind("ResinStore.labelColdTemp5", labelColdTemp5);

            Language.Bind("ResinStore.labelWarmTemp1", labelWarmTemp1);
            Language.Bind("ResinStore.labelWarmTemp2", labelWarmTemp2);
            Language.Bind("ResinStore.labelWarmTemp3", labelWarmTemp3);
            Language.Bind("ResinStore.labelWarmTemp4", labelWarmTemp4);
            Language.Bind("ResinStore.labelWarmTemp5", labelWarmTemp5);
            
            Language.SetText("SureDelete","Are You Sure To Delete The Info Of This Location?","確認要刪除這個庫位的資訊嗎?");
            
        }


       

        private void IncoldUpdate(string Location, string SlotID, string Overtime)
        {
            ThreadSafeHelper.UIThread(this, () =>
                   {
                       try
                       {
                           var location = int.Parse(Location);
                           var i = location - 1;
                           ColdResins[i].SlotID = SlotID;
                           ColdResins[i].InColdTime = DateTime.Now.ToString("yyyy-MM-dd");
                           ColdResins[i].ExpiredTime = Overtime;
                           ColdResins[i].InColdOperator = UserData.Instance.Now.Name;
                           panel2.Controls["ColdResin" + location].BackgroundImage.Dispose();
                           panel2.Controls["ColdResin" + location].BackgroundImage = Properties.Resources.BlueCircle1;
                           panel2.Controls["TbColdResin" + location].Text = SlotID;
                           panel2.Controls["LabelColdNum" + location].BackColor = Color.FromArgb(153, 217, 234);//Blue定義
                       }
                       catch (Exception err)
                       {
                           return;
                       }
                     
                      
                   });
        }

        private void ColdStoreChange(int Store, string Imformation)
        {
            ThreadSafeHelper.UIThread(this, () =>
                  {

                      switch (Imformation)
                      {
                          case "0":
                              ColdResins[Store].SlotID = "";
                              ColdResins[Store].InColdTime = "";
                              ColdResins[Store].ExpiredTime = "";
                              ColdResins[Store].InColdOperator = "";
                              ColdResins[Store].ColdType = 0;
                              panel2.Controls["ColdResin" + (Store + 1)].BackgroundImage.Dispose();
                              panel2.Controls["ColdResin" + (Store +1)].BackgroundImage = Properties.Resources.BlackCircle1;
                              panel2.Controls["TbColdResin" + (Store + 1)].Visible = false;
                              panel2.Controls["LabelColdNum" + (Store + 1)].BackColor = Color.FromArgb(100, 100, 100);//Black定義
                              break;
                          case "1":
                              ColdResins[Store].ColdType = 1;
                              panel2.Controls["ColdResin" + (Store + 1)].BackgroundImage.Dispose();
                              panel2.Controls["ColdResin" + (Store + 1)].BackgroundImage = Properties.Resources.BlueCircle1;
                              panel2.Controls["TbColdResin" + (Store + 1)].Visible = true;
                               panel2.Controls["LabelColdNum" + (Store + 1)].BackColor = Color.FromArgb(153, 217, 234);//Blue定義
                              break;
                          case "2":
                              ColdResins[Store].ColdType = 2;
                              panel2.Controls["ColdResin" + (Store + 1)].BackgroundImage.Dispose();
                              panel2.Controls["ColdResin" + (Store + 1)].BackgroundImage = Properties.Resources.RedCircle1;
                              panel2.Controls["LabelColdNum" + (Store + 1)].BackColor = Color.FromArgb(237,28,36);//Red定義
                              panel2.Controls["TbColdResin" + (Store + 1)].Visible = true;
                              break;
                      }

                     
                  });
        }
        private void WarmStoreChange(int Store, string Imformation)
        {
            ThreadSafeHelper.UIThread(this, () =>
                   {

                       switch (Imformation)
                       {
                           case "0":
                               WarmResins[Store].WarmType = 0;
                               panel3.Controls["TbWarmResin" + (Store + 1)].Visible = false;
                               break;
                           case "1":
                               WarmResins[Store].WarmType = 1;
                               panel3.Controls["TbWarmResin" + (Store + 1)].Visible = true;
                               break;
                           case "2":
                               WarmResins[Store].WarmType = 2;
                               panel3.Controls["TbWarmResin" + (Store + 1)].Visible = true;
                               break;
                           case "3":
                               WarmResins[Store].WarmType = 3;
                               panel3.Controls["TbWarmResin" + (Store + 1)].Visible = true;
                               break;
                           case "4":
                               WarmResins[Store].WarmType = 4;
                               panel3.Controls["TbWarmResin" + (Store + 1)].Visible = true;
                               break;
                       }


                 
                   });
        }

        private void WarmTaskSuccessUpdate(string ColdLocation, string WarmLocation)
        {
            try
            {
                ThreadSafeHelper.UIThread(this, () =>
                      {
                          StoreMessage Message = Read(Convert.ToInt32(WarmLocation), "", 2);
                          var Location = Convert.ToInt32(WarmLocation);

                          WarmResins[Location - 1].SlotID = Message.SlotID;
                          WarmResins[Location - 1].InWarmTime = Message.InWarmTime;
                          WarmResins[Location - 1].ExpiredTime = (Convert.ToDateTime(Message.InWarmTime).AddMinutes(Convert.ToInt32(ATS.SystemConfig.WarmTime))).ToString("MM/dd HH:mm");
                          panel3.Controls["WarmResin" + Location].BackgroundImage.Dispose();
                          panel3.Controls["WarmResin" + Location].BackgroundImage = Properties.Resources.YellowCircle1;
                          panel3.Controls["LabelWarmNum" + Location].BackColor = Color.FromArgb(239, 228, 176);
                     });
            }
            catch (Exception err)
            {
                LCSCommon.WriteRunLog(err.Message);
            }
        }

        private void WarmTimeEvent(int Store, string Time,int Expired) //0->Warming , 1->Success, 2->Expired 1st, 3->Expired 2rd
        {
            try
            {
                ThreadSafeHelper.UIThread(this, () =>
                      {
                          #region 無資料
                          if (Expired == -1)
                          {
                              WarmResins[Store].InWarmOperator = "";
                              WarmResins[Store].WarmType = 0;
                              WarmResins[Store].InWarmTime = "";
                              WarmResins[Store].ExpiredTime = "";
                              WarmResins[Store].SlotID = "";
                              WarmResins[Store].InColdOperator = "";
                              WarmResins[Store].InColdTime = "";
                              panel3.Controls["TbWarmResin" + (Store + 1)].Visible = false;
                              panel3.Controls["WarmResin" + (Store + 1)].BackgroundImage.Dispose();
                              panel3.Controls["WarmResin" + (Store + 1)].BackgroundImage = Properties.Resources.BlackCircle;
                              panel3.Controls["LabelWarmNum" + (Store + 1)].BackColor = Color.FromArgb(100, 100, 100);
                             
                          }
                          #endregion
                          else
                          {
                              var num = Store + 1;
                              StoreMessage Message = Read(Store + 1, "", 2);
                              WarmResins[Store].InWarmTime = Message.InWarmTime;
                              WarmResins[Store].SlotID = Message.SlotID;
                              WarmResins[Store].ExpiredTime = (Convert.ToDateTime(Message.InWarmTime).AddMinutes(Convert.ToInt32(ATS.SystemConfig.WarmTime))).ToString("MM/dd HH:mm");
                              WarmResins[Store].InWarmOperator = Message.InWarmOperator;

                              panel3.Controls["TbWarmResin" + num].Visible = true;
                              panel3.Controls["TbWarmResin" + num].Text = Message.SlotID;
                              panel3.Controls["WarmResin" + (Store + 1)].BackgroundImage.Dispose();
                              panel3.Controls["WarmResin" + (Store + 1)].BackgroundImage = Properties.Resources.RedCircle1;
                              panel3.Controls["WarmResin" + (Store + 1)].BackgroundImage.Dispose();
                              panel3.Controls["WarmResin" + (Store + 1)].BackgroundImage = Expired == 0 ?
                                  Properties.Resources.YellowCircle1 : (Expired == 1 ?
                                  Properties.Resources.GreenCircle2 : (Expired == 2 ?
                                  Properties.Resources.OrangeCircle : (Expired == 3 ?
                                  Properties.Resources.RedCircle1 : Properties.Resources.BlackCircle1)));
                              panel3.Controls["LabelWarmNum" + (Store + 1)].BackColor = Expired == 0 ?
                                  Color.FromArgb(239, 228, 176) : (Expired == 1 ?
                                  Color.FromArgb(188, 230, 29) : (Expired == 2 ?
                                  Color.FromArgb(225, 127, 39) : (Expired == 3 ?
                                  Color.FromArgb(237, 28, 36) : Color.FromArgb(100, 100, 100))));
                           }
                      });
            }
            catch (Exception err)
            {
                LCSCommon.WriteRunLog(err.Message);
            }
        }

        private void ColdInformationChange(int Location,string SlotID)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                if (SlotID == "")
                {
                    ColdResins[Location-1].SlotID = "";
                    ColdResins[Location - 1].ColdType = 0;
                    ColdResins[Location - 1].ExpiredTime = "";
                    ColdResins[Location - 1].InColdOperator = "";
                    ColdResins[Location - 1].InColdTime = "";
                    return;
                }
                else
                {
                    StoreMessage NewStoreMessage = Read(Location, SlotID,1);
                    if (NewStoreMessage == null)
                    {
                        return;
                    }

                    ColdResins[Location-1].SlotID = SlotID;
                    ColdResins[Location - 1].InColdTime = NewStoreMessage.InColdTime;
                    ColdResins[Location - 1].ExpiredTime = NewStoreMessage.ExpiredTime;
                    ColdResins[Location - 1].InColdOperator = NewStoreMessage.InColdOperator;
                    panel2.Controls["TbColdResin" + Location].Text = SlotID;
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


        private static StoreMessage Read(int Location,string SlotID,int TaskSelect) // 1-> Cold   2->Warm   3->Finally
        {
            lock (dbLock)
            {
                if (TaskSelect == 1)
                {
                    List<StoreMessage> result = new List<StoreMessage>();
                    connection.ConnectionString = "Data source = " + Application.StartupPath + "\\" + "AppData.db";
                    
                    string SqlCommand =
                        "SELECT ExpiredTime, InColdTime,InColdOperator" +
                        " FROM ResinInfo" +
                        "  Where ColdLocation = '" + Location.ToString() + "' And SlotID Like '" + SlotID + "'  And TaskSuccess = '0';";

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
                                        InColdOperator = reader["InColdOperator"].ToString(),
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
                        "SELECT SlotID, InWarmTime,InWarmOperator" +
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
                                        Location =Location.ToString(),
                                        InWarmOperator = reader["InWarmOperator"].ToString()

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
            if(UserData.Instance.Now.Level<3)
            { return; }
            if ((MessageBox.Show(Language.Text("SureDelete"), "提醒資訊", MessageBoxButtons.OKCancel)) == DialogResult.OK)
            {
                PictureBox Pb = (PictureBox)sender;
                int Location =Convert.ToInt32(Pb.Name.Substring(10, Pb.Name.Length - 10));
                Models.UserData.Instance.HandRemoveColdResin(Location);
                PLCconnect.PLCCommon.PLC_WRITE((1789 + Location).ToString(), "1","1");
                WiseTech.Log.Logger.DeleteResinInfo(Location.ToString(), 1);
            }

        }

        private void WarmBottleClear_Click(object sender, EventArgs e)
        {
            if (UserData.Instance.Now.Level < 3)
            { return; }
            if ((MessageBox.Show(Language.Text("SureDelete"), "提醒資訊", MessageBoxButtons.OKCancel)) == DialogResult.OK)
            {
                PictureBox Pb = (PictureBox)sender;
                int Location = Convert.ToInt32(Pb.Name.Substring(10, Pb.Name.Length - 10));
                Models.UserData.Instance.HandRemoveWarmResin(Location);
                PLCconnect.PLCCommon.PLC_WRITE((1799 + Location).ToString(), "1","1");
                WiseTech.Log.Logger.DeleteResinInfo(Location.ToString(), 2);
            }
        }

        private void BtnInwarm1_Click(object sender, EventArgs e)
        {

            if (PLCconnect.ReadSystemStatus.PlcStatus[2])
            {
                MessageBox.Show("請先等待目前作業完成", "提醒");
                return;
            }

            if (PLCconnect.ReadSystemStatus.CheckIOSafty() == false)
            {
                MessageBox.Show("請先確認各手臂是否有物品或在席是否正常", "確認請求", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                System.Threading.SpinWait.SpinUntil(() => { return false; }, 2000);
            }

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
            if (ReadSystemStatus.PlcStatus[2])
            {
                MessageBox.Show("請先等待目前作業完成", "提醒");
                return;
            }

            if (ReadSystemStatus.CheckIOSafty() == false)
            {
                MessageBox.Show("請先確認各手臂是否有物品或在席是否正常", "確認請求", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                SpinWait.SpinUntil(() => { return false; }, 2000);
            }

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
                case ATSData.SystemModeType.Automatic:
                    BtnInwarm1.BackColor = Color.SpringGreen;
                    BtnOutwarm.BackColor = Color.SpringGreen;
                    break;
                case ATSData.SystemModeType.Handmode:
                    BtnInwarm1.BackColor = Color.White;
                    BtnOutwarm.BackColor = Color.White;
                    break;
            }
        }

        
        


        private void ColdTempEvent(int[] ColdTemp)
        {

            ThreadSafeHelper.UIThread(this, () =>
            {

                LBColdTemp1.Text = ColdTemp[0] < 0 && ColdTemp[0] > -10 ? (Convert.ToDouble(ColdTemp[0]) / 10).ToString() : ColdTemp[0] < 10 && ColdTemp[0] > 0 ? "0." + ColdTemp[0].ToString()[ColdTemp[0].ToString().Length - 1] + " C" : ColdTemp[0].ToString().Substring(0, ColdTemp[0].ToString().Length - 1) + "." + ColdTemp[0].ToString()[ColdTemp[0].ToString().Length - 1] + " C";
                LBColdTemp2.Text = ColdTemp[1] < 0 && ColdTemp[1] > -10 ? (Convert.ToDouble(ColdTemp[1]) / 10).ToString() : ColdTemp[1] < 10 && ColdTemp[1] > 0 ? "0." + ColdTemp[1].ToString()[ColdTemp[1].ToString().Length - 1] + " C" : ColdTemp[1].ToString().Substring(0, ColdTemp[1].ToString().Length - 1) + "." + ColdTemp[1].ToString()[ColdTemp[1].ToString().Length - 1] + " C";
                LBColdTemp3.Text = ColdTemp[2] < 0 && ColdTemp[2] > -10 ? (Convert.ToDouble(ColdTemp[2]) / 10).ToString() : ColdTemp[2] < 10 && ColdTemp[2] > 0 ? "0." + ColdTemp[2].ToString()[ColdTemp[2].ToString().Length - 1] + " C" : ColdTemp[2].ToString().Substring(0, ColdTemp[2].ToString().Length - 1) + "." + ColdTemp[2].ToString()[ColdTemp[2].ToString().Length - 1] + " C";
                LBColdTemp4.Text = ColdTemp[3] < 0 && ColdTemp[3] > -10 ? (Convert.ToDouble(ColdTemp[3]) / 10).ToString() : ColdTemp[3] < 10 && ColdTemp[3] > 0 ? "0." + ColdTemp[3].ToString()[ColdTemp[3].ToString().Length - 1] + " C" : ColdTemp[3].ToString().Substring(0, ColdTemp[3].ToString().Length - 1) + "." + ColdTemp[3].ToString()[ColdTemp[3].ToString().Length - 1] + " C";
                LBColdTemp5.Text = ColdTemp[4] < 0 && ColdTemp[4] > -10 ? (Convert.ToDouble(ColdTemp[4]) / 10).ToString() : ColdTemp[4] < 10 && ColdTemp[4] > 0 ? "0." + ColdTemp[4].ToString()[ColdTemp[4].ToString().Length - 1] + " C" : ColdTemp[4].ToString().Substring(0, ColdTemp[4].ToString().Length - 1) + "." + ColdTemp[4].ToString()[ColdTemp[4].ToString().Length - 1] + " C";


                double Num = Convert.ToDouble(SystemConfig.ColdSettingTemp);

                if (Convert.ToDouble(ColdTemp[0]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[1]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[2]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[3]) / 10 > Num
                    || Convert.ToDouble(ColdTemp[4]) / 10 > Num)
                {
                    AlarmEvent(1545, 14);
                }

            });
        }
        private void WarmTempEvent(int[] WarmTemp)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                LBWarmTemp1.Text = WarmTemp[0].ToString().Substring(0, WarmTemp[0].ToString().Length - 1) + "." + WarmTemp[0].ToString()[WarmTemp[0].ToString().Length - 1] + " C";
                LBWarmTemp2.Text = WarmTemp[1].ToString().Substring(0, WarmTemp[1].ToString().Length - 1) + "." + WarmTemp[1].ToString()[WarmTemp[1].ToString().Length - 1] + " C";
                LBWarmTemp3.Text = WarmTemp[2].ToString().Substring(0, WarmTemp[2].ToString().Length - 1) + "." + WarmTemp[2].ToString()[WarmTemp[2].ToString().Length - 1] + " C";
                LBWarmTemp4.Text = WarmTemp[3].ToString().Substring(0, WarmTemp[3].ToString().Length - 1) + "." + WarmTemp[3].ToString()[WarmTemp[3].ToString().Length - 1] + " C";
                LBWarmTemp5.Text = WarmTemp[4].ToString().Substring(0, WarmTemp[4].ToString().Length - 1) + "." + WarmTemp[4].ToString()[WarmTemp[4].ToString().Length - 1] + " C";


                double Num = Convert.ToDouble(SystemConfig.WarmSettingTemp);

                if  (Convert.ToDouble(WarmTemp[0]) / 10 < Num
                    || Convert.ToDouble(WarmTemp[1]) / 10 < Num
                    || Convert.ToDouble(WarmTemp[2]) / 10 < Num
                    || Convert.ToDouble(WarmTemp[3]) / 10 < Num
                    || Convert.ToDouble(WarmTemp[4]) / 10 < Num)
                {
                    AlarmEvent(1545, 13);
                }
            });
        }


        private void OutColdFirstSendInfo(int Location)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                panel3.Controls["TbWarmResin" + Location].Visible = true;
                panel3.Controls["TbWarmResin" + Location].Text = PLCconnect.WriteOutCold.LotID;
                panel3.Controls["WarmResin" + Location].BackgroundImage.Dispose();
                panel3.Controls["WarmResin" + Location].BackgroundImage = Properties.Resources.YellowCircle1;
                panel3.Controls["LabelWarmNum" + Location].BackColor = Color.FromArgb(239, 228, 176);
            });
        }

        private void LBColdTemp1_Click(object sender, EventArgs e)
        {

        }
        
        private void Resin_Click(object sender, EventArgs e)
        {
            var str = (sender as PictureBox).Name;
            var Location = int.Parse(str.Substring(str.Length-1,1));
            if (ColdResins[Location - 1].SlotID == "")
            {
                return;
            }
            ColdInfo.SetInfo(Location,ColdResins[Location - 1]);
            ColdInfo.ShowDialog();
        }

        private void WarmResin_Click(object sender, EventArgs e)
        {
            var str = (sender as PictureBox).Name;
            var Location = int.Parse(str.Substring(str.Length - 1, 1));
            if (WarmResins[Location - 1].SlotID == "")
            {
                return;
            }
            WarmInfo.SetInfo(Location, WarmResins[Location - 1]);
            WarmInfo.ShowDialog();
        }

        private void TempHistory_Click(object sender, EventArgs e)
        {
            Forms.TempHistory Th = new Forms.TempHistory();
            Th.ShowDialog();
        }



        public void AlarmEvent(int Address, int Point)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                if (AlarmInformation.Time == DateTime.Now.Minute)
                {
                    return;
                }
                if (AlarmInformation.FormOpen == false)
                {
                    AlarmInformation.FormOpen = true;

                    if (!AlarmInformation.Once)
                    {
                        AlarmInfo.AddInfo(UserData.Instance.GetErrorInformation((Address).ToString(), Point));
                        ParentForm.Controls.Add(AlarmInfo);
                        ParentForm.Controls.SetChildIndex(AlarmInfo, 0);
                        AlarmInformation.Once = true;
                    }


                }
                else
                {
                    if (!AlarmInformation.Once)
                    {
                        AlarmInfo.AddInfo(ATS.Models.UserData.Instance.GetErrorInformation((Address).ToString(), Point));
                        AlarmInformation.Once = true;
                    }
                }
                WiseTech.Log.Logger.AlarmLog(UserData.Instance.GetErrorInformation((Address).ToString(), Point));
            });
        }
    }


    public class StoreMessage
    {
        public string Location = "";
        public string SlotID = "";
        public string InColdTime = "";
        public string ExpiredTime = "";
        public string InWarmTime = "";
        public string InColdOperator = "";
        public string InWarmOperator = "";
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
