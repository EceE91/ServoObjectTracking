using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace proje
{
    public partial class ServoControlFrame : Form
    {
        public SerialPort port;
        public string[] allPorts;
        public bool isConnected;
        public bool clickedClosed=false;
        public ServoControlFrame()
        {
            InitializeComponent();
           
            listAllPorts();
        }

        public void defineStatus(bool status)
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

        public void listAllPorts()
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

                permissions(true, true, false, true, true, false, false);

            }
            else
            {
                // Available olan port yok ise
                defineStatus(false);

                permissions(false, false, false, false, true, false, false);

                MessageBox.Show(this, "No Port Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void permissions(bool ports, bool connector, bool disconnector,
            bool baudrate, bool check, bool rightWing, bool leftWing)
        {
            comboBoxPorts.Enabled = ports;
            btConnector.Enabled = connector;
            btDisconnector.Enabled = disconnector;
            comboBoxBaudRate.Enabled = baudrate;

        }

          public double MinY = 60;
          public double MaxY = 120;

          public double MinX = 60; // 0 olarak degstr
          public double MaxX = 120;// 180 olarak degstr

        public void FindServoPosition(Point trackingObjectPoint, int screenWidth, int screenHeight)
        {
            double per_x = ((double)trackingObjectPoint.X / (double)screenWidth);
            double per_y = ((double)trackingObjectPoint.Y / (double)screenHeight);

            double pitch = Scale(per_y, 0, 1, MinY, MaxY);
            double yaw = Scale(per_x, 0, 1, MinX, MaxX);

            SetServoPos((int)yaw, (int)pitch);
            System.Threading.Thread.Sleep(100);
        }

        public double Scale(double value, int min1, int max1, double min2, double max2)
        {
            double sonuc=0;
                if(port.IsOpen){
                    if (value < min1) value = min1;
                    if (value > max1) value = max1;

                    double VP = (value - min1) / (max1 - min1);
                    sonuc=((max2 - min2) * VP + min2);
                }
                return sonuc;
        }

        public void SetServoPos(int Yaw, int Pitch)
        {
            if (port.IsOpen)
            {
                byte[] DATA = new byte[2];

                DATA[0] = (byte)Scale(Yaw, 0, 180, 0, 127);   // X  
                DATA[1] = (byte)Scale(Pitch, 0, 180, 127, 255); // Y 

                port.Write(DATA, 0, DATA.Length); // DATA => name of byte array, 0 => array index offset
            }
        }


        public void tbMinX_Scroll(object sender, EventArgs e)
        {
            MinX = tbMinX.Value;
            SetServoPos(tbMinX.Value, tbMinY.Value);
        }

        public void tbMaxX_Scroll(object sender, EventArgs e)
        {

            MaxX = tbMaxX.Value;
            SetServoPos(tbMaxX.Value, tbMaxY.Value);
        }

        public void tbMinY_Scroll(object sender, EventArgs e)
        {
            MinY = tbMinY.Value;
            SetServoPos(tbMinX.Value, tbMinY.Value);
        }

          public void tbMaxY_Scroll(object sender, EventArgs e)
        {
            MaxY = tbMaxY.Value;
            SetServoPos(tbMaxX.Value, tbMaxY.Value);
        }

        public void getPort()
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                port = null;
                defineStatus(false);
                listAllPorts();

                tbMaxX.Value = tbMaxX.Minimum;
                tbMaxY.Value = tbMaxY.Minimum;
                tbMinX.Value = tbMinX.Minimum;
                tbMinY.Value = tbMinY.Minimum;
            }
        }

        public void btConnector_Click(object sender, EventArgs e)
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
                    clickedClosed = false;
                    tabControl1.Enabled = true;
                    permissions(false, false, true, false, false, true, true);
                    defineStatus(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Sorry, we could not connect to the Arduino.\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(0);
            }
        }

          private void btDisconnector_Click(object sender, EventArgs e)
          {
              getPort();
              clickedClosed = true;
              tabControl1.Enabled = false;
          }

          private void ServoControlFrame_Load(object sender, EventArgs e)
          {
              tabControl1.Enabled = false;
       
              port = new SerialPort();
          }

          private void ServoControlFrame_FormClosing(object sender, FormClosingEventArgs e)
          {
              getPort();
              tbMaxX.Value = tbMaxX.Minimum;
              tbMaxY.Value = tbMaxY.Minimum;
              tbMinX.Value = tbMinX.Minimum;
              tbMinY.Value = tbMinY.Minimum;
              tbMaxY.Refresh();
              tbMinX.Refresh();
              tbMinY.Refresh();
              tbMaxX.Refresh();
          }

        

   
    }
}
