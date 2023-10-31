﻿namespace tbUSART
{
    partial class tbUSART
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbUSART));
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHand = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.hxEditRead = new Be.Windows.Forms.HexBox();
            this.hxEditWrite = new Be.Windows.Forms.HexBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPeriod = new System.Windows.Forms.TextBox();
            this.chbPeriodic = new System.Windows.Forms.CheckBox();
            this.btSend = new System.Windows.Forms.Button();
            this.tbClearTx = new System.Windows.Forms.Button();
            this.btClearRx = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPort
            // 
            this.cbPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(46, 21);
            this.cbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(104, 23);
            this.cbPort.TabIndex = 0;
            this.cbPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbPort_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "BaudRate";
            // 
            // cbBaud
            // 
            this.cbBaud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Location = new System.Drawing.Point(232, 21);
            this.cbBaud.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(116, 23);
            this.cbBaud.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "DataBits";
            // 
            // cbDataBits
            // 
            this.cbDataBits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Location = new System.Drawing.Point(178, 54);
            this.cbDataBits.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(48, 23);
            this.cbDataBits.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Parity";
            // 
            // cbParity
            // 
            this.cbParity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(405, 21);
            this.cbParity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(71, 23);
            this.cbParity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "StopBits";
            // 
            // cbStop
            // 
            this.cbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Location = new System.Drawing.Point(66, 54);
            this.cbStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(49, 23);
            this.cbStop.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "HandShake";
            // 
            // cbHand
            // 
            this.cbHand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbHand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbHand.FormattingEnabled = true;
            this.cbHand.Location = new System.Drawing.Point(311, 54);
            this.cbHand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbHand.Name = "cbHand";
            this.cbHand.Size = new System.Drawing.Size(166, 23);
            this.cbHand.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btOpen);
            this.groupBox1.Controls.Add(this.cbPort);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbHand);
            this.groupBox1.Controls.Add(this.cbBaud);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbStop);
            this.groupBox1.Controls.Add(this.cbDataBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 88);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Configuration";
            // 
            // btOpen
            // 
            this.btOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOpen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOpen.Location = new System.Drawing.Point(482, 21);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(150, 56);
            this.btOpen.TabIndex = 13;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // hxEditRead
            // 
            this.hxEditRead.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hxEditRead.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hxEditRead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hxEditRead.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hxEditRead.LineInfoVisible = true;
            this.hxEditRead.Location = new System.Drawing.Point(5, 97);
            this.hxEditRead.Name = "hxEditRead";
            this.hxEditRead.ReadOnly = true;
            this.hxEditRead.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxEditRead.Size = new System.Drawing.Size(638, 170);
            this.hxEditRead.StringViewVisible = true;
            this.hxEditRead.TabIndex = 13;
            this.hxEditRead.UseFixedBytesPerLine = true;
            this.hxEditRead.VScrollBarVisible = true;
            // 
            // hxEditWrite
            // 
            this.hxEditWrite.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hxEditWrite.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hxEditWrite.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hxEditWrite.LineInfoVisible = true;
            this.hxEditWrite.Location = new System.Drawing.Point(5, 269);
            this.hxEditWrite.Name = "hxEditWrite";
            this.hxEditWrite.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxEditWrite.Size = new System.Drawing.Size(638, 87);
            this.hxEditWrite.StringViewVisible = true;
            this.hxEditWrite.TabIndex = 14;
            this.hxEditWrite.UseFixedBytesPerLine = true;
            this.hxEditWrite.VScrollBarVisible = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbPeriod);
            this.groupBox2.Controls.Add(this.chbPeriodic);
            this.groupBox2.Controls.Add(this.btSend);
            this.groupBox2.Controls.Add(this.tbClearTx);
            this.groupBox2.Controls.Add(this.btClearRx);
            this.groupBox2.Location = new System.Drawing.Point(5, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 56);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "msec";
            // 
            // tbPeriod
            // 
            this.tbPeriod.Location = new System.Drawing.Point(287, 24);
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.Size = new System.Drawing.Size(97, 21);
            this.tbPeriod.TabIndex = 18;
            // 
            // chbPeriodic
            // 
            this.chbPeriodic.AutoSize = true;
            this.chbPeriodic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPeriodic.Location = new System.Drawing.Point(208, 26);
            this.chbPeriodic.Name = "chbPeriodic";
            this.chbPeriodic.Size = new System.Drawing.Size(73, 19);
            this.chbPeriodic.TabIndex = 17;
            this.chbPeriodic.Text = "Periodic";
            this.chbPeriodic.UseVisualStyleBackColor = true;
            this.chbPeriodic.CheckedChanged += new System.EventHandler(this.chbPeriodic_CheckedChanged);
            // 
            // btSend
            // 
            this.btSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSend.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.Location = new System.Drawing.Point(445, 20);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(187, 28);
            this.btSend.TabIndex = 16;
            this.btSend.Text = "Send TxData";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // tbClearTx
            // 
            this.tbClearTx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbClearTx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tbClearTx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClearTx.Location = new System.Drawing.Point(107, 20);
            this.tbClearTx.Name = "tbClearTx";
            this.tbClearTx.Size = new System.Drawing.Size(95, 28);
            this.tbClearTx.TabIndex = 15;
            this.tbClearTx.Text = "Clear TxData";
            this.tbClearTx.UseVisualStyleBackColor = true;
            this.tbClearTx.Click += new System.EventHandler(this.tbClearTx_Click);
            // 
            // btClearRx
            // 
            this.btClearRx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btClearRx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClearRx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClearRx.Location = new System.Drawing.Point(6, 20);
            this.btClearRx.Name = "btClearRx";
            this.btClearRx.Size = new System.Drawing.Size(95, 28);
            this.btClearRx.TabIndex = 14;
            this.btClearRx.Text = "Clear RxData";
            this.btClearRx.UseVisualStyleBackColor = true;
            this.btClearRx.Click += new System.EventHandler(this.btClearRx_Click);
            // 
            // tbUSART
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 423);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.hxEditWrite);
            this.Controls.Add(this.hxEditRead);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "tbUSART";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CH.IO.Comm.USART Test Bench";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.tbUSART_FormClosing);
            this.Load += new System.EventHandler(this.tbUSART_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOpen;
        private Be.Windows.Forms.HexBox hxEditRead;
        private Be.Windows.Forms.HexBox hxEditWrite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button tbClearTx;
        private System.Windows.Forms.Button btClearRx;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.TextBox tbPeriod;
        private System.Windows.Forms.CheckBox chbPeriodic;
        private System.Windows.Forms.Label label7;

    }
}

