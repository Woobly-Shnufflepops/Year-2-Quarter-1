using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SimpleWindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            Socket client = null;
            try
            {
                string request = txtRequest.Text;
                if (request.Trim() == String.Empty)
                {
                    MessageBox.Show("Must enter a request");
                    return;
                }

                //1: Create socket
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //2: Build the server endpoint
                IPAddress ipaddress = IPAddress.Parse(txtIPAddress.Text);
                int port = int.Parse(txtPortNumber.Text);
                IPEndPoint serverEndP = new IPEndPoint(ipaddress, port);

                //3: Connect to the server, using the connect method defined in the Socket class
                client.Connect(serverEndP);

                //Request/Response client server app

                //send request
                //conver to bytes
                byte[] data = Encoding.UTF8.GetBytes(request);
                client.Send(data);

                //receive response
                byte[] buffer = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytesReceived;
                while((bytesReceived = client.Receive(buffer)) != 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    sb.Append(response);
                }

                //int bytesReceived = client.Receive(buffer);
                //string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                //display it
                richTextBox1.Text = "Result = " + sb.ToString();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            finally
            {
                if(client != null && client.Connected)
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
        }
    }
}
