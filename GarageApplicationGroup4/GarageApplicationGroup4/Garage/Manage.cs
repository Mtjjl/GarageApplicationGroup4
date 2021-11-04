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
    //Denna klass hanterar vårt Garage<Vehicle>-objekt.
    class Manage
    {
        /*Skapar en lokal referens till den enda instansen som finns av Garage<T>-klassen, så att
         * den smidigt kan arbetas med i denna klass utan att man behöver kalla på den varje gång den
         * ska användas. Istället för "Garage<Vehicle>.Get()", räcker det med "garage".*/
        private Garage<Vehicle> garage = Garage<Vehicle>.Get();

        //Den enda instansen av Manage-klassen som ska finnas i lösningen.
        private static readonly Manage garageHandler = new Manage();

        //Privat constructor, eftersom inga instanser ska kunna skapas någon annanstans än inom denna klass.
        private Manage() { }

        /*Via denna metod kan andra klasser komma åt den enda instansen av Manage-klassen som ska finnas.
         *så i menyn kommer man t.ex. kunna skriva Manage.Garage().ListAllVehicles(); */
        public static Manage Garage() => garageHandler;



        /* 
         -*-*-*-*- NEDAN FÖLJLER ALLA METODER SOM HANTERAR GARAGET -*-*-*-*-
         */



        //Tar emot ett objekt av typen Vehicle och lägger till det i garaget. Ska eventuellt korrigeras när alla Vehicle-klasser är satta
        public void AddVehicle(Vehicle vehicle)
        {
            if (garage.vehicles.Count < garage.MaxLimit)
            {
                garage.vehicles.Add(vehicle);
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
            if (garage.vehicles.Any())
            {
                StringBuilder stringBuilder = new StringBuilder();
                int index = 1;

                stringBuilder.Append($"Here are all the vehicles in the garage:\n\n");

                foreach (Vehicle vehicle in garage)
                {
                    stringBuilder.Append($"{index}. {vehicle}\n");
                    index++;
                }

                stringBuilder.Append($"\nEnter the number of the vehicle you want to remove." +
                                     $"\nIf you do not wish to remove a vehicle, enter 0");

                int userInput = Validate.GetValidNumber(stringBuilder.ToString(), 0, garage.vehicles.Count) - 1;

                if (userInput < 0)
                {
                    Console.WriteLine("Going back to main menu");
                    Break.PleaseWait(3);
                    return;
                }
                else
                {
                    garage.vehicles.RemoveAt(userInput);
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
            if (garage.vehicles.Any())
            {
                Console.WriteLine("Here are all the vehicles in the garage:\n");
                int index = 1;
                foreach (Vehicle vehicle in garage)
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
            if (garage.vehicles.OfType<T>().Any())
            {
                Console.WriteLine("Here are all the vehicles of the chosen type in the garage:\n");
                int index = 1;
                foreach (Vehicle vehicle in garage.OfType<T>())
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
            foreach (Vehicle vehicle in garage)
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
                Stream stream = File.Create(Environment.CurrentDirectory + "SavedVehicles.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));
                xmlSerializer.Serialize(stream, garage.vehicles);
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
                if (!File.Exists(Environment.CurrentDirectory + "SavedVehicles.xml"))
                {
                    File.Create(Environment.CurrentDirectory + "SavedVehicles.xml");
                }
                else
                {
                    XmlSerializer xmlDeserializer = new XmlSerializer(typeof(List<Vehicle>));
                    using (FileStream streamReader = File.Open(Environment.CurrentDirectory + "SavedVehicles.xml", FileMode.Open))
                    {
                        garage.vehicles = (List<Vehicle>)xmlDeserializer.Deserialize(streamReader);

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
        public void CreateVehicle()
        {
            bool BetweenRanges(int a, int b, int number)
            {
                return (a <= number && number <= b);
            }

            Console.WriteLine("What kind of vehicle do you want to park: ");
            string kindOfVehicle = Console.ReadLine().ToLower();

            Console.WriteLine("Please enter the registration number: ");
            string RegNr = Console.ReadLine();
            //Validate.GetValidPlateNumber();           

            Console.WriteLine("What manufactorer: ");
            string ManuFac = Console.ReadLine();

            Console.WriteLine("Which model: ");
            string Model = Console.ReadLine();

            Console.WriteLine("When was it made: ");
            int YearMade = Convert.ToInt32(Console.ReadLine());
            while (!BetweenRanges(1950, 2021, YearMade))
            {
                Console.WriteLine("Not a valid year, try again.");
                YearMade = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("What kind of propellant: ");
            string Propellant = Console.ReadLine();

            Console.WriteLine("How many wheels: ");
            int Wheels = Convert.ToInt32(Console.ReadLine());
            while (!BetweenRanges(2, 8, Wheels))
            {
                Console.WriteLine("Not a valid number of wheels, try again.");
                Wheels = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("What color is it: ");
            string Color = Console.ReadLine().ToLower();

            switch (kindOfVehicle)
            {
                case "car":
                    bool carCabbool = false;
                    askBool("Is it a cabrollet Y/N: ", out carCabbool);

                    Console.WriteLine("");

                    bool carTowbool = false;
                    askBool("Does it have a towbar Y/N: ", out carTowbool);

                    Garage<Vehicle>.Get().vehicles.Add(new Car(carCabbool, carTowbool, $"{RegNr}", $"{Model}", $"{Color}", $"{Propellant}", $"{ManuFac}", Wheels, YearMade));
                    Console.WriteLine($"Your {Color} {ManuFac} {Model} with licencenumer {RegNr} has now been parked.");
                    break;

                case "bus":
                    bool busDeckbool = false;
                    askBool("Is it a doubledecker Y/N: ", out busDeckbool);

                    Console.WriteLine("How many passengers does it take: ");
                    int numberOfPass = Convert.ToInt32(Console.ReadLine());
                    while (!BetweenRanges(1, 100, numberOfPass))
                    {
                        Console.WriteLine("Not a valid number of passengers, try again.");
                        numberOfPass = Convert.ToInt32(Console.ReadLine());
                    }

                    Garage<Vehicle>.Get().vehicles.Add(new Bus(numberOfPass, busDeckbool, $"{RegNr}", $"{Model}", $"{Color}", $"{Propellant}", $"{ManuFac}", Wheels, YearMade));
                    //int PassangerNo, bool isDoubleDecker, string RegistrationNumber, string Model, string Color, string Propellant, string Manufacturer, int NumberOfWheels, int YearMade
                    Console.WriteLine($"Your {Color} {ManuFac} {Model} with licencenumer {RegNr} has now been parked.");
                    break;
                case "truck":
                    Console.WriteLine("What weight class is it: ");
                    string truckWeightclass = Console.ReadLine();

                    Console.WriteLine("How much weight can it pull: ");
                    int truckMaxPull = Convert.ToInt32(Console.ReadLine());

                    Garage<Vehicle>.Get().vehicles.Add(new Truck(truckWeightclass, truckMaxPull, $"{RegNr}", $"{Model}", $"{Color}", $"{Propellant}", $"{ManuFac}", Wheels, YearMade));
                    // (string WeightClass, int WeightPulled,
                    Console.WriteLine($"Your {Color} {ManuFac} {Model} with licencenumer {RegNr} has now been parked.");
                    break;
                case "moped":
                    Console.WriteLine("What weight class is it: ");
                    string mopedWeightclass = Console.ReadLine();

                    Console.WriteLine("What kind of moped is it: ");
                    string mopedType = Console.ReadLine();

                    Garage<Vehicle>.Get().vehicles.Add(new Moped(mopedWeightclass, mopedType, $"{RegNr}", $"{Model}", $"{Color}", $"{Propellant}", $"{ManuFac}", Wheels, YearMade));
                    Console.WriteLine($"Your {Color} {ManuFac} {Model} with licencenumer {RegNr} has now been parked.");
                    break;
                case "motorcycle":
                    Console.WriteLine("What weight class is it: ");
                    string mcWeightclass = Console.ReadLine();

                    Console.WriteLine("How many CC does it have: ");
                    int numberOfcc = Convert.ToInt32(Console.ReadLine());

                    Garage<Vehicle>.Get().vehicles.Add(new Motorcycle($"{RegNr}", $"{ManuFac}", $"{Model}", YearMade, $"{Propellant}", $"{Color}", Wheels, mcWeightclass, numberOfcc));
                    //(string RegistrationNumber, string Model, string Manufacturer, int YearMade, string Propellent, string Color, int NumberOfWheels, string WeightClass, int NumberOfCC)
                    Console.WriteLine($"Your {Color} {ManuFac} {Model} with licencenumer {RegNr} has now been parked.");
                    break;
                default:
                    break;
            }
        }
        static public bool askBool(string question, out bool answer)
        {
            while (true)
            {
                
                Console.Write(question);
                var input = Console.ReadLine().Trim().ToLowerInvariant();
                switch (input)
                {
                    case "y":
                    case "yes":
                        return (answer) = true;

                    case "n":
                    case "no":
                        return (answer) = false;
                }
            }
        }
    }
}
