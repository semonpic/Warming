namespace ATS.UI.CST.Forms
{
	partial class SafetyDoorAlarmForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelAlarm2 = new System.Windows.Forms.Label();
            this.labelAlarmInfomation = new System.Windows.Forms.Label();
            this.labelAlarm1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonOK);
            this.panel2.Controls.Add(this.labelAlarm2);
            this.panel2.Controls.Add(this.labelAlarmInfomation);
            this.panel2.Controls.Add(this.labelAlarm1);
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 246);
            this.panel2.TabIndex = 83;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.LightBlue;
            this.buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOK.Location = new System.Drawing.Point(400, 173);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 60);
            this.buttonOK.TabIndex = 89;
            this.buttonOK.Text = "Cancel";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelAlarm2
            // 
            this.labelAlarm2.AutoSize = true;
            this.labelAlarm2.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm2.ForeColor = System.Drawing.Color.LightGray;
            this.labelAlarm2.Location = new System.Drawing.Point(12, 113);
            this.labelAlarm2.Name = "labelAlarm2";
            this.labelAlarm2.Size = new System.Drawing.Size(320, 120);
            this.labelAlarm2.TabIndex = 93;
            this.labelAlarm2.Text = "Alarm";
            // 
            // labelAlarmInfomation
            // 
            this.labelAlarmInfomation.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarmInfomation.ForeColor = System.Drawing.Color.Black;
            this.labelAlarmInfomation.Location = new System.Drawing.Point(76, 46);
            this.labelAlarmInfomation.Name = "labelAlarmInfomation";
            this.labelAlarmInfomation.Size = new System.Drawing.Size(524, 153);
            this.labelAlarmInfomation.TabIndex = 92;
            this.labelAlarmInfomation.Text = "安全門 開啟/關閉 自動切換為維護模式";
            // 
            // labelAlarm1
            // 
            this.labelAlarm1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm1.ForeColor = System.Drawing.Color.Black;
            this.labelAlarm1.Location = new System.Drawing.Point(26, 0);
            this.labelAlarm1.Name = "labelAlarm1";
            this.labelAlarm1.Size = new System.Drawing.Size(210, 36);
            this.labelAlarm1.TabIndex = 90;
            this.labelAlarm1.Text = "Alarm";
            // 
            // SafetyDoorAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 280);
            this.Controls.Add(this.panel2);
            this.Name = "SafetyDoorAlarmForm";
            this.Text = "SafetyDoorAlarmForm";
            this.TopMost = false;
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labelAlarm2;
		private System.Windows.Forms.Label labelAlarmInfomation;
		private System.Windows.Forms.Label labelAlarm1;
		private System.Windows.Forms.Button buttonOK;
	}
}