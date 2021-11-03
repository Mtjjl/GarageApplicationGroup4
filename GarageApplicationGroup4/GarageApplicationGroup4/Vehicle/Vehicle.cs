using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; 

namespace GarageApplicationGroup4
{
   public class Vehicle
    {
        public string RegistrationNumber
        { get; set; }
        public string Model
        { get; set; }
        public string Color
        { get; set; }
        public string propellant
        { get; set; }
        public string Manufacturer
        { get; set; }
        public int NumberOfWheels
        { get; set; }



    }
}
