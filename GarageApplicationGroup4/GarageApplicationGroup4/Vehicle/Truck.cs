﻿namespace GarageApplicationGroup4
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
	}


}