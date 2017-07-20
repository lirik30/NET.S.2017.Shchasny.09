using System;
using System.IO;
using BookLogic;
using BookListServiceLogic;
using BookListStorageLogic;
using ConsoleUI.Comparer;
using Logging;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: storageFactory class?
            ILog logger = new NLogAdapter();
            try
            {
                var csharp = new Book {Author = "Andrew Troelsen", Name = "C#...", Genre = "IT", Pages = 1312};
                Console.WriteLine(csharp);

                var dotnet = new Book {Author = "John Skit", Name = "C#...", Genre = "IT", Pages = 608};
                Console.WriteLine(dotnet);

                var csharp2 = new Book {Author = "Andrew Troelsen", Name = "C#...", Genre = "IT", Pages = 2012};
                Console.WriteLine(csharp.CompareTo(csharp2, new PagesComparer()));



                var service = new BookListService(new storageFactory());
                var service2 = new BookListService();
                service2.Load();
                service.AddBook(csharp);
                service.AddBook(dotnet);
                service.AddBook(csharp2);
                Console.WriteLine("___________");
                Console.WriteLine();

                service.Save();
                var hahaika = new Book {Author = "petrosyan", Name = "shytki", Genre = "smeh", Pages = 10};
                service.AddBook(hahaika);

                Console.WriteLine(service.FindBookByTag((x) => x.Author == "John Skit") + "-> find");

                Console.WriteLine(service.ToString());
                Console.WriteLine("___________");
                service.Load();
                Console.WriteLine(service.ToString());

                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logger.Info("Unhandled exception");
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                Console.ReadKey();
            }
            catch (ArgumentNullException ex)
            {

                logger.Info("Unhandled exception");
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {

                logger.Info("Unhandled exception");
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                Console.ReadKey();
            }
            catch (FileNotFoundException ex)
            {
                logger.Info("Unhandled exception");
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                Console.ReadKey();
            }
            catch (StorageCreateException ex)
            {
                logger.Info("Unhandled exception");
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                Console.ReadKey();
            }
        }
    }

    class storageFactory : IStorageFactory
    {
        public IStorage Create()
        {
            return new BinaryStorage("library.bin");
        }
    }
}
