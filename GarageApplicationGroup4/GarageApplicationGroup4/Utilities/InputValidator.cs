using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageApplicationGroup4
{
    static class Validate
    {
        //Denna metod tittar om ett reg-nummer redan är upptaget.
        public static bool IsPlateNumberBusy(string input, Manage manage)
        {
            List<string> plateNumbers = manage.Garage.Vehicles
                            .Select(x => x.RegistrationNumber.ToUpper()).ToList();

            if (plateNumbers.Contains(input.ToUpper()))
            {
                Console.WriteLine("The registration number you tried is already in use. Please enter another one");
                Break.PressToContinue();
                return true;
            }
            return false;
        }

        //Denna metod returnerar en string med registreringsnummer baserad på användarens inpt. Fortsätter tills användaren matar in i rätt format.
        public static string GetValidPlateNumber()
        {
            string input = string.Empty;
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid plate number in the following format: ABC123 or ABC12A (I, Q, V, Å, Ä & Ö are not allowed)\n");
                input = Console.ReadLine().ToUpper().Trim();

                if (input.Length == 6
                    && !input.Contains("Å")
                    && !input.Contains("Ä")
                    && !input.Contains("Ö")
                    && !input.Contains("I")
                    && !input.Contains("Q")
                    && !input.Contains("V")
                    )
                {
                    if (
                        Char.IsLetter(input[0])
                        && Char.IsLetter(input[1])
                        && Char.IsLetter(input[2])
                        && Char.IsNumber(input[3])
                        && Char.IsNumber(input[4])
                        && (Char.IsNumber(input[5]) || Char.IsLetter(input[5]))
                        )
                    {
                        Console.Clear();
                        inputAccepted = true;
                        return input;
                    }
                }
            }
            Console.Clear();
            return "";
        }

        /*Denna metod returnerar sedan en siffra mellan ett min- och maxvärde. 
        Användaren får mata in värdet tills det är inom detta talområde.*/
        public static int GetValidNumber(string info, int min, int max)
        {
            bool inputAccepted = false;
            int validNumber = min - 1;

            while (!inputAccepted || validNumber < min || validNumber > max)
            {
                Console.Clear();
                Console.WriteLine(info);
                Console.WriteLine($"\nEnter a number between {min} and {max}");
                inputAccepted = Int32.TryParse(Console.ReadLine().Trim(), out validNumber);
            }

            Console.Clear();
            return validNumber;
        }

        //Returnerar en string som användaren matar in. Det får inte vara en tom string, då måste användaren göra om sin input
        public static string GetValidString(string info)
        {
            string output = string.Empty;

            while (string.IsNullOrEmpty(output))
            {
                Console.WriteLine(info);
                output = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(output))
                {
                    Console.Clear();
                    Console.WriteLine("Input can not be empty.");
                    Break.PleaseWait(1);
                }
                Console.Clear();
            }
            return output;
        }

        /*Returnerar en string baserad på användarens input. Denna input måste stämma överens med någon av de "choices" som anges.
        Om det inte stämmer överens, måste användaren skriva in input på nytt.*/
        public static string GetValidString(string info, params string[] choices)
        {
            bool inputAccepted = false;
            string output = "";
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < choices.Length; i++)
            {
                stringBuilder.Append(choices[i] + "\n");
            }

            while (!inputAccepted)
            {
                Console.WriteLine(info + "\nChose between the following:\n");
                Console.WriteLine(stringBuilder.ToString());
                output = Console.ReadLine().Trim();

                for (int i = 0; i < choices.Length; i++)
                {
                    if (output.ToLower() == choices[i].ToLower())
                    {
                        inputAccepted = true;
                        Console.Clear();
                        return choices[i];
                    }
                }
                Console.Clear();
            }
            return output;
        }

        //Denna metod används vid Ja- eller nejfrågor. Fortsätter tills användaren matat in korrekt input
        public static bool GetYesOrNo(string inputInfo)
        {
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                Console.WriteLine($"{inputInfo} Press [Y] for Yes and [N] for no.");
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 'y':
                        Console.Clear();
                        return true;
                    case 'n':
                        Console.Clear();
                        return false;
                    case 'Y':
                        Console.Clear();
                        return true;
                    case 'N':
                        Console.Clear();
                        return false;
                    default:
                        Console.Clear();
                        break;
                }
            }
            return false;
        }
    }
}
