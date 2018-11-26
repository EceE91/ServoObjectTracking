using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace proje
{
    public class ServoClass
    {
        // define variables
        public SerialPort serial;
        public int positionX;
        public int positionY;
        public String[] allPorts;
        public bool isConnected = false;

        // constructor
        public ServoClass() {
            begin();
        }

        public void begin() {
            serial = new SerialPort();

            allPorts = SerialPort.GetPortNames();
            if (allPorts.Length > 0)
            {

                serial.PortName = "COM19";
                serial.BaudRate = 19200;
               
                if (!serial.IsOpen)
                {
                    serial.Open();
                    isConnected = true;
                }
                positionX = 60;
                positionY = 60 + 181;
                serial.WriteLine("060");
            }
        
        }


        public void ClosePort() {
            
            if (serial != null && serial.IsOpen)
            {
                serial.Close();
                serial = null;
            }
        
        }

        // if object is moving at +Y direction, turn servoY to the right for keeeping the tracking object in the center
        public void TurnServoYRight()
        {
            if (!serial.IsOpen)
            {
                serial.Open(); 
            }
            if (isConnected == true) 
            {
                if (positionY >= 60+181 && positionY < 180+181)
                {
                    positionY += (10+181);

                }
                if (positionY >= 60+181 && positionY >= 100+181)
                {
                    serial.WriteLine(positionY.ToString());
                }
                else
                {
                    serial.WriteLine("0" + positionY.ToString());
                }
            }

        }

        // if object is moving at +x direction, turn servoX to the right for keeeping the tracking object in the center
        public void TurnServoXRight()
        {
            if (!serial.IsOpen)
            {
                serial.Open(); 
            }
            if (isConnected == true)
            {

                if (positionX >= 60 && positionX < 180)
                {
                    positionX += 10;

                }
                if (positionX >= 60 && positionX >= 100)
                {
                    serial.WriteLine(positionX.ToString());
                }
                else
                {
                    serial.WriteLine("0" + positionX.ToString());
                }

            }

        }

        // if object is moving at -y direction, turn servoY to the left for keeeping the tracking object in the center
        public void TurnServoYLeft()
        {
            if (!serial.IsOpen)
            {
                serial.Open();
            }

            if (isConnected == true)
            {
                if (positionY > 60+181 && positionY <= 180+181)
                {
                    positionY -= 10+181;
                }
                if (positionY >= 60+181 && positionY >= 100+181)
                {
                    serial.WriteLine(positionY.ToString());
                }
                else if (positionY == 60+181)
                {
                    serial.WriteLine("241");
                }
                else
                {
                    serial.WriteLine("0" + positionY.ToString());
                }

            }
        }

        // if object is moving at -x direction, turn servoX to the left for keeeping the tracking object in the center
        public void TurnServoXLeft()
        {
            if (!serial.IsOpen)
            {
                serial.Open();
            }
            if (isConnected == true)
            {

                if (positionX > 60 && positionX <= 180)
                {
                    positionX -= 10;
                }
                if (positionX >= 60 && positionX >= 100)
                {
                    serial.WriteLine(positionX.ToString());
                }
                else if (positionX == 60)
                {
                    serial.WriteLine("060");
                }
                else
                {
                    serial.WriteLine("0" + positionX.ToString());
                }
            }
         }
    }
}
