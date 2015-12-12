using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            IntegerList listOfIntegers = new IntegerList();

            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
            // lista je [1,2,3,4,5]

            //mičemo prvi element liste
            listOfIntegers.RemoveAt(0);
            //lista je [2,3,4,5]

            //mičemo element čija je vrijednost "5"
            listOfIntegers.Remove(5);

            Console.WriteLine(listOfIntegers.Count);

            Console.WriteLine(listOfIntegers.Remove(100));

            Console.WriteLine(listOfIntegers.RemoveAt(5));

            listOfIntegers.Clear();

            Console.WriteLine(listOfIntegers.Count);

            Console.ReadLine();
        }
             
    }
}
