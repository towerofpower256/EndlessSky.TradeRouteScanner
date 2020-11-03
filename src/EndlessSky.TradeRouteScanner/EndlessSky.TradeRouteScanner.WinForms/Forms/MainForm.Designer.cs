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
            this.btnRemoveDefFile = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.txtMinRouteScore = new System.Windows.Forms.TextBox();
            this.txtMinProfitPerUnit = new System.Windows.Forms.TextBox();
            this.txtRouteMaxStops = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSingleRoutePerStartSystem = new System.Windows.Forms.CheckBox();
            this.txtRunMaxJumps = new System.Windows.Forms.TextBox();
            this.txtStartSystems = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bgWorkerScanner = new System.ComponentModel.BackgroundWorker();
            this.groupOutput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDefFiles
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbDefFiles, 2);
            this.lbDefFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDefFiles.FormattingEnabled = true;
            this.lbDefFiles.Location = new System.Drawing.Point(3, 38);
            this.lbDefFiles.Name = "lbDefFiles";
            this.lbDefFiles.Size = new System.Drawing.Size(472, 311);
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
            this.tableLayoutPanel1.Controls.Add(this.btnScan, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddDefFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveDefFile, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDefFiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tlpOptions, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 567);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tlpOptions
            // 
            this.tlpOptions.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tlpOptions, 2);
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.txtMinRouteScore, 1, 3);
            this.tlpOptions.Controls.Add(this.txtMinProfitPerUnit, 1, 2);
            this.tlpOptions.Controls.Add(this.txtRouteMaxStops, 1, 1);
            this.tlpOptions.Controls.Add(this.label1, 0, 0);
            this.tlpOptions.Controls.Add(this.label2, 0, 1);
            this.tlpOptions.Controls.Add(this.label3, 0, 2);
            this.tlpOptions.Controls.Add(this.label4, 0, 3);
            this.tlpOptions.Controls.Add(this.label5, 0, 4);
            this.tlpOptions.Controls.Add(this.cbSingleRoutePerStartSystem, 1, 4);
            this.tlpOptions.Controls.Add(this.txtRunMaxJumps, 1, 0);
            this.tlpOptions.Controls.Add(this.txtStartSystems, 1, 5);
            this.tlpOptions.Controls.Add(this.label6, 0, 5);
            this.tlpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptions.Location = new System.Drawing.Point(3, 355);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.RowCount = 6;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.Size = new System.Drawing.Size(472, 174);
            this.tlpOptions.TabIndex = 8;
            // 
            // txtMinRouteScore
            // 
            this.txtMinRouteScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinRouteScore.Location = new System.Drawing.Point(183, 95);
            this.txtMinRouteScore.Name = "txtMinRouteScore";
            this.txtMinRouteScore.Size = new System.Drawing.Size(286, 20);
            this.txtMinRouteScore.TabIndex = 9;
            // 
            // txtMinProfitPerUnit
            // 
            this.txtMinProfitPerUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinProfitPerUnit.Location = new System.Drawing.Point(183, 65);
            this.txtMinProfitPerUnit.Name = "txtMinProfitPerUnit";
            this.txtMinProfitPerUnit.Size = new System.Drawing.Size(286, 20);
            this.txtMinProfitPerUnit.TabIndex = 8;
            // 
            // txtRouteMaxStops
            // 
            this.txtRouteMaxStops.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteMaxStops.Location = new System.Drawing.Point(183, 35);
            this.txtRouteMaxStops.Name = "txtRouteMaxStops";
            this.txtRouteMaxStops.Size = new System.Drawing.Size(286, 20);
            this.txtRouteMaxStops.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max jumps per run";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max runs per route";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min profit per comodity";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Min route score";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Single best system route";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSingleRoutePerStartSystem
            // 
            this.cbSingleRoutePerStartSystem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSingleRoutePerStartSystem.AutoSize = true;
            this.cbSingleRoutePerStartSystem.Location = new System.Drawing.Point(183, 128);
            this.cbSingleRoutePerStartSystem.Name = "cbSingleRoutePerStartSystem";
            this.cbSingleRoutePerStartSystem.Size = new System.Drawing.Size(15, 14);
            this.cbSingleRoutePerStartSystem.TabIndex = 5;
            this.cbSingleRoutePerStartSystem.UseVisualStyleBackColor = true;
            // 
            // txtRunMaxJumps
            // 
            this.txtRunMaxJumps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunMaxJumps.Location = new System.Drawing.Point(183, 5);
            this.txtRunMaxJumps.Name = "txtRunMaxJumps";
            this.txtRunMaxJumps.Size = new System.Drawing.Size(286, 20);
            this.txtRunMaxJumps.TabIndex = 6;
            // 
            // txtStartSystems
            // 
            this.txtStartSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStartSystems.Location = new System.Drawing.Point(183, 153);
            this.txtStartSystems.Name = "txtStartSystems";
            this.txtStartSystems.Size = new System.Drawing.Size(286, 20);
            this.txtStartSystems.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "Start systems (comma separated)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.groupOutput.ResumeLayout(false);
            this.groupOutput.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDefFiles;
        private System.Windows.Forms.Button btnAddDefFile;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnRemoveDefFile;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupOutput;
        private System.ComponentModel.BackgroundWorker bgWorkerScanner;
        private System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSingleRoutePerStartSystem;
        private System.Windows.Forms.TextBox txtRunMaxJumps;
        private System.Windows.Forms.TextBox txtMinRouteScore;
        private System.Windows.Forms.TextBox txtMinProfitPerUnit;
        private System.Windows.Forms.TextBox txtRouteMaxStops;
        private System.Windows.Forms.TextBox txtStartSystems;
        private System.Windows.Forms.Label label6;
    }
}