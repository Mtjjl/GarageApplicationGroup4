using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace GarageApplicationGroup4
{
    public class Manage
    {
        public Garage<Vehicle> Garage { get; set; }

        public Manage(Garage<Vehicle> garage)
        {
            Garage = garage;
        }

        //Lägger till en ny bil (som skapas via metoden GetNewVehicle) till garaget
        public void AddVehicle()
        {
            if (Garage.Vehicles.Count < Garage.MaxLimit)
            {
                Garage.Vehicles.Add(Vehicle.GetNewVehicle(this));
                Console.WriteLine("Vehicle added successfully.");
                Break.PressToContinue();
            }
            else
            {
                Console.WriteLine("The garage is full. No more vehicles can be added.");
                Break.PleaseWait(2);
            }
        }

        //Tar reda på om det finns fordon i garaget. Om det finns, låter den användaren välja vilket fordon som ska tas bort.
        //Användaren får också möjligheten att inte ta bort ett fordon.
        public void RemoveVehicle()
        {
            if (Garage.Vehicles.Any())
            {
                StringBuilder stringBuilder = new StringBuilder();
                int index = 1;

                stringBuilder.Append($"Here are all the vehicles in the garage:\n\n");

                foreach (Vehicle vehicle in Garage)
                {
                    stringBuilder.Append($"{index}. {vehicle}\n");
                    index++;
                }

                stringBuilder.Append($"\nEnter the number of the vehicle you want to remove." +
                                     $"\nIf you do not wish to remove a vehicle, enter 0");

                int userInput = Validate.GetValidNumber(stringBuilder.ToString(), 0, Garage.Vehicles.Count) - 1;

                if (userInput < 0)
                {
                    Console.WriteLine("Going back to main menu");
                    Break.PleaseWait(3);
                    return;
                }
                else
                {
                    Garage.Vehicles.RemoveAt(userInput);
                    Console.WriteLine("Vehicle removed successfully.");
                    Break.PleaseWait(3);
                }
            }
            else
            {
                Console.WriteLine("The garage is currently empty.");
                Break.PleaseWait(2);
            }
        }


        //Tar reda på om det om det finns fordon i garaget. Om det finns minst ett skriver den ut alla fordon, annars talar den om att garaget är tomt.
        public void ListAllVehicles()
        {
            if (Garage.Vehicles.Any())
            {
                Console.WriteLine("Here are all the vehicles in the garage:\n");
                int index = 1;
                foreach (Vehicle vehicle in Garage)
                {
                    Console.WriteLine($"{index}. {vehicle}");
                    index++;
                }
                Break.PressToContinue();
            }
            else
            {
                Console.WriteLine("The garage is currently empty.");
                Break.PleaseWait(2);
            }
        }

        /*Tar reda på om det finns fordon av en viss typ. Om det finns minst ett skriver den ut alla fordon av denna typ.
         * När man kallar på denna metod byts T ut mot en fordonstyp, t.ex. Car...*/
        public void ListVehiclesOfType<T>() where T : Vehicle
        {
            if (Garage.Vehicles.OfType<T>().Any())
            {
                Console.WriteLine("Here are all the vehicles of the chosen type in the garage:\n");
                int index = 1;
                foreach (Vehicle vehicle in Garage.OfType<T>())
                {
                    Console.WriteLine($"{index}. {vehicle}");
                    index++;
                }
                Break.PressToContinue();
            }
            else
            {
                Console.WriteLine("There are no vehicles of the chosen type in the garage.");
                Break.PleaseWait(2);
            }
        }

        //Söker igenom alla fordon efter matchande registreringsnummer och talar om huruvida fordonet hittades eller inte.
        public void SearchForVehicle(string licensePlate)
        {
            foreach (Vehicle vehicle in Garage)
            {
                if (vehicle.RegistrationNumber == licensePlate)
                {
                    Console.WriteLine("The vehicle you searched for is in the garage.");
                    Break.PressToContinue();
                    return;
                }
            }
            Console.WriteLine("The vehicle you searched for could not be found in the garage.");
            Break.PleaseWait(2);
        }

        //Skapar xml-fil och/eller skriver/skriver över denna fil med information från garaget.
        public void Save()
        {
            try
            {
                //Serialize: File.Create-- > Skapar, eller "uppdaterar" en fil.
                Stream stream = File.Create($"SavedVehicles\\{Garage.Name}.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));
                xmlSerializer.Serialize(stream, Garage.Vehicles);
                stream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong when saving.");
            }
        }

        /*Tar reda på om det finns en sparfil kopplat till garagets namn, om fil ej finns så skapas en sådan via Save-metoden varpå DefaultVehicles()
        kallas på så att det ska finnas några bilar färdiga i ett nystartat garage. Om fil finns översätts informationen från filen och läggs
        till i garaget*/
        public void Load()
        {
            try
            {
                if (!File.Exists($"SavedVehicles\\{Garage.Name}.xml"))
                {
                    Save();
                    DefaultVehicles();
                }
                else
                {
                    XmlSerializer xmlDeserializer = new XmlSerializer(typeof(List<Vehicle>));
                    using (FileStream streamReader = File.Open($"SavedVehicles\\{Garage.Name}.xml", FileMode.Open))
                    {
                        Garage.Vehicles = (List<Vehicle>)xmlDeserializer.Deserialize(streamReader);
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong when trying to load...");
                Break.PleaseWait(2);
            }
        }

        //Standardfordon som läggs till när nytt garage skapas
        private void DefaultVehicles()
        {
            Car firstCar = new Car(false, false, "XMP066", "RS6", "Black", "Diesel", "Audi", 2020);
            Motorcycle firstMotorcycle = new Motorcycle("YEZ822", "R1", "Yamaha", 2019, "Petrol", "Blue", 2, "Heavy", 2019);
            Moped firstMoped = new Moped("Class 1", "Crossmoped", "PLD781", "Senda DRD PRO", "Red/White", "Petrol", "Derbi", 2017);
            Truck firstTruck = new Truck("Heavy", 10, "TRY096", "PRT Range", "Dark green", "Diesel", "Scania", 8, 2018);
            Bus firstBus = new Bus(48, false, "MLT715", "9900", "Yellow", "Diesel", "Volvo", 10, 2015);

            Garage.Vehicles.Add(firstCar);
            Garage.Vehicles.Add(firstMotorcycle);
            Garage.Vehicles.Add(firstMoped);
            Garage.Vehicles.Add(firstTruck);
            Garage.Vehicles.Add(firstBus);
        }
    }
}
