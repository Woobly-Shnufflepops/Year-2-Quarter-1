using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using AccountsServiceLibrary;

namespace WCF_DataContractConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = null;

            try
            {
                //1: Set the address as a Uri object
                Uri baseAddress = new Uri("http://localhost:9999/MathService");
                //Create a ServiceHost
                sh = new ServiceHost(typeof(IAccountService), baseAddress);

                //Attach an EndPoint to this service host
                sh.AddServiceEndpoint(typeof(IAccountService), new BasicHttpBinding(), "account");
                //Allow metadata to be accessed by the client(s)
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                //Add this behavior to sh
                sh.Description.Behaviors.Add(smb);

                //Open the service
                sh.Open();
                Console.WriteLine("MathService is ready \n" + "http://localhost:8888/AccountService");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine(ce.Message);
            }
            finally
            {
                Console.WriteLine("\n\nHit 'enter' to close");
                Console.ReadLine();
                if (sh != null) sh.Close();
            }
        }
    }
}
/*
 * Exercise:
 * Add client to this service
 * Provide GUI to request an accoutn and perform deposit and withdraw transactions
 */