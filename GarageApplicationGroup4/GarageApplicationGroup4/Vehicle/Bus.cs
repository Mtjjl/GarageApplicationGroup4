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

		public static Bus NewBus(string plateNumber, string manufacturer, string model, string color, string propellant, int wheels, int yearMade)
		{
			int numberOfPassengers = Validate.GetValidNumber("How many passengers can it carry?", 10, 100);
			bool isDoubleDecker = Validate.GetYesOrNo("Is it a doubledecker?");
			return new Bus(numberOfPassengers, isDoubleDecker, plateNumber, model, color, propellant, manufacturer, wheels, yearMade);
		}
	}

}
