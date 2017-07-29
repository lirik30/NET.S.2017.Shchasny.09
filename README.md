# Book
Класс Book предоставляет все необходимые методы для работы с соответствующими объектами. В частности, реализованы отношения эквивалентности и порядка.
 - bool Equals(Book)
 - bool Equals(Object)
 - int CompareTo(Book)
 - int CompareTo(Book, IComparer<Book>)
 - int CompareTo(Object)
 - string ToString()

# Book service
Этот класс используется для работы с коллекцией книг. Он позволяет не только добавлять\удалять книгу, но и сохранять их в хранилище либо загружать оттуда:
 - void Load(IStorage)
 - void Save(IStorage)
 - void AddBook(Book)
 - void RemoveBook(Book)
 - Book FindBookByTag(Predicate<Book>)
 - void SortBookByTag(IComparer<Book>)
 - string ToString()

Property: 
 - int Count

# Book storage
Предоставляет интерфейс IStorage, содержащий методы:
 - void SaveBooks(List<Book>)
 - void LoadBooks(List<Book>)

### Binary storage
Class realize IStorage interface, using binary file as a repository.

### XML storage
Class realize IStorage interface, using XML-file as a repository.
