﻿using System;
using System.IO;
using LibraryNamespace;
using static LibraryNamespace.Book;

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
            TempBook = new Book(TempTitle, TempGenre, TempAuthor, TempYear);
            BookRepository.AddBook(TempBook); // Добавляем книгу в список
            return true;
            case "2":            
                Console.WriteLine("Enter book title: ");
                string searchTitle = Console.ReadLine();
                Book foundBook = BookRepository.FindBookByTitle(searchTitle);

                if (foundBook != null)
                {
                    Book.Print_Book(foundBook);
                }
                else
                {
                    Console.WriteLine($"Book with title '{searchTitle}' not found.");
                }
                return true;
            case "3":
                Console.WriteLine("Enter book title to delete: ");
                string deleteTitle = Console.ReadLine();
                Book bookToDelete = BookRepository.FindBookByTitle(deleteTitle);
                if (bookToDelete != null)
                {
                    BookRepository.RemoveBook(bookToDelete);
                    Console.WriteLine($"Book '{deleteTitle}' has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Book '{deleteTitle}' not found.");
                }
                return true;
            case "4":
                Console.WriteLine("Enter book title to rent: ");
                string rentTitle = Console.ReadLine();
                Book bookToRent = BookRepository.FindBookByTitle(rentTitle);
                if (bookToRent != null)
                {
                    if (bookToRent.Availability)
                    {
                        bookToRent.Availability = false;
                        BookRepository.SaveBooks();
                        Console.WriteLine($"Book '{rentTitle}' has been rented.");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{rentTitle}' is already rented.");
                    }
                }
                else
                {
                    Console.WriteLine($"Book '{rentTitle}' not found.");
                }
                return true;
            case "5":
                Console.WriteLine("Enter book title to return: ");
                string returnTitle = Console.ReadLine();
                Book bookToReturn = BookRepository.FindBookByTitle(returnTitle);
                if (bookToReturn != null)
                {
                    if (!bookToReturn.Availability)
                    {
                        bookToReturn.Availability = true;
                        BookRepository.SaveBooks();
                        Console.WriteLine($"Book '{returnTitle}' has been returned.");
                    }
                    else
                    {
                        Console.WriteLine($"Book '{returnTitle}' is not rented.");
                    }
                }
                else
                {
                    Console.WriteLine($"Book '{returnTitle}' not found.");
                }
                return true;
            case "11":
                return false;
            default:
                return true;
        }
    }
}