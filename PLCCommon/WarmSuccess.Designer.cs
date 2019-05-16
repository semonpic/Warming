namespace PLCconnect
{
    partial class WarmSuccess
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelAlarm2 = new System.Windows.Forms.Label();
            this.labelAlarmInfomation = new System.Windows.Forms.Label();
            this.labelAlarm1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 32);
            this.panel1.TabIndex = 83;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(705, 32);
            this.labelTitle.TabIndex = 83;
            this.labelTitle.Text = "WarmSuccess";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Brown;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(705, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(42, 32);
            this.buttonClose.TabIndex = 82;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Visible = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelAlarm2
            // 
            this.labelAlarm2.AutoSize = true;
            this.labelAlarm2.Font = new System.Drawing.Font("微軟正黑體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm2.ForeColor = System.Drawing.Color.LightGray;
            this.labelAlarm2.Location = new System.Drawing.Point(12, 159);
            this.labelAlarm2.Name = "labelAlarm2";
            this.labelAlarm2.Size = new System.Drawing.Size(469, 120);
            this.labelAlarm2.TabIndex = 94;
            this.labelAlarm2.Text = "TaskOver";
            // 
            // labelAlarmInfomation
            // 
            this.labelAlarmInfomation.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarmInfomation.ForeColor = System.Drawing.Color.Black;
            this.labelAlarmInfomation.Location = new System.Drawing.Point(50, 93);
            this.labelAlarmInfomation.Name = "labelAlarmInfomation";
            this.labelAlarmInfomation.Size = new System.Drawing.Size(524, 153);
            this.labelAlarmInfomation.TabIndex = 96;
            this.labelAlarmInfomation.Text = "已完成作業";
            // 
            // labelAlarm1
            // 
            this.labelAlarm1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAlarm1.ForeColor = System.Drawing.Color.Black;
            this.labelAlarm1.Location = new System.Drawing.Point(26, 48);
            this.labelAlarm1.Name = "labelAlarm1";
            this.labelAlarm1.Size = new System.Drawing.Size(210, 36);
            this.labelAlarm1.TabIndex = 95;
            this.labelAlarm1.Text = "Success";
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.LightBlue;
            this.buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOK.Location = new System.Drawing.Point(513, 212);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 60);
            this.buttonOK.TabIndex = 97;
            this.buttonOK.Text = "Close";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 260);
            this.label1.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(739, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 260);
            this.label2.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(2, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(741, 3);
            this.label3.TabIndex = 100;
            // 
            // WarmSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 292);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAlarm2);
            this.Controls.Add(this.labelAlarmInfomation);
            this.Controls.Add(this.labelAlarm1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarmSuccess";
            this.Text = "WarmSuccess";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelAlarm2;
        private System.Windows.Forms.Label labelAlarmInfomation;
        private System.Windows.Forms.Label labelAlarm1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}