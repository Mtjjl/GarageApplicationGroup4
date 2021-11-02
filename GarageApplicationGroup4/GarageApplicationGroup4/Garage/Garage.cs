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
        public int MaxLimit { get; set; }

        private static readonly Garage<Vehicle> garage = new Garage<Vehicle>(10);

        public static Garage<Vehicle> Get() => garage;

        private Garage(int maxLimit)
        {
            MaxLimit = maxLimit;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T item in vehicles)
            {
                yield return item;
            }
        }


    }
}