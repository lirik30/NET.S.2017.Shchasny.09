using System;
using System.Collections.Generic;
using BookLogic;

namespace BookListStorageLogic
{
    public interface IStorage
    {
        void SaveBooks(List<Book> books);
        void LoadBooks(List<Book> books);
    }
}
