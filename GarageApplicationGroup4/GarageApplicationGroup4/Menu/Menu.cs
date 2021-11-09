using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    class Menu
    {
        public void MenuMethod(Manage manage)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("[1] See vehicles" +
                    "\n[2] Park new vehicle" +
                    "\n[3] Remove vehicle" +
                    "\n[4] Search vehicle" +
                    "\n[5] Exit Garage");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowVehicles(manage);
                        break;

                    case "2":
                        Console.Clear();
                        manage.AddVehicle();
                        break;

                    case "3":
                        Console.Clear();
                        manage.RemoveVehicle();
                        break;

                    case "4":
                        string plateNumber = Validate.GetValidPlateNumber();
                        manage.SearchForVehicle(plateNumber);
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("You have decided to exit the Garage." +
                            "\nYour digital invoice has been sent to your email.\n\nBye bye!\n");
                        Email email = new Email();
                        email.Emailer();
                        manage.Save();
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
        }

        public void ShowVehicles(Manage manage)
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
                        manage.ListAllVehicles();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        manage.ListVehiclesOfType<Car>();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        manage.ListVehiclesOfType<Truck>();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        manage.ListVehiclesOfType<Bus>();
                        Console.Clear();
                        break;

                    case "5":
                        Console.Clear();
                        manage.ListVehiclesOfType<Motorcycle>();
                        Console.Clear();
                        break;

                    case "6":
                        Console.Clear();
                        manage.ListVehiclesOfType<Moped>();
                        Console.Clear();
                        break;

                    case "7":
                        Console.Clear();
                        isRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Select a number between 1-7 in the menu and press Enter to proceed.");
                        Break.PressToContinue();
                        break;
                }
            }
            
        }

    }
}
