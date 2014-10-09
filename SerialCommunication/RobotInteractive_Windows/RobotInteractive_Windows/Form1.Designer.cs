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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GetPortsB = new System.Windows.Forms.Button();
            this.PortMessage = new System.Windows.Forms.RichTextBox();
            this.ComboPorts = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PortRecieve = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetPortsB
            // 
            this.GetPortsB.Location = new System.Drawing.Point(289, 170);
            this.GetPortsB.Name = "GetPortsB";
            this.GetPortsB.Size = new System.Drawing.Size(75, 23);
            this.GetPortsB.TabIndex = 0;
            this.GetPortsB.Text = "Scan Ports";
            this.GetPortsB.UseVisualStyleBackColor = true;
            this.GetPortsB.Click += new System.EventHandler(this.button1_Click);
            // 
            // PortMessage
            // 
            this.PortMessage.Location = new System.Drawing.Point(28, 49);
            this.PortMessage.Name = "PortMessage";
            this.PortMessage.Size = new System.Drawing.Size(213, 196);
            this.PortMessage.TabIndex = 2;
            this.PortMessage.Text = "";
            // 
            // ComboPorts
            // 
            this.ComboPorts.FormattingEnabled = true;
            this.ComboPorts.Location = new System.Drawing.Point(264, 143);
            this.ComboPorts.Name = "ComboPorts";
            this.ComboPorts.Size = new System.Drawing.Size(121, 21);
            this.ComboPorts.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PortRecieve
            // 
            this.PortRecieve.Location = new System.Drawing.Point(416, 51);
            this.PortRecieve.Name = "PortRecieve";
            this.PortRecieve.Size = new System.Drawing.Size(213, 194);
            this.PortRecieve.TabIndex = 2;
            this.PortRecieve.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(503, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "COM Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MidnightBlue;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(25, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baud Rate : 9600";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(122, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Bits : 8";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(193, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hand Shake : None";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.MidnightBlue;
            this.label5.Enabled = false;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(301, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Stop Bit : One";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RobotInteractive_Windows.Properties.Resources.connect_e1324382075648_600;
            this.ClientSize = new System.Drawing.Size(656, 272);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ComboPorts);
            this.Controls.Add(this.PortRecieve);
            this.Controls.Add(this.PortMessage);
            this.Controls.Add(this.GetPortsB);
            this.ForeColor = System.Drawing.Color.DarkMagenta;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robo Talk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetPortsB;
        private System.Windows.Forms.RichTextBox PortMessage;
        private System.Windows.Forms.ComboBox ComboPorts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox PortRecieve;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

