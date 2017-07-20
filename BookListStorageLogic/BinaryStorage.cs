using System;
using System.Collections.Generic;
using System.IO;
using BookLogic;
using Logging;

namespace BookListStorageLogic
{
    /// <summary>
    /// Binary file as storage
    /// </summary>
    public class BinaryStorage : IStorage
    {

        ILog logger = new NLogAdapter();

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
                throw new ArgumentNullException(nameof(books), "Collection to save cannot be null");

            Stream stream = File.Open(_path, FileMode.Create, FileAccess.Write);

            using (var binWriter = new BinaryWriter(stream))
            {
                logger.Debug("Save started");
                foreach (var book in books)
                {
                    binWriter.Write(book.Author);
                    binWriter.Write(book.Name);
                    binWriter.Write(book.Genre);
                    binWriter.Write(book.Pages);
                }
                logger.Debug("Save finished");
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
                throw new FileNotFoundException($"File by path {_path} not found");

            Stream stream = File.Open(_path, FileMode.Open, FileAccess.Read);

            using (var binReader = new BinaryReader(stream))
            {
                logger.Debug("Load started");
                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                {
                    var book = new Book()
                    {
                        Author = binReader.ReadString(),
                        Name = binReader.ReadString(),
                        Genre = binReader.ReadString(),
                        Pages = binReader.ReadInt32()
                    };
                    books.Add(book);
                }
                logger.Debug("Load finished");
            }
        }
    }
}
