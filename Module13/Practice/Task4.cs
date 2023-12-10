using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Practice
{
    /*4. Дан файл, содержащий информацию о сотрудниках фирмы: фамилия, имя, отчество, пол, возраст, размер зарплаты.
     За один просмотр файла напечатать элементы файла в следующем порядке: сначала все данные о сотрудниках,
    зарплата которых меньше 10000, потом данные об остальных сотрудниках, сохраняя исходный порядок в каждой группе сотрудников.*/
    public class Task4
    {
        public static void Start()
        {
            string path = @"C:\Users\GigaT\source\repos\Module13\Module13\Practice\Employees.txt";
            List<Employee> employeesWithSalaryLessThan10000 = new List<Employee>();
            List<Employee> otherEmployees = new List<Employee>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(' ');

                    Employee employee = new Employee
                    {
                        LastName = data[0],
                        FirstName = data[1],
                        Patronymic = data[2],
                        Gender = data[3],
                        Age = int.Parse(data[4]),
                        Salary = decimal.Parse(data[5])
                    };

                    if (employee.Salary < 10000)
                    {
                        employeesWithSalaryLessThan10000.Add(employee);
                    }
                    else
                    {
                        otherEmployees.Add(employee);
                    }
                }
            }

            Console.WriteLine("Employees with salary less than 10000:");
            foreach (Employee employee in employeesWithSalaryLessThan10000)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("\nOther employees:");
            foreach (Employee employee in otherEmployees)
            {
                Console.WriteLine(employee);
            }

        }

        class Employee
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {Patronymic}, {Gender}, {Age} years old, Salary: {Salary}";
            }
        }
    }
}
