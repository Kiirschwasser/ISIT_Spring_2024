//bankaccount из примера == Readers отсюда
using System;

namespace LibraryNamespace
{
    class Reader
    {
        public string Name { set; get; }
        public int Year_of_birth { get; }
        public Guid id { get; }
        public DateTime date{get;} //Когда мужик пришёл
        
        // public decimal Existbook
        // {
        //     get
        //     {
        //         existbook=0;
        //         foreach(var item in _allTransactions)
        //         {
        //             existbook+=1;
        //         }
        //         return existbook;
        //     }
        // }

        // private List<Transaction> _allTransactions = new List<Transaction>();


    #region Ctor & Destructor
        /// <summary>
        /// Standard Constructor
        /// </summary>
        public Reader(string Name, int Year_of_birth)
        {
            this.Name = Name;
            this.Year_of_birth = Year_of_birth;
            this.id = Guid.NewGuid();
            this.date = DateTime.Now;
            // this.Existbook = 0;
        }
    #endregion


        public static void Print_Reader(Reader Reader)
        {
            Console.WriteLine($"------");
            Console.WriteLine($"Reader:");
            Console.WriteLine($"Name: {Reader.Name}");
            Console.WriteLine($"Birth year: {Reader.Year_of_birth}");
            Console.WriteLine($"id: {Reader.id}");
            Console.WriteLine($"Date: {Reader.date}");
        }

    }
}