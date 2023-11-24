using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module13.Practice;
//using Module13.HomeWork;

namespace Module13
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Task1 t1 = new Task1();
            t1.printAll();
            t1.PrintSorted();
            int sm = t1.SecondMax();
            Console.WriteLine($"second max = {sm}");
            t1.printAll();
            t1.PrintSorted();
            Console.ReadKey();

        }
    }
}
