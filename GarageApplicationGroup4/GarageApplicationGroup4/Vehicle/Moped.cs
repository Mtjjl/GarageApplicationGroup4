using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
	public class Moped:Vehicle
	{
        public string MopedClass { get; set; }
        public string TypeOfMoped { get; set; }
        public Moped()
		{
		}
        public Moped(string mopedClass, string typeOfMoped, string registrationNumber, string model, string color, string propellent, string manufacturer, int numberOfWheels, int yearMade)
        {
            this.MopedClass = mopedClass;
            this.TypeOfMoped = typeOfMoped;
            this.RegistrationNumber = registrationNumber;
            this.Model = model;
            this.Color = color;
            this.Propellant = propellent;
            this.Manufacturer = manufacturer;
            this.NumberOfWheels = numberOfWheels;
            this.YearMade = yearMade;
        }
		
	}

}
