using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoServoControl
{
    public partial class EcePrincipal : Form
    {

        public SerialPort SeriPort;

        public EcePrincipal()
        {
            InitializeComponent();
            Connect_Port();
        }

        private void Connect_Port()
        {
            SeriPort.PortName = "COM19";
            SeriPort.BaudRate = 115200;
            SeriPort.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeriPort.Write("turnon");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeriPort.Write("turnoff");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SeriPort.Write("onandoff");
        }
    }
}
