/*
 * Author: Matthew Powers
 * Date: 2/26/18
 * Assignment: Client Server Application
 */

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

namespace SimpleServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                const int port = 8000;
                
                try
                {
                    //1: Create a Socket
                    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //2: Create a Server EndPoint: IP Address + Port
                    //Get this local computer IP Address
                    IPAddress[] ipaddresses = Dns.GetHostAddresses(Dns.GetHostName());
                    IPAddress ipaddress = GetIPv4(ipaddresses);

                    EndPoint endP = new IPEndPoint(ipaddress, port);

                    //3: Bind the EndPoint to the Socket
                    server.Bind(endP);

                    //4: Set the socket in listening mode
                    server.Listen(20); //The listen starts a background thread that enques client to a queue
                    //(called backlog). 20 is the isze of the queue

                    //Display server name, address, and port
                    SetText(Dns.GetHostName() + " " + ipaddress + ":" + port);

                    //Steps 5 and 6 in a while loop
                    while (true)
                    {
                        //5: Accept client that connected with this server
                        Socket client = server.Accept();
                        //The Accept method blocks if the backlog is empty
                        //Otherwise, it returns a reference to the next client in the backlog to be processed

                        DisplayClientInfo(client);

                        //6: Process the client
                        Task.Factory.StartNew(() =>
                        {
                            ProcessClient(client);
                        });
                    }

                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
                
            });
        }
        //Helper method that returns an IPv4
        private IPAddress GetIPv4(IPAddress[] ipaddresses)
        {
            foreach(IPAddress ipaddress in ipaddresses)
            {
                if(ipaddress.GetAddressBytes().Length == 4)
                {
                    return ipaddress;
                }
            }
            return null;
        }

        private void SetText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                Action<string> action = SetText;
                this.Invoke(action, text);
            }
            else
            {
                richTextBox1.AppendText(text + "\n");
                richTextBox1.ScrollToCaret();
            }
        }

        public void DisplayClientInfo(Socket client)
        {
            //Get the client EndPoint using the RemoteEndPoint property of the Socket
            IPEndPoint clientEndP = (IPEndPoint)client.RemoteEndPoint;
            //client IP Address
            IPAddress clientIPAddress = clientEndP.Address;
            //client port
            int clientPort = clientEndP.Port;
            //get client hostname
            string clientName = Dns.GetHostEntry(clientIPAddress).HostName;

            richTextBox1.AppendText(string.Format("\nClient Request From {0} at {1}:{2}", clientName, clientIPAddress, clientPort));
        }

        static void ProcessClient(Socket client)
        {
            //1: Recive a client request
            byte[] buffer = new byte[256];
            int bytesReceived = client.Receive(buffer);
            //convert bytes to a string (convert only the bytes received not 256 bytes set up)

            string request = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

            //2: Do some work (process it)
            string response = ProcessRequest(request);

            //3: Return a response
            SendResponse(client, response);
        }

        static string ProcessRequest(string request)
        {
            if (request == string.Empty) return "Invalid Request";

            string response = "";
            try
            {
                string[] words = request.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length == 3)
                {
                    double v1 = double.Parse(words[1]);
                    double v2 = double.Parse(words[2]);

                    switch (words[0].ToLower())
                    {
                        case "add":
                            double result = v1 + v2;
                            response = result.ToString();
                            break;
                        case "sub":
                            result = v1 - v2;
                            response = result.ToString();
                            break;
                        case "mul":
                            result = v1 * v2;
                            response = result.ToString();
                            break;
                        case "div":
                            result = v1 / v2;
                            response = result.ToString();
                            break;
                        case "power":
                            int power = (int)Math.Pow(v1, v2);
                            response = power.ToString();
                            break;
                        default:
                            response = "Invalid Command";
                            break;
                    }
                }
                else if(words.Length == 1)
                {
                    switch (words[0].ToLower())
                    {
                        case "test":
                            string filepath = Directory.GetCurrentDirectory();
                            int index = filepath.LastIndexOf("\\");
                            string filename = filepath.Remove(index);
                            index = filename.LastIndexOf("\\");
                            filename = filename.Remove(index + 1);
                            filename += "Program.cs";
                            response = File.ReadAllText(filename);
                            //resposne = filename;
                            break;

                        case "lottery":
                            List<int> lottoNums = new List<int>();
                            Random rand = new Random();
                            string lottoNumsString = "";
                            while (lottoNums.Count < 6)
                            {
                                int numAdded = rand.Next(1, 50);
                                if (lottoNums.Contains(numAdded) == false)
                                {
                                    lottoNums.Add(numAdded);
                                }
                            }
                            foreach (int number in lottoNums)
                            {
                                lottoNumsString += number + " ";
                            }
                            response = lottoNumsString;
                            break;

                        default:
                            response = "Invalid Command";
                            break;
                    }
                }
                
            }
            catch (FormatException fe)
            {
                response = "Invalid data\n" + fe.Message;
            }

            return response;
        }

        //Send response back to client
        static void SendResponse(Socket client, string response)
        {
            try
            {
                //Convert response string to byte array
                byte[] buffer = Encoding.UTF8.GetBytes(response);
                client.Send(buffer);
            }
            catch (SocketException se)
            {
                MessageBox.Show("Socket Exception\n" + se.Message);
            }
            finally
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}
