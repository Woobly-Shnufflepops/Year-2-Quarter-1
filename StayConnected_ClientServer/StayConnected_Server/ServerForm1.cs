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

namespace StayConnected_Server
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
                int port = 8000;

                try
                {
                    //1. Create a Socket
                    Socket server = new Socket
                    (AddressFamily.InterNetwork,
                     SocketType.Stream, ProtocolType.Tcp);

                    //2. Create an Server EndPoint: IPAddress + Port
                    //get this local computer IPAddress
                    IPAddress[] ipaddresses = Dns.GetHostAddresses(Dns.GetHostName());
                    IPAddress ipaddress = GetIPv4(ipaddresses);

                    EndPoint endP = new IPEndPoint(ipaddress, port);

                    //3. Bind the EndPoint to the Socket
                    server.Bind(endP);

                    //4. Set the socket in listening mode
                    server.Listen(20);//the listen starts a background thread
                    //that enqueues clients to a queue (called backlog)
                    //20 is the size of the queue

                    //display server name, address and port
                    SetText(Dns.GetHostName() +
                        "  " + ipaddress + ":" + port);

                    //in a while loop
                    while (true)
                    {
                        //5. Accept client that connected with this server
                        Socket client = server.Accept();
                        //the Accept blocks if the backlog is empty
                        //otherwise it returns a reference to the 
                        //next client in the backlog to be processed

                        //6. Process the client
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
           
        }//end of button click

        private IPAddress GetIPv4(IPAddress[] ipaddresses)
        {
            foreach (IPAddress ipaddress in ipaddresses)
            {
                if (ipaddress.GetAddressBytes().Length == 4)
                    return ipaddress;
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
        //method to process client
        private void ProcessClient(Socket client)
        {

            //client just connected. 
            //you have multiple options: 
            //1 client sends credentials and server responds back
            //2 client does not send anything and server welcomes client

            //go with second option
            //convert response string to byte array
            string welcome = "Welcome to our World...";
            byte[]data = Encoding.UTF8.GetBytes(welcome);
            client.Send(data);
            //at this moment the client is supposed to read the welcome message

            //now call a method that will process request and returns a response
            //this method will have a while loop to keep the client connected until
            //the client sends a "bye" request


            string response = ProcessRequest(client);
            //send goodbye message

            //close the client
            if(client!=null && client.Connected)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
           
      
        }
        private string ProcessRequest(Socket client)
        {
            string response = String.Empty;
            string command = String.Empty;
            string request = String.Empty;

            while (command != "bye")
            {

               
                //1. Receive client request
                   byte[] buffer = new byte[1024];
                  int bytesReceived = client.Receive(buffer);
                //convert bytes to a string (convert only the bytes received not 256 bytes set up
                  request = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                //parse request to figure out the command portion
                string[] words = request.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                command = words[0];

                //if request is not in a correct format or not valid
                //set response to "request is incorrect or invalid"
                //return the response

                //otherwise use a switch to respond to each command
                switch (command.ToLower())
                {
                    //use multiple cases
                    case "add":

                        response = "just added numbers";
                        //add code
                        break;


                    case "bye":
                        response = "Thank you for stopping by, hope to see you later...";
                        break;

                }//end of switch
                 //send response
                 //convert response string to byte array
                 byte[]data = Encoding.UTF8.GetBytes(response);
                 client.Send(data);


            }//end of while

            //session ending
            //return a "bye" response
          
            return response;
        }
    }
}
