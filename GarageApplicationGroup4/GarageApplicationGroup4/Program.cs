﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu garageMenu = new Menu();

            garageMenu.GreetingMessage();
            garageMenu.MenuMethod();
            Console.ReadKey();

        }
    }
}
