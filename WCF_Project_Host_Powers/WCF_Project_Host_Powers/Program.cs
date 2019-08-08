using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Project_Library_Powers;
using System.ServiceModel;

namespace WCF_Project_Host_Powers
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sHost = null;
            try
            {
                sHost = new ServiceHost(typeof(WCF_Project_Library_Powers.StudentService));
                sHost.Open();
                DisplayHostInfo(sHost);
                Console.WriteLine("\nService is ready");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("\nCommunication Exception:\n{0}", ce.Message);
            }
            finally
            {
                Console.ReadLine();
                if (sHost != null) sHost.Close();
            }
        }

        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            foreach(System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine();
            }
        }
    }
}
