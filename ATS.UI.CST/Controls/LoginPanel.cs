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
using R100Test;
using PLCconnect;
using System.Text.RegularExpressions;

namespace ATS.UI.CST.Controls
{
	public partial class LoginPanel : UserControl
	{
		const int HEIGHT_NORMAL = 300;
		const int HEIGHT_ERROR = 360;

       
		private UserData userData;
		private string id = "";
		private string password = "";
        frmIrisOperator Iris = new frmIrisOperator();

		public LoginPanel()
		{
			InitializeComponent();
            frmIrisOperator.OnIrisLoginSuccess += new Action<string>(frmIrisOperator_OnIrisLoginSuccess);
			if (AppData.IsRuntime)
			{

				userData = UserData.Instance;
				userData.OnLogin += UserData_OnPowerChange;
				userData.OnLoginFailed += UserData_OnPowerChange;

				Language.Bind("LoginPanel.LoginFail", labelError);
				Language.Bind("LoginPanel.Title", labelTitle);
				Language.Bind("LoginPanel.User", labelUser);
				Language.Bind("LoginPanel.Password", labelPassowrd);
				Language.Bind("LoginPanel.Power", labelPower);
				Language.Bind("LoginPanel.Login", buttonLogin);
				Language.Bind("LoginPanel.Cancel", buttonCancel);

				Load += LoginPanel_Load;
			}

			showError(false);
           
		}

		private void LoginPanel_Load(object sender, EventArgs e)
		{
			//core.OnPowerChange += Core_OnPowerChange;
			userData.OnRefreshed += User_OnRefreshed;
			userData.Refresh();
			
			SuspendLayout();
			
			comboBoxUsers.Click += ComboBoxUsers_Click;
			comboBoxUsers.SelectedValueChanged += ComboBoxUsers_SelectedValueChanged;

			textBoxPassword.TextChanged += TextBoxPassword_TextChanged;
			textBoxPassword.Click += TextBoxPassword_Click;

			Left = (Parent.Width - Width) >> 1;
			Top = 32;

			comboBoxUsers.DataSource = userData.UserNames;

			UpdatePowerText();

            Iris.goidentify();

            ResumeLayout();

			Language.OnRefreshed += Language_OnRefreshed;

			showError(false);

		}

		private void UserData_OnPowerChange(object sender, EventArgs e)
		{
			if (userData.IsLogin)
			{
				Parent.Controls.Remove(this);
				textBoxPassword.Text = "";
			}
			showError(!userData.IsLogin);
		}

		private void ComboBoxUsers_Click(object sender, EventArgs e)
		{
			comboBoxUsers.DroppedDown = true;
			showError(false);
		}

		private void TextBoxPassword_TextChanged(object sender, EventArgs e)
		{
			password = textBoxPassword.Text;
		}
		private void User_OnRefreshed(object sender, EventArgs e)
		{
			comboBoxUsers.DataSource = userData.UserNames;
			UpdatePowerText();
		}
		private void ComboBoxUsers_SelectedValueChanged(object sender, EventArgs e)
		{
			UpdatePowerText();
		}
		private void Language_OnRefreshed(object sender, EventArgs e)
		{
			UpdatePowerText();
		}
		private void UpdatePowerText()
		{
			id = comboBoxUsers.SelectedValue.ToString();

			labelUserPower.Text = Language.Text("LoginPanel.Power") + " [ " + userData.UserInfo(id).Power + " ]";
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
            try
            {
                userData.Login(id, password);
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
        }

		private void buttonCancel_Click(object sender, EventArgs e)
		{
            try
            {
                Parent.Controls.Remove(this);
                textBoxPassword.Text = "";
                showError(false);
            }
            catch (Exception err)
            {
                ATS.LCSCommon.WriteRunLog(err.Message);
            }
		}


		private void TextBoxPassword_Click(object sender, EventArgs e)
		{
			SuspendLayout();
			showError(false);
            ResumeLayout();
		}
		private void showError(bool show)
		{
			if (show)
			{
				Height = HEIGHT_ERROR;

			}
			else
			{
				Height = HEIGHT_NORMAL;

			}
		}

        private void frmIrisOperator_OnIrisLoginSuccess(string Name)
        {
            userData.IrisLogin(Name);
        }

    }
}
