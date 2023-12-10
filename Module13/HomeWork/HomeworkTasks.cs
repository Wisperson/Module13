using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.HomeWork
{
    public class HomeworkTasks
    {
        static Queue<Client> bankQueue = new Queue<Client>();

        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Встать в очередь");
                Console.WriteLine("2. Обслужить следующего клиента");
                Console.WriteLine("3. Выйти из программы");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnqueueClient();
                        break;
                    case "2":
                        ServeNextClient();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        static void EnqueueClient()
        {
            Console.Write("Введите ИИН клиента: ");
            string id = Console.ReadLine();

            Console.Write("Выберите тип обслуживания (1 - Кредитование, 2 - Открытие вклада, 3 - Консультация): ");
            string serviceType = Console.ReadLine();
            ServiceType type = ParseServiceType(serviceType);

            Client client = new Client(id, type);
            bankQueue.Enqueue(client);

            Console.WriteLine($"Клиент {id} добавлен в очередь для {type}.");
            DisplayQueueStatus();
        }

        static void ServeNextClient()
        {
            if (bankQueue.Count > 0)
            {
                Client nextClient = bankQueue.Dequeue();
                Console.WriteLine($"Обслужен клиент {nextClient.Id} ({nextClient.Service}).");
                DisplayQueueStatus();
            }
            else
            {
                Console.WriteLine("Очередь пуста.");
            }
        }

        static void DisplayQueueStatus()
        {
            Console.WriteLine("Текущее состояние очереди:");

            foreach (var client in bankQueue)
            {
                Console.WriteLine($"Клиент {client.Id} ({client.Service})");
            }

            Console.WriteLine();
        }

        static ServiceType ParseServiceType(string input)
        {
            switch (input)
            {
                case "1":
                    return ServiceType.Credit;
                case "2":
                    return ServiceType.Deposit;
                case "3":
                    return ServiceType.Consultation;
                default:
                    Console.WriteLine("Неизвестный тип обслуживания. Установлен тип по умолчанию: Консультация.");
                    return ServiceType.Consultation;
            }
        }

    }

    class Client
    {
        private static int clientCounter = 1;

        public Client(string id, ServiceType service)
        {
            Id = id;
            Service = service;
        }

        public string Id { get; }
        public ServiceType Service { get; }
    }

    enum ServiceType
    {
        Credit,
        Deposit,
        Consultation
    }
}
