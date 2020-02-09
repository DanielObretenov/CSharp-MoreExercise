using OOP_Exercises.Exercise_1;
using OOP_Exercises.Exercise_3;
using OOP_Exercises.Exercise_4;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OOP_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            ExerciseOne();
            ExerciseTwo();
            ExerciseThree();
            ExerciseFour();
        }

        public static void ExerciseFour()
        {
            // Exercise 4 - Get price for books
            // Expected Input - {nubmer of books} /rn {title} {author} {publisher} {release date} {ISBN} {price}.
            // Expected Output - (Book total price by autor)

            int numberOfBooks = int.Parse(Console.ReadLine());
            int count = 1;
            List<Book> books = new List<Book>();
            while (numberOfBooks >= count)
            {
                string[] input = Console.ReadLine().Split(" ");
                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                string inputDate = input[3];
                DateTime releaseDate = DateTime.ParseExact(inputDate, "dd.MM.yyyy", null);
                string isbnNumber = input[4];
                double price = double.Parse(input[5], CultureInfo.InvariantCulture);
                Book book = new Book(title, author, publisher, releaseDate, isbnNumber, price);
                books.Add(book);
                count++;
            }
            Library library = new Library(books);
            var authors = books.Select(x => x.Author).Distinct().ToList();

            foreach (var author in authors)
            {
                double priceTotal = library.Books.Where(x => x.Author == author).Sum(x => x.Price);
                Console.WriteLine($"{author} -> {priceTotal:f2}");
            }

        }
 


        public static void ExerciseOne()
        {
            // Exercise 1 - Get Working days for a period of time
            // Expected Input - 11-04-2016 /r  14-04-2016
            // Expected Output - (Number of days)
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            DatePeriod datePeriod = new DatePeriod(Read(startDate), Read(endDate));
            Console.WriteLine(datePeriod.CalculateWorkingDays(datePeriod));
        }

        public static void ExerciseTwo()
        {
            // Exercise 2 - Intersecting Circles ( True - False )
            // Expected Input - 4 4 2 / r  8 8 1
            // Expected Output - (Yes - No)
            double[] firstInput = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] secondInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Circle first = new Circle(firstInput[0], firstInput[1], firstInput[2]);
            Circle second = new Circle(secondInput[0], secondInput[1], secondInput[2]);
            string areIntersected = first.AreIntersecting(first, second) ? "Yes" : "No";
            Console.WriteLine(areIntersected);
        }
        public static void ExerciseThree()
        {
            // Exercise 3 - Get Average Student Grade - 
            // {Number of Students} /r {Name} {Grade} {Grade}..
            int numberStudents = int.Parse(Console.ReadLine());
            List<Student> allStudents = ReadStudent(numberStudents);
            allStudents.ForEach(
                student => Console.WriteLine($"{student.Name} -> {Math.Round(student.AverageGrade, 2)}"));
        }

        //Exercise 1 - Read Date
        public static DateTime Read(string date)
        {
            string format = "dd-MM-yyyy";
            DateTime dateTime = DateTime.ParseExact(date, format,
                                           CultureInfo.InvariantCulture);
            return dateTime;
        }

        //Exercise 3 - Read Students
        public static List<Student> ReadStudent(int numberStudents)
        {

            List<Student> allStudents = new List<Student>();

            int count = 1;

            while (count <= numberStudents)
            {
                string[] input = Console.ReadLine().Split(" ");
                string name = input[0];
                double[] grades = input.Select(s => double.Parse(s)).Skip(1).ToArray();
                bool allGradesAreCorrect = grades.All(e => (e >= 2 && e <= 6));
                if (allGradesAreCorrect)
                {
                    Student student = new Student(name, grades);
                    allStudents.Add(student);
                }
                else
                {
                    Console.WriteLine($"Please enter valid grade in order to get average grades for {input[0]} ");
                }
                count++;
            }
            return allStudents;
        }
    }

}
