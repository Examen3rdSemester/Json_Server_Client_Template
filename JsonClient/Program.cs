using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //initalizere et nyt objekt af client for at anvende tilhørende metoder.
            Client client = new Client();

            //Metode med NS SW SR 
            client.Start();
            
            Console.ReadLine();
        }
    }
}
