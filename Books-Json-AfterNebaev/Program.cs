﻿using System;
using LibraryNamespace;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
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
        Console.WriteLine("8) Delete Reader");
        Console.WriteLine("11) Exit");
        Console.Write("\r\nSelect an option: ");
        switch (Console.ReadLine())
        {
            case "1":
                BookOperations.AddBook();
            return true;
            case "2":            
                BookOperations.ViewBook();
                return true;
            case "3":
                BookOperations.DeleteBook();
                return true;
            case "4":
                BookOperations.RentBook();
                return true;
            case "5":
                BookOperations.ReturnBook();
                return true;
            case "6":
                ReaderOperations.AddReader();
                return true;
            case "7":
                ReaderOperations.ViewReader();
                return true;
            case "8":
                ReaderOperations.DeleteReader();
                return true;
            case "11":
                return false;
            default:
                return true;
        }
    }
}