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
        
        SerialConnector connect = new SerialConnector();
        Interpreter inpt = new Interpreter();

        SerialPort ConnectedPort;
        int[] command;

        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.scanComPorts(ComboPorts);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string portName;
            //get port name from ComboBox
            try
            {
               // MessageBox.Show("Test1");
                portName = ComboPorts.Text;
                MessageBox.Show(portName);
            //connect to the port
            ConnectedPort = connect.connectRobot(portName);

            if (!ConnectedPort.IsOpen)//if not open 
            {
                ConnectedPort.Open();
            }

            string[] codes = inpt.divideIntoLines(PortMessage);

            System.Threading.Thread.Sleep(100);


            ConnectedPort.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter a valid message to decode and send..!!");
            } 
        }

        void recieve()
        {
          //  ConnectedPort = new SerialPort(PortNames[0], 9600, Parity.None, 8, StopBits.One);
            if (!ConnectedPort.IsOpen)
            {
                ConnectedPort.Open();
            }

           int c = ConnectedPort.ReadChar();
           PortRecieve.Text = c.ToString();
           ConnectedPort.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
