using System.Collections;
using System.Collections.Generic;

namespace GarageApplicationGroup4
{
    public class Garage<T> : IEnumerable where T : Vehicle
    {
        public List<T> Vehicles { get; set; } = new List<T>();
        public int MaxLimit { get; }
        public string Name { get; set; }

        public Garage(string name)
        {
            Name = name;
            MaxLimit = 10;
        }

        /*Följande metod är implementeringen av IEnumerable-interface:t. En foreach-loop 
         *på objekt från denna klass är kopplat till listan "vehicles". */
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T vehicle in Vehicles)
            {
                yield return vehicle;
            }
        }
    }
}