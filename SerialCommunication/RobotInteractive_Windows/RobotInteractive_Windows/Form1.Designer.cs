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
            this.SuspendLayout();
            // 
            // GetPortsB
            // 
            this.GetPortsB.Location = new System.Drawing.Point(171, 12);
            this.GetPortsB.Name = "GetPortsB";
            this.GetPortsB.Size = new System.Drawing.Size(75, 23);
            this.GetPortsB.TabIndex = 0;
            this.GetPortsB.Text = "Get Ports";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.PortNamesRTB);
            this.Controls.Add(this.GetPortsB);
            this.Name = "Form1";
            this.Text = "b";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetPortsB;
        private System.Windows.Forms.RichTextBox PortNamesRTB;
    }
}

