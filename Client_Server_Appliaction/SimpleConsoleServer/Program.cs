/*
 * Name: Matthew Powers
 * Class: CSI-256
 * Date: 2/23/18
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SimpleConsoleServer
{
    /*
     * Building a simple clinet server application. Allowing 2 computers to communicate thorugh sockets.
     * When 2 or more computers communicate together, one of the computers is the server and the other
     * ar the clients.
     * 
     * A server application needs to be installed on the server computer
     * A client application needs to be installed on the client computers
     * 
     * A computer may have both the server and the client apps and have both applications communicate
     * within the same computer
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 8000;
            Socket server = null;

            try
            {
                //1: Create a Socket object
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //2: Create an IP EndPoint (combination of IP Address and Port number)
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] ipaddresses = hostEntry.AddressList;
                foreach (IPAddress address in ipaddresses) Console.WriteLine(address);

                IPEndPoint endP = new IPEndPoint(IPAddress.Any, port);

                //3: Bind the IPEndPoint to the Socket
                server.Bind(endP);

                //4: Set the socket to listen to incoming requests (save client requests to an
                //internal queue)
                server.Listen(20);

                string hostname = Dns.GetHostName();
                Console.WriteLine("\nServer: {0} is ready at ip: {1}:{2}", hostname, ipaddresses[1], port);

                //5: Within a loop, Accept or get client requests formt he queue
                while (true)
                {
                    //use the Accept method to get the next waiting client from the internal queue
                    //The Accept method blocks, that means that the Accept method waits until it finds
                    //a client in the queue and returns a reference to it.
                    Socket client = server.Accept();
                    //display the client information
                    DisplayClientInfo(client);
                    //Could log info to a logfile

                    //6: Process the client
                    Task.Factory.StartNew(() => ProcessClient(client));
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine("\nSocket Exception\n");
                Console.WriteLine(se.Message);
            }
            Console.ReadLine(); //pauses
        }
        //method to dispaly client information
        static void DisplayClientInfo(Socket client)
        {
            //Get the client EndPoint using the RemoteEndPoint property of the Socket
            IPEndPoint clientEndP = (IPEndPoint)client.RemoteEndPoint;
            //client IP Address
            IPAddress clientIPAddress = clientEndP.Address;
            //client port
            int clientPort = clientEndP.Port;
            //get client hostname
            //string clientName = Dns.GetHostEntry(clientIPAddress).HostName;

            //Console.WriteLine("\nClient Request from {0} at {1}:{2}", clientName, clientIPAddress, clientPort);
        }

        //method to process a client
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
                        while(lottoNums.Count < 6)
                        {
                            int numAdded = rand.Next(1, 50);
                            if (lottoNums.Contains(numAdded) == false)
                            {
                                lottoNums.Add(numAdded);
                            }
                        }
                        foreach(int number in lottoNums)
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
            catch (FormatException fe)
            {
                response = "Invalid data";
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
            }
            finally
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}
/*
 * Lab Assignment:
 * Allow the server to accept command "lottery"
 * When the server receives this command it is to return a string with 6 distinct numbers from 1 to 49
 * 
 * Allow server to accept command "Power" followed by 2 values: base and exponent. The server is to return
 * a value equal to base to the power of exponent.
 * Example: Power 2 5 should cause the server to return 32
 */
