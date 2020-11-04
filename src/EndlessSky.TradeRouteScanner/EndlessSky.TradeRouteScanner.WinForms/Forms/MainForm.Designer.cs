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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbDefFiles = new System.Windows.Forms.ListBox();
            this.btnAddDefFile = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnRemoveDefFile = new System.Windows.Forms.Button();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.tlpMainWrapper = new System.Windows.Forms.TableLayoutPanel();
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
            this.panelOptions = new System.Windows.Forms.Panel();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtScoreWeightPerRun = new System.Windows.Forms.TextBox();
            this.txtScoreWeightPerDuplicateTrade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbAllowSameStopBuySell = new System.Windows.Forms.CheckBox();
            this.txtMapBounds = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxDefFiles = new System.Windows.Forms.GroupBox();
            this.tlpDefFiles = new System.Windows.Forms.TableLayoutPanel();
            this.btnScan = new System.Windows.Forms.Button();
            this.groupOutput.SuspendLayout();
            this.tlpMainWrapper.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxDefFiles.SuspendLayout();
            this.tlpDefFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDefFiles
            // 
            this.tlpDefFiles.SetColumnSpan(this.lbDefFiles, 2);
            this.lbDefFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDefFiles.FormattingEnabled = true;
            this.lbDefFiles.Location = new System.Drawing.Point(3, 38);
            this.lbDefFiles.Name = "lbDefFiles";
            this.lbDefFiles.Size = new System.Drawing.Size(374, 95);
            this.lbDefFiles.TabIndex = 0;
            this.lbDefFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDefFiles_MouseDoubleClick);
            // 
            // btnAddDefFile
            // 
            this.btnAddDefFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDefFile.Location = new System.Drawing.Point(3, 3);
            this.btnAddDefFile.Name = "btnAddDefFile";
            this.btnAddDefFile.Size = new System.Drawing.Size(184, 29);
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
            this.txtOutput.Size = new System.Drawing.Size(380, 549);
            this.txtOutput.TabIndex = 2;
            // 
            // btnRemoveDefFile
            // 
            this.btnRemoveDefFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveDefFile.Location = new System.Drawing.Point(193, 3);
            this.btnRemoveDefFile.Name = "btnRemoveDefFile";
            this.btnRemoveDefFile.Size = new System.Drawing.Size(184, 29);
            this.btnRemoveDefFile.TabIndex = 4;
            this.btnRemoveDefFile.Text = "Remove file...";
            this.btnRemoveDefFile.UseVisualStyleBackColor = true;
            this.btnRemoveDefFile.Click += new System.EventHandler(this.btnRemoveDefFile_Click);
            // 
            // groupOutput
            // 
            this.groupOutput.Controls.Add(this.txtOutput);
            this.groupOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOutput.Location = new System.Drawing.Point(395, 3);
            this.groupOutput.Name = "groupOutput";
            this.tlpMainWrapper.SetRowSpan(this.groupOutput, 3);
            this.groupOutput.Size = new System.Drawing.Size(386, 568);
            this.groupOutput.TabIndex = 6;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output";
            // 
            // tlpMainWrapper
            // 
            this.tlpMainWrapper.ColumnCount = 2;
            this.tlpMainWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainWrapper.Controls.Add(this.groupBoxDefFiles, 0, 0);
            this.tlpMainWrapper.Controls.Add(this.groupBoxOptions, 0, 1);
            this.tlpMainWrapper.Controls.Add(this.btnScan, 0, 2);
            this.tlpMainWrapper.Controls.Add(this.groupOutput, 1, 0);
            this.tlpMainWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainWrapper.Location = new System.Drawing.Point(0, 0);
            this.tlpMainWrapper.Name = "tlpMainWrapper";
            this.tlpMainWrapper.RowCount = 3;
            this.tlpMainWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMainWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMainWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMainWrapper.Size = new System.Drawing.Size(784, 574);
            this.tlpMainWrapper.TabIndex = 7;
            // 
            // tlpOptions
            // 
            this.tlpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOptions.AutoSize = true;
            this.tlpOptions.ColumnCount = 2;
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Controls.Add(this.label10, 0, 9);
            this.tlpOptions.Controls.Add(this.label9, 0, 8);
            this.tlpOptions.Controls.Add(this.txtScoreWeightPerDuplicateTrade, 1, 7);
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
            this.tlpOptions.Controls.Add(this.label7, 0, 6);
            this.tlpOptions.Controls.Add(this.label8, 0, 7);
            this.tlpOptions.Controls.Add(this.txtScoreWeightPerRun, 1, 6);
            this.tlpOptions.Controls.Add(this.cbAllowSameStopBuySell, 1, 8);
            this.tlpOptions.Controls.Add(this.txtMapBounds, 1, 9);
            this.tlpOptions.Location = new System.Drawing.Point(0, 0);
            this.tlpOptions.Name = "tlpOptions";
            this.tlpOptions.RowCount = 11;
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptions.Size = new System.Drawing.Size(377, 350);
            this.tlpOptions.TabIndex = 8;
            // 
            // txtMinRouteScore
            // 
            this.txtMinRouteScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinRouteScore.Location = new System.Drawing.Point(183, 95);
            this.txtMinRouteScore.Name = "txtMinRouteScore";
            this.txtMinRouteScore.Size = new System.Drawing.Size(191, 20);
            this.txtMinRouteScore.TabIndex = 9;
            // 
            // txtMinProfitPerUnit
            // 
            this.txtMinProfitPerUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinProfitPerUnit.Location = new System.Drawing.Point(183, 65);
            this.txtMinProfitPerUnit.Name = "txtMinProfitPerUnit";
            this.txtMinProfitPerUnit.Size = new System.Drawing.Size(191, 20);
            this.txtMinProfitPerUnit.TabIndex = 8;
            // 
            // txtRouteMaxStops
            // 
            this.txtRouteMaxStops.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteMaxStops.Location = new System.Drawing.Point(183, 35);
            this.txtRouteMaxStops.Name = "txtRouteMaxStops";
            this.txtRouteMaxStops.Size = new System.Drawing.Size(191, 20);
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
            this.txtRunMaxJumps.Size = new System.Drawing.Size(191, 20);
            this.txtRunMaxJumps.TabIndex = 6;
            // 
            // txtStartSystems
            // 
            this.txtStartSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartSystems.Location = new System.Drawing.Point(183, 155);
            this.txtStartSystems.Name = "txtStartSystems";
            this.txtStartSystems.Size = new System.Drawing.Size(191, 20);
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
            this.label6.Text = "Route start systems";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelOptions
            // 
            this.panelOptions.AutoScroll = true;
            this.panelOptions.Controls.Add(this.tlpOptions);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptions.Location = new System.Drawing.Point(3, 16);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(380, 352);
            this.panelOptions.TabIndex = 8;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.panelOptions);
            this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptions.Location = new System.Drawing.Point(3, 164);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(386, 371);
            this.groupBoxOptions.TabIndex = 9;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 30);
            this.label7.TabIndex = 12;
            this.label7.Text = "Route score per stop";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 30);
            this.label8.TabIndex = 13;
            this.label8.Text = "Route score per duplicate trade";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScoreWeightPerRun
            // 
            this.txtScoreWeightPerRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScoreWeightPerRun.Location = new System.Drawing.Point(183, 185);
            this.txtScoreWeightPerRun.Name = "txtScoreWeightPerRun";
            this.txtScoreWeightPerRun.Size = new System.Drawing.Size(191, 20);
            this.txtScoreWeightPerRun.TabIndex = 14;
            // 
            // txtScoreWeightPerDuplicateTrade
            // 
            this.txtScoreWeightPerDuplicateTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScoreWeightPerDuplicateTrade.Location = new System.Drawing.Point(183, 215);
            this.txtScoreWeightPerDuplicateTrade.Name = "txtScoreWeightPerDuplicateTrade";
            this.txtScoreWeightPerDuplicateTrade.Size = new System.Drawing.Size(191, 20);
            this.txtScoreWeightPerDuplicateTrade.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 30);
            this.label9.TabIndex = 16;
            this.label9.Text = "Allow same planet buy and sell";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAllowSameStopBuySell
            // 
            this.cbAllowSameStopBuySell.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAllowSameStopBuySell.AutoSize = true;
            this.cbAllowSameStopBuySell.Location = new System.Drawing.Point(183, 248);
            this.cbAllowSameStopBuySell.Name = "cbAllowSameStopBuySell";
            this.cbAllowSameStopBuySell.Size = new System.Drawing.Size(15, 14);
            this.cbAllowSameStopBuySell.TabIndex = 17;
            this.cbAllowSameStopBuySell.UseVisualStyleBackColor = true;
            // 
            // txtMapBounds
            // 
            this.txtMapBounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMapBounds.Location = new System.Drawing.Point(183, 273);
            this.txtMapBounds.Multiline = true;
            this.txtMapBounds.Name = "txtMapBounds";
            this.txtMapBounds.Size = new System.Drawing.Size(191, 74);
            this.txtMapBounds.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 80);
            this.label10.TabIndex = 19;
            this.label10.Text = "Limit map. Bounds set using system name and jump counts\r\nOne per line. E.g. Algor" +
    "el,10";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBoxDefFiles
            // 
            this.groupBoxDefFiles.Controls.Add(this.tlpDefFiles);
            this.groupBoxDefFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDefFiles.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDefFiles.Name = "groupBoxDefFiles";
            this.groupBoxDefFiles.Size = new System.Drawing.Size(386, 155);
            this.groupBoxDefFiles.TabIndex = 8;
            this.groupBoxDefFiles.TabStop = false;
            this.groupBoxDefFiles.Text = "Definition files";
            // 
            // tlpDefFiles
            // 
            this.tlpDefFiles.ColumnCount = 2;
            this.tlpDefFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDefFiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDefFiles.Controls.Add(this.btnAddDefFile, 0, 0);
            this.tlpDefFiles.Controls.Add(this.btnRemoveDefFile, 1, 0);
            this.tlpDefFiles.Controls.Add(this.lbDefFiles, 0, 1);
            this.tlpDefFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDefFiles.Location = new System.Drawing.Point(3, 16);
            this.tlpDefFiles.Name = "tlpDefFiles";
            this.tlpDefFiles.RowCount = 2;
            this.tlpDefFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDefFiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDefFiles.Size = new System.Drawing.Size(380, 136);
            this.tlpDefFiles.TabIndex = 0;
            // 
            // btnScan
            // 
            this.btnScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScan.Location = new System.Drawing.Point(3, 541);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(386, 30);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 574);
            this.Controls.Add(this.tlpMainWrapper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "MainForm";
            this.Text = "Endless Sky Trade Route Scanner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.groupOutput.ResumeLayout(false);
            this.groupOutput.PerformLayout();
            this.tlpMainWrapper.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpOptions.PerformLayout();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxDefFiles.ResumeLayout(false);
            this.tlpDefFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDefFiles;
        private System.Windows.Forms.Button btnAddDefFile;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnRemoveDefFile;
        private System.Windows.Forms.TableLayoutPanel tlpMainWrapper;
        private System.Windows.Forms.GroupBox groupOutput;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.TextBox txtScoreWeightPerRun;
        private System.Windows.Forms.TextBox txtScoreWeightPerDuplicateTrade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbAllowSameStopBuySell;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMapBounds;
        private System.Windows.Forms.TableLayoutPanel tlpDefFiles;
        private System.Windows.Forms.GroupBox groupBoxDefFiles;
        private System.Windows.Forms.Button btnScan;
    }
}