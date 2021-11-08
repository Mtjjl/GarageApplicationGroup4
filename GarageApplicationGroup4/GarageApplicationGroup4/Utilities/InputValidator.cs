using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GarageApplicationGroup4
{
    static class Validate
    {
        public static string GetValidPlateNumber()
        {
            string input = string.Empty;
            bool inputAccepted = false;

            while (!inputAccepted)
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid plate number in the following format: ABC123\n");
                input = Console.ReadLine().ToUpper().Trim();

                if (input.Length == 6)
                {
                    if (
                        Char.IsLetter(input[0])
                        && Char.IsLetter(input[1])
                        && Char.IsLetter(input[2])
                        && Char.IsNumber(input[3])
                        && Char.IsNumber(input[4])
                        && Char.IsNumber(input[5])
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




        public static bool GetValidPlateNumber(out string input)
        {
            input = string.Empty;
            while (input.ToUpper() != "EXIT")
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid plate number in the following format: ABC123\n");
                input = Console.ReadLine().ToUpper().Trim();

                if (input.Length == 6)
                {
                    if (
                        Char.IsLetter(input[0])
                        && Char.IsLetter(input[1])
                        && Char.IsLetter(input[2])
                        && Char.IsNumber(input[3])
                        && Char.IsNumber(input[4])
                        && Char.IsNumber(input[5])
                        )
                    {
                        Console.Clear();
                        return true;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"You have entered an invalid plate number. Plate number must have the following format: ABC123\n");
                    Break.PressToContinue();
                }
            }
            Console.Clear();
            return false;
        }

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

        public static string GetValidString(string info)
        {
            Console.WriteLine(info);
            string output = Console.ReadLine().Trim();
            Console.Clear();
            return output;
        }

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
