using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using InstanceManagementLibrary;

namespace InstanceManagementHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost shost = null;
            try
            {
                shost = new ServiceHost(typeof(InstanceManagementLibrary.Service1));
                shost.Open();
                DisplayHostInfo(shost);
                Console.WriteLine("\nService is ready...");

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("\n\nCommunication Exception:\n" + ce.Message);
            }
            finally
            {
                Console.ReadLine(); //pause
                if (shost != null)
                    shost.Close();

            }
        }
        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            foreach (System.ServiceModel.Description.ServiceEndpoint se in
                                            host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine();
            }
        }
    }
}
