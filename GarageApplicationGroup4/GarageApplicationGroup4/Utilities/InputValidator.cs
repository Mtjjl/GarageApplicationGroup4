﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GarageApplicationGroup4
{
    static class Validate
    {
        public static bool PlateNumberInput(out string input)
        {
            input = string.Empty;
            while (input.ToUpper() != "EXIT")
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid plate number in the following format: ABC123\n" +
                              $"To go back to the main menu, please type EXIT.");
                input = Console.ReadLine().ToUpper();

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
                else if (input != "EXIT")
                {
                    Console.Clear();
                    Console.WriteLine($"You have entered an invalid plate number. Plate number must have the following format: ABC123\n" +
                                      $"Please try again...");
                    Thread.Sleep(2000);
                }
            }
            Console.Clear();
            return false;
        }
    }
}