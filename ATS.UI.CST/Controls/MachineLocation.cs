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
using ATS.Models;

namespace ATS.UI.CST.Controls
{
    public partial class MachineLocation : UserControl
    {
        bool[] MachineInLocationOld = new bool[8] { false, false, false, false, false, false, false, false }; // 入料 , 過度 , 主夾爪 , 移載夾爪 磅秤
        bool[] MachineInLocationNew = new bool[8] { false, false, false, false, false, false, false, false };
        List<ColdCobtrols> ColdCols = new List<ColdCobtrols>();
        List<WarmControls> WarmCols = new List<WarmControls>();
        ATSData.SystemModeType Sm = ATSData.SystemModeType.Maintain;
        Timer LocationTimer = new Timer();
        double FillBottle = 0;
        double EmptyBottle = 0;

        struct WarmControls
        {
            public ProgressBar PB;
            public TextBox Tb;
        }

        class ColdCobtrols
        {
            public TextBox Message;
            public TextBox ColdTime;
            public DateTime InColdTime;
        }

        public MachineLocation()
        {
            InitializeComponent();
            Load +=MachineLocation_Load;
            ReadSystemStatus.WarmTimeShowEvent += WarmTimeEvent;
            WriteOutCold.UpdateWarmEvent += WarmTimeEvent;
            ReadSystemStatus.ColdStoreChange += ColdStoreEvent;
            WriteOutWarm.RecycleBottleChange += WriteOutWarm_RecycleBottleChange;
            CSTForm.RecycleBottleChange += WriteOutWarm_RecycleBottleChange;
            IniTbCold();
            IniPgBAndTBWarm();
            Language.Bind("MachineLocation.ColdlabelTitle", ColdlabelTitle);
            Language.Bind("MachineLocation.WarmlabelTitle", WarmlabelTitle);
            Language.Bind("MachineLocation.LabelLoadPort", LabelLoadPort);
            Language.Bind("MachineLocation.LabelRt", LabelRt);
            Language.Bind("MachineLocation.LabelStore", LabelStore);
            Language.Bind("MachineLocation.LabelRecycle", LabelRecycle);
            Language.Bind("MachineLocation.LabelWeight", LabelWeight);
            Language.Bind("MachineLocation.LabelOpen", LabelOpen);
            Language.Bind("MachineLocation.LabelLBF", LabelLBF);
            Language.Bind("MachineLocation.LabelTF", LabelTF);

            Language.SetText("NoResin", ". NoResin", ". 目前無膠材");
            Language.SetText("Warming", ". Warming", ". 回溫中");
            Language.SetText("Warmed", ". Warmed", ". 回溫完成");
            Language.SetText("Expired1st", ". Expired 1st", ". 回溫逾時階段(一)");
            Language.SetText("Expired2rd", ". Expired 2rd", ". 回溫逾時階段(二)");

            WriteOutWarm.WeightEvent += BottleWeightShow;
            WriteOutWarm.EmptyWeightEvent += EmptyBottleWeightShow;
        }

        private void IniTbCold()
        {
            ColdCobtrols col = new ColdCobtrols();
            col.InColdTime = new DateTime();

            col.Message = TbColdMessage1;
            col.ColdTime = TbColdTime1;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage2;
            col.ColdTime = TbColdTime2;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage3;
            col.ColdTime = TbColdTime3;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage4;
            col.ColdTime = TbColdTime4;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage5;
            col.ColdTime = TbColdTime5;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage6;
            col.ColdTime = TbColdTime6;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage7;
            col.ColdTime = TbColdTime7;
            ColdCols.Add(col);

            col = new ColdCobtrols();
            col.InColdTime = new DateTime();
            col.Message = TbColdMessage8;
            col.ColdTime = TbColdTime8;
            ColdCols.Add(col);
        }
        private void IniPgBAndTBWarm()
        {
            WarmControls col = new WarmControls();
            col.PB = WarmPgB1;
            col.Tb = TbWarmMessage1;
            WarmCols.Add(col);

            
            col.PB = WarmPgB2;
            col.Tb = TbWarmMessage2;
            WarmCols.Add(col);

            
            col.PB = WarmPgB3;
            col.Tb = TbWarmMessage3;
            WarmCols.Add(col);

            
            col.PB = WarmPgB4;
            col.Tb = TbWarmMessage4;
            WarmCols.Add(col);

            col.PB = WarmPgB5;
            col.Tb = TbWarmMessage5;
            WarmCols.Add(col);

            col.PB = WarmPgB6;
            col.Tb = TbWarmMessage6;
            WarmCols.Add(col);

            col.PB = WarmPgB7;
            col.Tb = TbWarmMessage7;
            WarmCols.Add(col);

            col.PB = WarmPgB8;
            col.Tb = TbWarmMessage8;
            WarmCols.Add(col);

        }
        private void MachineLocation_Load(object Sender, EventArgs e)
        {

            LocationTimer.Tick += LocationTimer_Tick;
            LocationTimer.Interval = 300;
            LocationTimer.Enabled = true;
        }


        private void WarmTimeEvent(int Location, string WarmHour,string Minutes, int WarmedType)//-1 -> Null  0->Warming , 1->Success, 2->Expired 1st, 3->Expired 2rd
        {
            ThreadSafeHelper.UIThread(this, () => {
            switch (WarmedType)
            { 
                case -1:
                    WarmCols[Location].PB.Visible = false;
                    WarmCols[Location].Tb.Text = (Location + 1).ToString() + Language.Text("NoResin");
                    WarmCols[Location].Tb.BackColor = Color.White;
                    break;
                case 0:
                    WarmCols[Location].PB.Visible = true;
                    WarmCols[Location].PB.Value =(((Convert.ToInt32(WarmHour) * 60) + (Convert.ToInt32(Minutes))) * 100)/  Convert.ToInt32(SystemConfig.WarmTime);
                    WarmCols[Location].Tb.Text = (Location + 1).ToString() + Language.Text("Warming");
                    WarmCols[Location].Tb.BackColor = Color.FromArgb(130, 210, 212);
                    break;
                case 1:
                    WarmCols[Location].PB.Visible = true; // 130, 210, 212
                    WarmCols[Location].PB.Value = ((Convert.ToInt32(WarmHour) * 60) + (Convert.ToInt32(Minutes)) * 100) / Convert.ToInt32(SystemConfig.WarmOutTime1);
                    WarmCols[Location].Tb.Text = (Location + 1).ToString() + Language.Text("Warmed");
                    WarmCols[Location].Tb.BackColor = Color.FromArgb(153, 217, 234);
                    break;
                case 2:
                    WarmCols[Location].PB.Visible = true;
                    WarmCols[Location].PB.Value = (((Convert.ToInt32(WarmHour) * 60) + (Convert.ToInt32(Minutes)))* 100)/ Convert.ToInt32(SystemConfig.WarmOutTime2);
                    WarmCols[Location].Tb.Text = (Location + 1).ToString() + Language.Text("Expired1st");
                    WarmCols[Location].Tb.BackColor = Color.FromArgb(255, 97, 3);
                    break;
                case 3:
                    WarmCols[Location].PB.Visible = true;
                    WarmCols[Location].PB.Value =100;
                    WarmCols[Location].Tb.Text = (Location + 1).ToString() + Language.Text("Expired2rd");
                    WarmCols[Location].Tb.BackColor = Color.FromArgb(237,28,36);
                    break;
 
            }
            });
        }


        private void ColdStoreEvent(int Location, string Info)
        {
            var LotID=  "";
            try
            {
                 LotID= UserData.Instance.SelectColdSlotID((Location + 1).ToString());
                 if (LotID == "")
                 {
                     LotID = WriteInClod.SlotThread;
                 }
            }
            catch (Exception err)
            {
                LotID = WriteInClod.SlotThread;
                LCSCommon.WriteRunLog("Cold在席讀取過快,已Pass");
            }
                if (Info == "0")
                {
                    WiseTech.ThreadSafeHelper.UIThread(this, () =>
                    {
                        ColdCols[Location].Message.Text = (Location + 1).ToString() + Language.Text("NoResin");
                        ColdCols[Location].ColdTime.Text = "";
                        ColdCols[Location].Message.BackColor = Color.White;
                    });
                }
                else if (Info == "1")
                {
                    WiseTech.ThreadSafeHelper.UIThread(this, () =>
                    {
                        ColdCols[Location].Message.Text = (Location + 1).ToString() + ". " + LotID;
                        ColdCols[Location].InColdTime = UserData.Instance.SelectClotInColdTime((Location + 1).ToString());
                        TimeSpan Ts = DateTime.Now - UserData.Instance.SelectClotInColdTime((Location + 1).ToString());
                        ColdCols[Location].ColdTime.Text = ((Ts.Days*24) +  Ts.Hours).ToString("00") + "hr " + Ts.Minutes + "m " + Ts.Seconds + "s";
                    });
                }

                else if (Info == "2")
                {
                    WiseTech.ThreadSafeHelper.UIThread(this, () =>
                    {
                        ColdCols[Location].Message.Text = (Location + 1).ToString() + ". " + LotID;
                        ColdCols[Location].Message.BackColor = Color.FromArgb(237,28,36);
                        ColdCols[Location].InColdTime = UserData.Instance.SelectClotInColdTime((Location + 1).ToString());
                        TimeSpan Ts = DateTime.Now - ColdCols[Location].InColdTime;
                        ColdCols[Location].ColdTime.Text = Ts.Hours.ToString("00") + "hr " + Ts.Minutes + "m " + Ts.Seconds + "s";
                    });
                }
        }
        #region Recycle Bottle Show And Alarm
        private void WriteOutWarm_RecycleBottleChange(int Number)
        {
            WiseTech.ThreadSafeHelper.UIThread(this, () =>
            {
                TbRecycle.Text = "Num: " + ReadSystemStatus.RecycleBottleNum.ToString();
            });

            if (ReadSystemStatus.RecycleBottleNum > 8)
            {
                RecycleBottleFullAlarm();
            }

            
        }

        private static void RecycleBottleFullAlarm()
        {
            MainTabsPanel mt = new MainTabsPanel();
            mt.AlarmEvent(1545, 15);
        }
        #endregion

        private void LocationTimer_Tick(object Sender, EventArgs e)// 入料 , 過度 , 主夾爪 , 移載夾爪  磅秤 回收 存儲
        {
            LocationTimer.Enabled = false;
            #region 確認在席
            if (ReadSystemStatus.IOInputStatus[6] != null && ReadSystemStatus.MachineStatus[6] != null)
            {

                MachineInLocationNew[0] = ReadSystemStatus.IOInputStatus[1] == null ? false : (LoadPortHaveNow() ? true : false);
                MachineInLocationNew[1] = ReadSystemStatus.IOInputStatus[3] == null ? false : RobotCatchHaveNow() ? true : false;
                MachineInLocationNew[2] = ReadSystemStatus.IOInputStatus[5] == null ? false : RobotMainHaveNow() ? true : false;
                MachineInLocationNew[3] = ReadSystemStatus.IOInputStatus[5] == null ? false : RobotTransferHaveNow() ? true : false;
                MachineInLocationNew[4] = ReadSystemStatus.MachineStatus[5] == null ? false : WeightHaveNow();
                MachineInLocationNew[5] = ReadSystemStatus.MachineStatus[5] == null ? false : RecycleHaveNow();
                MachineInLocationNew[6] = (ReadSystemStatus.MachineStatus[5] == null && ReadSystemStatus.IOInputStatus[0] == null) ? false : StoreHaveNow();

                if (MachineInLocationNew[0] != MachineInLocationOld[0] || ReadSystemStatus.RobotResinID != "")
                {
                    MachineInLocationOld[0] = MachineInLocationNew[0];

                    if (ReadSystemStatus.MachineStatus[5][13] != '1')
                    {


                        if (MachineInLocationOld[0])
                        {
                            TbLoadLot.BackColor = Color.Yellow;
                            TbLoadLot.Text = ReadSystemStatus.RobotResinID;
                        }
                        else
                        {
                            TbLoadLot.BackColor = Color.White;
                            TbLoadLot.Text = "";
                        }
                    }
                    else
                    {
                        TbLoadLot.BackColor = Color.White;
                        TbLoadLot.Text = "";
                    }
                }


                if (MachineInLocationNew[1] != MachineInLocationOld[1])
                {
                    MachineInLocationOld[1] = MachineInLocationNew[1];
                    if (MachineInLocationOld[1])
                    {
                        TbLBF.BackColor = Color.Yellow;
                        TbLBF.Text = ReadSystemStatus.RobotResinID;
                    }
                    else
                    {
                        TbLBF.BackColor = Color.White;
                        TbLBF.Text = "";
                    }
                }

                if (MachineInLocationNew[2] != MachineInLocationOld[2] && ReadSystemStatus.RobotResinID != "")
                {
                    MachineInLocationOld[2] = MachineInLocationNew[2];
                    if (MachineInLocationOld[2])
                    {
                        TbRtLot.BackColor = Color.Yellow;
                        TbRtLot.Text = ReadSystemStatus.RobotResinID;
                    }
                    else
                    {
                        TbRtLot.BackColor = Color.White;
                        TbRtLot.Text = "";
                    }
                }


                if (MachineInLocationNew[3] != MachineInLocationOld[3] && ReadSystemStatus.RobotResinID != "")
                {
                    MachineInLocationOld[3] = MachineInLocationNew[3];
                    if (MachineInLocationOld[3])
                    {
                        TbTFLot.BackColor = Color.Yellow;
                        TbTFLot.Text = ReadSystemStatus.RobotResinID;
                    }
                    else
                    {
                        TbTFLot.BackColor = Color.White;
                        TbTFLot.Text = "";
                    }
                }


                #region  磅秤區通過機構位置確認
                if (MachineInLocationNew != MachineInLocationOld && ReadSystemStatus.RobotResinID != "")
                {
                    MachineInLocationOld[4] = MachineInLocationNew[4];
                    if (MachineInLocationOld[4])
                    {
                        TbWeightLot.BackColor = Color.Yellow;
                        TbWeight.BackColor = Color.Yellow;
                        TbWeightLot.Text = ReadSystemStatus.RobotResinID;
                    }
                    else
                    {
                        TbWeightLot.BackColor = Color.White;
                        TbWeight.BackColor = Color.White;
                        TbWeightLot.Text = "";
                    }
                }

                #endregion



                //if (MachineInLocationNew[5] != MachineInLocationOld[5])
                //{
                //    MachineInLocationOld[5] = MachineInLocationNew[5];
                //    if (MachineInLocationOld[5])
                //    {
                //        TbRecycle.BackColor = Color.Yellow;
                //        TbRecycle.Text = "Num: " + PLCconnect.ReadSystemStatus.RecycleBottleNum.ToString();
                //    }

                //}
                if (MachineInLocationNew[6] != MachineInLocationOld[6] && ReadSystemStatus.RobotResinID != "")
                {
                    MachineInLocationOld[6] = MachineInLocationNew[6];
                    if (MachineInLocationOld[6])
                    {
                        if (ReadSystemStatus.MachineStatus[1][15] == '1' || ReadSystemStatus.MachineStatus[1][12] == '1'
                            || ReadSystemStatus.MachineStatus[1][11] == '1' || ReadSystemStatus.MachineStatus[1][5] == '1')
                        {

                            TbColdStoreLot.BackColor = Color.Yellow;
                            TbColdStoreLot.Text = ReadSystemStatus.RobotResinID;
                        }
                        else
                        {
                            TbWarmStoreLot.BackColor = Color.Yellow;
                            TbWarmStoreLot.Text = ReadSystemStatus.RobotResinID;
                        }
                    }
                    else
                    {
                        TbColdStoreLot.BackColor = Color.White;
                        TbColdStoreLot.Text = "";
                        TbWarmStoreLot.BackColor = Color.White;
                        TbWarmStoreLot.Text = "";
                    }
                }

            }
            #endregion

            #region Cold Time
            for (int i = 0; i < ColdCols.Count; i++)
            {
                if (ColdCols[i].ColdTime.Text != "")
                {
                    WiseTech.ThreadSafeHelper.UIThread(this, () =>
                    {
                        TimeSpan Ts = DateTime.Now - ColdCols[i].InColdTime;
                        ColdCols[i].ColdTime.Text = Ts.Days > 0 ? Ts.Days.ToString() + "d " + Ts.Hours.ToString("00") + "hr " + Ts.Minutes + "m " + Ts.Seconds + "s" : Ts.Hours.ToString("00") + "hr " + Ts.Minutes + "m " + Ts.Seconds + "s";
                    });
                }
            }
            #endregion

            LocationTimer.Enabled = true;




        }

        #region Read From PLC
        private static bool StoreHaveNow()
        {
            return ReadSystemStatus.MachineStatus[5][13] == '1' && ReadSystemStatus.IOInputStatus[0][7] == '1';
        }

        private static bool RecycleHaveNow()
        {
            return ReadSystemStatus.MachineStatus[5][11] == '1';
        }

        private static bool WeightHaveNow()
        {
            return (ReadSystemStatus.MachineStatus[5][12] == '1' && ReadSystemStatus.IOInputStatus[0][7] == '1');
        }

        private static bool RobotTransferHaveNow()
        {
            return ReadSystemStatus.IOInputStatus[5][4] == '1';
        }

        private static bool RobotMainHaveNow()
        {
            return ReadSystemStatus.IOInputStatus[5][5] == '1';
        }

        private static bool RobotCatchHaveNow()
        {
            return ReadSystemStatus.IOInputStatus[3][1] == '1';
        }

        private static bool LoadPortHaveNow()
        {
            return ReadSystemStatus.IOInputStatus[1][4] == '1';
        }

#endregion

        public void Fill(string Weight)
        {
            FillBottle = Convert.ToDouble(Weight) / 100;
            WiseTech.ThreadSafeHelper.UIThread(this, () =>
            {
                TbWeight.Visible = true;
                TbWeight.Text = FillBottle.ToString() + " (g)";
            });
        }

        public void Empty(string Weight)
        {
            EmptyBottle = Convert.ToDouble(Weight) / 1000;
            string ShowMessage = (FillBottle - EmptyBottle).ToString();
            ThreadSafeHelper.UIThread(this, () =>
            {
                TbWeight.Visible = true;
                TbWeight.Text = "淨重 : " + ShowMessage + " (g)";
            });
        }

        private void BottleWeightShow(string Weight)
        {
            FillBottle = Convert.ToDouble(Weight)/100;
            WiseTech.ThreadSafeHelper.UIThread(this, () =>
            {
                TbWeight.Visible = true;
                TbWeight.Text = FillBottle.ToString() + " (g)";
            });
        }


        private void EmptyBottleWeightShow(string Weight)
        {
            EmptyBottle = Convert.ToDouble(Weight)/1000;
            string ShowMessage = (FillBottle - EmptyBottle).ToString();
            ThreadSafeHelper.UIThread(this, () =>
            {
                TbWeight.Visible = true;
                TbWeight.Text = "淨重 : " + ShowMessage + " (g)";
            });
        }

        private void LabelWeight_Click(object sender, EventArgs e)
        {
            Forms.WeightHistory Wh = new Forms.WeightHistory();
            Wh.Focus();
            Wh.ShowDialog();
        }

        private void LabelRecycle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認要將料桶數量清空嗎?", "刪除提醒", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ATS.SystemConfig.RecycleBottle = "0";
                SystemConfig Sc = new SystemConfig();
                Sc.SaveRecycleBottle("0");
                TbRecycle.Text = "Num: 0";
            }
            else
            {
                return;
            }
        }




        
    }
}
