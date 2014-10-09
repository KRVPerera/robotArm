using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace RobotInteractive_Windows
{
<<<<<<< HEAD
    class Interpreter
    {
        public int[] interpret(string command)
        {
            int[] roboCommand=new int[3];
            char motorID;
            int position1=0;//1st byte of position
            int position2=0;//2nd byte of position


            int position=0;
            

            string[] sections;

            sections = command.Split(' ');
            motorID = sections[1][0];
            Debug.WriteLine(motorID);
            try
            {
                if (sections[2].Equals("STOP"))
                {
                    motorID = (char)(motorID ^ 32);
                }
                else
                {
                    try
                    {
                        position = Convert.ToInt16(sections[2]);
                    }
                    catch (System.FormatException e)
                    {
                        MessageBox.Show("Use correct format\nEx: Moter A 32547", "Invalid Command",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (position < 0)
                    {
                        //if position is negative add 1 to 8th bit
                        Debug.WriteLine(position);
                        position *= (-1);
                        position1 += (1 << 7);
                    }

                    position1 += (position / 255);
                    position2 = (position % 255);

                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.WriteLine(e);
                MessageBox.Show("Use correct format\nEx: Moter A STOP", "Invalid Command",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Debug.WriteLine(position1);
            Debug.WriteLine(position2);
            roboCommand[0] = (int)motorID;
            roboCommand[1] = position1;
            roboCommand[2] = position2;
            
            return roboCommand;
        }
    }
=======
   
>>>>>>> 0e17c62c0e59388742a2765357a2057a8bedb8fd
}
