using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    public class Bus : Vehicle
    {
        public bool isDoubleDecker { get; set; }
        public int numberOfPassenger { get; set; }
        public int YearMade { get; set; }
        public Bus()
        {

        }
        public Bus(string RegistrationNumber, string Manufacturer, string Model, int YearMade, string Propellant, int NumberOfWheels, string Color, bool isDoubleDecker, int numberOfPassenger)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.YearMade = YearMade;
            this.Propellant = Propellant;
            this.NumberOfWheels = NumberOfWheels;
            this.Color = Color;
            this.isDoubleDecker = isDoubleDecker;
            this.numberOfPassenger = numberOfPassenger;
        }
    }
}