using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplicationGroup4
{
    class GarageTest<T> : IEnumerable where T : Vehicle
    {
        public List<T> vehicles { get; set; } = new List<T>();
        public int MaxLimit { get; }
        public string Name { get; set; }

        public GarageTest(string name)
        {
            Name = name;
            MaxLimit = 10;
        }

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