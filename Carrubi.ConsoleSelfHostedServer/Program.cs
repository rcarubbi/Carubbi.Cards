using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using Carubbi.PokerServices;

namespace Carubbi.ConsoleSelfHostedServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8001/Carubbi.PokerServices/");

            Type instanceType =
               typeof(RoomManagerServiceImplementation);

            ServiceHost host = new ServiceHost(instanceType, baseAddress);
            using (host)
            {
                Type contractType = typeof(RoomManagerServiceContract);
                string relativeAddress = "";
                host.AddServiceEndpoint(contractType,
                   new WSHttpBinding(), relativeAddress);

                host.Open();
                Console.WriteLine("Carubbi Poker Server ativo");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
