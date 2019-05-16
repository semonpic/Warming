namespace ATS.UI.CST.Controls
{
	partial class WaferIDKeyInPanel
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
			this.labelWaferN1 = new System.Windows.Forms.Label();
			this.labelWaferID = new System.Windows.Forms.Label();
			this.labelInfomation = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxWaferID = new System.Windows.Forms.TextBox();
			this.labelWaferN2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
			// labelWaferN1
			// 
			this.labelWaferN1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelWaferN1.ForeColor = System.Drawing.Color.Black;
			this.labelWaferN1.Location = new System.Drawing.Point(470, 50);
			this.labelWaferN1.Name = "labelWaferN1";
			this.labelWaferN1.Size = new System.Drawing.Size(210, 36);
			this.labelWaferN1.TabIndex = 32;
			this.labelWaferN1.Text = "Wafer 000";
			// 
			// labelWaferID
			// 
			this.labelWaferID.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelWaferID.ForeColor = System.Drawing.Color.Black;
			this.labelWaferID.Location = new System.Drawing.Point(470, 517);
			this.labelWaferID.Name = "labelWaferID";
			this.labelWaferID.Size = new System.Drawing.Size(210, 36);
			this.labelWaferID.TabIndex = 33;
			this.labelWaferID.Text = "Wafer ID";
			// 
			// labelInfomation
			// 
			this.labelInfomation.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelInfomation.ForeColor = System.Drawing.Color.Black;
			this.labelInfomation.Location = new System.Drawing.Point(541, 96);
			this.labelInfomation.Name = "labelInfomation";
			this.labelInfomation.Size = new System.Drawing.Size(957, 43);
			this.labelInfomation.TabIndex = 35;
			this.labelInfomation.Text = "因讀取Wafer ID失敗 改由人員輸入Wafer ID";
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
			this.labelTitle.Text = "Wafer ID Key In";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxWaferID
			// 
			this.textBoxWaferID.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.textBoxWaferID.Location = new System.Drawing.Point(545, 556);
			this.textBoxWaferID.Name = "textBoxWaferID";
			this.textBoxWaferID.Size = new System.Drawing.Size(494, 71);
			this.textBoxWaferID.TabIndex = 1;
			this.textBoxWaferID.Text = "0123456789";
			// 
			// labelWaferN2
			// 
			this.labelWaferN2.AutoSize = true;
			this.labelWaferN2.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.labelWaferN2.ForeColor = System.Drawing.Color.LightGray;
			this.labelWaferN2.Location = new System.Drawing.Point(15, 537);
			this.labelWaferN2.Name = "labelWaferN2";
			this.labelWaferN2.Size = new System.Drawing.Size(513, 120);
			this.labelWaferN2.TabIndex = 74;
			this.labelWaferN2.Text = "Wafer 000";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox1.Location = new System.Drawing.Point(278, 130);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1024, 384);
			this.pictureBox1.TabIndex = 75;
			this.pictureBox1.TabStop = false;
			// 
			// WaferIDKeyInPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBoxWaferID);
			this.Controls.Add(this.labelWaferID);
			this.Controls.Add(this.labelWaferN2);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.labelInfomation);
			this.Controls.Add(this.labelWaferN1);
			this.Controls.Add(this.buttonOK);
			this.Name = "WaferIDKeyInPanel";
			this.Size = new System.Drawing.Size(1560, 680);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelWaferN1;
		private System.Windows.Forms.Label labelWaferID;
		private System.Windows.Forms.Label labelInfomation;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxWaferID;
		private System.Windows.Forms.Label labelWaferN2;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
