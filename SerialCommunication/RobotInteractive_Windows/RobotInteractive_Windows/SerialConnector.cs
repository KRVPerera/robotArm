using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace RobotInteractive_Windows
{
    public class SerialConnector
    {
        SerialPort ComPort = new SerialPort();
        SerialPort ConnectedPort;
        string[] PortNames = null;
        
        public void scanComPorts(ComboBox ComboPorts)
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
                    ComboPorts.Items.Add(PortNames[index]);
                    ComboPorts.Text = PortNames[0];
                } while (!((PortNames[index] == PortNm)) || (index == PortNames.GetUpperBound(0)));

            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Reading COM ports");
            }

        }


        public SerialPort connectRobot(string portName)
        {
            //selected values according to robots Atmega2560
            ConnectedPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            return ConnectedPort;
        }
        
    }

    
}
