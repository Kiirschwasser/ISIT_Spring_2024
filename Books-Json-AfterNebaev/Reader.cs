using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LibraryNamespace
{
    public class Reader
    {
        public string Name { get; }
        public int Year_of_birth { get; }
        public Guid id { get; }
        public DateTime date { get; }

        public Reader(string Name, int Year_of_birth, DateTime date)
        {
            this.Name = Name;
            this.Year_of_birth = Year_of_birth;
            this.id = Guid.NewGuid();
            this.date = date;
        }

        public static void Print_Reader(Reader Reader)
        {
            Console.WriteLine($"------");
            Console.WriteLine($"Reader:");
            Console.WriteLine($"Name: {Reader.Name}");
            Console.WriteLine($"Birth year: {Reader.Year_of_birth}");
            Console.WriteLine($"id: {Reader.id}");
            Console.WriteLine($"Date: {Reader.date}");
            Console.WriteLine($"------");
        }
    }
    class ReaderRepository
    {
        private static string filePath = "readers.json";
        private static List<Reader> _readers;

        static ReaderRepository()
        {
            _readers=LoadReader();
        }
        public static List<Reader> LoadReader()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Reader>>(json);
            }
            else
            {
                return new List<Reader>();
            }
        }
        public static void SaveReaders()
        {
            string json=JsonSerializer.Serialize(_readers);
            File.WriteAllText(filePath, json);
        }
        public static Reader FindReaderByName(string name)
        {
            return _readers.Find(b => b.Name.ToLower() == name.ToLower());
        }
        public static void RemoveReader(Reader Reader)
        {
            _readers.Remove(Reader);
            SaveReaders();
        }
        public static void AddReader(Reader Reader)
        {
            _readers.Add(Reader);
            SaveReaders();
        } 
    }

    class ReaderOperations
    {
        public static void AddReader()
        {
            Console.WriteLine("Enter reader name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter reader year of birth: ");
            int yearOfBirth = Convert.ToInt32(Console.ReadLine());
            DateTime dateOfRegistr = DateTime.Now;            Reader newReader = new Reader(name, yearOfBirth,dateOfRegistr);
            ReaderRepository.AddReader(newReader);
            Console.WriteLine($"Reader '{newReader.Name}' added successfully.");            //SaveReadersToFile();
        }
        public static void ViewReader()
        {
            Console.WriteLine("Enter reader name: ");
            string searchName = Console.ReadLine();
            Reader readerToView = ReaderRepository.FindReaderByName(searchName);

            if(readerToView != null)
            {
                Reader.Print_Reader(readerToView);
            }
            else
            {
                Console.WriteLine($"Reader with name '{readerToView}' not found.");
            }
        }
        public static void DeleteReader()
        {
            Console.WriteLine("Enter reader name to delete: ");
            string deleteName = Console.ReadLine();
            Reader readerToDelete = ReaderRepository.FindReaderByName(deleteName);
            if (readerToDelete != null)
            {
                ReaderRepository.RemoveReader(readerToDelete);
                Console.WriteLine($"Reader '{deleteName}' has been deleted.");
            }
            else
            {
                Console.WriteLine($"Reader '{deleteName}' not found.");
            }
        }

    }
}