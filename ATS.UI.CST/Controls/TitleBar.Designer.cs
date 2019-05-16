namespace ATS.UI.CST.Controls
{
	partial class TitleBar
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
            this.labelSystemName = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSystemName
            // 
            this.labelSystemName.AutoSize = true;
            this.labelSystemName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSystemName.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelSystemName.ForeColor = System.Drawing.Color.White;
            this.labelSystemName.Location = new System.Drawing.Point(32, 0);
            this.labelSystemName.Name = "labelSystemName";
            this.labelSystemName.Size = new System.Drawing.Size(158, 31);
            this.labelSystemName.TabIndex = 1;
            this.labelSystemName.Text = "料倉管理系統";
            this.labelSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonClose.Location = new System.Drawing.Point(1888, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 32);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Image = global::ATS.UI.CST.Properties.Resources.Icon_Circle;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 32);
            this.label2.TabIndex = 4;
            this.label2.Click += new System.EventHandler(this.Secret_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelUser.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(1822, 0);
            this.labelUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(66, 31);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "User";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Image = global::ATS.UI.CST.Properties.Resources.Icon_SystemUsers_32;
            this.label3.Location = new System.Drawing.Point(1790, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 32);
            this.label3.TabIndex = 6;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(610, -2);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(700, 32);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "主劃頁";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelSystemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonClose);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TitleBar";
            this.Size = new System.Drawing.Size(1920, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelSystemName;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelTitle;
	}
}
