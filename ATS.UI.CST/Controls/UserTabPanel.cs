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

namespace ATS.UI.CST.Controls
{
	public partial class UserTabPanel : UserControl, IComponent
	{
		private ATSCore core;
		private UserData userData;
		private ImageList imageListUser = new ImageList();

		private NumberInputPanel inputPanel = new NumberInputPanel();
		public UserTabPanel()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{
				core = ATSCore.Instance;
				userData = UserData.Instance;
				Load += UserTabPanel_Load;
			}
		}

		private void UserTabPanel_Load(object sender, EventArgs e)
		{
			userData.OnRefreshed += UserData_OnRefreshed;
			userData.Refresh();
			userData.RefreshGroups();

			imageListUser.ImageSize = new Size(128, 128);

			listView.View = View.LargeIcon;
			listView.LargeImageList = imageListUser;

			RefershListViewItems();

			listView.Scrollable = true;
			listView.Click += ListView_Click;


			comboBoxUserInfoGroupName.DataSource = userData.Groups;
			comboBoxUserInfoGroupName.DisplayMember = "Name";
			comboBoxUserInfoGroupName.ValueMember = "ID";

			comboBoxAddUserGroupName.DataSource = userData.Groups;
			comboBoxAddUserGroupName.DisplayMember = "Name";
			comboBoxAddUserGroupName.ValueMember = "ID";

			textBoxAddUserPassword.Click += TextBoxAddUserPassword_Click;
		}

		private void ListView_Click(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count == 1)
			{
				var ID = listView.SelectedItems[0].Text;
				var userInfo = userData.UserInfo(ID);
				textBoxUserInfoID.Text = userInfo.Name;
				comboBoxUserInfoGroupName.SelectedValue = userInfo.Group.ID;
				textboxUserInfoTabsAvailable.Text = string.Join(",", userInfo.Group.TabsAvailable);
			}
		}

		private void TextBoxAddUserPassword_Click(object sender, EventArgs e)
		{
			SuspendLayout();

			inputPanel.SetTarget(textBoxAddUserPassword);

			ResumeLayout();
		}

		private void UserData_OnRefreshed(object sender, EventArgs e)
		{
			RefershListViewItems();
		}

		private void RefershListViewItems()
		{
			var users = userData.Users;

			listView.BeginUpdate();

			//ListView中的每個使用者ID
			listView.Items.Clear();
			//ListView中的每個使用者圖示
			imageListUser.Images.Clear();

			int index = 0;
			foreach (var item in users)
			{
				listView.Items.Add(new ListViewItem
				{
					ImageIndex = index++,
					Text = item.Name,
				});
				imageListUser.Images.Add(UserGroup.Icons[item.Group.ID]);
			}

			listView.EndUpdate();
		}


		private void buttonAddUserCreate_Click(object sender, EventArgs e)
		{
			string id = textBoxAddUserID.Text;
			string password = textBoxAddUserPassword.Text;
			string groupID = comboBoxAddUserGroupName.SelectedValue.ToString();
			if (textBoxAddUserID.Text.Length > 0)
			{
				if (textBoxAddUserPassword.Text.Length > 0)
				{
					userData.NewUser(id, password, groupID);

					textBoxAddUserID.Text = "";
					textBoxAddUserPassword.Text = "";
				}
			}
		}

		private void buttonUserInfoDelete_Click(object sender, EventArgs e)
		{
			string id = textBoxUserInfoID.Text;

			if (userData.DeleteUser(id))
			{
				textBoxUserInfoID.Text = "";
				textboxUserInfoTabsAvailable.Text = "";
				comboBoxUserInfoGroupName.SelectedValue = "1";
			}
			else
			{
				MessageBox.Show("操作失敗");
			}
		}

		private void buttonAddUserCancel_Click(object sender, EventArgs e)
		{
			textBoxAddUserID.Text = "";
			textBoxAddUserPassword.Text = "";
			comboBoxAddUserGroupName.SelectedValue = "1";
		}

		private void buttonUserInfoUpeate_Click(object sender, EventArgs e)
		{
			string id = textBoxUserInfoID.Text;
			string groupID = comboBoxUserInfoGroupName.SelectedValue.ToString();
			userData.UpdateUser(id, groupID);

			textboxUserInfoTabsAvailable.Text = string.Join(",", userData.UserInfo(id).Group.TabsAvailable);
		}
	}
}
