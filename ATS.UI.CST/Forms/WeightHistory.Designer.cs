namespace ATS.UI.CST.Forms
{
    partial class WeightHistory
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
            this.DGWeightHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGWeightHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // DGWeightHistory
            // 
            this.DGWeightHistory.BackgroundColor = System.Drawing.Color.White;
            this.DGWeightHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWeightHistory.Location = new System.Drawing.Point(0, 32);
            this.DGWeightHistory.Name = "DGWeightHistory";
            this.DGWeightHistory.RowTemplate.Height = 24;
            this.DGWeightHistory.Size = new System.Drawing.Size(387, 333);
            this.DGWeightHistory.TabIndex = 86;
            // 
            // WeightHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 367);
            this.Controls.Add(this.DGWeightHistory);
            this.Name = "WeightHistory";
            this.Text = "WeightHistory";
            this.TopMost = false;
            this.Controls.SetChildIndex(this.DGWeightHistory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DGWeightHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGWeightHistory;
    }
}