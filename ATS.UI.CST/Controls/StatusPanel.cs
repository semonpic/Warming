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
using ATS.UI.CST.Forms;
using ATS.Data;
using PLCconnect;

namespace ATS.UI.CST.Controls
{
	public partial class StatusPanel : UserControl
	{


		private LoginPanel loginPanel = new LoginPanel();
		public StatusPanel()
		{
			InitializeComponent();

			if (AppData.IsRuntime)
			{
				Language.OnRefreshed += Language_OnRefreshed;
				UserData.Instance.OnLogin += Instance_OnLogin;
				UserData.Instance.OnLoginFailed += Instance_OnLoginFailed;
                PLCconnect.ReadSystemStatus.ColdBottleChangeNum += new Action<byte>(ColdBottleChangeNum);
                PLCconnect.ReadSystemStatus.WarmBottleChangeNum += new Action<byte>(WarmBottleChangeNum);
                PLCconnect.ReadSystemStatus.PLCStatusChange += new Action<bool>(PLCStatusChange);


				RefreshStatus();
                
				Language.Bind("StatusPanel.RunMode", labelRunMode);
				Language.Bind("StatusPanel.Recipe", labelView1Recipe);
				Language.Bind("StatusPanel.Power", labelPower);
				Language.Bind("StatusPanel.View1", labelView1);
				Language.Bind("StatusPanel.View2", labelView2);
				Language.Bind("StatusPanel.Loadport1", labelLoadport1);
				Language.Bind("StatusPanel.Loadport2", labelLoadport2);
                Language.Bind("StatusPanel.labelColdNum", labelColdNum);
                Language.Bind("StatusPanel.LbWarmNum", LabelWarmNum);
                //Language.Bind("StatusPanel.LbColdNum", LbColdNum);
                //Language.Bind("StatusPanel.LbWarmNum", LbWarmNum);
                PLCconnect.ReadSystemStatus.IOInputAutoOrMaintain += IOInputAutoOrMaintain;


             
			}

		}

		private void CSTForm_OnAnimationUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				RefreshStatus();
			});
		}

		private void RefreshStatus()
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				var systemStatusKey =  Enum.GetName(typeof(ATSData.SystemModeType), ATSData.SystemMode);
                if (systemStatusKey == "Handmode")
                    systemStatusKey = "Maintain";
                labelRunModeStatus.Text = systemStatusKey;//"OFFLineMode";

                systemStatusKey = Enum.GetName(typeof(ATSData.SystemTaskMode), ATSData.TaskMode);
                labelView1RecipeStatus.Text = systemStatusKey;

            });
		}

		private void Instance_OnTransportModeChenged(object sender, EventArgs e)
		{
			RefreshStatus();
		}

		private void Instance_OnSystemModeChenged(object sender, EventArgs e)
		{
			RefreshStatus();
		}

		private void Instance_OnLoginFailed(object sender, EventArgs e)
		{
			RefreashLoginButtonText();
		}

		private void Instance_OnLogin(object sender, EventArgs e)
		{
			RefreashLoginButtonText();
		}

		private void Language_OnRefreshed(object sender, EventArgs e)
		{
			RefreashLoginButtonText();
		}
		private void RefreashLoginButtonText()
		{
			buttonLogin.Text = UserData.Instance.IsLogin ? Language.Text("StatusPanel.Logout") : Language.Text("StatusPanel.Login");

			var user = UserData.Instance.Now;
			if (UserData.Instance.IsLogin)
			{
				labelUserName.Text = user.GroupName + " [ " + user.Power + " ] " + user.Name;
			}
			else
			{
				labelUserName.Text = Language.Text("User");
			}
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			if (UserData.Instance.IsLogin)
			{
				UserData.Instance.Logout();
				RefreashLoginButtonText();
				return;
			}
			ParentForm.Controls.Add(loginPanel);
			ParentForm.Controls.SetChildIndex(loginPanel, 0);
            
		}


		//打開選擇Recipe 的視窗
		private void labelView1RecipeStatus_Click(object sender, EventArgs e)
		{
		}

        private void labelView2_Click(object sender, EventArgs e)
        {

        }

        private void StatusPanel_Load(object sender, EventArgs e)
        {
            MainTabsPanel.OnStatusChange += new Action(MainTabsPanel_OnStatusChange);
            MainTabsPanel.OnTaskChange += new Action(MainTabsPanel_OnStatusChange);
        }

        private void CSTForm_OnStatusChange()
        {
            RefreshStatus();
        }
        private void MainTabsPanel_OnStatusChange()
        
        {
            RefreshStatus();
        }


        private void ColdBottleChangeNum(byte Num)
        {
            ThreadSafeHelper.UIThread(this, () =>
                {
                    LbColdNum.Text = Num.ToString();
                });
        }

        private void WarmBottleChangeNum(byte Num)
        {
            ThreadSafeHelper.UIThread(this, () =>
                {
                    LbWarmNum.Text = Num.ToString();
                });
        }
        private void PLCStatusChange(bool Status)
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                if (Status == true)
                {
                    labelView1Mode.Text = "ONLINE";
                }
                else
                {
                    labelView1Mode.Text = "OFFLINE";
                }
            });
        }


        private void IOInputAutoOrMaintain()
        {
            ThreadSafeHelper.UIThread(this, () =>
            {
                labelRunModeStatus.Text = MachineMode() ? "Automatic" : "Maintain";
                ATSData.SystemMode = MachineMode() ? ATSData.SystemModeType.Automatic : ATSData.SystemModeType.Handmode;
            });
            
        }

        private static bool MachineMode()
        {
            return ReadSystemStatus.IOInputStatus[0][15] == '1';
        }
        
    }
}
