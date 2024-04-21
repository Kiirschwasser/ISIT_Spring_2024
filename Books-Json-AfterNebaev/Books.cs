using System;
using System.IO;
using System.Collections.Generic;

namespace LibraryNamespace
{
    public class Book
    {
        public string Title { get; }
        public string Genre { get; }
        public string Author { get; }
        public int Year { get; }
        public Guid id { get; }
        public bool Availability {get; set;}//Так как нам нужно в процессе устанавливать доступность книги
        public DateTime date{get;} //Когда книга пришла

    #region Ctor & Destructor
        /// <summary>
        /// Standard Constructor
        /// </summary>
        public Book(string Title, string Genre, string Author, int Year)
        {
            this.Title = Title;
            this.Genre = Genre;
            this.Author = Author;
            this.Year = Year;
            this.id = Guid.NewGuid();
            this.Availability=true;
            this.date=DateTime.Now;
            
        }
    #endregion

        public static void Print_Book(Book Book)
        {
            Console.WriteLine($"------");
            Console.WriteLine($"Book:");
            Console.WriteLine($"Title: {Book.Title}");
            Console.WriteLine($"Genre: {Book.Genre}");
            Console.WriteLine($"Author: {Book.Author}");
            Console.WriteLine($"Year: {Book.Year}");
            Console.WriteLine($"id: {Book.id}");
            Console.WriteLine($"Availability: {Book.Availability}");
            Console.WriteLine($"Date: {Book.date}");
        }

    }
}