namespace ATS.UI.CST.Controls
{
    partial class MaintainPrealignerTabPanel
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
            this.buttonGetError = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxAngle = new System.Windows.Forms.ComboBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAlign = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonHold = new System.Windows.Forms.Button();
            this.buttonRelease = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonResetError = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonNormalHome = new System.Windows.Forms.Button();
            this.buttonRetract = new System.Windows.Forms.Button();
            this.buttonORG = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSetMode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.buttonSetSpeed1 = new System.Windows.Forms.Button();
            this.buttonSetSpeed5 = new System.Windows.Forms.Button();
            this.buttonSetSpeed50 = new System.Windows.Forms.Button();
            this.buttonSetSpeed75 = new System.Windows.Forms.Button();
            this.buttonSetSpeed100 = new System.Windows.Forms.Button();
            this.buttonSetSpeed25 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGetError
            // 
            this.buttonGetError.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonGetError.Location = new System.Drawing.Point(240, 44);
            this.buttonGetError.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetError.Name = "buttonGetError";
            this.buttonGetError.Size = new System.Drawing.Size(188, 64);
            this.buttonGetError.TabIndex = 56;
            this.buttonGetError.Text = "GetError";
            this.buttonGetError.UseVisualStyleBackColor = true;
            this.buttonGetError.Click += new System.EventHandler(this.buttonGetError_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxAngle);
            this.groupBox1.Controls.Add(this.buttonSet);
            this.groupBox1.Controls.Add(this.comboBoxSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonAlign);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(651, 266);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(543, 190);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Align";
            // 
            // comboBoxAngle
            // 
            this.comboBoxAngle.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxAngle.FormattingEnabled = true;
            this.comboBoxAngle.Items.AddRange(new object[] {
            "0",
            "2",
            "3",
            "4",
            "5",
            "6",
            "8",
            "12"});
            this.comboBoxAngle.Location = new System.Drawing.Point(111, 113);
            this.comboBoxAngle.Name = "comboBoxAngle";
            this.comboBoxAngle.Size = new System.Drawing.Size(188, 53);
            this.comboBoxAngle.TabIndex = 49;
            // 
            // buttonSet
            // 
            this.buttonSet.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSet.Location = new System.Drawing.Point(328, 113);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(188, 64);
            this.buttonSet.TabIndex = 48;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Location = new System.Drawing.Point(111, 49);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(188, 53);
            this.comboBoxSize.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 45);
            this.label1.TabIndex = 48;
            this.label1.Text = " Size";
            // 
            // buttonAlign
            // 
            this.buttonAlign.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAlign.Location = new System.Drawing.Point(328, 39);
            this.buttonAlign.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAlign.Name = "buttonAlign";
            this.buttonAlign.Size = new System.Drawing.Size(188, 64);
            this.buttonAlign.TabIndex = 48;
            this.buttonAlign.Text = "Align";
            this.buttonAlign.UseVisualStyleBackColor = true;
            this.buttonAlign.Click += new System.EventHandler(this.buttonAlign_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox6.Controls.Add(this.buttonHold);
            this.groupBox6.Controls.Add(this.buttonRelease);
            this.groupBox6.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox6.Location = new System.Drawing.Point(77, 308);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(544, 117);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hold&&Release";
            // 
            // buttonHold
            // 
            this.buttonHold.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonHold.Location = new System.Drawing.Point(18, 41);
            this.buttonHold.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHold.Name = "buttonHold";
            this.buttonHold.Size = new System.Drawing.Size(179, 59);
            this.buttonHold.TabIndex = 24;
            this.buttonHold.Text = "Hold";
            this.buttonHold.UseVisualStyleBackColor = true;
            this.buttonHold.Click += new System.EventHandler(this.buttonHold_Click);
            // 
            // buttonRelease
            // 
            this.buttonRelease.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonRelease.Location = new System.Drawing.Point(240, 41);
            this.buttonRelease.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRelease.Name = "buttonRelease";
            this.buttonRelease.Size = new System.Drawing.Size(179, 59);
            this.buttonRelease.TabIndex = 25;
            this.buttonRelease.Text = "Release";
            this.buttonRelease.UseVisualStyleBackColor = true;
            this.buttonRelease.Click += new System.EventHandler(this.buttonRelease_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.buttonGetError);
            this.groupBox5.Controls.Add(this.buttonResetError);
            this.groupBox5.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox5.Location = new System.Drawing.Point(77, 166);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(544, 124);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Reset&&Get Error";
            // 
            // buttonResetError
            // 
            this.buttonResetError.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonResetError.Location = new System.Drawing.Point(18, 47);
            this.buttonResetError.Margin = new System.Windows.Forms.Padding(4);
            this.buttonResetError.Name = "buttonResetError";
            this.buttonResetError.Size = new System.Drawing.Size(179, 59);
            this.buttonResetError.TabIndex = 22;
            this.buttonResetError.Text = "Reset Error";
            this.buttonResetError.UseVisualStyleBackColor = true;
            this.buttonResetError.Click += new System.EventHandler(this.buttonResetError_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.buttonNormalHome);
            this.groupBox4.Controls.Add(this.buttonRetract);
            this.groupBox4.Controls.Add(this.buttonORG);
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(651, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(453, 200);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HOME&&ORG&&RETRACT";
            // 
            // buttonNormalHome
            // 
            this.buttonNormalHome.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonNormalHome.Location = new System.Drawing.Point(16, 46);
            this.buttonNormalHome.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNormalHome.Name = "buttonNormalHome";
            this.buttonNormalHome.Size = new System.Drawing.Size(188, 64);
            this.buttonNormalHome.TabIndex = 20;
            this.buttonNormalHome.Text = "Normal Home";
            this.buttonNormalHome.UseVisualStyleBackColor = true;
            this.buttonNormalHome.Click += new System.EventHandler(this.buttonNormalHome_Click);
            // 
            // buttonRetract
            // 
            this.buttonRetract.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonRetract.Location = new System.Drawing.Point(233, 46);
            this.buttonRetract.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRetract.Name = "buttonRetract";
            this.buttonRetract.Size = new System.Drawing.Size(188, 64);
            this.buttonRetract.TabIndex = 19;
            this.buttonRetract.Text = "Retract";
            this.buttonRetract.UseVisualStyleBackColor = true;
            this.buttonRetract.Click += new System.EventHandler(this.buttonRetract_Click);
            // 
            // buttonORG
            // 
            this.buttonORG.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonORG.Location = new System.Drawing.Point(16, 124);
            this.buttonORG.Margin = new System.Windows.Forms.Padding(4);
            this.buttonORG.Name = "buttonORG";
            this.buttonORG.Size = new System.Drawing.Size(188, 64);
            this.buttonORG.TabIndex = 18;
            this.buttonORG.Text = "ORG Search";
            this.buttonORG.UseVisualStyleBackColor = true;
            this.buttonORG.Click += new System.EventHandler(this.buttonORG_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.buttonSetMode);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBoxMode);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(77, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 125);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SetMode";
            // 
            // buttonSetMode
            // 
            this.buttonSetMode.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetMode.Location = new System.Drawing.Point(333, 46);
            this.buttonSetMode.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetMode.Name = "buttonSetMode";
            this.buttonSetMode.Size = new System.Drawing.Size(179, 59);
            this.buttonSetMode.TabIndex = 10;
            this.buttonSetMode.Text = "SetMode";
            this.buttonSetMode.UseVisualStyleBackColor = true;
            this.buttonSetMode.Click += new System.EventHandler(this.buttonSetMode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(25, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 45);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mode";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(126, 52);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(200, 53);
            this.comboBoxMode.TabIndex = 9;
            // 
            // buttonSetSpeed1
            // 
            this.buttonSetSpeed1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetSpeed1.Location = new System.Drawing.Point(13, 47);
            this.buttonSetSpeed1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetSpeed1.Name = "buttonSetSpeed1";
            this.buttonSetSpeed1.Size = new System.Drawing.Size(82, 59);
            this.buttonSetSpeed1.TabIndex = 56;
            this.buttonSetSpeed1.Text = "1";
            this.buttonSetSpeed1.UseVisualStyleBackColor = true;
            this.buttonSetSpeed1.Click += new System.EventHandler(this.buttonSetSpeed1_Click);
            // 
            // buttonSetSpeed5
            // 
            this.buttonSetSpeed5.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetSpeed5.Location = new System.Drawing.Point(103, 47);
            this.buttonSetSpeed5.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetSpeed5.Name = "buttonSetSpeed5";
            this.buttonSetSpeed5.Size = new System.Drawing.Size(82, 59);
            this.buttonSetSpeed5.TabIndex = 57;
            this.buttonSetSpeed5.Text = "5";
            this.buttonSetSpeed5.UseVisualStyleBackColor = true;
            this.buttonSetSpeed5.Click += new System.EventHandler(this.buttonSetSpeed5_Click);
            // 
            // buttonSetSpeed50
            // 
            this.buttonSetSpeed50.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetSpeed50.Location = new System.Drawing.Point(283, 47);
            this.buttonSetSpeed50.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetSpeed50.Name = "buttonSetSpeed50";
            this.buttonSetSpeed50.Size = new System.Drawing.Size(82, 59);
            this.buttonSetSpeed50.TabIndex = 58;
            this.buttonSetSpeed50.Text = "50";
            this.buttonSetSpeed50.UseVisualStyleBackColor = true;
            this.buttonSetSpeed50.Click += new System.EventHandler(this.buttonSetSpeed50_Click);
            // 
            // buttonSetSpeed75
            // 
            this.buttonSetSpeed75.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetSpeed75.Location = new System.Drawing.Point(373, 47);
            this.buttonSetSpeed75.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetSpeed75.Name = "buttonSetSpeed75";
            this.buttonSetSpeed75.Size = new System.Drawing.Size(82, 59);
            this.buttonSetSpeed75.TabIndex = 59;
            this.buttonSetSpeed75.Text = "75";
            this.buttonSetSpeed75.UseVisualStyleBackColor = true;
            this.buttonSetSpeed75.Click += new System.EventHandler(this.buttonSetSpeed75_Click);
            // 
            // buttonSetSpeed100
            // 
            this.buttonSetSpeed100.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetSpeed100.Location = new System.Drawing.Point(463, 47);
            this.buttonSetSpeed100.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetSpeed100.Name = "buttonSetSpeed100";
            this.buttonSetSpeed100.Size = new System.Drawing.Size(82, 59);
            this.buttonSetSpeed100.TabIndex = 60;
            this.buttonSetSpeed100.Text = "100";
            this.buttonSetSpeed100.UseVisualStyleBackColor = true;
            this.buttonSetSpeed100.Click += new System.EventHandler(this.buttonSetSpeed100_Click);
            // 
            // buttonSetSpeed25
            // 
            this.buttonSetSpeed25.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSetSpeed25.Location = new System.Drawing.Point(193, 47);
            this.buttonSetSpeed25.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetSpeed25.Name = "buttonSetSpeed25";
            this.buttonSetSpeed25.Size = new System.Drawing.Size(82, 59);
            this.buttonSetSpeed25.TabIndex = 61;
            this.buttonSetSpeed25.Text = "25";
            this.buttonSetSpeed25.UseVisualStyleBackColor = true;
            this.buttonSetSpeed25.Click += new System.EventHandler(this.buttonSetSpeed25_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.buttonSetSpeed1);
            this.groupBox2.Controls.Add(this.buttonSetSpeed100);
            this.groupBox2.Controls.Add(this.buttonSetSpeed25);
            this.groupBox2.Controls.Add(this.buttonSetSpeed75);
            this.groupBox2.Controls.Add(this.buttonSetSpeed5);
            this.groupBox2.Controls.Add(this.buttonSetSpeed50);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(77, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 125);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SetSpeed";
            // 
            // MaintainPrealignerTabPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MaintainPrealignerTabPanel";
            this.Size = new System.Drawing.Size(1560, 680);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetError;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxAngle;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAlign;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonHold;
        private System.Windows.Forms.Button buttonRelease;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonNormalHome;
        private System.Windows.Forms.Button buttonRetract;
        private System.Windows.Forms.Button buttonORG;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSetMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Button buttonResetError;
        private System.Windows.Forms.Button buttonSetSpeed1;
        private System.Windows.Forms.Button buttonSetSpeed5;
        private System.Windows.Forms.Button buttonSetSpeed50;
        private System.Windows.Forms.Button buttonSetSpeed75;
        private System.Windows.Forms.Button buttonSetSpeed100;
        private System.Windows.Forms.Button buttonSetSpeed25;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
