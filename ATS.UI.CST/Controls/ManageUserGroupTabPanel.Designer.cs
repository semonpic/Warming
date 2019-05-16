namespace ATS.UI.CST.Controls
{
	partial class ManageUserGroupTabPanel
	{
		/// <summary> 
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 元件設計工具產生的程式碼

		/// <summary> 
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonEnable = new System.Windows.Forms.Button();
			this.buttonDisable = new System.Windows.Forms.Button();
			this.listViewDisable = new System.Windows.Forms.ListView();
			this.listViewEnable = new System.Windows.Forms.ListView();
			this.labelDeny = new System.Windows.Forms.Label();
			this.labelAllow = new System.Windows.Forms.Label();
			this.textBoxUserGroupName = new System.Windows.Forms.TextBox();
			this.labellabelUserGroupInfo = new System.Windows.Forms.Label();
			this.labelGroupPermission = new System.Windows.Forms.Label();
			this.labelGroupName = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.listView = new System.Windows.Forms.ListView();
			this.labelUserGroupList = new System.Windows.Forms.Label();
			this.labelUserGroupHelp = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.textBoxUserGroupHelp = new System.Windows.Forms.TextBox();
			this.labelSeletedTabName = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.labelSeletedTabName);
			this.panel2.Controls.Add(this.buttonEnable);
			this.panel2.Controls.Add(this.buttonDisable);
			this.panel2.Controls.Add(this.listViewDisable);
			this.panel2.Controls.Add(this.listViewEnable);
			this.panel2.Controls.Add(this.labelDeny);
			this.panel2.Controls.Add(this.labelAllow);
			this.panel2.Controls.Add(this.textBoxUserGroupName);
			this.panel2.Controls.Add(this.labellabelUserGroupInfo);
			this.panel2.Controls.Add(this.labelGroupPermission);
			this.panel2.Controls.Add(this.labelGroupName);
			this.panel2.Location = new System.Drawing.Point(430, 11);
			this.panel2.Margin = new System.Windows.Forms.Padding(10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 659);
			this.panel2.TabIndex = 17;
			// 
			// buttonEnable
			// 
			this.buttonEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEnable.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonEnable.Location = new System.Drawing.Point(335, 517);
			this.buttonEnable.Margin = new System.Windows.Forms.Padding(5);
			this.buttonEnable.Name = "buttonEnable";
			this.buttonEnable.Size = new System.Drawing.Size(130, 130);
			this.buttonEnable.TabIndex = 31;
			this.buttonEnable.Text = "<<";
			this.buttonEnable.UseVisualStyleBackColor = true;
			this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
			// 
			// buttonDisable
			// 
			this.buttonDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDisable.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonDisable.Location = new System.Drawing.Point(335, 226);
			this.buttonDisable.Margin = new System.Windows.Forms.Padding(5);
			this.buttonDisable.Name = "buttonDisable";
			this.buttonDisable.Size = new System.Drawing.Size(130, 130);
			this.buttonDisable.TabIndex = 30;
			this.buttonDisable.Text = ">>";
			this.buttonDisable.UseVisualStyleBackColor = true;
			this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
			// 
			// listViewDisable
			// 
			this.listViewDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewDisable.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.listViewDisable.Location = new System.Drawing.Point(470, 226);
			this.listViewDisable.Margin = new System.Windows.Forms.Padding(10);
			this.listViewDisable.MultiSelect = false;
			this.listViewDisable.Name = "listViewDisable";
			this.listViewDisable.Size = new System.Drawing.Size(300, 421);
			this.listViewDisable.TabIndex = 29;
			this.listViewDisable.UseCompatibleStateImageBehavior = false;
			// 
			// listViewEnable
			// 
			this.listViewEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewEnable.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.listViewEnable.Location = new System.Drawing.Point(30, 226);
			this.listViewEnable.Margin = new System.Windows.Forms.Padding(10);
			this.listViewEnable.MultiSelect = false;
			this.listViewEnable.Name = "listViewEnable";
			this.listViewEnable.Size = new System.Drawing.Size(300, 421);
			this.listViewEnable.TabIndex = 28;
			this.listViewEnable.UseCompatibleStateImageBehavior = false;
			this.listViewEnable.View = System.Windows.Forms.View.List;
			// 
			// labelDeny
			// 
			this.labelDeny.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelDeny.ForeColor = System.Drawing.Color.FromArgb(237,28,36);
			this.labelDeny.Location = new System.Drawing.Point(470, 180);
			this.labelDeny.Name = "labelDeny";
			this.labelDeny.Size = new System.Drawing.Size(290, 36);
			this.labelDeny.TabIndex = 27;
			this.labelDeny.Text = "禁止權限";
			this.labelDeny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAllow
			// 
			this.labelAllow.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelAllow.ForeColor = System.Drawing.Color.Green;
			this.labelAllow.Location = new System.Drawing.Point(40, 180);
			this.labelAllow.Name = "labelAllow";
			this.labelAllow.Size = new System.Drawing.Size(290, 36);
			this.labelAllow.TabIndex = 26;
			this.labelAllow.Text = "允許權限";
			this.labelAllow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxUserGroupName
			// 
			this.textBoxUserGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxUserGroupName.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxUserGroupName.ForeColor = System.Drawing.Color.Black;
			this.textBoxUserGroupName.Location = new System.Drawing.Point(300, 60);
			this.textBoxUserGroupName.MaxLength = 100;
			this.textBoxUserGroupName.Name = "textBoxUserGroupName";
			this.textBoxUserGroupName.ReadOnly = true;
			this.textBoxUserGroupName.Size = new System.Drawing.Size(470, 46);
			this.textBoxUserGroupName.TabIndex = 25;
			// 
			// labellabelUserGroupInfo
			// 
			this.labellabelUserGroupInfo.BackColor = System.Drawing.Color.Black;
			this.labellabelUserGroupInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.labellabelUserGroupInfo.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labellabelUserGroupInfo.ForeColor = System.Drawing.Color.White;
			this.labellabelUserGroupInfo.Location = new System.Drawing.Point(0, 0);
			this.labellabelUserGroupInfo.Name = "labellabelUserGroupInfo";
			this.labellabelUserGroupInfo.Size = new System.Drawing.Size(798, 36);
			this.labellabelUserGroupInfo.TabIndex = 19;
			this.labellabelUserGroupInfo.Text = "使用者群組資訊";
			this.labellabelUserGroupInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelGroupPermission
			// 
			this.labelGroupPermission.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelGroupPermission.ForeColor = System.Drawing.Color.Black;
			this.labelGroupPermission.Location = new System.Drawing.Point(30, 120);
			this.labelGroupPermission.Name = "labelGroupPermission";
			this.labelGroupPermission.Size = new System.Drawing.Size(264, 36);
			this.labelGroupPermission.TabIndex = 13;
			this.labelGroupPermission.Text = "群組權限";
			// 
			// labelGroupName
			// 
			this.labelGroupName.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelGroupName.ForeColor = System.Drawing.Color.Black;
			this.labelGroupName.Location = new System.Drawing.Point(30, 60);
			this.labelGroupName.Name = "labelGroupName";
			this.labelGroupName.Size = new System.Drawing.Size(264, 36);
			this.labelGroupName.TabIndex = 11;
			this.labelGroupName.Text = "群組名稱";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.listView);
			this.panel3.Controls.Add(this.labelUserGroupList);
			this.panel3.Location = new System.Drawing.Point(10, 10);
			this.panel3.Margin = new System.Windows.Forms.Padding(10);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(400, 660);
			this.panel3.TabIndex = 18;
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.listView.Location = new System.Drawing.Point(-1, 46);
			this.listView.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(400, 602);
			this.listView.TabIndex = 20;
			this.listView.UseCompatibleStateImageBehavior = false;
			// 
			// labelUserGroupList
			// 
			this.labelUserGroupList.BackColor = System.Drawing.Color.Black;
			this.labelUserGroupList.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelUserGroupList.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelUserGroupList.ForeColor = System.Drawing.Color.White;
			this.labelUserGroupList.Location = new System.Drawing.Point(0, 0);
			this.labelUserGroupList.Name = "labelUserGroupList";
			this.labelUserGroupList.Size = new System.Drawing.Size(398, 36);
			this.labelUserGroupList.TabIndex = 19;
			this.labelUserGroupList.Text = "使用者群組列表";
			this.labelUserGroupList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelUserGroupHelp
			// 
			this.labelUserGroupHelp.BackColor = System.Drawing.Color.Black;
			this.labelUserGroupHelp.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelUserGroupHelp.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelUserGroupHelp.ForeColor = System.Drawing.Color.White;
			this.labelUserGroupHelp.Location = new System.Drawing.Point(0, 0);
			this.labelUserGroupHelp.Name = "labelUserGroupHelp";
			this.labelUserGroupHelp.Size = new System.Drawing.Size(298, 36);
			this.labelUserGroupHelp.TabIndex = 19;
			this.labelUserGroupHelp.Text = "說明";
			this.labelUserGroupHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BackColor = System.Drawing.Color.White;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.textBoxUserGroupHelp);
			this.panel4.Controls.Add(this.labelUserGroupHelp);
			this.panel4.Location = new System.Drawing.Point(1250, 12);
			this.panel4.Margin = new System.Windows.Forms.Padding(10);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(300, 658);
			this.panel4.TabIndex = 19;
			// 
			// textBoxUserGroupHelp
			// 
			this.textBoxUserGroupHelp.BackColor = System.Drawing.Color.White;
			this.textBoxUserGroupHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxUserGroupHelp.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.textBoxUserGroupHelp.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxUserGroupHelp.ForeColor = System.Drawing.Color.Black;
			this.textBoxUserGroupHelp.Location = new System.Drawing.Point(10, 46);
			this.textBoxUserGroupHelp.Margin = new System.Windows.Forms.Padding(10);
			this.textBoxUserGroupHelp.Multiline = true;
			this.textBoxUserGroupHelp.Name = "textBoxUserGroupHelp";
			this.textBoxUserGroupHelp.ReadOnly = true;
			this.textBoxUserGroupHelp.Size = new System.Drawing.Size(278, 600);
			this.textBoxUserGroupHelp.TabIndex = 20;
			this.textBoxUserGroupHelp.Text = "使用者群組列表中選擇\r\n使用者群組\r\n可查詢該群組的資訊\r\n\r\n使用者群組資訊框\r\n可修改群組名稱\r\n\r\n群組權限可修改該群組可操作哪些分頁\r\n\r\n選擇允許項目按" +
    ">則禁止\r\n\r\n選擇禁止項目按<則允許";
			// 
			// labelSeletedTabName
			// 
			this.labelSeletedTabName.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelSeletedTabName.ForeColor = System.Drawing.Color.Black;
			this.labelSeletedTabName.Location = new System.Drawing.Point(300, 120);
			this.labelSeletedTabName.Name = "labelSeletedTabName";
			this.labelSeletedTabName.Size = new System.Drawing.Size(470, 36);
			this.labelSeletedTabName.TabIndex = 32;
			// 
			// ManageUserGroupTabPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ManageUserGroupTabPanel";
			this.Size = new System.Drawing.Size(1560, 680);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labellabelUserGroupInfo;
		private System.Windows.Forms.Label labelGroupPermission;
		private System.Windows.Forms.Label labelGroupName;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.Label labelUserGroupList;
		private System.Windows.Forms.Label labelUserGroupHelp;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox textBoxUserGroupHelp;
		private System.Windows.Forms.TextBox textBoxUserGroupName;
		private System.Windows.Forms.Button buttonDisable;
		private System.Windows.Forms.ListView listViewDisable;
		private System.Windows.Forms.Label labelDeny;
		private System.Windows.Forms.Label labelAllow;
		private System.Windows.Forms.Button buttonEnable;
		private System.Windows.Forms.ListView listViewEnable;
		private System.Windows.Forms.Label labelSeletedTabName;
	}
}
