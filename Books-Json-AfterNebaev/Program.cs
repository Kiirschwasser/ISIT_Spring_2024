﻿using System;
using System.IO;
using LibraryNamespace;

class Program
{
    private static Book TempBook; // Объявляем TempBook как переменную класса

    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        
        Book Harry_Potter = new Book("Harry Potter", "Fantasy", "Joan", 1994);
        Book.Print_Book(Harry_Potter);

        Reader Reader1 = new Reader("Harry Potter", 1982);
        Reader.Print_Reader(Reader1);

        bool showMainMenu = true;
        while (showMainMenu)
        {
            showMainMenu = MainMenu();
        }
    }

    private static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Book menu");
        Console.WriteLine("11) Exit");
        Console.Write("\r\nSelect an option: ");
    
        switch (Console.ReadLine())
        {
            case "1":
                bool showBookMenu = true;
                while (showBookMenu)
                {
                    showBookMenu = BookMenu();
                }
                return true;
            case "11":
                return false;
            default:
                return true;
        }
    }

    private static bool BookMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Add book");
        Console.WriteLine("2) View Book");
        Console.WriteLine("3) Delete book");
        Console.WriteLine("4) Rent a book");
        Console.WriteLine("5) Return book");
        Console.WriteLine("6) Add reader");
        Console.WriteLine("7) View Reader");
        Console.WriteLine("11) Exit");
        Console.Write("\r\nSelect an option: ");
        LibraryNamespace.Library lib = new LibraryNamespace.Library();
        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("Write title: ");
                string TempTitle = Console.ReadLine();
                Console.WriteLine("Write genre: ");
                string TempGenre = Console.ReadLine();
                Console.WriteLine("Write author: ");
                string TempAuthor = Console.ReadLine();
                Console.WriteLine("Write Year: ");
                int TempYear = Convert.ToInt32(Console.ReadLine());
                TempBook = new Book(TempTitle, TempGenre, TempAuthor, TempYear); // Присваиваем значение TempBook                
                lib.AddBook(TempBook);
                return true;
            case "2":            
                Console.Write("Enter book title: ");
                string FindTitle = Console.ReadLine();
                lib.PrintBooks(FindTitle);
                return true;
            case "3":
                return true;
            case "4":
                return true;
            case "11":
                return false;
            default:
                return true;
        }
    }
}