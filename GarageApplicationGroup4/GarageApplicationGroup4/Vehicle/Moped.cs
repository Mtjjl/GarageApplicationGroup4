
namespace GarageApplicationGroup4
{
	public class Moped : Vehicle
	{
        public string MopedClass { get; set; }
        public string TypeOfMoped { get; set; }
        public Moped()
		{
		}
        public Moped(string MopedClass, string TypeOfMoped, string RegistrationNumber, string Model, string Color, string Propellent, string Manufacturer, int YearMade)
        {
            this.MopedClass = MopedClass;
            this.TypeOfMoped = TypeOfMoped;
            this.RegistrationNumber = RegistrationNumber;
            this.Model = Model;
            this.Color = Color;
            this.Propellant = Propellent;
            this.Manufacturer = Manufacturer;
            this.NumberOfWheels = 2;
            this.YearMade = YearMade;
        }

        public static Moped NewMoped(string plateNumber, string manufacturer, string model, string color, string propellant, int yearMade)
        {
            string mopedclass = Validate.GetValidString("What moped class is it?", "Class 1", "Class 2");
            string typeofMoped = Validate.GetValidString("What type of moped is it?", "Vespa", "Crossmoped", "Veteran");
            return new Moped(mopedclass, typeofMoped, plateNumber, model, color, propellant, manufacturer, yearMade);
        }
        public override string ToString()
        {
            return $"A {Color.ToLower()} moped ({Manufacturer} {Model}) with the following registration number: {RegistrationNumber}";
        }
    }

}
