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
                        isRunning = false;
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
                        Console.Clear();
                        Console.WriteLine("Select a number between 1-5 in the Garage Menu and press Enter to proceed.");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }
        }

        public void GreetingMessage()
        {
            Console.WriteLine("Welcome to the Garage!\n");
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
                "\n[4] See all motorcycles" +
                "\n[5] See all mopeds" +
                "\n[6] Back to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        //Manage.Garage().ListAllVehicles();
                        //MenuMethod();
                        break;

                    case "2":
                        Console.Clear();
                        //Manage.Garage().ListVehiclesOfType<SUBKLASSENSNAMN>();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        MenuMethod();
                        break;

                    case "3":
                        Console.Clear();
                        //Manage.Garage().ListVehiclesOfType<SUBKLASSENSNAMN>();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        MenuMethod();
                        break;

                    case "4":
                        Console.Clear();
                        //Manage.Garage().ListVehiclesOfType<SUBKLASSENSNAMN>();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        MenuMethod();
                        break;

                    case "5":
                        Console.Clear();
                        //Manage.Garage().ListVehiclesOfType<SUBKLASSENSNAMN>();
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        MenuMethod();
                        break;

                    case "6":
                        Console.Clear();
                        MenuMethod();
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Select a number between 1-6 in the menu and press Enter to proceed.");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            
        }

    }
}
