using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_4
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public Library(List<Book> books)
        {
            Books = books;
        }
    }
}
