using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
	public class Car : Vehicle
		
	{
		public bool isCab { get; set; }'
		public bool hasTowbar { get; set; }
		public Car()
		{

		}
		public Car (bool isCab, bool hasTowbar, string RegistrationNumber, string Model, string Color, string Propellant, string Manufacturer, int NumberOfWheels, int YearMade)
		{
			this.isCab = isCab;
			this.hasTowbar = hasTowbar;
			this.RegistrationNumber = RegistrationNumber;
			this.Manufacturer = Manufacturer;
			this.Propellant = Propellant;
			this.Model = Model;
			this.Color = Color;
			this.NumberOfWheels = NumberOfWheels;
			this.YearMade = YearMade;
		}
	}

}
