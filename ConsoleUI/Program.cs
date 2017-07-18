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
            var csharp = new Book("Andrew Troelsen", "C#...", "IT");
            Console.WriteLine(csharp);

            var dotnet = new Book("John Skit", "C#...", "IT");
            Console.WriteLine(dotnet);

            var csharp2 = new Book("Andrew Troelsen", "C#...", "IT");
            
            Console.WriteLine(csharp.CompareTo(csharp2, new AuthorComparer()));

            //Console.ReadKey();


            BookListService service = new BookListService(new storageFac());
            service.AddBook(csharp);
            service.AddBook(dotnet);
            service.AddBook(csharp2);
            Console.WriteLine("___________");
            //Console.WriteLine(service.FindBookById(1));
            //Console.WriteLine(service.FindBookByTag("Andrew Troelsen", SearchTag.ByAuthor));
            service.Print();
            //Console.WriteLine("___________");
            //service.RemoveBook(dotnet);
            //service.Print();

            Console.WriteLine("___________");
            service.SortBookByTag(new AuthorComparer());
            service.Print();

            Console.ReadKey();
        }
    }

    class storageFac : IStorageFactory
    {
        public IStorage Create()
        {
            return new storage();
        }
    }

    class storage : IStorage
    {
        public void SaveBooks(List<Book> books)
        {
            throw new NotImplementedException();
        }

        public void LoadBooks(List<Book> books)
        {
            throw new NotImplementedException();
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
