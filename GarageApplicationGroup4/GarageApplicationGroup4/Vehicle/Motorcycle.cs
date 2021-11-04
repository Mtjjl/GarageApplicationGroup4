using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
	public class Motorcycle:Vehicle
	{
        public string WeightClass { get; set; }
        public int NumberOfCC { get; set; }
        public Motorcycle()
		{
		}

		public Motorcycle(string registrationNumber, string model, string manufacturer, int yearMade, string propellent, string color, int numberOfWheels, string weightClass, int numberOfCC)
		{
			this.RegistrationNumber = registrationNumber;
			this.Model = model;
			this.Manufacturer = manufacturer;
			this.YearMade = yearMade;
			this.Propellant = propellent;
			this.Color = color;
			this.NumberOfCC = numberOfCC;
			this.WeightClass = weightClass;
			this.NumberOfWheels = numberOfWheels;
		}
	}

}
