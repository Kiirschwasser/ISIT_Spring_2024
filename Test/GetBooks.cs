using System;
using System.Collections.Generic;

namespace Library
{
    class GetBook
    {
        //Мусорные?
        public string Title { get; }
        public string Author { get; } 


        public Guid idBook { get; }

        public Guid idReader { get; }

        public DateTime date{get;} //Когда книга пришла

        public void Add(Book Book, Reader Reader)
        {
            this.idBook = Book.id;
            this.idReader = Reader.id;
            this.date=DateTime.Now;
        }

        public static void Print_Transaction(GetBook Transaction)
        {
            Console.WriteLine($"------");
            Console.WriteLine($"Transaction:");
            Console.WriteLine($"Book: {Transaction.idBook}");
            Console.WriteLine($"Reader: {Transaction.idReader}");
            Console.WriteLine($"date: {Transaction.date}");
        }
    }
}