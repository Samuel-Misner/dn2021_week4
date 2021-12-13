using System;
using System.Collections.Generic;

namespace InterfaceDemo
{
    interface IRentable
    {
        DateTime? GetDueDate();
        void Rent();
        void Return(DateTime date);
    }
    class LibraryBook : IRentable
    {

        public string Title;
        public string Author;
        public DateTime? DueDate;
        public DateTime LastReturn;

        public DateTime? GetDueDate()
        {
            return DueDate;
        }
        public void Rent()
        {
            DueDate = DateTime.Today.AddMonths(1);
        }
        public void Return(DateTime date)
        {
            LastReturn = date;
            DueDate = null;
        }
        public override string ToString()
        {
            return $"Library Book: Title {Title} by {Author} due on {DueDate}.";
        }
    }
    class DVD : IRentable
    {

        public string Title;
        public string Director;
        public int Duration;
        public bool IsCheckedOut;
        public DateTime? DueBackOn;

        public DateTime? GetDueDate()
        {
            return DueBackOn;
        }
        public void Rent()
        {
            DueBackOn = DateTime.Today.AddDays(21);
            IsCheckedOut = true;
        }
        public void Return(DateTime date)
        {
            IsCheckedOut = false;
        }
        public override string ToString()
        {
            return $"DVD: Title {Title} Directed by {Director} due on {DueBackOn}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> myRentedItems = new List<IRentable>();
            LibraryBook book1 = new LibraryBook();
            book1.Title = "GreatExpectations";
            book1.Author = "Charles Dickens";
            myRentedItems.Add(book1);

            DVD dvd1 = new DVD();
            dvd1.Title = "Star Wars: A New Hope";
            dvd1.Director = "George Lucas";
            dvd1.Duration = 100;
            myRentedItems.Add(dvd1);

            foreach (IRentable rented in myRentedItems)
            {
                //rented.GetDueDate
            }
        }
    }
}
