using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; 

namespace GarageApplicationGroup4
{
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Moped))]
    [XmlInclude(typeof(Motorcycle))]
    [XmlInclude(typeof(Truck))]
    public class Vehicle
    {

        public string RegistrationNumber
        { get; set; }
        public string Model
        { get; set; }
        public string Color
        { get; set; }
        public string Propellant
        { get; set; }
        public string Manufacturer
        { get; set; }
        public int NumberOfWheels
        { get; set; }
        public int YearMade
        { get; set; }



    }
}
