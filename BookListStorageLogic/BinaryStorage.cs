using System;
using System.Collections.Generic;
using System.IO;
using BookLogic;

namespace BookListStorageLogic
{
    /// <summary>
    /// Binary file as storage
    /// </summary>
    public class BinaryStorage : IStorage
    {
        /// <summary>
        /// File path
        /// </summary>
        private string _path = "library.bin";

        public BinaryStorage(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Save collection of books into the binary file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(List<Book> books)
        {
            if(ReferenceEquals(books, null)) 
                throw new ArgumentNullException();

            Stream stream = File.Open(_path, FileMode.Create, FileAccess.Write);

            using (var binWriter = new BinaryWriter(stream))
            {
                Console.WriteLine("Save start!");
                foreach (var book in books)
                {
                    binWriter.Write(book.Author);
                    binWriter.Write(book.Name);
                    binWriter.Write(book.Genre);
                    binWriter.Write(book.Id);
                }
            }
            
            
        }


        /// <summary>
        /// Load collection of books from binary file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void LoadBooks(List<Book> books)
        {
            books.Clear();

            if(!File.Exists(_path))
                throw new FileNotFoundException();

            Stream stream = File.Open(_path, FileMode.Open, FileAccess.Read);

            using (var binReader = new BinaryReader(stream))
            {
                Console.WriteLine("Load start!");
                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                {
                    var book = new Book();
                    book.Author = binReader.ReadString();
                    book.Name = binReader.ReadString();
                    book.Genre = binReader.ReadString();
                    book.Id = binReader.ReadInt32();

                    books.Add(book);
                }
            }
        }
    }
}
