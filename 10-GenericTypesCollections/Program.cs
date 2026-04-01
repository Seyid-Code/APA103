using System;
using System.Collections.Generic;
class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int PageCount { get; set; }
    public Book(int id, string title, string author, int year, int pageCount)
    {
        Id = id;
        Title = title;
        Author = author;
        Year = year;
        PageCount = pageCount;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"[{Id}] {Title} - {Author} ({Year}) - {PageCount} Sehife");
    }
}
class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public Member(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        BorrowedBooks = new List<Book>();
    }
    public void BorrowBook(Book book)
    {
        if (BorrowedBooks.Count >= 3)
        {
            Console.WriteLine("Maksimum 3 Kitab Goture Bilersiniz!");
            return;
        }
        BorrowedBooks.Add(book);
        Console.WriteLine($"Kitab Goturuldu: {book.Title}");
    }
    public void ReturnBook(int bookId)
    {
        foreach (var book in BorrowedBooks)
        {
            if (book.Id == bookId)
            {
                BorrowedBooks.Remove(book);
                Console.WriteLine($"Kitab Qaytarildi: {book.Title}");
                return;
            }
        }
    }
    public void DisplayBorrowedBooks()
    {
        if (BorrowedBooks.Count == 0)
        {
            Console.WriteLine("Borc Kitab Yoxdur");
            return;
        }

        foreach (var book in BorrowedBooks)
            book.DisplayInfo();
    }
}
class Library<T>
{
    public List<T> Items { get; set; }
    public string Name { get; set; }
    public Library(string name)
    {
        Name = name;
        Items = new List<T>();
    }
    public void Add(T item)
    {
        Items.Add(item);
        Console.WriteLine("Elave Edildi");
    }
    public void Remove(T item)
    {
        Items.Remove(item);
        Console.WriteLine("Silindi");
    }
    public List<T> GetAll() => Items;
    public int Count() => Items.Count;
    public T FindByIndex(int index)
    {
        if (index >= 0 && index < Items.Count)
            return Items[index];

        return default(T);
    }
}
class BookManager
{
    public List<Book> Books { get; set; }
    public Dictionary<string, List<Book>> BooksByAuthor { get; set; }
    public Queue<string> WaitingQueue { get; set; }
    public Stack<Book> RecentlyReturned { get; set; }
    public BookManager()
    {
        Books = new List<Book>();
        BooksByAuthor = new Dictionary<string, List<Book>>();
        WaitingQueue = new Queue<string>();
        RecentlyReturned = new Stack<Book>();
    }
    public void AddBook(Book book)
    {
        Books.Add(book);

        if (!BooksByAuthor.ContainsKey(book.Author))
            BooksByAuthor[book.Author] = new List<Book>();
        BooksByAuthor[book.Author].Add(book);
    }
    public Book SearchByTitle(string title)
    {
        foreach (var b in Books)
            if (b.Title == title) return b;

        return null;
    }
    public List<Book> GetBooksByAuthor(string author)
    {
        if (BooksByAuthor.ContainsKey(author))
            return BooksByAuthor[author];

        return new List<Book>();
    }
    public void AddToWaitingQueue(string name)
    {
        WaitingQueue.Enqueue(name);
        Console.WriteLine($"{name} Novbeye Elave Olundu");
    }
    public string ServeNextInQueue()
    {
        if (WaitingQueue.Count > 0)
            return WaitingQueue.Dequeue();

        return null;
    }
    public void ReturnBook(Book book)
    {
        RecentlyReturned.Push(book);
        Console.WriteLine($"Kitab Qebul Edildi: {book.Title}");
    }
    public Book GetLastReturnedBook()
    {
        if (RecentlyReturned.Count > 0)
            return RecentlyReturned.Peek();

        return null;
    }
}
class Program
{
    static void Main()
    {
        Book b1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
        Book b2 = new Book(2, "1984", "George Orwell", 1949, 328);
        Book b3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
        Book b4 = new Book(4, "Ağ Gemi", "Cingiz Aytmatov", 1970, 200);
        Book b5 = new Book(5, "Qiriq Budaq", "Elcin", 1998, 350);
        b1.DisplayInfo(); b2.DisplayInfo(); b3.DisplayInfo(); b4.DisplayInfo(); b5.DisplayInfo();
        Library<Book> lib = new Library<Book>("Milli Kitabxana");
        lib.Add(b1); lib.Add(b2); lib.Add(b3); lib.Add(b4); lib.Add(b5);
        Console.WriteLine("Say: " + lib.Count());
        lib.FindByIndex(0)?.DisplayInfo();
        lib.FindByIndex(2)?.DisplayInfo();
        foreach (var b in lib.GetAll()) b.DisplayInfo();
        var m = new Member(1, "Ali", "ali@mail.com");
        m.BorrowBook(b1);
        m.BorrowBook(b2);
        m.DisplayBorrowedBooks();
        m.ReturnBook(1);
        m.DisplayBorrowedBooks();
        m.BorrowBook(b3);
        m.BorrowBook(b4);
        m.BorrowBook(b5);
        BookManager manager = new BookManager();
        manager.AddBook(b1); manager.AddBook(b2); manager.AddBook(b3); manager.AddBook(b4); manager.AddBook(b5);
        foreach (var b in manager.GetBooksByAuthor("George Orwell"))
            b.DisplayInfo();
        manager.AddToWaitingQueue("Nigar");
        manager.AddToWaitingQueue("Resad");
        manager.AddToWaitingQueue("Sebine");
        Console.WriteLine("Xidmet Edilir: " + manager.ServeNextInQueue());
        manager.ReturnBook(b1);
        manager.ReturnBook(b2);
        manager.ReturnBook(b3);
        Console.WriteLine(manager.GetLastReturnedBook()?.Title);
        manager.RecentlyReturned.Pop();
        Console.WriteLine(manager.GetLastReturnedBook()?.Title);
        var found = manager.SearchByTitle("1984");
        found?.DisplayInfo();
        if (manager.SearchByTitle("Harry Potter") == null)
            Console.WriteLine("Tapilmadi");
    }
}
