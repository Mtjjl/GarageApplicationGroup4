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
                        ShowVehicles();
                        break;

                    case "2":
                        //Manage.Garage().AddVehicle();
                        break;

                    case "3":
                        Console.Clear();
                        Manage.Garage().RemoveVehicle();
                        break;

                    case "4":
                        if (Validate.GetValidPlateNumber(out string plateNumber))
                        {
                            Manage.Garage().SearchForVehicle(plateNumber);
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("You have decided to exit the Garage.\nBye bye!");
                        Manage.Garage().Save();
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Select a number between 1-5 in the Garage menu and press Enter to proceed.");
                        Break.PressToContinue();
                        break;
                }

            }
        }

        public void GreetingMessage()
        {
            Console.WriteLine("Welcome to the Garage!\n");
            Manage.Garage().Load();
        }

        public void ShowVehicles()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("[1] See all vehicles" +
                "\n[2] See all cars" +
                "\n[3] See all trucks" +
                "\n[4] See all buses" +
                "\n[5] See all motorcycles" +
                "\n[6] See all mopeds" +
                "\n[7] Back to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Manage.Garage().ListAllVehicles();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        Manage.Garage().ListVehiclesOfType<Car>();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Manage.Garage().ListVehiclesOfType<Truck>();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        Manage.Garage().ListVehiclesOfType<Bus>();
                        Console.Clear();
                        break;

                    case "5":
                        Console.Clear();
                        Manage.Garage().ListVehiclesOfType<Motorcycle>();
                        Console.Clear();
                        break;

                    case "6":
                        Console.Clear();
                        Manage.Garage().ListVehiclesOfType<Moped>();
                        Console.Clear();
                        break;

                    case "7":
                        Console.Clear();
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Select a number between 1-6 in the menu and press Enter to proceed.");
                        Break.PressToContinue();
                        break;
                }
            }
            
        }

    }
}
