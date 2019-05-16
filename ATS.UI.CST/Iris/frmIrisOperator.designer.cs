
namespace R100Test
{
    partial class frmIrisOperator
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
            this.picRightEye = new System.Windows.Forms.PictureBox();
            this.picLeftEye = new System.Windows.Forms.PictureBox();
            this.TbMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRightEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftEye)).BeginInit();
            this.SuspendLayout();
            // 
            // picRightEye
            // 
            this.picRightEye.Location = new System.Drawing.Point(13, 24);
            this.picRightEye.Name = "picRightEye";
            this.picRightEye.Size = new System.Drawing.Size(180, 217);
            this.picRightEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRightEye.TabIndex = 0;
            this.picRightEye.TabStop = false;
            this.picRightEye.Click += new System.EventHandler(this.picRightEye_Click);
            // 
            // picLeftEye
            // 
            this.picLeftEye.Location = new System.Drawing.Point(215, 24);
            this.picLeftEye.Name = "picLeftEye";
            this.picLeftEye.Size = new System.Drawing.Size(180, 217);
            this.picLeftEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeftEye.TabIndex = 1;
            this.picLeftEye.TabStop = false;
            // 
            // TbMessage
            // 
            this.TbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.TbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbMessage.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TbMessage.Location = new System.Drawing.Point(2, 21);
            this.TbMessage.Multiline = true;
            this.TbMessage.Name = "TbMessage";
            this.TbMessage.Size = new System.Drawing.Size(338, 329);
            this.TbMessage.TabIndex = 2;
            // 
            // frmIrisOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 444);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmIrisOperator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "虹膜";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIrisOperator_FormClosing);
            this.Load += new System.EventHandler(this.frmIrisOperator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRightEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftEye)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRightEye;
        private System.Windows.Forms.PictureBox picLeftEye;
        private System.Windows.Forms.TextBox TbMessage;
        private System.Windows.Forms.TextBox TBUserName;
 
    }
}