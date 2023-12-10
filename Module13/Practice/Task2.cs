using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Practice
{
    public class Task2
    {
        /*2. Дана коллекция типа List<double>.Вывести на экран элементы списка, 
         значение которых больше среднего арифметического всех элементов коллекции.*/
        public static void Start()
        {
            Random random = new Random();
            List<double> list = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(Math.Round(random.NextDouble(), 5));
            }
            double mid = 0;
            foreach(double d in list)
            {
                mid += d;
            }
            mid /= list.Count;
            Console.WriteLine($"Mid: {mid}");
            foreach(double d in list)
            {
                if (d >= mid)
                {
                    Console.WriteLine(d);
                }
            }

        }
    }
}
