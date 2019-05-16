namespace ATS.UI.CST.Controls
{
	partial class RecipeListSelectTabPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeListSelectTabPanel));
			this.listViewRecipeList = new System.Windows.Forms.ListView();
			this.label9 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelGeneral = new System.Windows.Forms.Label();
			this.labelAlignment = new System.Windows.Forms.Label();
			this.labelInspection = new System.Windows.Forms.Label();
			this.labelGeneralReply = new System.Windows.Forms.Label();
			this.labelAlignmentReply = new System.Windows.Forms.Label();
			this.labelInspectionReply = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listViewRecipeList
			// 
			this.listViewRecipeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewRecipeList.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.listViewRecipeList.FullRowSelect = true;
			this.listViewRecipeList.GridLines = true;
			this.listViewRecipeList.Location = new System.Drawing.Point(57, 96);
			this.listViewRecipeList.Margin = new System.Windows.Forms.Padding(10);
			this.listViewRecipeList.MultiSelect = false;
			this.listViewRecipeList.Name = "listViewRecipeList";
			this.listViewRecipeList.Size = new System.Drawing.Size(400, 574);
			this.listViewRecipeList.TabIndex = 29;
			this.listViewRecipeList.UseCompatibleStateImageBehavior = false;
			this.listViewRecipeList.View = System.Windows.Forms.View.List;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(20, 50);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(210, 36);
			this.label9.TabIndex = 30;
			this.label9.Text = "Recipe List";
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.LightBlue;
			this.buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonOK.FlatAppearance.BorderSize = 0;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonOK.Location = new System.Drawing.Point(1298, 610);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(5);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(200, 60);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// labelGeneral
			// 
			this.labelGeneral.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelGeneral.ForeColor = System.Drawing.Color.Black;
			this.labelGeneral.Location = new System.Drawing.Point(470, 50);
			this.labelGeneral.Name = "labelGeneral";
			this.labelGeneral.Size = new System.Drawing.Size(210, 36);
			this.labelGeneral.TabIndex = 32;
			this.labelGeneral.Text = "GENERAL";
			// 
			// labelAlignment
			// 
			this.labelAlignment.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelAlignment.ForeColor = System.Drawing.Color.Black;
			this.labelAlignment.Location = new System.Drawing.Point(470, 343);
			this.labelAlignment.Name = "labelAlignment";
			this.labelAlignment.Size = new System.Drawing.Size(210, 36);
			this.labelAlignment.TabIndex = 33;
			this.labelAlignment.Text = "ALIGNMENT";
			// 
			// labelInspection
			// 
			this.labelInspection.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelInspection.ForeColor = System.Drawing.Color.Black;
			this.labelInspection.Location = new System.Drawing.Point(470, 530);
			this.labelInspection.Name = "labelInspection";
			this.labelInspection.Size = new System.Drawing.Size(210, 36);
			this.labelInspection.TabIndex = 34;
			this.labelInspection.Text = "INSPECTION";
			// 
			// labelGeneralReply
			// 
			this.labelGeneralReply.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelGeneralReply.ForeColor = System.Drawing.Color.Black;
			this.labelGeneralReply.Location = new System.Drawing.Point(541, 96);
			this.labelGeneralReply.Name = "labelGeneralReply";
			this.labelGeneralReply.Size = new System.Drawing.Size(957, 245);
			this.labelGeneralReply.TabIndex = 35;
			this.labelGeneralReply.Text = resources.GetString("labelGeneralReply.Text");
			// 
			// labelAlignmentReply
			// 
			this.labelAlignmentReply.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelAlignmentReply.ForeColor = System.Drawing.Color.Black;
			this.labelAlignmentReply.Location = new System.Drawing.Point(541, 379);
			this.labelAlignmentReply.Name = "labelAlignmentReply";
			this.labelAlignmentReply.Size = new System.Drawing.Size(957, 151);
			this.labelAlignmentReply.TabIndex = 36;
			this.labelAlignmentReply.Text = resources.GetString("labelAlignmentReply.Text");
			// 
			// labelInspectionReply
			// 
			this.labelInspectionReply.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelInspectionReply.ForeColor = System.Drawing.Color.Black;
			this.labelInspectionReply.Location = new System.Drawing.Point(541, 563);
			this.labelInspectionReply.Name = "labelInspectionReply";
			this.labelInspectionReply.Size = new System.Drawing.Size(680, 107);
			this.labelInspectionReply.TabIndex = 37;
			this.labelInspectionReply.Text = "Example:\r\nSTART INSPECTION SECTION:\r\nSEL SELECTALL( ) ALL() INSPECTION() ALGORITH" +
    "M(DEFAULT)  ALIGNCODE(PCS1)  FCSCODE(PCS1)  SELECTIONNAME(SelectionName1) \r\nEND " +
    "INSPECTION SECTION:";
			// 
			// buttonClose
			// 
			this.buttonClose.BackColor = System.Drawing.Color.Black;
			this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.buttonClose.FlatAppearance.BorderSize = 0;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.buttonClose.ForeColor = System.Drawing.Color.White;
			this.buttonClose.Location = new System.Drawing.Point(1528, 0);
			this.buttonClose.Margin = new System.Windows.Forms.Padding(5);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(32, 32);
			this.buttonClose.TabIndex = 38;
			this.buttonClose.Text = "X";
			this.buttonClose.UseVisualStyleBackColor = false;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// labelTitle
			// 
			this.labelTitle.BackColor = System.Drawing.Color.Black;
			this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelTitle.ForeColor = System.Drawing.Color.White;
			this.labelTitle.Location = new System.Drawing.Point(0, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(1560, 32);
			this.labelTitle.TabIndex = 39;
			this.labelTitle.Text = "Select Recipe";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RecipeListSelectTabPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.labelInspectionReply);
			this.Controls.Add(this.labelAlignmentReply);
			this.Controls.Add(this.labelGeneralReply);
			this.Controls.Add(this.labelInspection);
			this.Controls.Add(this.labelAlignment);
			this.Controls.Add(this.labelGeneral);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.listViewRecipeList);
			this.Name = "RecipeListSelectTabPanel";
			this.Size = new System.Drawing.Size(1560, 680);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelGeneral;
		private System.Windows.Forms.Label labelAlignment;
		private System.Windows.Forms.Label labelInspection;
		private System.Windows.Forms.Label labelGeneralReply;
		private System.Windows.Forms.Label labelAlignmentReply;
		private System.Windows.Forms.Label labelInspectionReply;
		private System.Windows.Forms.ListView listViewRecipeList;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelTitle;
	}
}
