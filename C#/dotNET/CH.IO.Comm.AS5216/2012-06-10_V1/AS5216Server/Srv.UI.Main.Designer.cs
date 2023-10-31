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
            ((System.ComponentModel.ISupportInitialize)(this.ChartSpectrum)).BeginInit();
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
            this.ChartSpectrum.Size = new System.Drawing.Size(624, 347);
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
            this.lbBoot.Location = new System.Drawing.Point(1, 355);
            this.lbBoot.Name = "lbBoot";
            this.lbBoot.Size = new System.Drawing.Size(624, 22);
            this.lbBoot.TabIndex = 3;
            this.lbBoot.Text = "Avantes Server";
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
            this.pbBoot.Size = new System.Drawing.Size(624, 13);
            this.pbBoot.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbBoot.TabIndex = 4;
            // 
            // lbMsg
            // 
            this.lbMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMsg.BackColor = System.Drawing.Color.White;
            this.lbMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMsg.Location = new System.Drawing.Point(1, 379);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(624, 22);
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
            this.lbError.Location = new System.Drawing.Point(1, 403);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(624, 22);
            this.lbError.TabIndex = 6;
            this.lbError.Text = "No error";
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 509);
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
            ((System.ComponentModel.ISupportInitialize)(this.ChartSpectrum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSpectrum;
        private System.ComponentModel.BackgroundWorker MountWorker;
        private System.Windows.Forms.Label lbBoot;
        private System.ComponentModel.BackgroundWorker UIWorker;
        private System.Windows.Forms.ProgressBar pbBoot;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label lbError;
    }
}

