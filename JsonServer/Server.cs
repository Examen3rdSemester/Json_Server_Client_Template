using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonServer
{
    public class Server
    {
        public Server()
        {

        }

        //Metode med TcpListener(Transmission Control Protocol) - så den lytter på den angivet port.
        public void Start()
        {
            //TcpListener anvendes for at lytte på følgende ip-adresse og port, loopback(127.0.0.1), port: 10001
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 10001);
            //iniateres Start metoden.  
            tcpListener.Start();

            //while løkken gør så den bliver ved med at accpetere tcp clienter 
            //task gør så serveren bliver ved med at give hver client en socket, efterfulgt af metoden DoClient(TcpClient client)
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient socket = client;
                    DoClient(client);
                });
            }
        }


        //Doclient anvender Stream/StreamReader/StreamWriter, bemærk parameter.
        private static void DoClient(TcpClient client)
        {
            //her er vores streams først get stream så vi kan læse og skrive på den stream
            using (Stream ns = client.GetStream())
            //vores stream reader så vi kan læse fra den stream bemærk vi ønsker at læse fra ns
            using (StreamReader sr = new StreamReader(ns))
            //writer bliver ikke brug da vi kun vil læse fra stream
            using (StreamWriter sw = new StreamWriter(ns))
            {

                //Serveren modtager en besked denne besked lagres som string objektFraClient
                string objektFraClient = sr.ReadLine();


                //Clienten sender en serilizeret json string som string.
                //deserializering af json til Car objekt.
                Car print = JsonConvert.DeserializeObject<Car>(objektFraClient);

                Console.WriteLine("Client har sendt: " + print.Model + " " + print.RegistrationNo);
            }
        }
    }
}
