namespace RobotInteractive_Windows
{
    partial class Form1
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
            this.GetPortsB = new System.Windows.Forms.Button();
            this.PortNamesRTB = new System.Windows.Forms.RichTextBox();
            this.ComboPorts = new System.Windows.Forms.ComboBox();
            this.ComboBaudRates = new System.Windows.Forms.ComboBox();
            this.ComboDataBits = new System.Windows.Forms.ComboBox();
            this.ComboHandShake = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBreakStatus = new System.Windows.Forms.Label();
            this.lblCTSStatus = new System.Windows.Forms.Label();
            this.lblDSRStatus = new System.Windows.Forms.Label();
            this.lblRIStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetPortsB
            // 
            this.GetPortsB.Location = new System.Drawing.Point(282, 12);
            this.GetPortsB.Name = "GetPortsB";
            this.GetPortsB.Size = new System.Drawing.Size(75, 23);
            this.GetPortsB.TabIndex = 0;
            this.GetPortsB.Text = "Scan Ports";
            this.GetPortsB.UseVisualStyleBackColor = true;
            this.GetPortsB.Click += new System.EventHandler(this.button1_Click);
            // 
            // PortNamesRTB
            // 
            this.PortNamesRTB.Location = new System.Drawing.Point(33, 61);
            this.PortNamesRTB.Name = "PortNamesRTB";
            this.PortNamesRTB.Size = new System.Drawing.Size(213, 172);
            this.PortNamesRTB.TabIndex = 2;
            this.PortNamesRTB.Text = "";
            // 
            // ComboPorts
            // 
            this.ComboPorts.FormattingEnabled = true;
            this.ComboPorts.Location = new System.Drawing.Point(363, 14);
            this.ComboPorts.Name = "ComboPorts";
            this.ComboPorts.Size = new System.Drawing.Size(121, 21);
            this.ComboPorts.TabIndex = 3;
            // 
            // ComboBaudRates
            // 
            this.ComboBaudRates.FormattingEnabled = true;
            this.ComboBaudRates.Location = new System.Drawing.Point(363, 41);
            this.ComboBaudRates.Name = "ComboBaudRates";
            this.ComboBaudRates.Size = new System.Drawing.Size(121, 21);
            this.ComboBaudRates.TabIndex = 4;
            // 
            // ComboDataBits
            // 
            this.ComboDataBits.FormattingEnabled = true;
            this.ComboDataBits.Location = new System.Drawing.Point(363, 68);
            this.ComboDataBits.Name = "ComboDataBits";
            this.ComboDataBits.Size = new System.Drawing.Size(121, 21);
            this.ComboDataBits.TabIndex = 5;
            // 
            // ComboHandShake
            // 
            this.ComboHandShake.FormattingEnabled = true;
            this.ComboHandShake.Location = new System.Drawing.Point(363, 95);
            this.ComboHandShake.Name = "ComboHandShake";
            this.ComboHandShake.Size = new System.Drawing.Size(121, 21);
            this.ComboHandShake.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblBreakStatus
            // 
            this.lblBreakStatus.AutoSize = true;
            this.lblBreakStatus.Location = new System.Drawing.Point(253, 176);
            this.lblBreakStatus.Name = "lblBreakStatus";
            this.lblBreakStatus.Size = new System.Drawing.Size(35, 13);
            this.lblBreakStatus.TabIndex = 7;
            this.lblBreakStatus.Text = "label1";
            // 
            // lblCTSStatus
            // 
            this.lblCTSStatus.AutoSize = true;
            this.lblCTSStatus.Location = new System.Drawing.Point(294, 176);
            this.lblCTSStatus.Name = "lblCTSStatus";
            this.lblCTSStatus.Size = new System.Drawing.Size(35, 13);
            this.lblCTSStatus.TabIndex = 7;
            this.lblCTSStatus.Text = "label1";
            // 
            // lblDSRStatus
            // 
            this.lblDSRStatus.AutoSize = true;
            this.lblDSRStatus.Location = new System.Drawing.Point(335, 176);
            this.lblDSRStatus.Name = "lblDSRStatus";
            this.lblDSRStatus.Size = new System.Drawing.Size(35, 13);
            this.lblDSRStatus.TabIndex = 7;
            this.lblDSRStatus.Text = "label1";
            // 
            // lblRIStatus
            // 
            this.lblRIStatus.AutoSize = true;
            this.lblRIStatus.Location = new System.Drawing.Point(376, 176);
            this.lblRIStatus.Name = "lblRIStatus";
            this.lblRIStatus.Size = new System.Drawing.Size(35, 13);
            this.lblRIStatus.TabIndex = 7;
            this.lblRIStatus.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 277);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRIStatus);
            this.Controls.Add(this.lblDSRStatus);
            this.Controls.Add(this.lblCTSStatus);
            this.Controls.Add(this.lblBreakStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ComboHandShake);
            this.Controls.Add(this.ComboDataBits);
            this.Controls.Add(this.ComboBaudRates);
            this.Controls.Add(this.ComboPorts);
            this.Controls.Add(this.PortNamesRTB);
            this.Controls.Add(this.GetPortsB);
            this.Name = "Form1";
            this.Text = "b";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetPortsB;
        private System.Windows.Forms.RichTextBox PortNamesRTB;
        private System.Windows.Forms.ComboBox ComboPorts;
        private System.Windows.Forms.ComboBox ComboBaudRates;
        private System.Windows.Forms.ComboBox ComboDataBits;
        private System.Windows.Forms.ComboBox ComboHandShake;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblBreakStatus;
        private System.Windows.Forms.Label lblCTSStatus;
        private System.Windows.Forms.Label lblDSRStatus;
        private System.Windows.Forms.Label lblRIStatus;
        private System.Windows.Forms.Label label5;
    }
}

