using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
	public class Motorcycle : Vehicle
	{
        public string WeightClass { get; set; }
        public int NumberOfCC { get; set; }
        public Motorcycle()
		{
		}

		public Motorcycle(string RegistrationNumber, string Model, string Manufacturer, int YearMade, string Propellent, string Color, int NumberOfWheels, string WeightClass, int NumberOfCC)
		{
			this.RegistrationNumber = RegistrationNumber;
			this.Model = Model;
			this.Manufacturer = Manufacturer;
			this.YearMade = YearMade;
			this.Propellant = Propellent;
			this.Color = Color;
			this.NumberOfCC = NumberOfCC;
			this.WeightClass = WeightClass;
			this.NumberOfWheels = NumberOfWheels;
		}
	}

}
