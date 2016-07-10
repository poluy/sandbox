using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Playing.Host;

namespace WCF.Playing.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            StartService();
            Console.WriteLine("=====================================");
            Console.ReadKey();
        }

        public static void StartService()
        {

            using (var serviceHost = new ServiceHost(typeof (PlayerService)))
            {
                serviceHost.Open();

                Console.WriteLine("Service started");

                Console.ReadKey();
            }
            Console.WriteLine("Service stopped");
        }
    }
}
