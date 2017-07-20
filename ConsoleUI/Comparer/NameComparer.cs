using System;
using System.Collections.Generic;
using BookLogic;

namespace ConsoleUI.Comparer
{
    class NameComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return 0;
            if (ReferenceEquals(rhs, null)) return 1;
            if (ReferenceEquals(lhs, null)) return -1;
            return String.Compare(lhs.Name, rhs.Name, StringComparison.Ordinal);
        }
    }
}
