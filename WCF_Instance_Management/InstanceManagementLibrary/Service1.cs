using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace InstanceManagementLibrary
{
    //Every client would get its own instance and only one instance per client
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        int counter;
        public Service1()
        {
            //for testing purposes
            Console.WriteLine("\n------------------------");
            Console.WriteLine("Service1 instance has been created.\n"+
                                "so counter variable is reset to 0");
            Console.WriteLine("---------------------------");

            counter = 0;
        }
        public int GetNextCount()
        {
            //increment counter and return the new value
            counter++;
            return counter;
        }
    }
}
