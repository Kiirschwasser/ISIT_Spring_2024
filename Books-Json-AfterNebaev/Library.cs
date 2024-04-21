using System;
using System.Collections.Generic;

namespace LibraryNamespace
{
    public class Library
    {
        public List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine("Book added successfully!");
            //Console.WriteLine(book);
        }
        public void PrintBooks(string searchText)
        {
            Book foundBook = _books.Find(book => book.Title.Equals(searchText, StringComparison.OrdinalIgnoreCase));
            if (foundBook != null)
            {
                Book.Print_Book(foundBook);
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
    }
}