using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_4
{
    public class Book
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, string publisher,DateTime releaseDate , string isbnNumber, double price)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            IsbnNumber = isbnNumber;
            Price = price;
        }



    }
}
