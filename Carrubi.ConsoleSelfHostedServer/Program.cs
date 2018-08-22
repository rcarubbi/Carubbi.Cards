using System;
using System.ServiceModel;
using Carubbi.PokerServices;

namespace Carubbi.ConsoleSelfHostedServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8001/Carubbi.PokerServices/");

            var instanceType =
                typeof(RoomManagerServiceImplementation);

            var host = new ServiceHost(instanceType, baseAddress);
            using (host)
            {
                var contractType = typeof(RoomManagerServiceContract);
                var relativeAddress = "";
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