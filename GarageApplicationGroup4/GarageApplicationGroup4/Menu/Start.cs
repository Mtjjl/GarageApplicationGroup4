using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    static class Start
    {
        private static GarageTest<Vehicle> CreateGarage(out ManageTest manage)
        {
            string name = Validate.GetValidString("Before the application can start, we need to know which garage you want to use.\n\n" +
                                                  "To create a new garage, simply enter the name you want the garage to have.\n" +
                                                  "To load an existing garage, enter the name of a garage you have previously saved.");
            GarageTest<Vehicle> garage = new GarageTest<Vehicle>(name);
            manage = new ManageTest(garage);
            return garage;
        }

        public static void LaunchApplication()
        {
            GarageTest<Vehicle> garage = CreateGarage(out ManageTest manage);
            manage.Load();

            Graphics graphs = new Graphics();
            graphs.Hellomessage(manage);

            Menu menu = new Menu();
            menu.GreetingMessage(manage);
            menu.MenuMethod(manage);
        }
    }
}
