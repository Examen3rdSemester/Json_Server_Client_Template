using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonClient
{
    public class Car
    {
        private string model;
        private string registrationNo;

        public string Model { get => model; set => model = value; }
        public string RegistrationNo { get => registrationNo; set => registrationNo = value; }

        public Car()
        {
            
        }

        public Car(string model, string registrationNo)
        {
            this.model = model;
            this.registrationNo = registrationNo;
        }
    }
}
