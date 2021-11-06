using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; 

namespace GarageApplicationGroup4
{
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Moped))]
    [XmlInclude(typeof(Motorcycle))]
    [XmlInclude(typeof(Truck))]
    public 
        class Vehicle
    {

        public string RegistrationNumber
        { get; set; }
        public string Model
        { get; set; }
        public string Color
        { get; set; }
        public string Propellant
        { get; set; }
        public string Manufacturer
        { get; set; }
        public int NumberOfWheels
        { get; set; }
        public int YearMade
        { get; set; }


        public static Vehicle GetNewVehicle()
        {
            int choice = Validate.GetValidNumber("What type of vehicle would you like to park?\n[1] Car \n[2] Bus\n[3] Moped\n[4] Motocycle\n[5] Truck", 1, 5);
            Validate.GetValidPlateNumber(out string plateNumber);
            string manufacturer = Validate.GetString("What's the manufacturer?");
            string model = Validate.GetString("What model is it?");
            string color = Validate.GetString("What color is it?");
            string propellant = Validate.GetString("What propellant is it?");
            int wheels = Validate.GetValidNumber("How many wheels does it have?", 2, 8);
            int yearMade = Validate.GetValidNumber("When was it made?", 1950, 2021);

            switch (choice)
            {
                case 1:
                    return Car.NewCar(plateNumber, manufacturer, model, color, propellant, wheels, yearMade);

                case 2:
                    return Bus.NewBus(plateNumber, manufacturer, model, color, propellant, wheels, yearMade);

                case 3:
                    return Moped.NewMoped(plateNumber, manufacturer, model, color, propellant, wheels, yearMade);

                case 4:
                    return Motorcycle.NewMotorcycle(plateNumber, manufacturer, model, color, propellant, wheels, yearMade);

                case 5:
                    return Truck.NewTruck(plateNumber, manufacturer, model, color, propellant, wheels, yearMade);
            }
            return null;
        }

    }
}
