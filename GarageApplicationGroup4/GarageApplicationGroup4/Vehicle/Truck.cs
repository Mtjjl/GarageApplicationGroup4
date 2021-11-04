using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    public class Truck : Vehicle
    {
        public string WeightClass { get; set; }
        public int MaxWeightPulled { get; set; }
        public Truck()
        {

        }
        public Truck(string RegistrationNumber, string Manufacturer, string Model, int YearMade, string Propellant, int NumberOfWheels, string Color, string WeightClass, int MaxWeightPulled)
        {
            this.RegistrationNumber = RegistrationNumber;
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.YearMade = YearMade;
            this.Propellant = Propellant;
            this.NumberOfWheels = NumberOfWheels;
            this.Color = Color;
            this.WeightClass = WeightClass;
            this.MaxWeightPulled = MaxWeightPulled;
        }
    }
}