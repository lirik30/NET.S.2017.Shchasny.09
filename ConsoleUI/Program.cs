using System;
using BookLogic;

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

            Console.ReadKey();
        }
    }

    class AuthorComparer : IComparer
    {
        public int Compare(Book lhs, Book rhs)
        {
            return String.Compare(lhs.Author, rhs.Author, StringComparison.Ordinal);
        }
    }
}
