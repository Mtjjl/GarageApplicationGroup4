using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace GarageApplicationGroup4
{
    static class Start
    {
        /*Denna metod startar applikationen. Via metoden SelectGarage skapas ett Garage<Vehicle>-objekt med tillhörande Manage-objekt
        Manage-objektet kör sedan Load-metoden för att hantera filer. Hellomessage() tar emot manage-objektet för att visa animationen
        så att den stämmer överens med aktuellt garag. Sedan tar menu in manage för att få rätt information till dess metoder*/
        public static void LaunchApplication()
        {
            Garage<Vehicle> garage = SelectGarage(out Manage manage);
            manage.Load();

            Graphics graphs = new Graphics();
            graphs.Hellomessage(manage);

            Menu menu = new Menu();
            menu.GreetingMessage();
            menu.MenuMethod(manage);
        }

        /*Denna metod låter användaren välja vilket garage som ska användas. Om garage finns sparade visas dessa.
        Användaren skriver in namnet på sparat garage för att ladda detta eller ett nytt namn för att skapa nytt.
        Metoden returnerar garaget och tar även med sig ett Manage-objekt kopplat till garaget.*/
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

        /*Denna metod returnerar en lista på filnamn från mappen SavedVehicles, om sådana filer finns.
        Annars talar den om att inga filer finns. För säkerhets skull kollar den om mappen SavedVehicles finns
        Och skapar den om den ej existerar. Metoden används i SelectGarage.*/
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
                    stringBuilder.Append("You don't have any garages saved on your computer, you need to add a new one.");
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
