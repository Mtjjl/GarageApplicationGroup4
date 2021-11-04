using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{

	public class Bus : Vehicle
	{
		public int PassangerNo {get; set; }
		public bool IsDoubleDecker { get; set; }
		public Bus()
		{

		}
		public Bus (int PassangerNo, bool isDoubleDecker, string RegistrationNumber, string Model, string Color, string Propellant, string Manufacturer, int NumberOfWheels, int YearMade)
		{
			this.RegistrationNumber = RegistrationNumber;
			this.Manufacturer = Manufacturer;
			this.Propellant = Propellant;
			this.Model = Model;
			this.Color = Color;
			this.NumberOfWheels = NumberOfWheels;
			this.YearMade = YearMade;
			this.PassangerNo = PassangerNo;
			this.IsDoubleDecker = isDoubleDecker;
		}
	}

}
