using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.IO.Comm;
using CH.IO.Service;

namespace AS5216Client
{
    public partial class UIClient : Form
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
            this.chartSpectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.UIWorker = new System.ComponentModel.BackgroundWorker();
            this.tbCmd = new System.Windows.Forms.TextBox();
            this.btSendCmd = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSpectrum
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSpectrum.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSpectrum.Legends.Add(legend1);
            this.chartSpectrum.Location = new System.Drawing.Point(12, 12);
            this.chartSpectrum.Name = "chartSpectrum";
            this.chartSpectrum.Size = new System.Drawing.Size(511, 384);
            this.chartSpectrum.TabIndex = 0;
            this.chartSpectrum.Text = "chart2";
            // 
            // UIWorker
            // 
            this.UIWorker.WorkerReportsProgress = true;
            this.UIWorker.WorkerSupportsCancellation = true;
            this.UIWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UIWorker_DoWork);
            this.UIWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UIWorker_ProgressChanged);
            // 
            // tbCmd
            // 
            this.tbCmd.Location = new System.Drawing.Point(12, 402);
            this.tbCmd.Name = "tbCmd";
            this.tbCmd.Size = new System.Drawing.Size(360, 21);
            this.tbCmd.TabIndex = 1;
            // 
            // btSendCmd
            // 
            this.btSendCmd.Location = new System.Drawing.Point(379, 402);
            this.btSendCmd.Name = "btSendCmd";
            this.btSendCmd.Size = new System.Drawing.Size(144, 21);
            this.btSendCmd.TabIndex = 2;
            this.btSendCmd.Text = "Send Command";
            this.btSendCmd.UseVisualStyleBackColor = true;
            this.btSendCmd.Click += new System.EventHandler(this.btSendCmd_Click);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(12, 429);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(511, 48);
            this.btTest.TabIndex = 3;
            this.btTest.Text = "Test Start";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(12, 483);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMsg.Size = new System.Drawing.Size(511, 137);
            this.tbMsg.TabIndex = 4;
            // 
            // UIClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 632);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btSendCmd);
            this.Controls.Add(this.tbCmd);
            this.Controls.Add(this.chartSpectrum);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UIClient";
            this.Text = "AS5216 Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIClient_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIClient_FormClosed);
            this.Load += new System.EventHandler(this.UIClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSpectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpectrum;
        private BackgroundWorker UIWorker;
        private TextBox tbCmd;
        private Button btSendCmd;
        private Button btTest;
        private TextBox tbMsg;
    }
}

