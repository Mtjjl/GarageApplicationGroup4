using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    class Manage
    {
        private Garage<Vehicle> garage = Garage<Vehicle>.Get();

        private static readonly Manage garageHandler = new Manage();

        private Manage() { }

        public static Manage Garage() => garageHandler;

        public void AddVehicle(Vehicle vehicle)
        {
            if (garage.vehicles.Count < garage.MaxLimit)
            {
                garage.vehicles.Add(vehicle);
            }
            else
            {
                Console.WriteLine("The garage is full. No more vehicles can be added.");
            }
        }

        public void ListAllVehicles()
        {
            foreach (Vehicle vehicle in garage)
            {
                Console.WriteLine(vehicle);
            }
        }

        public void ListVehiclesOfType<U>() where U : Vehicle
        {
            if (garage.vehicles.OfType<U>().Any())
            {
                foreach (Vehicle vehicle in garage.OfType<U>())
                {
                    Console.WriteLine(vehicle);
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles of the chosen type in the garage.");
            }
        }

        public void RemoveVehicleOfType<U>() where U : Vehicle
        {
            if (garage.vehicles.OfType<U>().Any())
            {
                garage.vehicles.Remove(garage.vehicles.OfType<U>().First());
            }
            else
            {
                Console.WriteLine("There are no vehicles of the chosen type in the garage.");
            }
        }

    }
}
