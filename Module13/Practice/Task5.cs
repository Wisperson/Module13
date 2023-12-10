using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Practice
{
    internal class Task5
    {
        /*5. Решить задачу, используя класс HashTable:реализовать простейший каталог музыкальных компакт-дисков, который позволяет:
             o Добавлять и удалять диски.
             o Добавлять и удалять песни.
             o Просматривать содержимое целого каталога и каждого диска в отдельности.
             o Осуществлять поиск всех записей заданного исполнителя по всему каталогу.*/
        public static void Start()
        {
            Hashtable Disks = new Hashtable();
            InitMenu(Disks);
        }
        class Disk
        {
            public Disk(string name)
            {
                Name = name;
                Songs = new Hashtable();
            }
            public string Name { get; set; }
            public Hashtable Songs { get; set; }
        }
        public static void InitMenu(Hashtable Disks)
        {
            Console.Clear();
            int i = 0;
            string input;
            while (true)
            {
                while (true)
                {
                    Console.Write(
                    "1. Create disk\n" +
                    "2. Add song to disk\n" +
                    "3. Show disks\n" +
                    "4. Show songs on disk\n" +
                    "5. Exit\n");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out i) && i > 0 && i <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
                switch (i)
                {
                    case 1:
                        Console.Clear();
                        CreateDisk(Disks);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        AddSong(Disks);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        ShowDisks(Disks);
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        ShowSongs(Disks);
                        Console.Clear();
                        break;
                    case 5:
                        return;
                }
            }
        }

        public static void CreateDisk(Hashtable Disks)
        {
            Console.Write("Enter disk name: ");
            string input = Console.ReadLine();
            Disks.Add(Disks.Count, new Disk(input));
        }

        public static void AddSong(Hashtable Disks)
        {
            if (Disks.Count == 0)
            {
                Console.WriteLine("0 Disks, click to return");
                Console.ReadKey();
                return;
            }
            int i = 1;
            Console.WriteLine("Choose disk:");
            foreach (DictionaryEntry entry in Disks)
            {
                Disk disk = (Disk)entry.Value;
                Console.WriteLine(i++ + ". " + disk.Name);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out i) && i >= 1 && i <= Disks.Count) break;
                else Console.WriteLine("Incorrect input");
            }
            Disk editdisk = (Disk)Disks[i - 1];
            Console.WriteLine("Enter song name: ");
            string songname = Console.ReadLine();
            editdisk.Songs.Add(editdisk.Songs.Count, songname);
            Disks[i - 1] = editdisk;
        }

        public static void ShowDisks(Hashtable Disks)
        {
            if (Disks.Count == 0)
            {
                Console.WriteLine("0 Disks, click to return");
                Console.ReadKey();
                return;
            }
            int i = 1;
            foreach (DictionaryEntry entry in Disks)
            {
                Disk disk = (Disk)entry.Value;
                Console.WriteLine($"{i++}. " + disk.Name);
            }
            Console.WriteLine("0 Disks, click to return");
            Console.ReadKey();
        }

        public static void ShowSongs(Hashtable Disks)
        {
            if (Disks.Count == 0)
            {
                Console.WriteLine("0 Disks, click to return");
                Console.ReadKey();
                return;
            }
            int i = 1;
            Console.WriteLine("Choose disk:");
            foreach (DictionaryEntry entry in Disks)
            {
                Disk disk = (Disk)entry.Value;
                Console.WriteLine(i++ + ". " + disk.Name);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out i) && i >= 1 && i <= Disks.Count) break;
                else Console.WriteLine("Incorrect input");
            }
            Disk showdisk = (Disk)Disks[i - 1];
            int j = 1;
            foreach (DictionaryEntry entry in showdisk.Songs)
            {
                string song = (string)entry.Value;
                Console.WriteLine($"{j++}. " + song);
            }
            Console.WriteLine("0 Disks, click to return");
            Console.ReadKey();
        }

    }
}
