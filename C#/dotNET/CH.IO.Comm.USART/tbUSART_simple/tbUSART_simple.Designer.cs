namespace tbUSART_simple
{
    partial class tbUSART_simple
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
            this.bt370LedON = new System.Windows.Forms.Button();
            this.bt370LedOFF = new System.Windows.Forms.Button();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.bt370LedPulseOFF = new System.Windows.Forms.Button();
            this.bt370LedPulseON = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt370LedON
            // 
            this.bt370LedON.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt370LedON.Location = new System.Drawing.Point(14, 36);
            this.bt370LedON.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt370LedON.Name = "bt370LedON";
            this.bt370LedON.Size = new System.Drawing.Size(210, 91);
            this.bt370LedON.TabIndex = 0;
            this.bt370LedON.Text = "370 nm LED ON";
            this.bt370LedON.UseVisualStyleBackColor = true;
            this.bt370LedON.Click += new System.EventHandler(this.bt370LedON_Click);
            // 
            // bt370LedOFF
            // 
            this.bt370LedOFF.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt370LedOFF.Location = new System.Drawing.Point(14, 133);
            this.bt370LedOFF.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt370LedOFF.Name = "bt370LedOFF";
            this.bt370LedOFF.Size = new System.Drawing.Size(210, 91);
            this.bt370LedOFF.TabIndex = 1;
            this.bt370LedOFF.Text = "370 nm LED OFF";
            this.bt370LedOFF.UseVisualStyleBackColor = true;
            this.bt370LedOFF.Click += new System.EventHandler(this.bt370LedOFF_Click);
            // 
            // serial
            // 
            this.serial.PortName = "COM8";
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // bt370LedPulseOFF
            // 
            this.bt370LedPulseOFF.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt370LedPulseOFF.Location = new System.Drawing.Point(15, 133);
            this.bt370LedPulseOFF.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt370LedPulseOFF.Name = "bt370LedPulseOFF";
            this.bt370LedPulseOFF.Size = new System.Drawing.Size(310, 91);
            this.bt370LedPulseOFF.TabIndex = 3;
            this.bt370LedPulseOFF.Text = "370 nm LED Pulse OFF";
            this.bt370LedPulseOFF.UseVisualStyleBackColor = true;
            this.bt370LedPulseOFF.Click += new System.EventHandler(this.bt370LedPulseOFF_Click);
            // 
            // bt370LedPulseON
            // 
            this.bt370LedPulseON.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt370LedPulseON.Location = new System.Drawing.Point(15, 36);
            this.bt370LedPulseON.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt370LedPulseON.Name = "bt370LedPulseON";
            this.bt370LedPulseON.Size = new System.Drawing.Size(310, 91);
            this.bt370LedPulseON.TabIndex = 2;
            this.bt370LedPulseON.Text = "370 nm LED Pulse ON";
            this.bt370LedPulseON.UseVisualStyleBackColor = true;
            this.bt370LedPulseON.Click += new System.EventHandler(this.bt370LedPulseON_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt370LedOFF);
            this.groupBox1.Controls.Add(this.bt370LedON);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 236);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Continuous Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt370LedPulseOFF);
            this.groupBox2.Controls.Add(this.bt370LedPulseON);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(258, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 239);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pulse Mode";
            // 
            // tbUSART_simple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 262);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "tbUSART_simple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Probe II : Test Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.tbUSART_simple_FormClosing);
            this.Load += new System.EventHandler(this.tbUSART_simple_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt370LedON;
        private System.Windows.Forms.Button bt370LedOFF;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Button bt370LedPulseOFF;
        private System.Windows.Forms.Button bt370LedPulseON;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

