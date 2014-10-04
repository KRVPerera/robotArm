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
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;

        public Form1()
        {
            InitializeComponent();
            SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            ComPort.PinChanged += SerialPinChangedEventHandler1;
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
            SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            ComPort.PinChanged += SerialPinChangedEventHandler1;
            try
            {
                ComPort.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("IO Exception Occured while openning com port");
            }
            ComPort.RtsEnable = true;
            ComPort.DtrEnable = true;
            button1.Enabled = false;
        }

        internal void PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange SerialPinChange1 = 0;
            bool signalState = false;
            SerialPinChange1 = e.EventType;
            lblCTSStatus.BackColor = Color.Green;
            lblDSRStatus.BackColor = Color.Green;
            lblRIStatus.BackColor = Color.Green;
            lblBreakStatus.BackColor = Color.Green;

            switch (SerialPinChange1)
            {
                case SerialPinChange.Break:
                    lblBreakStatus.BackColor = Color.Red;
                    //MessageBox.Show("Break is Set");
                    break;
                case SerialPinChange.CDChanged:
                    signalState = ComPort.CtsHolding;
                    //  MessageBox.Show("CD = " + signalState.ToString());
                    break;
                case SerialPinChange.CtsChanged:
                    signalState = ComPort.CDHolding;
                    lblCTSStatus.BackColor = Color.Red;
                    //MessageBox.Show("CTS = " + signalState.ToString());
                    break;
                case SerialPinChange.DsrChanged:
                    signalState = ComPort.DsrHolding;
                    lblDSRStatus.BackColor = Color.Red;
                    // MessageBox.Show("DSR = " + signalState.ToString());
                    break;
                case SerialPinChange.Ring:
                    lblRIStatus.BackColor = Color.Red;
                    //MessageBox.Show("Ring Detected");
                    break;
            }
        }
    }
}
