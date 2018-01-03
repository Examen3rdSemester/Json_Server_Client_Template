using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //iniatering af Server klassen så tilhørende metoder kan anvendes.
            Server server = new Server();

            //Metode med TcpListener(Transmission Control Protocol) - så den lytter på den angivet port.
            server.Start();

            Console.ReadLine();
        }
    }
}
