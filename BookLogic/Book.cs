﻿using System;
using System.Collections.Generic;

namespace BookLogic
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        private static int _count;
        private int _id;

        public string Author { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public int Id//bug
        {
            get => _id;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _id = value;
            }
        }

        public Book(string author = null, string name = null, string genre = null)
        {
            //TODO: обрабатывать null аргументы
            Author = author??"NoAuthor";
            Name = name??"NoName";
            Genre = genre??"Unknown";
            _count++;
            Id = _count;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Name == other.Name && //this.Id == other.Id &&
                this.Genre == other.Genre && this.Author == other.Author; 
        }

        
        /// <summary>
        /// Compare 2 books by Id
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns></returns>
        public int CompareTo(Book other) => CompareTo(other, null);

        /// <summary>
        /// Method compares 2 books by comparer. Compare by Id is default
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <param name="comparer">Custom comparer</param>
        /// <returns></returns>
        public int CompareTo(Book other, IComparer<Book> comparer) => ReferenceEquals(comparer, null) ? this.Id - other.Id : comparer.Compare(this, other);

        public override string ToString()
        {
            return $"{Name}. Author: {Author}. Genre: {Genre}. Book id: {Id}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;

            var book = obj as Book;
            return book != null && Equals(book);
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }
}
