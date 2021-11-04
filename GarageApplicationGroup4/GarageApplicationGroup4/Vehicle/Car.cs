using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    public class Car : Vehicle
    {
        public bool isCab { get; set; }
        public bool hasTowbar { get; set; }
        public Car()
        {

        }
        public Car(string RegistrationNumber, string Manufacturer, string Model, int YearMade, string Propellant, int NumberOfWheels, string Color, bool isCab, bool hasTowbar)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.YearMade = YearMade;
            this.Propellant = Propellant;
            this.NumberOfWheels = NumberOfWheels;
            this.Color = Color;
            this.isCab = isCab;
            this.hasTowbar = hasTowbar;
        }
    }
}
