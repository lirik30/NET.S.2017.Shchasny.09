using System;
using System.Collections.Generic;
using BookLogic;
using BookListStorageLogic;

namespace BookListServiceLogic
{

    public enum SearchTag
    {
        ByAuthor,
        ByName,
        ByGenre
    }

    public class BookListService
    {
        private List<Book> books = new List<Book>();
        private readonly IStorageFactory storageFactory;

        public BookListService(IStorageFactory storageFactory)
        {
            this.storageFactory = storageFactory;

            Load();
        }

        //private?
        private void Load()
        {
            var storage = storageFactory.Create();
            //TODO
        }

        public void Save()
        {
            var storage = storageFactory.Create();
            //TODO
        }

        public void AddBook(Book book)//
        {
            if(ReferenceEquals(book, null))
                throw new ArgumentNullException();

            if(FindBookById(book.Id) != null) 
                throw new ArgumentException();//TODO: need to throw custom exception

            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if(FindBookById(book.Id) == null)
                throw new ArgumentException();//TODO: need to throw custom exception

            books.Remove(book);
        }


        public Book FindBookById(int id)
        {
            foreach (var book in books)
                if (book.Id == id) return book;
            return null;
        }

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


        public void SortBookByTag(IComparer<Book> comparer)
        {
            if(ReferenceEquals(comparer, null))
                throw new ArgumentNullException();

            books.Sort(comparer);
        }

        public void Print()
        {
            foreach (var book in books)
                Console.WriteLine(book);
        }

    }
}
