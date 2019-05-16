namespace ATS.UI.CST.Controls
{
    partial class MatchImformationPanel
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.BtnCancle = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbPdaShelf = new System.Windows.Forms.Label();
            this.LbPdaSlotID = new System.Windows.Forms.Label();
            this.LbPdaBarco = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LbReaderShelf = new System.Windows.Forms.Label();
            this.LbReaderSlotID = new System.Windows.Forms.Label();
            this.LbReaderBarco = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnRetry = new System.Windows.Forms.Button();
            this.PbShelfLife = new System.Windows.Forms.PictureBox();
            this.PbSlotID = new System.Windows.Forms.PictureBox();
            this.PbBarco = new System.Windows.Forms.PictureBox();
            this.BtnReread = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbShelfLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSlotID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBarco)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1032, 36);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "入冷藏前膠材資訊比對";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCancle
            // 
            this.BtnCancle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnCancle.Location = new System.Drawing.Point(781, 674);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(229, 66);
            this.BtnCancle.TabIndex = 11;
            this.BtnCancle.Text = "取消作業";
            this.BtnCancle.UseVisualStyleBackColor = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnStart.Location = new System.Drawing.Point(417, 675);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(229, 66);
            this.BtnStart.TabIndex = 12;
            this.BtnStart.Text = "確認入冷藏";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Visible = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(32, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 35);
            this.label1.TabIndex = 13;
            this.label1.Text = "SlotID:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(32, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 35);
            this.label2.TabIndex = 14;
            this.label2.Text = "Shelf Life:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(32, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 35);
            this.label3.TabIndex = 15;
            this.label3.Text = "Barco:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LbPdaShelf);
            this.panel1.Controls.Add(this.LbPdaSlotID);
            this.panel1.Controls.Add(this.LbPdaBarco);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(17, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 439);
            this.panel1.TabIndex = 16;
            // 
            // LbPdaShelf
            // 
            this.LbPdaShelf.AutoSize = true;
            this.LbPdaShelf.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbPdaShelf.Location = new System.Drawing.Point(220, 375);
            this.LbPdaShelf.Name = "LbPdaShelf";
            this.LbPdaShelf.Size = new System.Drawing.Size(0, 31);
            this.LbPdaShelf.TabIndex = 19;
            // 
            // LbPdaSlotID
            // 
            this.LbPdaSlotID.AutoSize = true;
            this.LbPdaSlotID.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbPdaSlotID.Location = new System.Drawing.Point(220, 222);
            this.LbPdaSlotID.Name = "LbPdaSlotID";
            this.LbPdaSlotID.Size = new System.Drawing.Size(0, 31);
            this.LbPdaSlotID.TabIndex = 18;
            // 
            // LbPdaBarco
            // 
            this.LbPdaBarco.AutoSize = true;
            this.LbPdaBarco.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbPdaBarco.Location = new System.Drawing.Point(220, 69);
            this.LbPdaBarco.Name = "LbPdaBarco";
            this.LbPdaBarco.Size = new System.Drawing.Size(0, 31);
            this.LbPdaBarco.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 36);
            this.label4.TabIndex = 16;
            this.label4.Text = "PDA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LbReaderShelf);
            this.panel2.Controls.Add(this.LbReaderSlotID);
            this.panel2.Controls.Add(this.LbReaderBarco);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(583, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 439);
            this.panel2.TabIndex = 17;
            // 
            // LbReaderShelf
            // 
            this.LbReaderShelf.AutoSize = true;
            this.LbReaderShelf.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbReaderShelf.Location = new System.Drawing.Point(233, 378);
            this.LbReaderShelf.Name = "LbReaderShelf";
            this.LbReaderShelf.Size = new System.Drawing.Size(0, 31);
            this.LbReaderShelf.TabIndex = 20;
            // 
            // LbReaderSlotID
            // 
            this.LbReaderSlotID.AutoSize = true;
            this.LbReaderSlotID.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbReaderSlotID.Location = new System.Drawing.Point(233, 222);
            this.LbReaderSlotID.Name = "LbReaderSlotID";
            this.LbReaderSlotID.Size = new System.Drawing.Size(0, 31);
            this.LbReaderSlotID.TabIndex = 19;
            // 
            // LbReaderBarco
            // 
            this.LbReaderBarco.AutoSize = true;
            this.LbReaderBarco.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbReaderBarco.Location = new System.Drawing.Point(233, 72);
            this.LbReaderBarco.Name = "LbReaderBarco";
            this.LbReaderBarco.Size = new System.Drawing.Size(0, 31);
            this.LbReaderBarco.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(424, 36);
            this.label5.TabIndex = 16;
            this.label5.Text = "BarcoReader";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(32, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 35);
            this.label6.TabIndex = 13;
            this.label6.Text = "SlotID:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(32, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 35);
            this.label7.TabIndex = 15;
            this.label7.Text = "Barco:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(32, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 35);
            this.label8.TabIndex = 14;
            this.label8.Text = "Shelf Life:";
            // 
            // BtnRetry
            // 
            this.BtnRetry.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnRetry.Location = new System.Drawing.Point(781, 598);
            this.BtnRetry.Name = "BtnRetry";
            this.BtnRetry.Size = new System.Drawing.Size(229, 66);
            this.BtnRetry.TabIndex = 21;
            this.BtnRetry.Text = "重新輸入PDA條碼";
            this.BtnRetry.UseVisualStyleBackColor = true;
            this.BtnRetry.Visible = false;
            this.BtnRetry.Click += new System.EventHandler(this.BtnRetry_Click);
            // 
            // PbShelfLife
            // 
            this.PbShelfLife.BackColor = System.Drawing.Color.Transparent;
            this.PbShelfLife.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbShelfLife.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PbShelfLife.Image = global::ATS.UI.CST.Properties.Resources.Error;
            this.PbShelfLife.Location = new System.Drawing.Point(481, 424);
            this.PbShelfLife.Name = "PbShelfLife";
            this.PbShelfLife.Size = new System.Drawing.Size(64, 50);
            this.PbShelfLife.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbShelfLife.TabIndex = 20;
            this.PbShelfLife.TabStop = false;
            // 
            // PbSlotID
            // 
            this.PbSlotID.BackColor = System.Drawing.Color.Transparent;
            this.PbSlotID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbSlotID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PbSlotID.Image = global::ATS.UI.CST.Properties.Resources.Error;
            this.PbSlotID.Location = new System.Drawing.Point(481, 271);
            this.PbSlotID.Name = "PbSlotID";
            this.PbSlotID.Size = new System.Drawing.Size(64, 50);
            this.PbSlotID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbSlotID.TabIndex = 19;
            this.PbSlotID.TabStop = false;
            // 
            // PbBarco
            // 
            this.PbBarco.BackColor = System.Drawing.Color.Transparent;
            this.PbBarco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbBarco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PbBarco.Image = global::ATS.UI.CST.Properties.Resources.Error;
            this.PbBarco.Location = new System.Drawing.Point(481, 118);
            this.PbBarco.Name = "PbBarco";
            this.PbBarco.Size = new System.Drawing.Size(64, 50);
            this.PbBarco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbBarco.TabIndex = 18;
            this.PbBarco.TabStop = false;
            // 
            // BtnReread
            // 
            this.BtnReread.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnReread.Location = new System.Drawing.Point(781, 522);
            this.BtnReread.Name = "BtnReread";
            this.BtnReread.Size = new System.Drawing.Size(229, 66);
            this.BtnReread.TabIndex = 22;
            this.BtnReread.Text = "條碼重新讀取";
            this.BtnReread.UseVisualStyleBackColor = true;
            this.BtnReread.Visible = false;
            this.BtnReread.Click += new System.EventHandler(this.BtnReread_Click);
            // 
            // MatchImformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BtnReread);
            this.Controls.Add(this.BtnRetry);
            this.Controls.Add(this.PbShelfLife);
            this.Controls.Add(this.PbSlotID);
            this.Controls.Add(this.PbBarco);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.labelTitle);
            this.Name = "MatchImformationPanel";
            this.Size = new System.Drawing.Size(1032, 761);
            this.Load += new System.EventHandler(this.MatchImformationPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbShelfLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSlotID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBarco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button BtnCancle;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PbBarco;
        private System.Windows.Forms.PictureBox PbSlotID;
        private System.Windows.Forms.PictureBox PbShelfLife;
        private System.Windows.Forms.Label LbPdaShelf;
        private System.Windows.Forms.Label LbPdaSlotID;
        private System.Windows.Forms.Label LbPdaBarco;
        private System.Windows.Forms.Label LbReaderShelf;
        private System.Windows.Forms.Label LbReaderSlotID;
        private System.Windows.Forms.Label LbReaderBarco;
        private System.Windows.Forms.Button BtnRetry;
        private System.Windows.Forms.Button BtnReread;
    }
}
