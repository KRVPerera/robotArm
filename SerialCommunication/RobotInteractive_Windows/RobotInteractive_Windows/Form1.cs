using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace RobotInteractive_Windows
{
    
    public partial class Form1 : Form
    {
        SerialPort ComPort = new SerialPort(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] PortNames = null;
            int index = -1;
            string PortNm = null;

            PortNames = SerialPort.GetPortNames();
            try
                {
            do
            {
                index += 1;
                
                    PortNamesRTB.Text += PortNames[index] + "\n";
              
            } while (!((PortNames[index] == PortNm)) || (index == PortNames.GetUpperBound(0)));
                }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Array");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
