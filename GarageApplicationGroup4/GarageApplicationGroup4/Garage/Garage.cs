using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    class Garage<T> : IEnumerable where T : Vehicle
    {
        public List<T> vehicles { get; set; } = new List<T>();
        public int MaxLimit { get; }

        //Skapar den enda instansen av klassen som behövs för denna lösning
        private static readonly Garage<Vehicle> garage = new Garage<Vehicle>(10);

        //Privat constructor, då instanser bara ska få skapas inom denna klass.
        private Garage(int maxLimit)
        {
            MaxLimit = maxLimit;
        }

        //Via följande metod kan Manage-klassen komma åt den enda instansen av Garage-klassen.
        public static Garage<Vehicle> Get() => garage;

        /*Följande metod är implementeringen av IEnumerable-interface:t. En foreach-loop 
         *på objekt från denna klass är kopplat till listan "vehicles". */ 
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T vehicle in vehicles)
            {
                yield return vehicle;
            }
        }
    }
}