using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    class Menu
    {
        public void MenuMethod()
        {
            Console.WriteLine("Welcome to the Garage!");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("[1] Show all vehicles" +
                    "\n[2] Park new vehicle" +
                    "\n[3] Remove vehicle" +
                    "\n[4] Search vehicle" +
                    "\n[5] Exit Garage");

                switch (Console.ReadLine())
                {
                    case "1":
                        //ShowVehicles()
                        break;

                    case "2":
                        //AddVehicle()
                        break;

                    case "3":
                        //RemoveVehicle()
                        break;

                    case "4":
                        //SearchVehicle()
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("You have decided to exit the Garage.");
                        Console.WriteLine("Bye bye!");
                        isRunning = false;
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
