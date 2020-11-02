namespace EndlessSky.TradeRouteScanner.WinForms.Forms
{
    partial class MainForm
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
            this.lbDefFiles = new System.Windows.Forms.ListBox();
            this.btnAddDefFile = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtMaxRunJump = new System.Windows.Forms.TextBox();
            this.btnRemoveDefFile = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bgWorkerScanner = new System.ComponentModel.BackgroundWorker();
            this.groupOutput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDefFiles
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbDefFiles, 2);
            this.lbDefFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDefFiles.FormattingEnabled = true;
            this.lbDefFiles.Location = new System.Drawing.Point(3, 38);
            this.lbDefFiles.Name = "lbDefFiles";
            this.lbDefFiles.Size = new System.Drawing.Size(472, 461);
            this.lbDefFiles.TabIndex = 0;
            this.lbDefFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDefFiles_MouseDoubleClick);
            // 
            // btnAddDefFile
            // 
            this.btnAddDefFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDefFile.Location = new System.Drawing.Point(3, 3);
            this.btnAddDefFile.Name = "btnAddDefFile";
            this.btnAddDefFile.Size = new System.Drawing.Size(233, 29);
            this.btnAddDefFile.TabIndex = 1;
            this.btnAddDefFile.Text = "Add file...";
            this.btnAddDefFile.UseVisualStyleBackColor = true;
            this.btnAddDefFile.Click += new System.EventHandler(this.btnAddDefFile_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(467, 542);
            this.txtOutput.TabIndex = 2;
            // 
            // txtMaxRunJump
            // 
            this.txtMaxRunJump.Location = new System.Drawing.Point(242, 505);
            this.txtMaxRunJump.Name = "txtMaxRunJump";
            this.txtMaxRunJump.Size = new System.Drawing.Size(100, 20);
            this.txtMaxRunJump.TabIndex = 3;
            // 
            // btnRemoveDefFile
            // 
            this.btnRemoveDefFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveDefFile.Location = new System.Drawing.Point(242, 3);
            this.btnRemoveDefFile.Name = "btnRemoveDefFile";
            this.btnRemoveDefFile.Size = new System.Drawing.Size(233, 29);
            this.btnRemoveDefFile.TabIndex = 4;
            this.btnRemoveDefFile.Text = "Remove file...";
            this.btnRemoveDefFile.UseVisualStyleBackColor = true;
            this.btnRemoveDefFile.Click += new System.EventHandler(this.btnRemoveDefFile_Click);
            // 
            // btnScan
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnScan, 2);
            this.btnScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScan.Location = new System.Drawing.Point(3, 535);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(472, 29);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // groupOutput
            // 
            this.groupOutput.Controls.Add(this.txtOutput);
            this.groupOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOutput.Location = new System.Drawing.Point(481, 3);
            this.groupOutput.Name = "groupOutput";
            this.tableLayoutPanel1.SetRowSpan(this.groupOutput, 4);
            this.groupOutput.Size = new System.Drawing.Size(473, 561);
            this.groupOutput.TabIndex = 6;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupOutput, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMaxRunJump, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnScan, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddDefFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveDefFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDefFiles, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 567);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // bgWorkerScanner
            // 
            this.bgWorkerScanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerScanner_DoWork);
            this.bgWorkerScanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerScanner_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Endless Sky Trade Route Scanner";
            this.groupOutput.ResumeLayout(false);
            this.groupOutput.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDefFiles;
        private System.Windows.Forms.Button btnAddDefFile;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtMaxRunJump;
        private System.Windows.Forms.Button btnRemoveDefFile;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupOutput;
        private System.ComponentModel.BackgroundWorker bgWorkerScanner;
    }
}