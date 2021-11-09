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
            Garage<Vehicle> garage = SelectGarage(out Manage manage);
            manage.Load();

            Graphics graphs = new Graphics();
            graphs.Hellomessage(manage);

            Menu menu = new Menu();
            menu.GreetingMessage(manage);
            menu.MenuMethod(manage);
        }

        private static Garage<Vehicle> SelectGarage(out Manage manage)
        {
            Thread.Sleep(1000);
            ListAllFiles();
            string name = Validate.GetValidString($"Before the application can start, we need to know which garage you want to use.\n" +
                $"{ListAllFiles()}" +
                $"\nTo add a new garage, enter the name you want to give it.").ToLower();
            
            Garage<Vehicle> garage = new Garage<Vehicle>(name);
            manage = new Manage(garage);
            return garage;
        }

        private static string ListAllFiles()
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

                StringBuilder stringBuilder = new StringBuilder();

                if (garageNames.Any())
                {
                    stringBuilder.Append("Here is a list of all the saved garages:\n\n");
                    foreach (var item in garageNames)
                    {
                        stringBuilder.Append(item + "\n");
                    }
                    stringBuilder.Append("\nTo load one of the saved garages, simply enter its name.");
                }
                else
                {
                    stringBuilder.Append("You currently don't have any garages saved on your computer.");
                }

                return stringBuilder.ToString();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong...");
                return string.Empty;
            }
        }
    }
}
