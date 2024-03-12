using System;
using Library;
// using Readers;


class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        
        Book Harry_Potter = new Book("Harry Potter", "Fantasy", "Joan", 1994);

        Book.Print_Book(Harry_Potter);

        

        var Reader1 = new Reader("Harry Potter", 1982);

        Reader.Print_Reader(Reader1);

        Book.TakeBook(Harry_Potter, Reader1);

        bool showMainMenu = true;
        while (showMainMenu)
        {
            showMainMenu = MainMenu();
        }

    }

    private static bool MainMenu()
    {
        //Console.Clear();
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
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Add book");
        Console.WriteLine("2) View Book");
        Console.WriteLine("3) Delete book");
        Console.WriteLine("4) Rent a book");
        Console.WriteLine("5) Return book");
//Добавить-исправить


        Console.WriteLine("4) Add reader");
        Console.WriteLine("5) View Reader");

        Console.WriteLine("11) Exit");
        Console.Write("\r\nSelect an option: ");
    
        switch (Console.ReadLine())
        {
            case "1":
                return true;
            case "2":
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