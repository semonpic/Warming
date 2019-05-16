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
	public partial class ManageUserGroupTabPanel : UserControl, IComponent
	{
		private ATSCore core;
		private UserData userData;
		private ImageList imageListUserGroup = new ImageList();

		private ImageList imageListTab = new ImageList();
		private static Image tabsIcon;//{ get { return Image.FromFile(ATSCore.exePath + "images/green_folder.png");  } }

		private ListViewItem lastSelectTab;
		private string lastSelectGroupName = "";
		public ManageUserGroupTabPanel()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{
				core = ATSCore.Instance;
				userData = UserData.Instance;
				Load += UserTabPanel_Load;
				tabsIcon = Image.FromFile(AppData.exePath + "images/Icon_GreenFolder.png");

				Language.Bind("ManageUserGroupTabPanel.Allow", labelAllow);
				Language.Bind("ManageUserGroupTabPanel.Deny", labelDeny);
                Language.Bind("ManageUserGroupTabPanel.UserGroupList", labelUserGroupList);
                Language.Bind("ManageUserGroupTabPanel.UserGroupInfo", labellabelUserGroupInfo);
                Language.Bind("ManageUserGroupTabPanel.UserGroupHelp", labelUserGroupHelp);
                Language.Bind("ManageUserGroupTabPanel.GroupName", labelGroupName);
                Language.Bind("ManageUserGroupTabPanel.GroupPermission", labelGroupPermission);
                Language.Bind("ManageUserGroupTabPanel.UserGroupHelpText", textBoxUserGroupHelp);





                            }
        }

		private void UserTabPanel_Load(object sender, EventArgs e)
		{
			userData.OnRefreshed += UserData_OnRefreshed;
			userData.RefreshGroups();

			imageListUserGroup.ImageSize = new Size(128, 128);

			listView.View = View.LargeIcon;
			listView.LargeImageList = imageListUserGroup;
			listView.Scrollable = true;
			listView.Click += ListView_Click;

			RefershListViewItems();


			imageListTab.ImageSize = new Size(96, 96);
			imageListTab.Images.Add(tabsIcon);

			listViewEnable.LargeImageList = imageListTab;
			listViewEnable.View = View.LargeIcon;
			listViewEnable.Scrollable = true;
			listViewEnable.Click += ListViewEnable_Click;

			listViewDisable.LargeImageList = imageListTab;
			listViewDisable.View = View.LargeIcon;
			listViewDisable.Scrollable = true;
			listViewDisable.Click += ListViewEnable_Click;

		}

		private void ListView_Click(object sender, EventArgs e)
		{
			SuspendLayout();

			string GroupName = "";
			if (listView.SelectedItems.Count == 1)
			{
				GroupName = listView.SelectedItems[0].Text;
				var seletedGroup = userData.GroupInfo(GroupName);
				var tabsKey = core.TabsKey;

				listViewEnable.BeginUpdate();
				listViewDisable.BeginUpdate();

				listViewEnable.Clear();
				listViewDisable.Clear();
				foreach (var item in tabsKey)
				{
					if (seletedGroup.TabsAvailable.Contains(item))
					{
						listViewEnable.Items.Add(new ListViewItem
						{
							ImageIndex = 0,
							Text = item,
						});

					}
					else
					{
						listViewDisable.Items.Add(new ListViewItem
						{
							ImageIndex = 0,
							Text = item,
						});

					}
				}
				listViewEnable.EndUpdate();
				listViewDisable.EndUpdate();
			}
			textBoxUserGroupName.Text = GroupName;
			lastSelectGroupName = GroupName;


			ResumeLayout();
		}

		private void ListViewEnable_Click(object sender, EventArgs e)
		{
			ListView _listView = sender as ListView;

			if (_listView.SelectedItems.Count == 1)
			{
				lastSelectTab = _listView.SelectedItems[0];
				labelSeletedTabName.Text = Language.Text("Tabs." + lastSelectTab.Text);
			}
		}
		private void UserData_OnRefreshed(object sender, EventArgs e)
		{
			RefershListViewItems();
		}

		private void RefershListViewItems()
		{
			var groups = userData.Groups;

			listView.BeginUpdate();

			//ListView中的每個使用者ID
			listView.Items.Clear();
			//ListView中的每個使用者圖示
			imageListUserGroup.Images.Clear();

			int index = 0;
			//
			foreach (var item in groups.Where(g => g.ID != UserGroup.Developer))
			{
				var groupName = item.Name;
				var groupID = item.ID;

				listView.Items.Add(new ListViewItem
				{
					ImageIndex = index++,
					Text = item.Name,
				});
				imageListUserGroup.Images.Add(UserGroup.Icons[item.ID]);

			}

			listView.EndUpdate();
		}

		private void buttonDisable_Click(object sender, EventArgs e)
		{

			if (lastSelectTab != null)
			{
				if (listViewEnable.Items.Contains(lastSelectTab))
				{
					listViewEnable.Items.Remove(lastSelectTab);
					listViewDisable.Items.Add(lastSelectTab);
					lastSelectTab = null;
					labelSeletedTabName.Text = "";
					UpdateGroupTabsAvailable();
				}
			}

		}

		private void buttonEnable_Click(object sender, EventArgs e)
		{
			if (lastSelectTab != null)
			{
				if (listViewDisable.Items.Contains(lastSelectTab))
				{
					listViewDisable.Items.Remove(lastSelectTab);
					listViewEnable.Items.Add(lastSelectTab);
					lastSelectTab = null;
					labelSeletedTabName.Text = "";
					UpdateGroupTabsAvailable();
				}
			}
		}
		private void UpdateGroupTabsAvailable()
		{
			List<string> tabsAvailable = new List<string>();
			foreach (var item in listViewEnable.Items)
			{
				tabsAvailable.Add((item as ListViewItem).Text);
			}
			var strTabsAvailable = string.Join(",", tabsAvailable);

			userData.UpdateGroup(lastSelectGroupName, strTabsAvailable);
		}
	}
}
