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
using System.IO;

namespace StayConnected_Client
{
    public partial class Form1 : Form
    {
        Socket client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //1: Create socket
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //2: Build the server endpoint
                IPAddress ipaddress = IPAddress.Parse(txtIPAddress.Text);
                int port = int.Parse(txtPortNumber.Text);
                IPEndPoint serverEndP = new IPEndPoint(ipaddress, port);

                //3: Connect to the server, using the connect method defined in the Socket class
                client.Connect(serverEndP);

                //enable the other buttons
                btnSendReceive.Enabled = true;
                btnCloseConnection.Enabled = true;

                btnConnect.Enabled = false;
                //Optional
                MessageBox.Show("Connection established");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            catch(FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSendReceive.Enabled = false;
            btnCloseConnection.Enabled = false;
        }

        private void btnSendReceive_Click(object sender, EventArgs e)
        {
            string request = txtRequest.Text;
            if (request.Trim() == String.Empty)
            {
                MessageBox.Show("Must enter a request");
                return;
            }
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(request);
                client.Send(data);

                //receive response
                byte[] buffer = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytesReceived;
                while ((bytesReceived = client.Receive(buffer)) != 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    sb.Append(response);
                }

                //int bytesReceived = client.Receive(buffer);
                //string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                //display it
                rchtxtbxResponse.Text = "Result = " + sb.ToString();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void btnCloseConnection_Click(object sender, EventArgs e)
        {
            //Choose a keyword to use to let the server know the client wants to close
            //the connection
            string request = "bye";
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(request);
                client.Send(data);

                //receive response
                byte[] buffer = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytesReceived;
                while ((bytesReceived = client.Receive(buffer)) != 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    sb.Append(response);
                }

                //int bytesReceived = client.Receive(buffer);
                //string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                //display it
                rchtxtbxResponse.Text = "Result = " + sb.ToString();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if(client != null && client.Connected)
                {
                    //Close both the input and output streams
                    client.Shutdown(SocketShutdown.Both);
                    //Close or dispose of the socket
                    client.Close();
                    //optional
                    MessageBox.Show("Client is now disconnected");
                    btnConnect.Enabled = true;
                    btnSendReceive.Enabled = false;
                    btnCloseConnection.Enabled = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(btnCloseConnection.Enabled == true)
            {
                btnCloseConnection_Click(sender, new EventArgs());
            }
        }
    }
}
