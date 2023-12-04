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

namespace U4_Practica_3_Arduino
{
    public partial class Form1 : Form
    {
        String[] ports;
        SerialPort port;
        bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
            getAvailableCOM_PORTS();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);

                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox1.Checked)
                {
                    port.Write("$LEDRON");
                }

                else
                {
                    port.Write("$LEDROF");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox2.Checked)
                {
                    port.Write("$LEDGON");
                }

                else
                {
                    port.Write("$LEDGOF");
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox3.Checked)
                {
                    port.Write("$LEDBON");
                }

                else
                {
                    port.Write("$LEDBOF");
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox4.Checked)
                {
                    port.Write("$LEDYON");
                }

                else
                {
                    port.Write("$LEDYOF");
                }

            }
        }
        private void getAvailableCOM_PORTS()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            button1.Text = "Desconectar";
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
            button1.Text = "Conectar";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }

            else
            {
                disconnectFromArduino();
            }
        }
    }
}
