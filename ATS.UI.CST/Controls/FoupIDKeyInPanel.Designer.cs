namespace ATS.UI.CST.Controls
{
	partial class FoupIDKeyInPanel
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelLoadportN1 = new System.Windows.Forms.Label();
			this.labelFoupID = new System.Windows.Forms.Label();
			this.labelInfomation = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxFoupID = new System.Windows.Forms.TextBox();
			this.labelLoadportN2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// labelLoadportN1
			// 
			this.labelLoadportN1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelLoadportN1.ForeColor = System.Drawing.Color.Black;
			this.labelLoadportN1.Location = new System.Drawing.Point(470, 50);
			this.labelLoadportN1.Name = "labelLoadportN1";
			this.labelLoadportN1.Size = new System.Drawing.Size(210, 36);
			this.labelLoadportN1.TabIndex = 32;
			this.labelLoadportN1.Text = "Loadport N";
			// 
			// labelFoupID
			// 
			this.labelFoupID.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelFoupID.ForeColor = System.Drawing.Color.Black;
			this.labelFoupID.Location = new System.Drawing.Point(470, 176);
			this.labelFoupID.Name = "labelFoupID";
			this.labelFoupID.Size = new System.Drawing.Size(210, 36);
			this.labelFoupID.TabIndex = 33;
			this.labelFoupID.Text = "Foup ID";
			// 
			// labelInfomation
			// 
			this.labelInfomation.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelInfomation.ForeColor = System.Drawing.Color.Black;
			this.labelInfomation.Location = new System.Drawing.Point(541, 96);
			this.labelInfomation.Name = "labelInfomation";
			this.labelInfomation.Size = new System.Drawing.Size(957, 80);
			this.labelInfomation.TabIndex = 35;
			this.labelInfomation.Text = "因讀取RFID失敗\r\n改由人員輸入FoupID";
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
			this.labelTitle.Text = "Foup ID Key In";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxFoupID
			// 
			this.textBoxFoupID.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxFoupID.Location = new System.Drawing.Point(545, 215);
			this.textBoxFoupID.Name = "textBoxFoupID";
			this.textBoxFoupID.Size = new System.Drawing.Size(676, 71);
			this.textBoxFoupID.TabIndex = 1;
			this.textBoxFoupID.Text = "0123456789";
			// 
			// labelLoadportN2
			// 
			this.labelLoadportN2.AutoSize = true;
			this.labelLoadportN2.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelLoadportN2.ForeColor = System.Drawing.Color.LightGray;
			this.labelLoadportN2.Location = new System.Drawing.Point(15, 537);
			this.labelLoadportN2.Name = "labelLoadportN2";
			this.labelLoadportN2.Size = new System.Drawing.Size(590, 120);
			this.labelLoadportN2.TabIndex = 74;
			this.labelLoadportN2.Text = "Loadport ID";
			// 
			// FoupIDKeyInPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.labelLoadportN2);
			this.Controls.Add(this.textBoxFoupID);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.labelInfomation);
			this.Controls.Add(this.labelFoupID);
			this.Controls.Add(this.labelLoadportN1);
			this.Controls.Add(this.buttonOK);
			this.Name = "FoupIDKeyInPanel";
			this.Size = new System.Drawing.Size(1560, 680);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelLoadportN1;
		private System.Windows.Forms.Label labelFoupID;
		private System.Windows.Forms.Label labelInfomation;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxFoupID;
		private System.Windows.Forms.Label labelLoadportN2;
	}
}
