using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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



        //Tar emot ett objekt av typen Vehicle och lägger till det i garaget
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

        /*Tar reda på om det finns fordon av en viss typ. Om det finns, tar den bort det första matchande objektet från garaget.
         * När man kallar på denna metod byts T ut mot en fordonstyp, t.ex. Car...*/
        public void RemoveVehicleOfType<T>() where T : Vehicle
        {
            if (garage.vehicles.OfType<T>().Any())
            {
                garage.vehicles.Remove(garage.vehicles.OfType<T>().First());
                Console.WriteLine("A vehicle of the chosen type has been removed from the garage.");
                Break.PressToContinue();
            }
            else
            {
                Console.WriteLine("There are no vehicles of the chosen type in the garage.");
                Break.PleaseWait(2);
            }
        }

        //Tar reda på om det om det finns fordon i garaget. Om det finns minst ett skriver den ut alla fordon.
        public void ListAllVehicles()
        {
            if (garage.vehicles.Any())
            {
                foreach (Vehicle vehicle in garage)
                {
                    Console.WriteLine(vehicle);
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
                foreach (Vehicle vehicle in garage.OfType<T>())
                {
                    Console.WriteLine(vehicle);
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
                //Följande villkor kommer att behövas fixas när registration blivit publik
                if (vehicle.ToString().Contains(licensePlate)) 
                {
                    Console.WriteLine("The vehicle you searched for is in the garage.");
                    Break.PressToContinue();
                    return;
                }
            }
            Console.WriteLine("The vehicle you searched for could not be found in the garage.");
            Break.PleaseWait(2);
        }
    }
}
