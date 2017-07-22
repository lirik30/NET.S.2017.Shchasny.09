using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using BookListStorageLogic;
using BookLogic;
using Logging;

namespace BookListServiceLogic
{
    public class XMLStorage : IStorage
    {
        /// <summary>
        /// File path
        /// </summary>
        private readonly string _path;

        private readonly ILog _logger;

        /// <summary>
        /// Create new storage with using XML file
        /// </summary>
        /// <param name="path">Binary file path</param>
        public XMLStorage(string path) : this(path, new NLogAdapter()) { }

        /// <summary>
        /// Create new storage with using XML File
        /// </summary>
        /// <param name="path">Binary file path</param>
        /// <param name="logger">Used logger. NLog logger is default</param>
        public XMLStorage(string path, ILog logger)
        {
            if(ReferenceEquals(path, null))
                throw new ArgumentNullException(nameof(path), "File path must be not null");
            var correctName = new Regex(@"\w+\.(?:xml)$");
            if(!correctName.IsMatch(path))
                throw new ArgumentException("File must be xml compatible");

            _path = path;
            _logger = logger ?? new NLogAdapter();
        }


        /// <summary>
        /// Save collection of books into the XML file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(List<Book> books)
        {
            var formatter = new XmlSerializer(typeof(List<Book>));

            using (Stream stream = File.Open(_path, FileMode.Create, FileAccess.Write))
            {
                _logger.Debug("Save in XML file started");
                formatter.Serialize(stream, books);

                _logger.Debug("Save in XML file finished");
            }
        }


        /// <summary>
        /// Load collection of books from XML file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void LoadBooks(List<Book> books)
        {
            books.Clear();
            var formatter = new XmlSerializer(typeof(List<Book>));
            if (!File.Exists(_path))
                throw new FileNotFoundException($"File by path {_path} not found");

            using (Stream stream = File.Open(_path, FileMode.Open, FileAccess.Read))
            {
                _logger.Debug("Load from XML file started");
                books.AddRange((List<Book>)formatter.Deserialize(stream));
                _logger.Debug("Load from XML file finished");
            }
        }
    }
}
