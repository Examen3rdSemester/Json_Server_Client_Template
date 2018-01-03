using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonClient
{
    public class Client
    {
        //vi laver en metode til at starte det hele
        public void Start()
        {
            //her oprettes clienten som har ip-addressen localhost, derudover er den på port 10001
            using (TcpClient client = new TcpClient("localhost", 10001))

            //NetworkStream indeholder metoder til at sende og modtage data.
            using (NetworkStream ns = client.GetStream())

            //StreamReader anvendes når/hvis der skal læses noget fra serveren.
            using (StreamReader sr = new StreamReader(ns))

            //StreamWriter tillader at skrive til serveren via streamen.
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //her sendes der et objekt.

                #region Oprettet Bil
                Car bil = new Car
                {
                    Model = "Toyota",
                    RegistrationNo = "KA12345"
                };
                #endregion

                //json(JavaScript Object Notation.) er en string og kan se således ud: {"hello": "world"}.
                string json = JsonConvert.SerializeObject(bil);



                //På serveren aflæses beskeden som en string derfor skal denne Deserilizeres på server siden.
                sw.Write(json);

                sw.Flush();
            }
        }
    }
}
