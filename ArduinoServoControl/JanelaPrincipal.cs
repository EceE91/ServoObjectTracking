/**
 * 
 * 
 * Ardinio ile Servo motoru  
 * portlara bağlama aplikasyonu
 * 
 * Autor: Ece ERCAN
 * E-mail: eceercan91@hotmail.com
 * 
 * Data: 12/08/2013
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArduinoServoControl
{
    public partial class MainWindow : Form 
    {
        /**
         * used the class "SerialPort" to connect the serial port 
         * (in my case the port "COM19") and send the desired command using "Write ()" or 
         * "WriteLine ()", which can be a string, char or array of bytes.
         *                          WARNING !!!
         *  For Ardunio Pro mini because of a hardware error the baud rate on Ardunio Serial Monitor or 
         *  C# Application Program Has to be set to 19200
         *  BUT on Ardunio 1.5.0 IDE the baud rate has to be set to 9600 !!
         */


        private SerialPort port;
        private string[] allPorts;
        private int position;
        private Boolean isConnected;

        public MainWindow()
        {
            InitializeComponent();
            listAllPorts();
            
        }

        private void defineStatus(bool status)
        {
            if (status == true)
            {
                // Eger açık (available) bir port var ise Connected durumda olur
                statusLabel.Text = "Connected";
                statusLabel.ForeColor = Color.Green;
                isConnected = true;
            }
            else
            {
                statusLabel.Text = "Disconnected";
                statusLabel.ForeColor = Color.Red;
                isConnected = false;
            }
        }

        private void listAllPorts()
        {
            allPorts = SerialPort.GetPortNames();

            if (allPorts.Length > 0)
            {
                comboBoxPorts.Items.Clear();
                comboBoxPorts.SelectedIndex = -1;
                comboBoxBaudRate.SelectedIndex = -1;

                foreach (string s in SerialPort.GetPortNames())
                {
                    comboBoxPorts.Items.Add(s);
                }

                defineStatus(false);

                permissions(true,true,false,true,true,false,false);

            }
            else
            {
                // Available olan port yok ise
                defineStatus(false);

                permissions(false, false, false, false, true, false,false);

                MessageBox.Show(this, "No Port Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void permissions(bool ports, bool connector, bool disconnector,
            bool baudrate, bool check, bool rightWing, bool leftWing)
        {
            comboBoxPorts.Enabled = ports;
            btConnector.Enabled = connector;
            btDisconnector.Enabled = disconnector;
            comboBoxBaudRate.Enabled = baudrate;
           
            // available olan portları combobox ta göster
            btCheckPorts.Enabled = check;

            btRight.Enabled = rightWing;
            btLeft.Enabled = leftWing;
        }

        private void getPort()
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                port = null;
                defineStatus(false);
                listAllPorts();
            }
            
        }

        // ProcessCmdKey, keyboard dan aldığı keycode a göre işlem yapacaktır (servo motorun dönme yönünün keyboard dan kontrolü)
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            if (isConnected == true)
            {
                bool blnProcess = false;
                
                // sol tuşuna basıldıysa
                if (keyData == Keys.Left)
                {
                    // servo nun max 180 derece döndüğü düşünülür ve eğer 180'den küçük ise 10 derece sola döndürülür
                    if (position >= 60 && position < 180)
                    {
                        position += 10;
                        
                    }
                    if (position >= 60 && position >= 100)
                    {
                        port.WriteLine(position.ToString());
                    }
                    else
                    {
                        port.WriteLine("0" + position.ToString());
                    }

                    labelDegrees.Text = position.ToString();

                    imgRight.Image = Properties.Resources.right_up;
                    imgLeft.Image = Properties.Resources.left_down;
                    
                    blnProcess = true;
                }

                if (keyData == Keys.Right)
                {
                    if (position > 60 && position <= 180)
                    {
                        position -= 10;
                    }


                    if (position >= 60 && position >= 100)
                    {
                        port.WriteLine(position.ToString());
                    }
                    else if (position == 60)
                    {
                        port.WriteLine("060");
                    }
                    else
                    {
                        port.WriteLine("0" + position.ToString());
                    }

                    labelDegrees.Text = position.ToString();

                    imgLeft.Image = Properties.Resources.left_up;
                    imgRight.Image = Properties.Resources.right_down;

                    blnProcess = true; 
                }

                if (blnProcess == true)
                {
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref m, keyData);
                }
            }

            else

            {
                return false;
            }

        }

        private void btDisconnector_Click(object sender, EventArgs e)
        {
            getPort();
            imgLeft.Image = Properties.Resources.left_up;
            imgRight.Image = Properties.Resources.right_up;
            labelDegrees.Text = "60";
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBoxPorts.SelectedIndex != -1 && comboBoxBaudRate.SelectedIndex != -1)
                {
                    port = new SerialPort();
                    port.PortName = comboBoxPorts.SelectedItem.ToString();
                    port.BaudRate = Int32.Parse(comboBoxBaudRate.SelectedItem.ToString());
                }
                else
                {
                    throw new Exception("Select the PORT and BAUD RATE to connect");
                }

                if (!port.IsOpen)
                {
                    port.Open();
                    position = 60;
                    port.WriteLine("060");

                    permissions(false, false, true, false, false,true,true);
                    defineStatus(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Sorry, we could not connect to the Arduino.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(0);
            }
        }

        private void btCheckPorts_Click(object sender, EventArgs e)
        {
            listAllPorts();
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            if (position >= 60 && position < 180)
            {
                position += 10;
               
            }


            if (position >= 60 && position >= 100)
            {
                port.WriteLine(position.ToString());
            }
            else
            {
                port.WriteLine("0" + position.ToString());
            }

            labelDegrees.Text = position.ToString();
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            if (position > 60 && position <= 180)
            {
                position -= 10;
            }


            if (position >= 60 && position >= 100)
            {
                port.WriteLine(position.ToString());
            }
            else if (position == 60)
            {
                port.WriteLine("060");
            }
            else
            {
                port.WriteLine("0" + position.ToString());
            }

            labelDegrees.Text = position.ToString();
        }

        private void JanelaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            getPort();
        }

        
    }
}
