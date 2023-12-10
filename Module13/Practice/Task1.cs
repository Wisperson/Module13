using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Module13.Practice
{
    /*Создать коллекцию List<int>.Вывести на экран позицию и значение элемента, являющегося вторым максимальным значением в коллекции

a.Удалить все нечетные элементы списка List<int>

*/
    public class Task1
    {
        /*циклом нахожу наибольший элемент. Затем, запустив цикл с 2 повторениями присваиваю второму максимальному элементу
         значение случайного элемента листа с так, чтобы он не повторился с тем что уже записан. тем самым гарантирую, что во второй
        максимальный элемент не будет записано значение максимального, что сломало бы алгоритм*/

        public static void Start()
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(random.Next(100));
            }
            int max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > max) max = list[i];
            }
            int secondmax = list[0];
            int previoussecond = list[0];
            for (int i = 0; i < 2; i++)
            {
                while(secondmax == previoussecond)
                {
                    secondmax = list[random.Next(list.Count)];
                }
                previoussecond = secondmax;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] > secondmax && list[j] != max)
                    {
                        secondmax = list[j];
                    }
                }
            }
            foreach(int i in list)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
            Console.WriteLine($"Max element: {max}");
            Console.WriteLine($"Second Max element: {secondmax}");
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 0) list.RemoveAt(i);
            }
            foreach (int i in list)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
        }

    }
}
