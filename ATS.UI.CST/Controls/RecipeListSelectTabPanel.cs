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
using ATS.Devices;
using ViewMM;

namespace ATS.UI.CST.Controls
{
	public partial class RecipeListSelectTabPanel : UserControlBase
	{
		public RecipeListSelectTabPanel()
		{
			InitializeComponent();
			if (AppData.IsRuntime)
			{
				VmsLogicHandler.OnRecipeListUpdate += VmsLogicHandler_OnRecipeListUpdate;
				Load += RecipeListSelectTabPanel_Load;
				listViewRecipeList.Click += ListViewRecipeList_Click;
			}

		}
		public void Open(Control parent)
		{

			var width = Width;
			var height = Height;

			var locationX = (parent.Width - width) >> 1;
			var locationY = 32;
			var toLocationX = locationX;
			var toLocationY = (parent.Height - height) >> 1;

			TweenOut(new Point(MousePosition.X, MousePosition.Y), new Size(0, 0));
			TweenIn(new Point(toLocationX, toLocationY), new Size(width, height));
			TweenShow();

			parent.Controls.Add(this);
			parent.Controls.SetChildIndex(this, 0);
		}

		private void ListViewRecipeList_Click(object sender, EventArgs e)
		{
			if (listViewRecipeList.SelectedItems.Count == 1)
			{
				var recipeName = listViewRecipeList.SelectedItems[0].Text;
				//Send Get Recipe Secation
				switch (ATSData.TransportMode)
				{
					case ATSData.TransportModeType.MixedMode:
						ATSCore.Instance.VmsLogicHandlers[1].GetRecipeSection(recipeName);
						break;
					case ATSData.TransportModeType.View1Mode:
						ATSCore.Instance.VmsLogicHandlers[1].GetRecipeSection(recipeName);
						break;
					case ATSData.TransportModeType.View2Mode:
						ATSCore.Instance.VmsLogicHandlers[2].GetRecipeSection(recipeName);
						break;
					default:
						break;
				}
			}
		}

		private void RecipeListSelectTabPanel_Load(object sender, EventArgs e)
		{
			RefreashRecipeList();

			ATSCore.Instance.VmsLogicHandlers[1].Vms.OnGetRecipeSectionGeneralReply += Vms_OnGetRecipeSectionGeneralReply;
			ATSCore.Instance.VmsLogicHandlers[1].Vms.OnGetRecipeSectionAlignmentReply += Vms_OnGetRecipeSectionAlignmentReply;
			ATSCore.Instance.VmsLogicHandlers[1].Vms.OnGetRecipeSectionInspectionReply += Vms_OnGetRecipeSectionInspectionReply;
			//ATSCore.Instance.VmsLogicHandlers[2].Vms.OnGetRecipeSectionGeneralReply += Vms_OnGetRecipeSectionGeneralReply;
			//ATSCore.Instance.VmsLogicHandlers[2].Vms.OnGetRecipeSectionAlignmentReply += Vms_OnGetRecipeSectionAlignmentReply;
			//ATSCore.Instance.VmsLogicHandlers[2].Vms.OnGetRecipeSectionInspectionReply += Vms_OnGetRecipeSectionInspectionReply;

		}

		private void VmsLogicHandler_OnRecipeListUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				foreach (var item in VmsLogicHandler.AllRecipeList)
				{
					//Console.WriteLine(item.ToString());
					var listViewItem = new ListViewItem(item.ToString());
					listViewRecipeList.Items.Add(listViewItem);
				}
			});
		}

		private void Vms_OnGetRecipeSectionAlignmentReply(object sender, VmsEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelAlignmentReply.Text = e.Data.ToString();
			});
		}

		private void Vms_OnGetRecipeSectionInspectionReply(object sender, VmsEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				labelInspectionReply.Text = e.Data.ToString();
			});
		}

		private void Vms_OnGetRecipeSectionGeneralReply(object sender, VmsEventArgs e)
		{
			ThreadSafeHelper.UIThread(this, () =>
			{
				//MessageBox.Show(e.Data.ToString());
				labelGeneralReply.Text = e.Data.ToString();
			});
		}

		private void RefreashRecipeList()
		{
			VmsLogicHandler.UpdateRecipeList();

		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (listViewRecipeList.SelectedItems.Count == 1)
			{
				var recipe = listViewRecipeList.SelectedItems[0].Text;
				switch (ATSData.TransportMode)
				{
					case ATSData.TransportModeType.MixedMode:
						ATSCore.Instance.VmsLogicHandlers[1].Recipe = recipe;
						ATSCore.Instance.VmsLogicHandlers[2].Recipe = recipe;
						break;
					case ATSData.TransportModeType.View1Mode:
						ATSCore.Instance.VmsLogicHandlers[1].Recipe = recipe;
						break;
					case ATSData.TransportModeType.View2Mode:
						ATSCore.Instance.VmsLogicHandlers[2].Recipe = recipe;
						break;
					default:
						break;
				}

				Close();
			}
			else
			{
				MessageBox.Show("未選擇Recipe");
			}

		}
		public void Close()
		{
			if (AppData.IsRuntime)
			{
				VmsLogicHandler.OnRecipeListUpdate -= VmsLogicHandler_OnRecipeListUpdate;
				Load -= RecipeListSelectTabPanel_Load;
				listViewRecipeList.Click -= ListViewRecipeList_Click;
				ATSCore.Instance.VmsLogicHandlers[1].Vms.OnGetRecipeSectionGeneralReply -= Vms_OnGetRecipeSectionGeneralReply;
				ATSCore.Instance.VmsLogicHandlers[1].Vms.OnGetRecipeSectionAlignmentReply -= Vms_OnGetRecipeSectionAlignmentReply;
				ATSCore.Instance.VmsLogicHandlers[1].Vms.OnGetRecipeSectionInspectionReply -= Vms_OnGetRecipeSectionInspectionReply;
			}

			//Parent.Controls.Remove(this);
			//Dispose();			
			TweenHide(true);
		}
		
	}
}
