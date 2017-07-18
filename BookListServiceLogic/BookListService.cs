using System;
using System.Collections.Generic;
using BookLogic;
using BookListStorageLogic;

namespace BookListServiceLogic
{
    /// <summary>
    /// Tags for finding the element
    /// </summary>
    public enum SearchTag
    {
        ByAuthor,
        ByName,
        ByGenre
    }

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
        private readonly IStorageFactory storageFactory;

        public BookListService(IStorageFactory storageFactory)
        {
            this.storageFactory = storageFactory;
        }

        /// <summary>
        /// Method allows to load collection from storage
        /// </summary>
        public void Load()
        {
            var storage = storageFactory.Create();
            storage.LoadBooks(books);
        }

        /// <summary>
        /// Method allows to save collection into the storage
        /// </summary>
        public void Save()
        {
            var storage = storageFactory.Create();
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

            if(FindBookById(book.Id) != null) 
                throw new ArgumentException();//TODO: need to throw custom exception

            books.Add(book);
        }

        /// <summary>
        /// Method allows to remove the book from the collection
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if(FindBookById(book.Id) == null)
                throw new ArgumentException();//TODO: need to throw custom exception

            books.Remove(book);
        }

        /// <summary>
        /// Method allows to find the book by id
        /// </summary>
        /// <param name="id">Expected id</param>
        /// <returns>Book if exists, null otherwise</returns>
        public Book FindBookById(int id)
        {
            foreach (var book in books)
                if (book.Id == id) return book;
            return null;
        }

        /// <summary>
        /// Method allows to find the book by tag
        /// </summary>
        /// <param name="criterion">Criterion string(author, name or genre)</param>
        /// <param name="tag">Tag for finding</param>
        /// <returns>Book if exists, null otherwise</returns>
        //TODO: add possibility to use interface or something other
        public Book FindBookByTag(string criterion, SearchTag tag)//maybe return set of books?
        {
            foreach (var book in books)
            {
                switch (tag)
                {
                    case SearchTag.ByAuthor:
                        if (book.Author == criterion)
                            return book;
                        continue;
                    case SearchTag.ByName:
                        if (book.Author == criterion)
                            return book;
                        continue;
                    case SearchTag.ByGenre:
                        if (book.Genre == criterion)
                            return book;
                        continue;
                }
            }
            return null;
        }

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
        /// Print collection on the console
        /// </summary>
        public void Print()
        {
            foreach (var book in books)
                Console.WriteLine(book);
        }

    }
}
