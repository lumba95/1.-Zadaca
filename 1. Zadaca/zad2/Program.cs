using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");

            Console.WriteLine("Ovo je zadatak 2");
            Console.WriteLine(stringList.Count);
            Console.WriteLine(stringList.Contains("Hello"));
            Console.WriteLine(stringList.IndexOf("Hello"));
            Console.WriteLine(stringList.GetElement(1));

            IGenericList<double> doubleList = new GenericList<double>();
            doubleList.Add(0.2);
            doubleList.Add(0.7);
            Console.WriteLine(doubleList.GetElement(1));
            Console.ReadLine();

        }
    }
}
