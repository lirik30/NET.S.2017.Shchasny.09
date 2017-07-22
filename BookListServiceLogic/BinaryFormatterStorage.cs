using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BookListStorageLogic;
using BookLogic;
using Logging;

namespace BookListServiceLogic
{
    public class BinaryFormatterStorage : IStorage
    {
        /// <summary>
        /// File path
        /// </summary>
        private readonly string _path;
        
        private readonly ILog _logger;

        /// <summary>
        /// Create new storage with using binary formatter
        /// </summary>
        /// <param name="path">Binary file path</param>
        public BinaryFormatterStorage(string path) : this(path, new NLogAdapter()) { }

        /// <summary>
        /// Create new storage with using binary formatter
        /// </summary>
        /// <param name="path">Binary file path</param>
        /// <param name="logger">Used logger. NLog logger is default</param>
        public BinaryFormatterStorage(string path, ILog logger)
        {
            _path = path ?? "library.bin";
            _logger = logger ?? new NLogAdapter();
        }


        /// <summary>
        /// Save collection of books into the binary file by using binary formatter
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(List<Book> books)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = File.Open(_path, FileMode.Create, FileAccess.Write))
            {
                _logger.Debug("Save with binary formatter started");
                formatter.Serialize(stream, books);

                _logger.Debug("Save with binary formatter finished");
            }
        }


        /// <summary>
        /// Load collection of books from binary file by using binary formatter
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void LoadBooks(List<Book> books)
        {
            books.Clear();
            IFormatter formatter = new BinaryFormatter();
            if(!File.Exists(_path))
                throw new FileNotFoundException($"File by path {_path} not found");

            using (Stream stream = File.Open(_path, FileMode.Open, FileAccess.Read))
            {
                _logger.Debug("Load with binary formatter started");
                books.AddRange((List<Book>) formatter.Deserialize(stream));
                _logger.Debug("Load with binary formatter finished");
            }
        }
    }
}
