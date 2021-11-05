namespace GarageApplicationGroup4
{
	public class Car : Vehicle
		
	{
		public bool isCab { get; set; }
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

		public static Car NewCar(string plateNumber, string manufacturer, string model, string color, string propellant, int wheels, int yearMade)
        {
			bool isCab = Validate.GetYesOrNo("Is it a cab?");
			bool hasTowbar = Validate.GetYesOrNo("Does it have a towbar?");
			return new Car(isCab, hasTowbar, plateNumber, model, color, propellant, manufacturer, wheels, yearMade);
        }
	}

}
