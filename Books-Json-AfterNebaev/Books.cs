using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public DateTime ReleaseDate{get;} //Когда книга пришла

    #region Ctor & Destructor
        /// Standard Constructor <summary>    
        public Book(string Title, string Genre, string Author, int Year, DateTime ReleaseDate)
        {
            this.Title = Title;
            this.Genre = Genre;
            this.Author = Author;
            this.Year = Year;
            id = Guid.NewGuid();
            Availability=true;
            this.ReleaseDate= ReleaseDate;
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
            Console.WriteLine($"Date: {Book.ReleaseDate}");
            Console.WriteLine($"------");
        }
    }
        class BookOperations
        {
            public static void AddBook()
            {
                Console.WriteLine("Write title: ");
                string TempTitle = Console.ReadLine();
                Console.WriteLine("Write genre: ");
                string TempGenre = Console.ReadLine();
                Console.WriteLine("Write author: ");
                string TempAuthor = Console.ReadLine();
                Console.WriteLine("Write Year: ");
                int TempYear = Convert.ToInt32(Console.ReadLine());
                DateTime TempRelease = DateTime.Now;

                Book TempBook = new Book(TempTitle, TempGenre, TempAuthor, TempYear, TempRelease);
                BookRepository.AddBook(TempBook);
            }
            public static void ViewBook()
            {
                Console.WriteLine("Enter book title: ");
                string searchTitle = Console.ReadLine();
                Book bookToView = BookRepository.FindBookByTitle(searchTitle);

                if (bookToView != null)
                {
                    Book.Print_Book(bookToView);
                }
                else
                {
                    Console.WriteLine($"Book with title '{searchTitle}' not found.");
                }
            }

            public static void DeleteBook()
            {
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
            }
            public static void RentBook()
            {
                Console.WriteLine("Enter book title to rent: ");
                string rentTitle = Console.ReadLine();
                Book bookToRent = BookRepository.FindBookByTitle(rentTitle);

                if (bookToRent != null)
                {
                    if (bookToRent.Availability)
                    {
                        bookToRent.Availability = false;
                        Console.WriteLine($"Book '{rentTitle}' has been rented.");
                        BookRepository.SaveBooks();
                    }
                    else
                    {
                        Console.WriteLine($"Book '{rentTitle}' is not available for rent.");
                    }
                }
                else
                {
                    Console.WriteLine($"Book '{rentTitle}' not found.");
                }
            }
            public static void ReturnBook()
            {
                Console.WriteLine("Enter book title to return: ");
                string returnTitle = Console.ReadLine();
                Book bookToReturn = BookRepository.FindBookByTitle(returnTitle);

                if (bookToReturn != null)
                {
                    if (!bookToReturn.Availability)
                    {
                        bookToReturn.Availability = true;
                        Console.WriteLine($"Book '{returnTitle}' has been returned.");
                        BookRepository.SaveBooks();
                    }
                    else
                    {
                        Console.WriteLine($"Book '{returnTitle}' is not currently rented.");
                    }
                }
                else
                {
                    Console.WriteLine($"Book '{returnTitle}' not found.");
                }
            }   
        }
        class BookRepository
        {
            private const string FilePath = "books.json";
            private static List<Book> _books;

            static BookRepository()
            {
                _books = LoadBooks();
            }
            public static List<Book> LoadBooks()
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<List<Book>>(json);
                }
                else
                {
                    return new List<Book>();
                }
            }
            public static void SaveBooks()
            {
                string json = JsonSerializer.Serialize(_books);
                File.WriteAllText(FilePath, json);
            }

            
            public static Book FindBookByTitle(string title)
            {
                return _books.Find(b => b.Title.ToLower() == title.ToLower());
            } 
            public static void RemoveBook(Book book)
            {
                _books.Remove(book);
                SaveBooks();
            }   
            public static void AddBook(Book book)
            {
                _books.Add(book);
                SaveBooks();
            }
        }
}