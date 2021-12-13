using System;
using System.Collections.Generic;

namespace PolymorphismDemo
{
    class Book
    {
        public string Title;
        public string Author;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        virtual public void PrintInfo()
        {
            Console.WriteLine($"Book {Title} by {Author}");
        }
    }
    class EBook : Book
    {
        public string Format;

        public EBook(string title, string author, string format) : base(title, author)
        {
            Format = format;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"EBook {Title} by {Author} available for {Format}");
        }
    }
    class Program
    {
        private static void PrintLibrary(string LibraryName, List<Book> library)
        {
            Console.WriteLine(LibraryName);
            foreach (Book next in library)
            {
                next.PrintInfo();
            }
        }
        static void Main(string[] args)
        {
            List<Book> library = new List<Book>();
            Book mybook;
            mybook = new Book("Christmas Carol", "Charles Dickens");
            library.Add(mybook);
            mybook = new EBook("Great Expectations", "Charles Dickens", "Kindle");
            library.Add(mybook);
            mybook = new EBook("The Martian Chronicles", "Ray Bradbury", "Nook");
            library.Add(mybook); 
            PrintLibrary("Cool Library", library);
        }
    }
}
