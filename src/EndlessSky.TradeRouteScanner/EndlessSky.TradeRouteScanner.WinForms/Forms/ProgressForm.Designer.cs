namespace EndlessSky.TradeRouteScanner.WinForms.Forms
{
    partial class ProgressForm
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
            this.progMain = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progMain
            // 
            this.progMain.Location = new System.Drawing.Point(12, 42);
            this.progMain.Name = "progMain";
            this.progMain.Size = new System.Drawing.Size(470, 23);
            this.progMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(488, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Location = new System.Drawing.Point(9, 9);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(35, 13);
            this.lblMain.TabIndex = 2;
            this.lblMain.Text = "label1";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 71);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMain;
    }
}