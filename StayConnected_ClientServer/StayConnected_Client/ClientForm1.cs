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
                //1. create sockect
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2. build the server endpoint
                IPAddress ipaddress = IPAddress.Parse(txtServerIP.Text);
                int port = int.Parse(txtPort.Text);
                IPEndPoint serverEndP = new IPEndPoint(ipaddress, port);
                //3.Connect to the server, using the connect method defined in the Socket class
                client.Connect(serverEndP);
                //send credentials
                //string request = "credentials Lhoucine";
                // byte[] data = Encoding.UTF8.GetBytes(request);
                //client.Send(data);

                //get response if you set up the server to respond to this request
                byte[] buffer = new byte[1024];
                int bytesReceived = client.Receive(buffer);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                rtbResponse.Text = response;

                //enable the other buttons
                btnSend.Enabled = true;
                btnClose.Enabled = true;

                btnConnect.Enabled = false;
                //optional
                MessageBox.Show("connection was made");
            }
            catch(SocketException se)
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
            btnSend.Enabled = false;
            btnClose.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string request = txtRequest.Text;
            if (request.Trim() == String.Empty)
            {
                MessageBox.Show("Must enter a request");
                return;
            }
            try
            {
                //send request                   
                //convert to bytes
                byte[] data = Encoding.UTF8.GetBytes(request);
                client.Send(data);

                //receive response
                byte[] buffer = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytesReceived;
                //while ((bytesReceived = client.Receive(buffer)) != 0)
                //{
                //    string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                //    sb.Append(response);
                //}
                bytesReceived = client.Receive(buffer);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                //display it
                rtbResponse.Text = "Result = " + response;
            }
            catch(SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //choose a keyword to use to let the server know the client
            //wants to close the connection
            string request = "bye";

            try
            {
                //send request                   
                //convert to bytes
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


                //display it
                rtbResponse.Text = "Result = " + sb.ToString();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if(client!=null && client.Connected)
                {
                    //close both the input and output streams
                    client.Shutdown(SocketShutdown.Both);
                    //close or dispose of the socket
                    client.Close();
                    //optional
                    MessageBox.Show("Client is now disconnected");
                    btnConnect.Enabled = true;
                    btnSend.Enabled = false;
                    btnClose.Enabled = false;
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose_Click(sender, new EventArgs());
        }
    }
}
