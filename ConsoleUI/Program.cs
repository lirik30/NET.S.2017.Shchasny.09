using System;
using System.Collections.Generic;
using BookLogic;
using BookListServiceLogic;
using BookListStorageLogic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: comparer classes, storageFactory class

            var csharp = new Book("Andrew Troelsen", "C#...", "IT");
            Console.WriteLine(csharp);

            var dotnet = new Book("John Skit", "C#...", "IT");
            Console.WriteLine(dotnet);

            var csharp2 = new Book("Andrew Troelsen", "C#...", "IT");
            
            Console.WriteLine(csharp.CompareTo(csharp2, new AuthorComparer()));
            


            var service = new BookListService(new storageFactory());
            service.AddBook(csharp);
            service.AddBook(dotnet);
            service.AddBook(csharp2);
            Console.WriteLine("___________");
            Console.WriteLine();

            service.Save();
            var hahaika = new Book("petrosyan", "shytki", "smeh");
            service.AddBook(hahaika);
            service.Print();
            Console.WriteLine("___________");
            service.Load();
            service.Print();

            Console.ReadKey();
        }
    }

    class storageFactory : IStorageFactory
    {
        public IStorage Create()
        {
            return new BinaryStorage("library.bin");
        }
    }
    
    class AuthorComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            return String.Compare(lhs.Author, rhs.Author, StringComparison.Ordinal);
        }
    }
}
