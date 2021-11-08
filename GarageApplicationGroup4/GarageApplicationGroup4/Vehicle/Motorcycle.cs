using System;

namespace GarageApplicationGroup4
{
    public class Motorcycle:Vehicle
	{
        public string WeightClass { get; set; }
        public int NumberOfCC { get; set; }
        public Motorcycle()
		{
		}

		public Motorcycle(string RegistrationNumber, string Model, string Manufacturer, int YearMade, string Propellent, string Color, int NumberOfWheels,  string WeightClass, int NumberOfCC)
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

		public static Motorcycle NewMotorcycle(string plateNumber, string manufacturer, string model, string color, string propellant, int yearMade)
		{
			string weightclass = Validate.GetValidString("What weight class is it?", "Light", "Heavy");
			int numberOfCC = Validate.GetValidNumber("What CC does it have?", 50, 2000);
			int wheels = Convert.ToInt32(Validate.GetValidString("How many wheels does it have?", "2", "3", "4"));
			return new Motorcycle(plateNumber, model, manufacturer, yearMade, propellant, color, wheels, weightclass, numberOfCC);
		}
	}

}
