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
            this.PortMessage = new System.Windows.Forms.RichTextBox();
            this.ComboPorts = new System.Windows.Forms.ComboBox();
            this.ComboBaudRates = new System.Windows.Forms.ComboBox();
            this.ComboDataBits = new System.Windows.Forms.ComboBox();
            this.ComboHandShake = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PortRecieve = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetPortsB
            // 
            this.GetPortsB.Location = new System.Drawing.Point(349, 159);
            this.GetPortsB.Name = "GetPortsB";
            this.GetPortsB.Size = new System.Drawing.Size(75, 23);
            this.GetPortsB.TabIndex = 0;
            this.GetPortsB.Text = "Scan Ports";
            this.GetPortsB.UseVisualStyleBackColor = true;
            this.GetPortsB.Click += new System.EventHandler(this.button1_Click);
            // 
            // PortMessage
            // 
            this.PortMessage.Location = new System.Drawing.Point(28, 34);
            this.PortMessage.Name = "PortMessage";
            this.PortMessage.Size = new System.Drawing.Size(213, 172);
            this.PortMessage.TabIndex = 2;
            this.PortMessage.Text = "";
            // 
            // ComboPorts
            // 
            this.ComboPorts.FormattingEnabled = true;
            this.ComboPorts.Location = new System.Drawing.Point(326, 34);
            this.ComboPorts.Name = "ComboPorts";
            this.ComboPorts.Size = new System.Drawing.Size(121, 21);
            this.ComboPorts.TabIndex = 3;
            // 
            // ComboBaudRates
            // 
            this.ComboBaudRates.FormattingEnabled = true;
            this.ComboBaudRates.Location = new System.Drawing.Point(326, 61);
            this.ComboBaudRates.Name = "ComboBaudRates";
            this.ComboBaudRates.Size = new System.Drawing.Size(121, 21);
            this.ComboBaudRates.TabIndex = 4;
            // 
            // ComboDataBits
            // 
            this.ComboDataBits.FormattingEnabled = true;
            this.ComboDataBits.Location = new System.Drawing.Point(326, 88);
            this.ComboDataBits.Name = "ComboDataBits";
            this.ComboDataBits.Size = new System.Drawing.Size(121, 21);
            this.ComboDataBits.TabIndex = 5;
            // 
            // ComboHandShake
            // 
            this.ComboHandShake.FormattingEnabled = true;
            this.ComboHandShake.Location = new System.Drawing.Point(326, 115);
            this.ComboHandShake.Name = "ComboHandShake";
            this.ComboHandShake.Size = new System.Drawing.Size(121, 21);
            this.ComboHandShake.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PortRecieve
            // 
            this.PortRecieve.Location = new System.Drawing.Point(541, 34);
            this.PortRecieve.Name = "PortRecieve";
            this.PortRecieve.Size = new System.Drawing.Size(213, 172);
            this.PortRecieve.TabIndex = 2;
            this.PortRecieve.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(430, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(760, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 232);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ComboHandShake);
            this.Controls.Add(this.ComboDataBits);
            this.Controls.Add(this.ComboBaudRates);
            this.Controls.Add(this.ComboPorts);
            this.Controls.Add(this.PortRecieve);
            this.Controls.Add(this.PortMessage);
            this.Controls.Add(this.GetPortsB);
            this.Name = "Form1";
            this.Text = "Robo Talk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetPortsB;
        private System.Windows.Forms.RichTextBox PortMessage;
        private System.Windows.Forms.ComboBox ComboPorts;
        private System.Windows.Forms.ComboBox ComboBaudRates;
        private System.Windows.Forms.ComboBox ComboDataBits;
        private System.Windows.Forms.ComboBox ComboHandShake;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox PortRecieve;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

