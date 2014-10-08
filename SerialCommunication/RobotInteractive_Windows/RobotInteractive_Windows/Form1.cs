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
        SerialPort ConnectedPort;
        string[] PortNames = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
                    ComboPorts.Text = PortNames[0];
                } while (!((PortNames[index] == PortNm)) || (index == PortNames.GetUpperBound(0)));

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Reading COM ports");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBaudRates.Items.Add(300);
            ComboBaudRates.Items.Add(600);
            ComboBaudRates.Items.Add(1200);
            ComboBaudRates.Items.Add(2400);
            ComboBaudRates.Items.Add(9600);
            ComboBaudRates.Items.Add(14400);
            ComboBaudRates.Items.Add(19200);
            ComboBaudRates.Items.Add(38400);
            ComboBaudRates.Items.Add(57600);
            ComboBaudRates.Items.Add(115200);
            ComboBaudRates.Text = ComboBaudRates.Items[0].ToString();

            ComboDataBits.Items.Add(8);
            ComboDataBits.Items.Add(7);
            ComboDataBits.Items.Add(6);
            ComboDataBits.Items.Add(5);
            ComboDataBits.Text = ComboDataBits.Items[0].ToString();

            ComboHandShake.Items.Add("None");
            ComboHandShake.Items.Add("XOnXOff");
            ComboHandShake.Items.Add("RequestToSend");
            ComboHandShake.Items.Add("RequestToSendXOnXOff");
            ComboHandShake.Text = ComboHandShake.Items[0].ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConnectedPort = new SerialPort("COM1",9600,Parity.None,8,StopBits.One);
            if (!ConnectedPort.IsOpen)
            {
                ConnectedPort.Open();
            }

            string text = PortMessage.Text;
            text = text.Remove(text.Length-1,1);
            ConnectedPort.WriteLine(text);
            char a = (char)ConnectedPort.ReadChar();
            char b = (char)ConnectedPort.ReadChar();
            char c = (char)ConnectedPort.ReadChar();
            PortRecieve.Text += a.ToString();
            PortRecieve.Text += b.ToString();
            PortRecieve.Text += c.ToString();
            ConnectedPort.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            PortRecieve.Text = "";
        }

       
    }
}
