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
using System.Diagnostics;


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
            
           
            try
            {
                string portName = ComboPorts.Text; //get port name from ComboBox
                ConnectedPort = connect.connectRobot(portName);
              //  MessageBox.Show(portName);
        
                string[] codes = inpt.divideIntoLines(PortMessage);

                foreach (var item in codes)
                {
                    command = inpt.interpret(item);
                    string sendMessage = "";
                    for (int i = 0; i < command.Length; i++)
                    {
                        char c = (char)command[i];
                        sendMessage += c.ToString();
                     }
                    sendMessage += "a";
                   sendMessage =  sendMessage.Remove(sendMessage.Length - 1, 1);
                    Debug.WriteLine(sendMessage);
                   // ConnectedPort.Write(sendMessage);
                    ConnectedPort.WriteLine(sendMessage);
                    System.Threading.Thread.Sleep(100);

                    string recieve = "";
                    for (int i = 0; i < command.Length; i++)
                    {
                        char c = (char)ConnectedPort.ReadChar();
                        recieve += c.ToString();
                    }
                    //ConnectedPort.ReadChar();
                    PortRecieve.Text = recieve;

                }
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

           char c = (char)ConnectedPort.ReadChar();
           PortRecieve.Text += c.ToString();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ConnectedPort != null && ConnectedPort.IsOpen)
            {
                ConnectedPort.Close();
            }
        }

       
    }
}
