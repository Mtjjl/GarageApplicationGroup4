using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GarageApplicationGroup4
{
    static class Break
    {
        //DRY-metod för kommando som ofta repeterades. En paus på x sekunder och console-rensning.
        public static void PleaseWait(int seconds)
        {
            Console.WriteLine("Please wait...");
            Thread.Sleep(seconds * 1000);
            Console.Clear();
        }

        //DRY-metod för kommando som ofta repeterades. En paus tills användaren trycker på en knapp.
        public static void PressToContinue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
