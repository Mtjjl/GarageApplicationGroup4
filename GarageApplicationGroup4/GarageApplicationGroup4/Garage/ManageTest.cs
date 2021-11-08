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
    class ManageTest
    {
        public GarageTest<Vehicle> Garage { get; set; }

        public ManageTest(GarageTest<Vehicle> garage) 
        {
            Garage = garage;
        }

        /* 
         -*-*-*-*- NEDAN FÖLJLER ALLA METODER SOM HANTERAR GARAGET -*-*-*-*-
         */



        //Tar emot ett objekt av typen Vehicle och lägger till det i garaget. Ska eventuellt korrigeras när alla Vehicle-klasser är satta
        public void AddVehicle()
        {
            if (Garage.vehicles.Count < Garage.MaxLimit)
            {
                Garage.vehicles.Add(Vehicle.GetNewVehicle());
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
            if (Garage.vehicles.Any())
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

                int userInput = Validate.GetValidNumber(stringBuilder.ToString(), 0, Garage.vehicles.Count) - 1;

                if (userInput < 0)
                {
                    Console.WriteLine("Going back to main menu");
                    Break.PleaseWait(3);
                    return;
                }
                else
                {
                    Garage.vehicles.RemoveAt(userInput);
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


        //Tar reda på om det om det finns fordon i garaget. Om det finns minst ett skriver den ut alla fordon.
        public void ListAllVehicles()
        {
            if (Garage.vehicles.Any())
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
            if (Garage.vehicles.OfType<T>().Any())
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

        public void Save()
        {
            try
            {
                //Serialize: File.Create-- > Skapar, eller "uppdaterar" en fil.
                Stream stream = File.Create($"SavedVehicles\\{Garage.Name}.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));
                xmlSerializer.Serialize(stream, Garage.vehicles);
                stream.Close();

                //Check in Console
                //xmlSerializer.Serialize(Console.Out, Garage<Vehicle>.Get().vehicles);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong when saving.");
            }
        }

        public void Load()
        {
            try
            {
                if (!Directory.Exists("SavedVehicles"))
                {
                    Directory.CreateDirectory("SavedVehicles");
                }
                if (!File.Exists($"SavedVehicles\\{Garage.Name}.xml"))
                {
                    Save();
                }
                else
                {
                    XmlSerializer xmlDeserializer = new XmlSerializer(typeof(List<Vehicle>));
                    using (FileStream streamReader = File.Open($"SavedVehicles\\{Garage.Name}.xml", FileMode.Open))
                    {
                        Garage.vehicles = (List<Vehicle>)xmlDeserializer.Deserialize(streamReader);

                        //Check in Console
                        //xmlDeserializer.Serialize(Console.Out, Garage<Vehicle>.Get().vehicles);
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong when trying to load...");
                Break.PleaseWait(2);
            }
        }
    }
}
