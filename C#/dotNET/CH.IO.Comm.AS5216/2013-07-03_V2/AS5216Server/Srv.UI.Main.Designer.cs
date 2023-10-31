namespace AS5216Server
{
    partial class UI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.ChartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MountWorker = new System.ComponentModel.BackgroundWorker();
            this.lbBoot = new System.Windows.Forms.Label();
            this.UIWorker = new System.ComponentModel.BackgroundWorker();
            this.pbBoot = new System.Windows.Forms.ProgressBar();
            this.lbMsg = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.btDisplay = new System.Windows.Forms.Button();
            this.btTopMost = new System.Windows.Forms.Button();
            this.tbAvantesInfo = new System.Windows.Forms.TextBox();
            this.lbServerStatusIndicator = new System.Windows.Forms.Label();
            this.btTest = new System.Windows.Forms.Button();
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSpectrum)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChartSpectrum
            // 
            this.ChartSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.ChartSpectrum.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartSpectrum.Legends.Add(legend1);
            this.ChartSpectrum.Location = new System.Drawing.Point(1, 13);
            this.ChartSpectrum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChartSpectrum.Name = "ChartSpectrum";
            this.ChartSpectrum.Size = new System.Drawing.Size(677, 351);
            this.ChartSpectrum.TabIndex = 0;
            this.ChartSpectrum.Text = "chart1";
            // 
            // MountWorker
            // 
            this.MountWorker.WorkerReportsProgress = true;
            this.MountWorker.WorkerSupportsCancellation = true;
            this.MountWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MountWorker_DoWork);
            this.MountWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MountWorker_ProgressChanged);
            // 
            // lbBoot
            // 
            this.lbBoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBoot.BackColor = System.Drawing.Color.White;
            this.lbBoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBoot.Location = new System.Drawing.Point(1, 368);
            this.lbBoot.Name = "lbBoot";
            this.lbBoot.Size = new System.Drawing.Size(677, 22);
            this.lbBoot.TabIndex = 3;
            this.lbBoot.Text = "No Boot message";
            this.lbBoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIWorker
            // 
            this.UIWorker.WorkerReportsProgress = true;
            this.UIWorker.WorkerSupportsCancellation = true;
            this.UIWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UIWorker_DoWork);
            this.UIWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UIWorker_ProgressChanged);
            // 
            // pbBoot
            // 
            this.pbBoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBoot.BackColor = System.Drawing.Color.White;
            this.pbBoot.ForeColor = System.Drawing.Color.PowderBlue;
            this.pbBoot.Location = new System.Drawing.Point(1, 1);
            this.pbBoot.Maximum = 8;
            this.pbBoot.Name = "pbBoot";
            this.pbBoot.Size = new System.Drawing.Size(914, 13);
            this.pbBoot.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbBoot.TabIndex = 4;
            // 
            // lbMsg
            // 
            this.lbMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMsg.BackColor = System.Drawing.Color.White;
            this.lbMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMsg.Location = new System.Drawing.Point(1, 392);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(677, 22);
            this.lbMsg.TabIndex = 5;
            this.lbMsg.Text = "No message";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbError
            // 
            this.lbError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbError.BackColor = System.Drawing.Color.White;
            this.lbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbError.Location = new System.Drawing.Point(1, 416);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(677, 22);
            this.lbError.TabIndex = 6;
            this.lbError.Text = "No error";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btDisplay
            // 
            this.btDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDisplay.Location = new System.Drawing.Point(684, 42);
            this.btDisplay.Name = "btDisplay";
            this.btDisplay.Size = new System.Drawing.Size(219, 23);
            this.btDisplay.TabIndex = 7;
            this.btDisplay.Text = "Display ON";
            this.btDisplay.UseVisualStyleBackColor = true;
            this.btDisplay.Click += new System.EventHandler(this.btDisplay_Click);
            // 
            // btTopMost
            // 
            this.btTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTopMost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTopMost.Location = new System.Drawing.Point(684, 71);
            this.btTopMost.Name = "btTopMost";
            this.btTopMost.Size = new System.Drawing.Size(219, 23);
            this.btTopMost.TabIndex = 8;
            this.btTopMost.Text = "TopMost ON";
            this.btTopMost.UseVisualStyleBackColor = true;
            this.btTopMost.Click += new System.EventHandler(this.btTopMost_Click);
            // 
            // tbAvantesInfo
            // 
            this.tbAvantesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAvantesInfo.BackColor = System.Drawing.Color.White;
            this.tbAvantesInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAvantesInfo.Location = new System.Drawing.Point(684, 161);
            this.tbAvantesInfo.Multiline = true;
            this.tbAvantesInfo.Name = "tbAvantesInfo";
            this.tbAvantesInfo.ReadOnly = true;
            this.tbAvantesInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAvantesInfo.Size = new System.Drawing.Size(219, 277);
            this.tbAvantesInfo.TabIndex = 9;
            // 
            // lbServerStatusIndicator
            // 
            this.lbServerStatusIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbServerStatusIndicator.BackColor = System.Drawing.Color.Red;
            this.lbServerStatusIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbServerStatusIndicator.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerStatusIndicator.Location = new System.Drawing.Point(684, 13);
            this.lbServerStatusIndicator.Name = "lbServerStatusIndicator";
            this.lbServerStatusIndicator.Size = new System.Drawing.Size(219, 22);
            this.lbServerStatusIndicator.TabIndex = 10;
            this.lbServerStatusIndicator.Text = "Server is Booting ...";
            this.lbServerStatusIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btTest
            // 
            this.btTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTest.Location = new System.Drawing.Point(684, 100);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(219, 55);
            this.btTest.TabIndex = 11;
            this.btTest.Text = "Minimize Window";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // Tray
            // 
            this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
            this.Tray.Text = "Avantes Server";
            this.Tray.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 441);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.lbServerStatusIndicator);
            this.Controls.Add(this.tbAvantesInfo);
            this.Controls.Add(this.btTopMost);
            this.Controls.Add(this.btDisplay);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.pbBoot);
            this.Controls.Add(this.lbBoot);
            this.Controls.Add(this.ChartSpectrum);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avantes Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UI_FormClosed);
            this.Load += new System.EventHandler(this.UI_Load);
            this.Resize += new System.EventHandler(this.UI_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ChartSpectrum)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSpectrum;
        private System.ComponentModel.BackgroundWorker MountWorker;
        private System.Windows.Forms.Label lbBoot;
        private System.ComponentModel.BackgroundWorker UIWorker;
        private System.Windows.Forms.ProgressBar pbBoot;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btDisplay;
        private System.Windows.Forms.Button btTopMost;
        private System.Windows.Forms.TextBox tbAvantesInfo;
        private System.Windows.Forms.Label lbServerStatusIndicator;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

