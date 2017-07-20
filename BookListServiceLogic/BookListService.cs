using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Collection of books
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Method allows to create the instance of storage when it's need
        /// </summary>
        private readonly IStorageFactory _storageFactory;

        public BookListService(IStorageFactory storageFactory = null) => _storageFactory = storageFactory;

        /// <summary>
        /// Method allows to load collection from storage
        /// </summary>
        public void Load()
        {
            if(ReferenceEquals(_storageFactory, null))
                throw new StorageCreateException();
            var storage = _storageFactory.Create();
            storage.LoadBooks(books);
        }

        /// <summary>
        /// Method allows to save collection into the storage
        /// </summary>
        public void Save()
        {
            if(ReferenceEquals(_storageFactory, null))
                throw new StorageCreateException();
            var storage = _storageFactory.Create();
            storage.SaveBooks(books);
        }

        /// <summary>
        /// Method allows to add book into the collection
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if(ReferenceEquals(book, null))
                throw new ArgumentNullException();

            if(books.Contains(book)) 
                throw new ArgumentException();

            books.Add(book);
        }

        /// <summary>
        /// Method allows to remove the book from the collection
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if(!books.Contains(book))
                throw new ArgumentException();

            books.Remove(book);
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
                throw new ArgumentNullException();

            books.Sort(comparer);
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
