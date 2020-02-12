using OOP_Exercises.Exercise_1;
using OOP_Exercises.Exercise_3;
using OOP_Exercises.Exercise_4;
using OOP_Exercises.Exercise_6;
using OOP_Exercises.Exercise_7;
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

            //ExerciseOne();
            //ExerciseTwo();
            //ExerciseThree();
            //ExrciseFour();
            //ExerciseFive();
            //ExerciseSix();
            ExerciseSeven();
        }

        public static Dictionary<string, StudentExersice7> GetAttendancyForStudents()
        {
            string input = Console.ReadLine();
            Dictionary<string, StudentExersice7> allStudents = new Dictionary<string, StudentExersice7>();
            while (input.ToLower() != "end of dates")
            {
                List<DateTime> attendancy = new List<DateTime>();
                string[] inputArray = input.Split(new char[] { ',', ' ' });
                string name = inputArray[0];
                if (allStudents.ContainsKey(name))
                {
                    for (int i = 1; i < inputArray.Length; i++)
                    {
                        DateTime date = DateTime.ParseExact(inputArray[i], "dd/MM/yyyy", null);
                        allStudents[name].AttendaceDates.Add(date);
                        attendancy.Add(date);
                    }
                    
                }
                else
                {
                    for (int i = 1; i < inputArray.Length; i++)
                    {
                        DateTime date = DateTime.ParseExact(inputArray[i], "dd/MM/yyyy", null);
                        attendancy.Add(date);
                    }
                    StudentExersice7 student7 = new StudentExersice7(name, attendancy);
                    allStudents.Add(name, student7);
                    input = Console.ReadLine();
                }
       

              
            }
            AddComments(allStudents);
            return allStudents;
        }
        public static void ExerciseSeven()
        {
            //expected input:
/*
nakov 22/08/2016,20/08/2016
simeon10 22/08/2016
end of dates
nakov-Excellent algorithmetic thinking.
Gesh4o-Total noob.
end of comments
*/
            Dictionary<string, StudentExersice7> studentExersice7 = GetAttendancyForStudents();

            Console.WriteLine();
            foreach (var student in studentExersice7.Values)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine("Comments:");
                if (student.Comments != null)
                {
                    Console.WriteLine($"-{student.Comments}");
                }
                Console.WriteLine("Dates attended:");
                student.AttendaceDates.ForEach(date => Console.WriteLine(date.ToShortDateString()));
                Console.WriteLine();
            }
        }





        public static void AddComments(Dictionary<string, StudentExersice7> students)
        {
            string input = Console.ReadLine();
            while (input.ToLower() != "end of comments")
            {
                string[] inputArray = input.Split("-");
                string name = inputArray[0];
                string comment = inputArray[1];
                if (students.ContainsKey(name))
                {
                    students[name].Comments = comment;
                }
                input = Console.ReadLine();
            }
        }


        public static Dictionary<string, decimal>  AddProducts()
        {
            int numberOfPoducts = int.Parse(Console.ReadLine());

            int counter = 1;
            Dictionary<string, decimal> products = new Dictionary<string, decimal>();

            while (numberOfPoducts >= counter)
            {
                string[] input = Console.ReadLine().Split("-");
                string product = input[0];
                decimal price = decimal.Parse(input[1]);
                if (products.ContainsKey(product))
                {
                    products[product] = price;
                }
                else
                {
                    products.Add(product, price);
                }
                counter++;
            }
            return products;
        }

        public static Dictionary<string,Customer> Customer(Dictionary<string, decimal> allProducts)
        {
            Dictionary<string, Customer> customersList = new Dictionary<string, Customer>();
            string[] customerOrders = Console.ReadLine().Split(new char[] { '-', ',' });

            while (customerOrders[0] != "end of clients")
            {
                string name = customerOrders[0];
                string product = customerOrders[1];
                int quantity = int.Parse(customerOrders[2]);
                if (IsValidProduct(allProducts, product))
                {
                    if (customersList.ContainsKey(name))
                    {
                        if (customersList[name].ShopList.ContainsKey(product))
                        {
                            customersList[name].ShopList[product] += quantity;
                        }
                        else
                        {
                            customersList[name].ShopList.Add(product, quantity);
                        }
                    }
                    else
                    {
                        Customer customer = new Customer(name);
                        Dictionary<string, int> customerShopList = new Dictionary<string, int>
                        {
                            { product, quantity }
                        };
                        customer.ShopList = customerShopList;
                        customersList.Add(name, customer);
                    }
                }
                customerOrders = Console.ReadLine().Split(new char[] { '-', ',' });
            }
            return customersList;
        }
        public static void ExerciseSix()
        {
            // Get Bill
            //Example Input:
/*       
4
Cola-1.25
Sandwich-2.30
Bira-0.01
Bira-2
Toshko-Bira,3
Mira-Sandwich,1
Marto-Kola,2
end of clients
 */
            Dictionary<string, decimal> allProducts = AddProducts();
            Dictionary<string, Customer> customerList = Customer(allProducts);

            Console.WriteLine();
            decimal TotalBill = 0;
            foreach (var customer in customerList.Values)
            {
                Console.WriteLine("Customer Name: " + customer.Name);
                foreach (var productName in customer.ShopList.Keys)
                {
                    Console.WriteLine($"--product: {productName} - quantity: {customer.ShopList[productName]} ");
                }
                Console.WriteLine($"Customer Bill: {customer.Bill(allProducts)} dollars");
                TotalBill += customer.Bill(allProducts);
                Console.WriteLine();
            }
            Console.WriteLine($"Total Bill: {TotalBill:f2}");
        }

        public static bool IsValidProduct(Dictionary<string, decimal> allProducts, string product )
        {
            bool validProduct = false;
            if (allProducts.ContainsKey(product))
            {
                validProduct= true;
            }
            return validProduct;
        }
        public static Library GetLibrary()
        {
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

            return library;
        }
 
        public static void ExrciseFour()
        {

            // Expected Input: Copy the text below
/*
5
LOTR Tolkien GeorgeAllen 29.07.1954 0395082999 30.00
Hobbit Tolkien GeorgeAll 21.09.1937 0395082888 10.25
HP1 JKRowling Bloomsbury 26.06.1997 0395082777 15.50
HP7 JKRowling Bloomsbury 21.07.2007 0395082666 20.00
AC OBowden PenguinBooks 20.11.2009 0395082555 14.00
*/
            Library library = GetLibrary();
            var authors = library.Books.Select(x => x.Author).Distinct().ToList();

            foreach (var author in authors)
            {
                double priceTotal = library.Books.Where(x => x.Author == author).Sum(x => x.Price);
                Console.WriteLine($"{author} -> {priceTotal:f2}");
            }
        }
        public static void ExerciseFive()
        {
            //expected input:
/*
5
LOTR Tolkien GeorgeAllen 29.07.1954 0395082999 30.00
Hobbit Tolkien GeorgeAll 21.09.1937 0395082888 10.25
HP1 JKRowling Bloomsbury 26.06.1997 0395082777 15.50
HP7 JKRowling Bloomsbury 21.07.2007 0395082666 20.00
AC OBowden PenguinBooks 20.11.2009 0395082555 14.00
30.07.1954
*/

            Library library = GetLibrary();
            DateTime releaseDateAfter = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy",null);
            List<Book> books = library.Books.Where(date => date.ReleaseDate >= releaseDateAfter).ToList();
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{books[i].Title} -> {books[i].ReleaseDate.ToShortDateString()}");
            }
           
        }

        public static void ExerciseOne()
        {
            // Exercise 1 - Get Working days for a period of time
            //Expected Input - Copy dates below
/*
11-04-2016
14-04-2016
*/

            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            DatePeriod datePeriod = new DatePeriod(Read(startDate), Read(endDate));
            Console.WriteLine(datePeriod.CalculateWorkingDays(datePeriod));
        }

        public static void ExerciseTwo()
        {
            // Exercise 2 - Intersecting Circles ( True - False )
            // Expected Input -
/*
4 4 2 
8 8 1
*/
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
            // Expected Input: Copy below

/*
6
Petar 3 5 4 3 2 5 6 2 6
Mitko 6 6 5 6 5 6
Gosho 6 6 6 6 6 6
Ani 6 5 6 5 6 5 6 5
Iva 4 5 4 3 4 5 2 2 4
Ani 5.50 5.25 6.00
*/
            int numberStudents = int.Parse(Console.ReadLine());
            List<Student> allStudents = ReadStudent(numberStudents);
            allStudents.ForEach(
                student => Console.WriteLine($"{student.Name} -> {Math.Round(student.AverageGrade, 2):f2}"));
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
