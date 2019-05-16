using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATS.Models;
using WiseTech;
using ATS.Data;
using System.IO.Ports;
using System.Threading;


namespace ATS.UI.CST.Controls
{
    public partial class MainTabsPanel : UserControl
    {
        internal static event Action OnStatusChange = null;
        internal static event Action OnTaskChange = null;
        internal static Action TaskStart = null;
        private BarcoReader BarcoReaderFrm = new BarcoReader();
        public delegate void Refresh();
        public static event Refresh RefreshEvent;
        private static AlarmInformation AlarmInfo;
        string Message1023 = "0000000000000000";
        Dictionary<int, Label> UDMZ = new Dictionary<int, Label>();
        Dictionary<int, Label> TFLC = new Dictionary<int, Label>();
        Dictionary<int, Label> RTLC = new Dictionary<int, Label>();
        Dictionary<int, Label> LFLC = new Dictionary<int, Label>();
        List<Button> BtnList = new List<Button>();
        List<GroupBox> GbList = new List<GroupBox>();
        List<Label> LbList = new List<Label>();
        TaskNumberSelect TN = new TaskNumberSelect();

        //所有分頁
        private Dictionary<string, TabPage> tabsAvailable
        {
            get
            {
                return new Dictionary<string, TabPage>() {
                            {"Main", tabPageMain},                                {"Log", tabPageLog},                {"Maintain", tabPageMaintain},
                            { "IO", tabPageIO},                     {"Settings", tabPageSettings},      {"Manage", tabPageManage},
                        };
            }
        }

        //private ATSCore core;
        private UserData userData;
        private int surplus = 60;
        private int Advance = 40;
        private bool StartChangeLocaion = false;



        public MainTabsPanel()
        {
            InitializeComponent();
            List<string> xData = new List<string>() { "預支量", "剩餘量" };
            List<int> yData = new List<int>() { surplus, Advance };
            chart1.Series[0]["PieLabelStyle"] = "Outside";//將文字移到外側
            chart1.Series[0]["PieLineColor"] = "Black";//繪製黑線。
            chart1.Series[0].Points.DataBindXY(xData, yData);

            if (AppData.IsRuntime)
            {
                //core = ATSCore.Instance;
                userData = UserData.Instance;
                userData.OnLogin += UserData_OnPowerChange;
                userData.OnLoginFailed += UserData_OnPowerChange;

                tabControl.Selected += TabControl_Selected;
                Language.OnRefreshed += Language_OnRefreshed;

                Load += MainTabsPanel_Load;

                Language.Bind("Tabs.Main", tabPageMain);
                
                Language.Bind("Tabs.Log", tabPageLog);
                Language.Bind("Tabs.Maintain", tabPageMaintain);
                Language.Bind("Tabs.IO", tabPageIO);
                Language.Bind("Tabs.Settings", tabPageSettings);
                Language.Bind("Tabs.Manage", tabPageManage);

                Language.Bind("Tabs.Main.Process", Lb);
                Language.Bind("Tabs.Main.StoreInfo", Store);


                Language.Bind("Tabs.Manage.Users", tabPageUsers);
                Language.Bind("Tabs.Manage.Groups", tabPageUserGroups);

                Language.Bind("Tabs.Mode.Equipment", tabPageModeEquipment);
                Language.Bind("Tabs.Run", tabPageRun);
                Language.Bind("Tabs.Alarm", tabPageAlarm);
                Language.Bind("Tabs.Product", tabPageProduct);
                Language.Bind("Tabs.System", tabPageSystem);

                Language.Bind("Tabs.LbAutoStatus", LbAutoStatus);
                Language.Bind("Tabs.LbHandStatus", LbHandStatus);
                Language.Bind("Tabs.LbDeviceStart", LbDeviceStart);
                Language.Bind("Tabs.LbErrrorStatus", LbErrrorStatus);
                Language.Bind("Tabs.LbDevicePause", LbDevicePause);
                Language.Bind("Tabs.LbDeviceStop", LbDeviceStop);


                Language.Bind("Maintain.MainPage", MainPage);
                Language.Bind("Maintain.GroupBoxOpr", GroupBoxOpr);
                Language.Bind("Maintain.LBUD_OPR", LBUD_OPR);
                Language.Bind("Maintain.LBTR_OPR", LBTR_OPR);
                Language.Bind("Maintain.LBBT_OPR", LBBT_OPR);
                Language.Bind("Maintain.LBRT_OPR", LBRT_OPR);
                Language.Bind("Maintain.LBCT_OPR", LBCT_OPR);
                Language.Bind("Maintain.LabelStore", LabelStore);
                Language.Bind("Maintain.LabelRotage", LabelRotage);
                Language.Bind("Maintain.LabelWeight", LabelWeight);
                Language.Bind("Maintain.LabelOpenBottle", LabelOpenBottle);
                Language.Bind("Maintain.LabelLoadPort", LabelLoadPort);
                Language.Bind("Maintain.LabelLF", LabelLF);
                Language.Bind("Maintain.LabelTF", LabelTF);
                Language.Bind("Maintain.BtnChangeLocation", BtnChangeLocation);
                Language.Bind("Maintain.GbTF", GbTF);
                Language.Bind("Maintain.LbTF1", LbTF1);
                Language.Bind("Maintain.LbTF2", LbTF2);
                Language.Bind("Maintain.LabelTFWait", LabelTFWait);
                Language.Bind("Maintain.label23", label23);
                Language.Bind("Maintain.label22", label22);
                Language.Bind("Maintain.label21", label21);
                Language.Bind("Maintain.GbStore", GbStore);
                Language.Bind("Maintain.LbUD10", LbUD10);
                Language.Bind("Maintain.LbUD0", LbUD0);
                Language.Bind("Maintain.LbUD3", LbUD3);
                Language.Bind("Maintain.LbUD4", LbUD4);
                Language.Bind("Maintain.LbUD5", LbUD5);
                Language.Bind("Maintain.LbUD6", LbUD6);
                Language.Bind("Maintain.GbRt", GbRt);
                Language.Bind("Maintain.LbRT1", LbRT1);
                Language.Bind("Maintain.LbRT2", LbRT2);
                Language.Bind("Maintain.LbRT3", LbRT3);
                Language.Bind("Maintain.LbRT4", LbRT4);
                Language.Bind("Maintain.LabelRtWait", LabelRtWait);
                Language.Bind("Maintain.LbRTLogPlus", LbRTLogPlus);
                Language.Bind("Maintain.LbRTJogReduce", LbRTJogReduce);
                Language.Bind("Maintain.LbRTOPR", LbRTOPR);
                Language.Bind("Maintain.JogPlus", JogPlus);
                Language.Bind("Maintain.JogReduce", JogReduce);
                Language.Bind("Maintain.OPR", OPR);
                Language.Bind("Maintain.GbOB", GbOB);
                Language.Bind("Maintain.BtnBFixtureAdvence", BtnBFixtureAdvence);
                Language.Bind("Maintain.BtnBFixtureBack", BtnBFixtureBack);
                Language.Bind("Maintain.BtnOBWait", BtnOBWait);
                Language.Bind("Maintain.BtnBFixtureOpen", BtnBFixtureOpen);
                Language.Bind("Maintain.BtnBFixtureLock", BtnBFixtureLock);
                Language.Bind("Maintain.LbOBJogPlus", LbOBJogPlus);
                Language.Bind("Maintain.LbOBJogReduce", LbOBJogReduce);
                Language.Bind("Maintain.LbOBOPR", LbOBOPR);
                Language.Bind("Maintain.GbMain", GbMain);
                Language.Bind("Maintain.BtnFixtureBack", BtnFixtureBack);
                Language.Bind("Maintain.BtnFixtureAdvence", BtnFixtureAdvence);
                Language.Bind("Maintain.BtnFixtureOpen", BtnFixtureOpen);
                Language.Bind("Maintain.BtnFixtureLock", BtnFixtureLock);
                Language.Bind("Maintain.GbLBF", GbLBF);
                Language.Bind("Maintain.SendMachine_UDUp", SendMachine_UDUp);
                Language.Bind("Maintain.SendMachine_UD", SendMachine_UD);
                Language.Bind("Maintain.SendMachine_LO", SendMachine_LO);
                Language.Bind("Maintain.SendMachine_Lock", SendMachine_Lock);
                Language.Bind("Maintain.GbStoreLock", GbStoreLock);
                Language.Bind("Maintain.BtnWarmDoorOpen", BtnWarmDoorOpen);
                Language.Bind("Maintain.BtnWarmDoorClose", BtnWarmDoorClose);
                Language.Bind("Maintain.BtnColdDoorOpen", BtnColdDoorOpen);
                Language.Bind("Maintain.BtnColdDoorClose", BtnColdDoorClose);
                Language.Bind("Maintain.BtnMotorOpen", BtnMotorOpen);
                Language.Bind("Maintain.GbTFLock", GbTFLock);
                Language.Bind("Maintain.BtnTFixtureAdvence", BtnTFixtureAdvence);
                Language.Bind("Maintain.BtnTFixtureBack", BtnTFixtureBack);
                Language.Bind("Maintain.BtnTFixtureOpen", BtnTFixtureOpen);
                Language.Bind("Maintain.BtnTFixtureLock", BtnTFixtureLock);
                Language.Bind("Maintain.BtnShakeOn", BtnShakeOn);
                Language.Bind("Maintain.BtnShakeOff", BtnShakeOff);
                Language.Bind("Maintain.GBUD", GBUD);
                Language.Bind("Maintain.LbUD2", LbUD2);
                Language.Bind("Maintain.LbUD1", LbUD1);
                Language.Bind("Maintain.LbUD19", LbUD19);
                Language.Bind("Maintain.LbUD14", LbUD14);
                Language.Bind("Maintain.LbUD9", LbUD9);
                Language.Bind("Maintain.LbUD18", LbUD18);
                Language.Bind("Maintain.LbUD16", LbUD16);
                Language.Bind("Maintain.LbUD12", LbUD12);
                Language.Bind("Maintain.LbUD13", LbUD13);
                Language.Bind("Maintain.GbWeight", GbWeight);
                Language.Bind("Maintain.LbUD7", LbUD7);
                Language.Bind("Maintain.LbUD8", LbUD8);
                Language.Bind("Maintain.LbUD15", LbUD15);
                Language.Bind("Maintain.GbLF", GbLF);
                Language.Bind("Maintain.LbLF1", LbLF1);
                Language.Bind("Maintain.LbLF2", LbLF2);
                Language.Bind("Maintain.label4", label4);
                Language.Bind("Maintain.label1", label1);
                Language.Bind("Maintain.label3", label3);
                Language.Bind("Maintain.label2", label2);
                Language.Bind("Maintain.BtnIncold1", BtnIncold1);
                

                PLCconnect.ReadSystemStatus.PlcAlarmEvent += new Action<int, string>(PlcAlarmEvent);
                ResinStore.InWarmEvent += Btninwarm_Click;
                ResinStore.OutWarmEvent += BtnOutwarm_Click;


                AlarmInfo = new AlarmInformation();
                

            }
            MainTabsPanel.OnStatusChange += new Action(MainTabsPanel_OnStatusChange);
            MainTabsPanel.OnTaskChange += new Action(MainTabsPanel_OnStatusChange);
            CSTForm.OnAnimationUpdate += CSTForm_OnAnimationUpdate;
            PLCconnect.ReadSystemStatus.MachineStatusEvent += MachineStatusEvent;
            PLCconnect.ReadSystemStatus.MachineLocationEvent += MachineLocationEvent;
            PLCconnect.ReadSystemStatus.IOInputEvent += IOInputEvent;
            

        }




        private void MainTabsPanel_Load(object sender, EventArgs e)
        {
            PLCconnect.PLCCommon.StratSacnPlcStatus();
            IniControl();
            IniGroupBox();
            IniPanel();
            GbList.ForEach(u => u.Visible = false);
        }

        private void IniPanel()
        {
            LbList.Add(LabelStore);
            LbList.Add(LabelLF);
            LbList.Add(LabelLoadPort);
            LbList.Add(LabelRotage);
            LbList.Add(LabelTF);
            LbList.Add(LabelWeight);
            LbList.Add(LabelOpenBottle);
        }
        private void IniGroupBox()
        {
            GbList.Add(GbOB);
            GbList.Add(GBUD);
            GbList.Add(GbMain);
            GbList.Add(GbWeight);
            GbList.Add(GbRt);
            GbList.Add(GbLBF);
            GbList.Add(GbTFLock);
            GbList.Add(GbStoreLock);
            GbList.Add(GbLF);
            GbList.Add(GbTF);
            GbList.Add(GbStore);

        }
        private void IniControl()
        {
            UDMZ.Add(0, LbUD0);
            UDMZ.Add(1, LbUD1);
            UDMZ.Add(2, LbUD2);
            UDMZ.Add(3, LbUD3);
            UDMZ.Add(4, LbUD4);
            UDMZ.Add(5, LbUD5);
            UDMZ.Add(6, LbUD6);
            UDMZ.Add(7, LbUD7);
            UDMZ.Add(8, LbUD8);
            UDMZ.Add(9, LbUD9);
            UDMZ.Add(10, LbUD10);
            UDMZ.Add(12, LbUD12);
            UDMZ.Add(13, LbUD13);
            UDMZ.Add(14, LbUD14);
            UDMZ.Add(15, LbUD15);
            UDMZ.Add(16, LbUD16);
            UDMZ.Add(17, new Label());
            UDMZ.Add(18, LbUD18);
            UDMZ.Add(19, LbUD19);


            TFLC.Add(1, LbTF1);
            TFLC.Add(2, LbTF2);


            RTLC.Add(1, LbRT1);
            RTLC.Add(2, LbRT2);
            RTLC.Add(3, LbRT3);
            RTLC.Add(4, LbRT4);


            LFLC.Add(1,LbLF1);
            LFLC.Add(2, LbLF2);


            foreach (Control col in MainPage.Controls)
            {
                if (col is Button)
                {
                    BtnList.Add((Button)col);
                }
                if (col is GroupBox)
                {
                    OpenGroupBox(col);
                }
            }

        }

        private void OpenGroupBox(Control Controls)
        {
            foreach (Control col in Controls.Controls)
            {
                if (col is Button)
                {
                    BtnList.Add((Button)col);
                }
            }
        }
        private void Language_OnRefreshed(object sender, EventArgs e)
        {
           
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                if (tabControl.SelectedTab.Name.IndexOf("Maintain") > -1)
                {
                    switch (ATSData.SystemMode)
                    {
                        case ATSData.SystemModeType.Maintain:
                            break;
                        case ATSData.SystemModeType.Handmode:
                            break;
                        default:
                            MessageBox.Show("手動模式才可使用手動劃頁功能", "手動模式才可使用手動劃頁功能", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabControl.SelectedTab = tabPageMain;
                            return;
                    }
                }
                if (tabControl.SelectedTab.Name.IndexOf("Setting") > -1)
                {
                    switch (ATSData.SystemMode)
                    {
                        case ATSData.SystemModeType.Maintain:
                            if (RefreshEvent != null)
                            {
                                RefreshEvent();
                            }
                            break;
                        case ATSData.SystemModeType.Handmode:
                            if (RefreshEvent != null)
                            {
                                RefreshEvent();
                            }
                            break;
                        default:
                            MessageBox.Show("手動模式才可使用設定功能", "手動模式才可使用設定功能", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tabControl.SelectedTab = tabPageMain;
                            return;
                    }
                }
                //ATSCore.Instance.PageChange(tabControl.SelectedTab.Text);
            }
        }


        private void UserData_OnPowerChange(object sender, EventArgs e)
        {

            SuspendLayout();
            tabControl.TabPages.Clear();
            foreach (var tabNamme in userData.Now.TabsAvailable)
            {
                tabControl.TabPages.Add(tabsAvailable[tabNamme]);
            }
            ResumeLayout();
        }

        private void tabPageLog_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnStatusChange != null)
            {
                ini1to3Button();
                button1.BackColor = Color.LightGreen;///Color.FromArgb(48, 48, 48);
                button1.ForeColor = Color.Black;
                ATSData.SystemMode = ATSData.SystemModeType.Automatic;
                OnStatusChange();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OnStatusChange != null)
            {
                ini1to3Button();
                button2.BackColor = Color.LightGreen;// Color.FromArgb(48, 48, 48);
                button2.ForeColor = Color.Black;
                ATSData.SystemMode = ATSData.SystemModeType.Handmode;
                OnStatusChange();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OnStatusChange != null)
            {
                ini1to3Button();
                button3.BackColor = Color.FromArgb(48, 48, 48);
                button3.ForeColor = Color.White;
                ATSData.SystemMode = ATSData.SystemModeType.Maintain;
                OnStatusChange();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OnTaskChange != null)
            {
                ini4to6Button();
                ATSData.TaskMode = ATSData.SystemTaskMode.Incold;
                OnTaskChange();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (OnTaskChange != null)
            {
                ini4to6Button();
                ATSData.TaskMode = ATSData.SystemTaskMode.Inwarm;
                OnTaskChange();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (OnTaskChange != null)
            {
                ini4to6Button();
                ATSData.TaskMode = ATSData.SystemTaskMode.Outwarm;
                OnTaskChange();
            }
        }

        private void ini4to6Button()
        {

            BtnInwarm1.FlatAppearance.BorderColor = Color.Black;
            BtnInwarm1.FlatAppearance.BorderSize = 1;
            BtnIncold1.FlatAppearance.BorderColor = Color.Black;
            BtnIncold1.FlatAppearance.BorderSize = 1;
            BtnOutwarm.FlatAppearance.BorderColor = Color.Black;
            BtnOutwarm.FlatAppearance.BorderSize = 1;
        }

        private void ini1to3Button()
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
        }

        bool Succ = false;

        private void button7_Click(object sender, EventArgs e)
        {
            PLCconnect.PLCCommon.PLC_WRITE("1014", "2", "1");
            PLCconnect.PLCCommon.PLC_WRITE("1014", "0", "1");
        }


        private void ChartChange()
        {
            List<string> xData = new List<string>() { "預支量", "剩餘量" };
            List<int> yData = new List<int>() { surplus, Advance };
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
            PLCconnect.PLCCommon.PLC_WRITE("1000", "0000", "1");
        }

        private void BtnIncold_Click(object sender, EventArgs e)
        {
            if (PLCconnect.ReadSystemStatus.PlcStatus[2])
            {
                MessageBox.Show("請先等待目前入庫作業完成", "提醒");
                return;
            }
            if (OnTaskChange != null)
            {
                ini4to6Button();
                BtnIncold1.FlatAppearance.BorderColor = Color.LightSeaGreen;
                BtnIncold1.FlatAppearance.BorderSize = 5;
                ATSData.TaskMode = ATSData.SystemTaskMode.Incold;
                StartButtonClick0();
                OnTaskChange();
            }
        }

        private void BtnOutwarm_Click(object sender, EventArgs e)
        {
            if (OnTaskChange != null)
            {
                ini4to6Button();
                BtnOutwarm.FlatAppearance.BorderColor = Color.LightSeaGreen;
                BtnOutwarm.FlatAppearance.BorderSize = 5;
                ATSData.TaskMode = ATSData.SystemTaskMode.Outwarm;
                TN.IniUserControl("倒料");
                ParentForm.Controls.Add(TN);
                ParentForm.Controls.SetChildIndex(TN, 0);
                OnTaskChange();
            }
        }

        private void Btninwarm_Click(object sender, EventArgs e)
        {
            if (OnTaskChange != null)
            {
                ini4to6Button();
                BtnInwarm1.FlatAppearance.BorderColor = Color.LightSeaGreen;
                BtnInwarm1.FlatAppearance.BorderSize = 5;
                ATSData.TaskMode = ATSData.SystemTaskMode.Inwarm;
                TN.IniUserControl("入回溫");
                ParentForm.Controls.Add(TN);
                ParentForm.Controls.SetChildIndex(TN, 0);
                OnTaskChange();
            }
        }

        private void MainTabsPanel_OnStatusChange()
        {
            switch (ATSData.SystemMode)
            {
                case ATSData.SystemModeType.Maintain:
                    LbIniStatus.BackColor = Color.SeaGreen;
                    LbAutoStatus.BackColor = Color.Transparent;
                    LbHandStatus.BackColor = Color.Transparent;
                    break;
                case ATSData.SystemModeType.Automatic:
                    LbAutoStatus.BackColor = Color.SeaGreen;
                    LbIniStatus.BackColor = Color.Transparent;
                    LbHandStatus.BackColor = Color.Transparent;
                    break;
                case ATSData.SystemModeType.Handmode:
                    LbHandStatus.BackColor = Color.SeaGreen;
                    LbIniStatus.BackColor = Color.Transparent;
                    LbAutoStatus.BackColor = Color.Transparent;
                    break;
            }
        }


        private async void CSTForm_OnAnimationUpdate(object sender, EventArgs e)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {

                var statusKey = Enum.GetName(typeof(ATSData.AutomaticModeStatusType), ATSData.AutomaticModeStatus);
                switch (ATSData.AutomaticModeStatus)
                {
                    case ATSData.AutomaticModeStatusType.Reset:
                        LbDeviceStart.BackColor = Color.White;
                        LbErrrorStatus.BackColor = Color.White;
                        LbDeviceStop.BackColor = Color.White;
                        LbDevicePause.BackColor = Color.White;
                        break;
                    case ATSData.AutomaticModeStatusType.Pause:
                        LbDevicePause.BackColor = Color.LightSeaGreen;
                        LbDeviceStop.BackColor = Color.White;
                        LbDeviceStart.BackColor = Color.White;
                        LbErrrorStatus.BackColor = Color.White;
                        break;
                    case ATSData.AutomaticModeStatusType.Run:
                        LbDeviceStart.BackColor = Color.LightSeaGreen;
                        LbErrrorStatus.BackColor = Color.White;
                        LbDeviceStop.BackColor = Color.White;
                        LbDevicePause.BackColor = Color.White;
                        break;
                    case ATSData.AutomaticModeStatusType.Stop:
                        LbDeviceStop.BackColor = Color.LightSeaGreen;
                        LbDeviceStart.BackColor = Color.White;
                        LbErrrorStatus.BackColor = Color.White;
                        LbDevicePause.BackColor = Color.White;
                        break;
                    case ATSData.AutomaticModeStatusType.Error:
                        LbErrrorStatus.BackColor = Color.LightSeaGreen;
                        LbDeviceStart.BackColor = Color.White;
                        LbDeviceStop.BackColor = Color.White;
                        LbDevicePause.BackColor = Color.White;
                        break;
                }

                switch (ATSData.SystemMode)
                {
                    case ATSData.SystemModeType.Automatic:
                        LbAutoStatus.BackColor = Color.LightSeaGreen;
                        LbIniStatus.BackColor = Color.White;
                        LbHandStatus.BackColor = Color.White;
                        break;
                    case ATSData.SystemModeType.Handmode:
                        LbHandStatus.BackColor = Color.LightSeaGreen;
                        LbAutoStatus.BackColor = Color.White;
                        LbIniStatus.BackColor = Color.White;
                        break;
                    case ATSData.SystemModeType.Maintain:
                        LbIniStatus.BackColor = Color.LightSeaGreen;
                        LbAutoStatus.BackColor = Color.White;
                        LbHandStatus.BackColor = Color.White;
                        break;
                }
            });

        }

        #region Upper
        private void Btn1002_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1002", Commont, "1");
                ResetCommand("1002");

            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void Btn1003_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1003", Commont, "1");
                System.Threading.Thread.Sleep(500);
                ResetCommand("1003");

            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void OPR_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1003", "8000", "1");
                System.Threading.Thread.Sleep(500);
                ResetCommand("1003");

            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        #region Transfer
        private void Transfer1004_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {

                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1004", Commont, "1");
                ResetCommand("1004");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void Transfer1005_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1005", Commont, "1");
                ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void TransferOPR_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1005", "8000", "1");
                System.Threading.Thread.Sleep(500);
                ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        #endregion

        #region OpenBottle
        private void OpenBottle1006_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1006", Commont, "1");
                ResetCommand("1006");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void OpenBottle1007_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1007", Commont, "1");
                ResetCommand("1007");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void OpenBottleOPR(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1007", "8000", "1");
                System.Threading.Thread.Sleep(500);
                ResetCommand("1007");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        #region Rotate
        private void Rotate1008_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1008", Commont, "1");
                System.Threading.Thread.Sleep(1000);
                ResetCommand("1008");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void Rotate1009_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1009", Commont, "1");
                ResetCommand("1009");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void RotateOPR_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1009", "8000", "1");
                System.Threading.Thread.Sleep(500);
                ResetCommand("1009");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        #region Fixture
        private void FixtureAdvence_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "1", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void FixtureBack_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "2", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void FixtureOpen_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "4", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void FixtureLock_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "8", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        #region BottleFixture
        private void BtnBFixtureAdvence_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "10", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnBFixtureBack_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "20", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnBFixtureOpen_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "40", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnBFixtureLock_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "80", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        #region TransferFixture
        private void BtnTFixtureAdvence_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "100", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnTFixtureBack_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "200", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnTFixtureOpen_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "400", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnTFixtureLock_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "800", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        #region Door / Motor
        private void BtnWarmDoorOpen_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "1000", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnWarmDoorClose_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "2000", "1");
                BtnSetBorderColor(sender);
                //System.Threading.Thread.Sleep(3000);
                //ResetCommand("1022");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnColdDoorOpen_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "4000", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnColdDoorClose_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "8000", "1");
                //System.Threading.Thread.Sleep(2000);
                BtnSetBorderColor(sender);

                //ResetCommand("1022");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        private void BtnMotorOpen_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                if (Message1023[15] == '0')
                {
                    Message1023 = Message1023.Substring(0, 15) + "1";
                }
                else
                {
                    Message1023 = Message1023.Substring(0, 15) + "0";
                }
                int message = Convert.ToInt32(Message1023, 2);

                PLCconnect.PLCCommon.PLC_WRITE("1023", message.ToString(), "1");
                //ResetCommand("1023");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }
        #endregion

        private void BtnShakeOn_Click(object Sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                if (Message1023[12] == '0')
                {
                    Message1023 = Message1023.Substring(0, 12) + "1" + Message1023.Substring(13, 3);
                }
                else
                {
                    Message1023 = Message1023.Substring(0, 12) + "0" + Message1023.Substring(13, 3);
                }
                int message = Convert.ToInt32(Message1023, 2);

                PLCconnect.PLCCommon.PLC_WRITE("1023", message.ToString(), "1");
                BtnSetBorderColor(Sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        
        }


        private string TransByteNumber(int SendNum)
        {
            string CurrentNumber = "";
            switch (SendNum)
            {
                case 0:
                    CurrentNumber = "1";
                    break;
                case 1:
                    CurrentNumber = "2";
                    break;
                case 2:
                    CurrentNumber = "4";
                    break;
                case 3:
                    CurrentNumber = "8";
                    break;
                case 4:
                    CurrentNumber = "10";
                    break;
                case 5:
                    CurrentNumber = "20";
                    break;
                case 6:
                    CurrentNumber = "40";
                    break;
                case 7:
                    CurrentNumber = "80";
                    break;
                case 8:
                    CurrentNumber = "100";
                    break;
                case 9:
                    CurrentNumber = "200";
                    break;
                case 10:
                    CurrentNumber = "400";
                    break;
                case 11:
                    CurrentNumber = "800";
                    break;
                case 12:
                    CurrentNumber = "1000";
                    break;
                case 13:
                    CurrentNumber = "2000";
                    break;
                case 14:
                    CurrentNumber = "4000";
                    break;
                case 15:
                    CurrentNumber = "8000";
                    break;
            }
            return CurrentNumber;
        }

        private void JogPlus_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1003", "2000", "1");
                // ResetCommand("1003");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }



        private void JogReduce_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode && (!PLCconnect.ReadSystemStatus.PlcStatus[2]))
            {
                PLCconnect.PLCCommon.PLC_WRITE("1003", "4000", "1");
                //ResetCommand("1003");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }



        private void TransferJogPius_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1005", "2000", "1");
                //ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void TransferJogReduce_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1005", "4000", "1");
                //ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void OpenBottleJogPius_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1007", "2000", "1");
                //ResetCommand("1007");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void OpenBottleJogReduce_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1007", "4000", "1");
                //ResetCommand("1007");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void RotateJogPlus_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1009", "2000", "1");
                //ResetCommand("1009");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void RotateJogReduce_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1009", "4000", "1");
                //ResetCommand("1009");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }




        private void TransferStop(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                //PLCconnect.PLCCommon.PLC_WRITE("1005", "8000");
                ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void UDStop(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1003", "0", "1");

            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }

        }

        private void OBStop(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1007", "0", "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void RTStop(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1009", "0", "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }




        private void PlcAlarmEvent(int Machine, string AlarmCode)
        {

            ThreadSafeHelper.UIThread(this, () =>
            {
                if (AlarmCode == "0")
                {
                    AlarmMessage.Text = "";
                }
                else
                {
                    string AlarmCodeRev = Convert.ToString(Convert.ToInt32(AlarmCode), 2);
                    AlarmCodeRev = AddZeroToStringFromOld(AlarmCodeRev);
                    //AlarmCodeRev = String.Join("", AlarmCodeRev.Select(i => i).Reverse());
                    for (int i = 0; i < AlarmCodeRev.Length; i++)
                    {
                        if (AlarmCodeRev[i] == '1')
                        {
                            if (AlarmInformation.FormOpen == false)
                            {
                                AlarmInformation.FormOpen = true;
                                
                                AlarmMessage.Text = UserData.Instance.GetErrorInformation((1530 + Machine).ToString(), i);
                                AlarmInfo.AddInfo(UserData.Instance.GetErrorInformation((1530 + Machine).ToString(), i));
                                ParentForm.Controls.Add(AlarmInfo);
                                ParentForm.Controls.SetChildIndex(AlarmInfo, 0);


                            }
                            else
                            {
                                AlarmInfo.AddInfo(ATS.Models.UserData.Instance.GetErrorInformation((1530 + Machine).ToString(), i));
                            }
                            WiseTech.Log.Logger.AlarmLog(UserData.Instance.GetErrorInformation((1530 + Machine).ToString(), i));
                        }
                    }
                }
            });
        }


        public void AlarmEvent(int Address, int Point)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                AlarmInfo = new AlarmInformation();
                if (AlarmInformation.Time == DateTime.Now.Minute)
                {
                    return;
                }
                if (AlarmInformation.FormOpen == false)
                {
                    AlarmInformation.FormOpen = true;

                    AlarmMessage.Text = UserData.Instance.GetErrorInformation((Address).ToString(), Point);
                    AlarmInfo.AddInfo(UserData.Instance.GetErrorInformation((Address).ToString(), Point));
                    ParentForm.Controls.Add(AlarmInfo);
                    ParentForm.Controls.SetChildIndex(AlarmInfo, 0);


                }
                else
                {
                    AlarmInfo.AddInfo(ATS.Models.UserData.Instance.GetErrorInformation((Address).ToString(), Point));
                }
                WiseTech.Log.Logger.AlarmLog(UserData.Instance.GetErrorInformation((Address).ToString(), Point));
            });
        }

        private string AddZeroToStringFromOld(string AlarmCode)
        {
            string ReturnWord = AlarmCode;
            for (int i = 0; i < 16 - AlarmCode.Length; i++)
            {
                ReturnWord = "0" + ReturnWord;
            }

            return ReturnWord;
        }
        private void ResetCommand(string Address)
        {
            PLCconnect.PLCCommon.PLC_WRITE(Address, "0", "1");
        }

        private void JogPlus_Click(object sender, EventArgs e)
        {

        }

        private void TransferLifiter1010_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {

                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1010", Commont, "1");
                ResetCommand("1010");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void TransferLifiter1011_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {

                Label lb = (Label)sender;
                int address = 0;
                int.TryParse(lb.Name.Substring(4, lb.Name.Length - 4), out address);
                string Commont = TransByteNumber(address % 16);
                PLCconnect.PLCCommon.PLC_WRITE("1011", Commont, "1");
                ResetCommand("1011");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LifiterJogPius_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1011", "2000", "1");
                //ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LifiterStop(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                ResetCommand("1011");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LifiterJogReduce_Click(object sender, MouseEventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1011", "4000", "1");
                //ResetCommand("1005");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LifiterOPR(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1011", "8000", "1");
                ResetCommand("1011");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void SendMachine_Down_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Btn = (Label)sender;
                if (Btn.TabIndex == 86)
                {
                    Message1023 = Message1023.Substring(0, 14) + "0" + Message1023[15];
                }

                else
                {
                    Message1023 = Message1023.Substring(0, 14) + "1" + Message1023[15];
                }
                int message = Convert.ToInt32(Message1023, 2);
                PLCconnect.PLCCommon.PLC_WRITE("1023", message.ToString(), "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void SendMachine_FixtureLock_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Lb = (Label)sender;
                if (Lb.TabIndex == 76)
                {
                    Message1023 = Message1023.Substring(0, 13) + "0" + Message1023.Substring(14, 2);
                }
                else
                {
                    Message1023 = Message1023.Substring(0, 13) + "1" + Message1023.Substring(14, 2);
                }
                int message = Convert.ToInt32(Message1023, 2);
                PLCconnect.PLCCommon.PLC_WRITE("1023", message.ToString(), "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LoadResinMotor_On_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                if (Message1023[12] == '0')
                {
                    Message1023 = Message1023.Substring(0, 12) + "1" + Message1023.Substring(13, 3);
                }
                else
                {
                    Message1023 = Message1023.Substring(0, 12) + "0" + Message1023.Substring(13, 3);
                }
                int message = Convert.ToInt32(Message1023, 2);

                PLCconnect.PLCCommon.PLC_WRITE("1023", message.ToString(), "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LbColdLock_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1704", "1", "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LbWarmLock_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1705", "1", "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LbBarcoTest_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1703", "1", "1");
                 
                PLCconnect.PLCCommon.PLC_WRITE("1703", "0", "1");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }



        private void IOIn_Selected(object sender, TabControlEventArgs e)
        {
            int a = IOIn.SelectedTab.Name.IndexOf("Output");
            if (tabControl.SelectedTab != null)
            {
                if (IOIn.SelectedTab.Name.IndexOf("Input") > -1)
                {
                    IOTable.StartLocation = 1560;
                    ioTable1.IniIOTable();
                    ioTable1.IOinfoChange();
                }
                if (IOIn.SelectedTab.Name.IndexOf("Output") > -1)
                {
                    IOTable.StartLocation = 1567;
                    ioTable2.IniIOTable();
                    ioTable2.IOinfoChange();
                }
            }

            

        }


        private void MachineStatusEvent(string SendMessage)
        {
            string ReverseIOPoint = String.Join("", SendMessage.Select(s => s).Reverse());

            LBUD_OPR.BackColor = ReverseIOPoint[8] == '1' ? Color.LightSeaGreen : Color.White;
            LBTR_OPR.BackColor = ReverseIOPoint[9] == '1' ? Color.LightSeaGreen : Color.White;
            LBBT_OPR.BackColor = ReverseIOPoint[10] == '1' ? Color.LightSeaGreen : Color.White;
            LBRT_OPR.BackColor = ReverseIOPoint[11] == '1' ? Color.LightSeaGreen : Color.White;
            LBCT_OPR.BackColor = ReverseIOPoint[12] == '1' ? Color.LightSeaGreen : Color.White;
        }


        private void StartButtonClick0()
        {
            ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Run;
            if (!ATSData.ResetOK)
            {
                MessageBox.Show("尚未初始化完成 請先初始化", "尚未初始化完成 請先初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                return;
            }

            if (PLCconnect.ReadSystemStatus.CheckIOSafty() == false)
            {
                MessageBox.Show("請先確認各手臂是否有物品或在席是否正常", "確認請求", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                System.Threading.SpinWait.SpinUntil(() => { return false; }, 2000);
            }


            //要確定所有設備Reset完成沒有Alarm才能開始
            if (AlarmManager.IsAlarm)
            {
                MessageBox.Show("設備仍有錯誤未清除請先排除錯誤後再按開始", "設備仍有錯誤未清除請先排除錯誤後再按開始", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Error;
                return;
            }

            switch (ATSData.SystemMode)
            {
                case ATSData.SystemModeType.Handmode:
                    //Maintain模式不能按Start
                    MessageBox.Show("請先切換為Auto模式後才能啟動", "請先切換為Auto模式後才能啟動", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ATSData.AutomaticModeStatus = ATSData.AutomaticModeStatusType.Stop;
                    ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                    System.Threading.SpinWait.SpinUntil(() => { return false; }, 2000);
                    break;
                default:

                    if (AppData.Debug)
                    {
                        ATSData.AutomaticModeStatus = (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Run) ? ATSData.AutomaticModeStatusType.Pause :
                                                    (ATSData.AutomaticModeStatus == ATSData.AutomaticModeStatusType.Pause) ? ATSData.AutomaticModeStatusType.Run :
                                                    ATSData.AutomaticModeStatusType.Run;
                        return;
                    }

                    if (ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Busy)
                    {
                        switch (ATSData.AutomaticModeStatus)
                        {
                            case ATSData.AutomaticModeStatusType.Pause:
                                PLCconnect.WriteSystem.WriteSystemPause();
                                break;
                            case ATSData.AutomaticModeStatusType.Run:
                                PLCconnect.WriteSystem.WriteSystemPause();
                                break;
                            case ATSData.AutomaticModeStatusType.Stop:
                                PLCconnect.WriteSystem.WriteSystemStop();
                                break;
                            default:
                                MessageBox.Show("異常中/初始化中不可開始", "異常中/初始化中不可開始", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                System.Threading.SpinWait.SpinUntil(() => { return false; }, 2000);
                                //System.Threading.Thread.Sleep(2000);
                                break;
                        }
                    }

                    //只有系統目前是暫停、執行、停止 這三種狀態才能按開始
                    else if (ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Init || ATSData.MaintainModeStatus == ATSData.MaintainModeStatusType.Idle)
                    {
                        switch (ATSData.AutomaticModeStatus)
                        {
                            case ATSData.AutomaticModeStatusType.Pause:

                                break;
                            case ATSData.AutomaticModeStatusType.Run:
                                switch (ATSData.TaskMode)
                                {
                                    case ATSData.SystemTaskMode.Incold:
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Busy;
                                        BarcoReaderFrm.BarcoFrmClear();
                                        ParentForm.Controls.Add(BarcoReaderFrm);
                                        ParentForm.Controls.SetChildIndex(BarcoReaderFrm, 0);
                                        ATSData.MaintainModeStatus = ATSData.MaintainModeStatusType.Init;
                                        if (TaskStart != null)
                                        {
                                            TaskStart();
                                        }
                                        break;
                                }
                                break;
                            case ATSData.AutomaticModeStatusType.Stop:
                                break;
                            default:
                                MessageBox.Show("異常中/初始化中不可開始", "異常中/初始化中不可開始", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                System.Threading.SpinWait.SpinUntil(() => { return false; }, 2000);
                                break;
                        }
                    }

                    break;
            }
        }
        List<Label> SetLabels = new List<Label>();
        private void BtnChangeLocation_Click(object sender, EventArgs e)
        {
            SetLabelIni();
            if (UserData.Instance.Now.Level < 4)
            { MessageBox.Show("目前操作者權限不足，請登入更高權限的使用者","權限提醒"); }
            else
            {
                if (!StartChangeLocaion)
                {
                    foreach (Label lb in SetLabels)
                    {
                        lb.Visible = true;
                    }
                    BtnChangeLocation.Text = "設定完成";
                    StartChangeLocaion = true;
                }

                else
                {
                    foreach (Label lb in SetLabels)
                    {
                        lb.Visible = false;
                    }
                    BtnChangeLocation.Text = "開啟校正點位";
                    StartChangeLocaion = false;
                }
            }
        }

        private void SetLabelIni()
        {
            SetLabels.Clear();
            SetLabels.Add(UDSet0);
            SetLabels.Add(UDSet1);
            SetLabels.Add(UDSet10);
            SetLabels.Add(UDSet12);
            SetLabels.Add(UDSet13);
            SetLabels.Add(UDSet14);
            SetLabels.Add(UDSet15);
            SetLabels.Add(UDSet16);
            SetLabels.Add(UDSet18);
            SetLabels.Add(UDSet19);
            SetLabels.Add(UDSet2);
            SetLabels.Add(UDSet3);
            SetLabels.Add(UDSet4);
            SetLabels.Add(UDSet5);
            SetLabels.Add(UDSet6);
            SetLabels.Add(UDSet7);
            SetLabels.Add(UDSet8);
            SetLabels.Add(UDSet9);

            SetLabels.Add(RtSet1);
            SetLabels.Add(RtSet2);
            SetLabels.Add(RtSet3);
            SetLabels.Add(RtSet4);

            SetLabels.Add(TFSet1);
            SetLabels.Add(TFSet2);

            SetLabels.Add(LFSet1);
            SetLabels.Add(LFSet2);
        }

        private void UDSet_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Model = (Label)sender;

                if (MessageBox.Show("確認要設定此點位嗎?", "再次確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int address = 0;
                    int.TryParse(Model.Name.Substring(5, Model.Name.Length - 5), out address);
                    string Commont = TransByteNumber(address % 16);
                    PLCconnect.PLCCommon.PLC_WRITE("1012", Commont, "1");
                    ResetCommand("1012");
                }
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void RTSet_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Model = (Label)sender;
                if (MessageBox.Show("確認要設定此點位嗎?", "再次確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int address = 0;
                    int.TryParse(Model.Name.Substring(5, Model.Name.Length - 5), out address);
                    string Commont = TransByteNumber(address % 16);
                    PLCconnect.PLCCommon.PLC_WRITE("1018", Commont, "1");
                    ResetCommand("1018");
                }
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void TFSet_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Model = (Label)sender;
                if (MessageBox.Show("確認要設定此點位嗎?", "再次確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int address = 0;
                    int.TryParse(Model.Name.Substring(5, Model.Name.Length - 5), out address);
                    string Commont = TransByteNumber(address % 16);
                    PLCconnect.PLCCommon.PLC_WRITE("1014", Commont, "1");
                    ResetCommand("1014");
                }
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LFSet_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Model = (Label)sender;
                if (MessageBox.Show("確認要設定此點位嗎?", "再次確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int address = 0;
                    int.TryParse(Model.Name.Substring(5, Model.Name.Length - 5), out address);
                    string Commont = TransByteNumber(address % 16);
                    PLCconnect.PLCCommon.PLC_WRITE("1020", Commont, "1");
                    ResetCommand("1020");
                }
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void Other_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                if (MessageBox.Show("確認要設定此點位嗎?", "再次確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PLCconnect.PLCCommon.PLC_WRITE("1013", "1", "1");
                    ResetCommand("1013");
                }

            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void SetLocation1013_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                Label Model = (Label)sender;

                if (MessageBox.Show("確認要設定此點位嗎?", "再次確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int address = 0;
                    int.TryParse(Model.Name.Substring(5, Model.Name.Length - 5), out address);
                    string Commont = TransByteNumber(address % 16);
                    PLCconnect.PLCCommon.PLC_WRITE("1013", Commont, "1");
                    ResetCommand("1013");
                }
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LbAutoStatus_Click(object sender, EventArgs e)
        {
            ATSData.SystemMode = ATSData.SystemModeType.Automatic;
            OnStatusChange();
            BtnIncold1.BackColor = Color.SpringGreen;
        }

        private void LbHandStatus_Click(object sender, EventArgs e)
        {
            ATSData.SystemMode = ATSData.SystemModeType.Handmode;
            OnStatusChange();
            BtnIncold1.BackColor = Color.White;
        }




        private void MachineLocationEvent(int Point, string Information)
        {
            string ReverseIOPoint = String.Join("", Information.Select(s => s).Reverse());
            switch (Point)
            { 
                case 1:
                    for (int i = 0; i < ReverseIOPoint.Length; i++)
                    {
                        UDMZ[i].BackColor = ReverseIOPoint[i] == '1' ? Color.LightSeaGreen : Color.Transparent;
                    }
                    break;

                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        UDMZ[i+16].BackColor = ReverseIOPoint[i] == '1' ? Color.LightSeaGreen : Color.Transparent;
                    }
                    break;

                case 3:
                    for (int i = 1; i < TFLC.Count+1; i++)
                    {
                        TFLC[i].BackColor = ReverseIOPoint[i] == '1' ? Color.LightSeaGreen : Color.Transparent;
                    }
                    break;
                case 5:
                    for (int i = 1; i < RTLC.Count+1; i++)
                    {
                        RTLC[i].BackColor = ReverseIOPoint[i] == '1' ? Color.LightSeaGreen : Color.Transparent;
                    }
                    break;
                case 6:
                    for (int i = 1; i < LFLC.Count+1; i++)
                    {
                        LFLC[i].BackColor = ReverseIOPoint[i] == '1' ? Color.LightSeaGreen : Color.Transparent;
                    }
                    break;
            }
        }


        private void BtnSetBorderColor(object sender)
        {
            List<Button> HaveChangeBtn = BtnList.Where(u => u.FlatAppearance.BorderColor != Color.Black).ToList();

            for (int i = 0; i < HaveChangeBtn.Count; i++)
            {
                HaveChangeBtn[i].FlatAppearance.BorderColor = Color.Black;
                HaveChangeBtn[i].FlatAppearance.BorderSize = 2;
            }
            Button Btn = (Button)sender;
            Btn.FlatAppearance.BorderColor = Color.FromArgb(237,28,36);
            Btn.FlatAppearance.BorderSize = 4;
        }

        private void IOInputEvent(int Location,string Message)
        {
            string RevStr = String.Join("", Message.Select(s => s).Reverse());
            if (Location == 0)
            {
                #region 主夾爪
                if (RevStr[8] == '1')
                {
                    BtnFixtureBack.BackColor = Color.LightSeaGreen;
                    BtnFixtureAdvence.BackColor = Color.Transparent;
                }
                else if (RevStr[9] == '1')
                {
                    BtnFixtureBack.BackColor = Color.Transparent;
                    BtnFixtureAdvence.BackColor = Color.LightSeaGreen;
                }

                else
                {
                    BtnFixtureBack.BackColor = Color.Transparent;
                    BtnFixtureAdvence.BackColor = Color.Transparent;
                }


                
                if (RevStr[10] == '1')
                {
                    BtnFixtureOpen.BackColor = Color.LightSeaGreen;
                    BtnFixtureLock.BackColor = Color.Transparent;
                }
                else if (RevStr[11] == '1')
                {
                    BtnFixtureOpen.BackColor = Color.Transparent;
                    BtnFixtureLock.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    BtnFixtureOpen.BackColor = Color.Transparent;
                    BtnFixtureLock.BackColor = Color.Transparent;
                }
                #endregion
                #region 開蓋夾爪
                if (RevStr[12] == '1')
                {
                    BtnBFixtureAdvence.BackColor = Color.LightSeaGreen;
                    BtnBFixtureBack.BackColor = Color.Transparent;
                }
                else if (RevStr[13] == '1')
                {
                    BtnBFixtureAdvence.BackColor = Color.Transparent;
                    BtnBFixtureBack.BackColor = Color.LightSeaGreen;
                }

                else
                {
                    BtnBFixtureAdvence.BackColor = Color.Transparent;
                    BtnBFixtureBack.BackColor = Color.Transparent;
                }



                if (RevStr[14] == '1')
                {
                    BtnBFixtureOpen.BackColor = Color.LightSeaGreen;
                    BtnBFixtureLock.BackColor = Color.Transparent;
                }
                else if (RevStr[15] == '1')
                {
                    BtnBFixtureOpen.BackColor = Color.Transparent;
                    BtnBFixtureLock.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    BtnBFixtureOpen.BackColor = Color.Transparent;
                    BtnBFixtureLock.BackColor = Color.Transparent;
                }
                #endregion
            }
            else if(Location == 1)
            {
                #region 移載夾爪
                if (RevStr[0] == '1')
                {
                    BtnTFixtureOpen.BackColor = Color.LightSeaGreen;
                    BtnTFixtureLock.BackColor = Color.Transparent;
                }
                else if (RevStr[1] == '1')
                {
                    BtnTFixtureOpen.BackColor = Color.Transparent;
                    BtnTFixtureLock.BackColor = Color.LightSeaGreen;
                }

                else
                {
                    BtnTFixtureOpen.BackColor = Color.Transparent;
                    BtnTFixtureLock.BackColor = Color.Transparent;
                }



                if (RevStr[2] == '1')
                {
                    BtnTFixtureAdvence.BackColor = Color.LightSeaGreen;
                    BtnTFixtureBack.BackColor = Color.Transparent;
                }
                else if (RevStr[3] == '1')
                {
                    BtnTFixtureAdvence.BackColor = Color.Transparent;
                    BtnTFixtureBack.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    BtnTFixtureAdvence.BackColor = Color.Transparent;
                    BtnTFixtureBack.BackColor = Color.Transparent;
                }
                #endregion
                #region 冷凍回溫庫
                if (RevStr[4] == '1')
                {
                    BtnWarmDoorOpen.BackColor = Color.LightSeaGreen;
                    BtnWarmDoorClose.BackColor = Color.Transparent;
                }
                else if (RevStr[5] == '1')
                {
                    BtnWarmDoorOpen.BackColor = Color.Transparent;
                    BtnWarmDoorClose.BackColor = Color.LightSeaGreen;
                }

                else
                {
                    BtnWarmDoorOpen.BackColor = Color.Transparent;
                    BtnWarmDoorClose.BackColor = Color.Transparent;
                }



                if (RevStr[6] == '1')
                {
                    BtnColdDoorOpen.BackColor = Color.LightSeaGreen;
                    BtnColdDoorClose.BackColor = Color.Transparent;
                }
                else if (RevStr[7] == '1')
                {
                    BtnColdDoorOpen.BackColor = Color.Transparent;
                    BtnColdDoorClose.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    BtnColdDoorOpen.BackColor = Color.Transparent;
                    BtnColdDoorClose.BackColor = Color.Transparent;
                }
                #endregion
            }


            else if (Location == 3)
            {
                if (RevStr[10] == '1')
                {
                    SendMachine_UDUp.BackColor = Color.LightSeaGreen;
                    SendMachine_UD.BackColor = Color.Transparent;
                }
                else if (RevStr[11] == '1')
                {
                    SendMachine_UDUp.BackColor = Color.Transparent;
                    SendMachine_UD.BackColor = Color.LightSeaGreen;
                }

                else
                {
                    SendMachine_UDUp.BackColor = Color.Transparent;
                    SendMachine_UD.BackColor = Color.Transparent;
                }



                if (RevStr[12] == '1')
                {
                    SendMachine_LO.BackColor = Color.LightSeaGreen;
                    SendMachine_Lock.BackColor = Color.Transparent;
                }
                else if (RevStr[13] == '1')
                {
                    SendMachine_LO.BackColor = Color.Transparent;
                    SendMachine_Lock.BackColor = Color.LightSeaGreen;
                }
                else
                {
                    SendMachine_LO.BackColor = Color.Transparent;
                    SendMachine_Lock.BackColor = Color.Transparent;
                }
            }
           
        }

        private void LabelLoadPort_Click(object sender, EventArgs e)
        {
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GBUD.Visible = true;
        }

        private void LabelRotage_Click(object sender, EventArgs e)
        {
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GbRt.Visible = true;
        }

        private void LabelStore_Click(object sender, EventArgs e)
        {
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GbStore.Visible = true;
            GbStoreLock.Visible = true;
        }

        private void LabelOpenBottle_Click(object sender, EventArgs e)
        {
            
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GbOB.Visible = true;
        }

        private void LabelWeight_Click(object sender, EventArgs e)
        {
            
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GbWeight.Visible = true;
            GbMain.Visible = true;
        }

        private void LabelTF_Click(object sender, EventArgs e)
        {
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GbTF.Visible = true;
            GbTFLock.Visible = true;
        }

        private void LabelLF_Click(object sender, EventArgs e)
        {
            GbList.ForEach(u => u.Visible = false);
            LbList.ForEach(u => u.BackColor = Color.Black);
            (sender as Label).BackColor = Color.SeaGreen;
            GbLF.Visible = true;
            GbLBF.Visible = true;
        }

        private void TFWait_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {

                PLCconnect.PLCCommon.PLC_WRITE("1010", "2", "1");
                ResetCommand("1010");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void BtnOBWait_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1022", "20", "1");
                ResetCommand("1022");
                BtnSetBorderColor(sender);
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LabelRtWait_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {
                PLCconnect.PLCCommon.PLC_WRITE("1008", "2", "1");
                System.Threading.Thread.Sleep(1000);
                ResetCommand("1008");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void LabelTFWait_Click(object sender, EventArgs e)
        {
            if (ATSData.SystemMode == ATSData.SystemModeType.Handmode)
            {

                PLCconnect.PLCCommon.PLC_WRITE("1004", "2", "1");
                SpinWait.SpinUntil(() => { return false; }, 2000);
                ResetCommand("1004");
            }
            else
            {
                MessageBox.Show("請先切換手動模式", "作業提醒");
                return;
            }
        }

        private void resinStore1_Load(object sender, EventArgs e)
        {

        }
    }
}
