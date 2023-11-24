using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Practice
{
    public class Task1
    {
        /*
        Создать коллекцию List <int>.
        Вывести на экран позицию и значение элемента, являющегося вторым максимальным значением в коллекции 
        Удалить все нечетные элементы списка List<int>
        */
        public List<int> list {  get; set; }

        public Task1()
        {
            Random r = new Random();
            list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(100));
            }
        }

        public int SecondMax()
        {
            int max = list.ElementAt(0);

            for (int i = 1; i < list.Count; i++)
            {
                if (list.ElementAt(i) > max)
                {
                    max = list.ElementAt(i);
                }
            }

            int indexOfMax = list.IndexOf(max);
            list.RemoveAt(indexOfMax);

            int result = list.ElementAt(0);

            for (int i = 1; i < list.Count; i++)
            {
                if (list.ElementAt(i) > result)
                {
                    result = list.ElementAt(i);
                }
            }

            list.Add(max);
            for (int i = 1; i < indexOfMax; i++)
            {
                (list[i], list[i - 1]) = (list[i - 1], list[i]);
            }

            return result;

        }

        public void printAll()
        {
            Console.WriteLine("All\n------------");
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------");
        }

        public void PrintSorted()
        {
            Console.WriteLine("Sorted\n------------");
            List<int> bufList = new List<int>();
            foreach (var item in list)
            {
                bufList.Add(item);
            }
            bufList.Sort();
            foreach(var item in bufList)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("---------------");
        }
        
    }
}
