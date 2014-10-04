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
            Array.Sort(PortNames);

            try
                {
            do
            {
                index += 1;
                
                   // PortNamesRTB.Text += PortNames[index] + "\n";
               ComboPorts.Items.Add(PortNames[index]);
              
            } while (!((PortNames[index] == PortNm)) || (index == PortNames.GetUpperBound(0)));
                }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Reading COM ports");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
