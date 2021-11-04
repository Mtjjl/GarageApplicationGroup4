namespace GarageApplicationGroup4
{
	public class Moped:Vehicle
	{
        public string MopedClass { get; set; }
        public string TypeOfMoped { get; set; }
        public Moped()
		{
		}
        public Moped(string MopedClass, string TypeOfMoped, string RegistrationNumber, string Model, string Color, string Propellent, string Manufacturer, int NumberOfWheels, int YearMade)
        {
            this.MopedClass = MopedClass;
            this.TypeOfMoped = TypeOfMoped;
            this.RegistrationNumber = RegistrationNumber;
            this.Model = Model;
            this.Color = Color;
            this.Propellant = Propellent;
            this.Manufacturer = Manufacturer;
            this.NumberOfWheels = NumberOfWheels;
            this.YearMade = YearMade;
        }
		
	}

}
