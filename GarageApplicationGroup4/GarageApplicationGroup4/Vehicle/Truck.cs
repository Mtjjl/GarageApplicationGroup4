using System;

namespace GarageApplicationGroup4
{
	public class Truck : Vehicle
	{
		public string WeightClass { get; set; }
		public int WeightPulled { get; set; }
		public Truck()
		{

		}
		public Truck (string WeightClass, int WeightPulled, string RegistrationNumber, string Model, string Color, string Propellant, string Manufacturer, int NumberOfWheels, int YearMade)
		{
			this.WeightClass = WeightClass;
			this.WeightPulled = WeightPulled;
			this.YearMade = YearMade;
			this.RegistrationNumber = RegistrationNumber;
			this.Propellant = Propellant;
			this.NumberOfWheels = NumberOfWheels;
			this.Manufacturer = Manufacturer;
			this. Model = Model;
			this.Color = Color;

		}

		public static Truck NewTruck(string plateNumber, string manufacturer, string model, string color, string propellant, int yearMade)
		{
			string weightclass = Validate.GetValidString("What weight class is it?");
			int weightpulled = Validate.GetValidNumber("How much weight can it pull? In tons.", 1, 15);
			int wheels = Convert.ToInt32(Validate.GetValidString("How many wheels does it have?", "8", "10", "12", "14", "16", "18"));
			return new Truck(weightclass, weightpulled, plateNumber, model, color, propellant, manufacturer, wheels, yearMade);
		}
	}


}