using System;
using System.Collections.Generic;
using Logging;
using System.Text;
using BookLogic;
using BookListStorageLogic;

namespace BookListServiceLogic
{
    /// <summary>
    /// Class provides us with method for work with collection of books
    /// </summary>
    public class BookListService
    {
        ILog logger = new NLogAdapter();

        /// <summary>
        /// Collection of books
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Method allows to create the instance of storage when it's need
        /// </summary>
        //private readonly IStorageFactory _storageFactory;

        public BookListService(){}// => _storageFactory = storageFactory;

        /// <summary>
        /// Method allows to load collection from storage
        /// </summary>
        public void Load(IStorage storage)
        {
            if(ReferenceEquals(storage, null))
                throw new StorageException("If you want to save or load collection of books, you must to set storage creator");
            storage.LoadBooks(books);
            logger.Info("Collection of books was loaded");
        }

        /// <summary>
        /// Method allows to save collection into the storage
        /// </summary>
        public void Save(IStorage storage)//TODO: Remove Factory and take storage by argument in Save/Load method
        {
            if(ReferenceEquals(storage, null))
                throw new StorageException("You cannot load or save collection without storage. Please, set storage creator");
            storage.SaveBooks(books);
            logger.Info("Collection of books was saved");
        }

        /// <summary>
        /// Method allows to add book into the collection
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if(ReferenceEquals(book, null))
                throw new ArgumentNullException(nameof(book), "Book to add cannot be null");

            if(books.Contains(book)) 
                throw new ArgumentException("This book already exists in the collection", nameof(book));

            books.Add(book);
            logger.Info($"{book} was successfully added in the collection");
        }

        /// <summary>
        /// Method allows to remove the book from the collection
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if(!books.Contains(book))
                throw new ArgumentException("Book not found", nameof(book));

            books.Remove(book);
            logger.Info($"{book} was successfully removed from the collection");
        }

        /// <summary>
        /// Method allows to find the book by tag
        /// </summary>
        /// <param name="predicate">Criterion to finding</param>
        /// <returns>Book if exists, null otherwise</returns>
        public Book FindBookByTag(Predicate<Book> predicate) => books.Find(predicate);

        /// <summary>
        /// Method allows to sort collection by criterion
        /// </summary>
        /// <param name="comparer">Criterion of sorting</param>
        public void SortBookByTag(IComparer<Book> comparer)
        {
            if(ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer), "Comparer cannot be null");

            books.Sort(comparer);
            logger.Info("Collection of the books was sorted");
        }

        /// <summary>
        /// Show elements of the collection of books
        /// </summary>
        public override string ToString()
        {
            var result = new StringBuilder(String.Empty);
            foreach (var book in books)
                result.Append(book + "\n");
            return result.ToString();
        }
    }
}
