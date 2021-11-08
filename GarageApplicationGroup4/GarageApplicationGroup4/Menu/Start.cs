using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace GarageApplicationGroup4
{
    static class Start
    {
        public static void LaunchApplication()
        {
            Garage<Vehicle> garage = CreateGarage(out Manage manage);
            manage.Load();

            Graphics graphs = new Graphics();
            graphs.Hellomessage(manage);

            Menu menu = new Menu();
            menu.GreetingMessage(manage);
            menu.MenuMethod(manage);
        }

        private static Garage<Vehicle> CreateGarage(out Manage manage)
        {
            Console.WriteLine("Before the application can start, we need to know which garage you want to use.\n");
            Thread.Sleep(1000);
            ListAllFiles();
            string name = Validate.GetValidString("To add a new garage, enter the name you want to give it.").ToLower();
            
            Garage<Vehicle> garage = new Garage<Vehicle>(name);
            manage = new Manage(garage);
            return garage;
        }

        private static void ListAllFiles()
        {
            try
            {
                if (!Directory.Exists("SavedVehicles"))
                {
                    Directory.CreateDirectory("SavedVehicles");
                }
                string[] garageNames = Directory.GetFiles($"SavedVehicles\\", "*.xml")
                    .Select(fileName => Path.GetFileNameWithoutExtension(fileName))
                    .ToArray();

                if (garageNames.Any())
                {
                    Console.WriteLine("Here is a list of all the saved garages:\n");
                    foreach (var item in garageNames)
                    {
                        Thread.Sleep(400);
                        Console.WriteLine(item);
                    }
                    Thread.Sleep(400);
                    Console.WriteLine("\nTo load one of the saved garages, simply enter its name.");
                }
                else
                {
                    Console.WriteLine("You currently don't have any garages saved on your computer.");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong...");
            }  
        }
    }
}
