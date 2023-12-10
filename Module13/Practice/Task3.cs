using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Practice
{
    /*3. Дан файл, в котором записан набор чисел.Переписать в другой файл все числа в обратном порядке.*/
    public class Task3
    {
        public static void Start()
        {
            string path = @"C:\Users\GigaT\source\repos\Module13\Module13\Practice";
            string[] content = File.ReadAllLines(path + @"\Numbers.txt");
            List<int> ints = new List<int>();
            foreach (string line in content)
            {
                ints.Add(int.Parse(line));
            }
            ints.Reverse();
            string writecontent = string.Join("\r\n", ints.ToArray());
            File.WriteAllText(path + @"\BackNumbers.txt", writecontent);
            Console.WriteLine("Numbers.txt was reversed and saved in BackNumbers");
        }
    }
}
