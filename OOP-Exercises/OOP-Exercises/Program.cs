using OOP_Exercises.Exercise_1;
using OOP_Exercises.Exercise_3;
using OOP_Exercises.Exercise_4;
using OOP_Exercises.Exercise_6;
using OOP_Exercises.Exercise_7;
using OOP_Exercises.Exercise_8;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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
            //ExerciseSeven();
            ExerciseEight();
        }

        public static List<Town> GetTowns()
        {
            List<Town> towns = new List<Town>();

            string input = Console.ReadLine();
            while (input.ToLower() != "end")
            {

                string townRegex = @"([a-zA-Z ]*)=>\s+(\d{1,4}) seats";
                string studentRegex = @"(^[a-zA-Z0-9_ ]*)\|([a-zA-Z0-9_ .]*@[a-zA-Z.]*.[a-zA-Z ]*)\|([\s]*\d{1,2}-[a-zA-Z]{3}-\d{4})";

                Regex townExpression = new Regex(townRegex);
                Regex studentExpression =  new Regex(studentRegex);

                Town currentTown = new Town();

                if (townExpression.IsMatch(input))
                {

                    Match m = townExpression.Match(input);
                    string town = m.Groups[1].ToString().Trim();
                    bool isValidCount = int.TryParse(m.Groups[2].ToString(), out int seatCount);
                    currentTown = new Town
                    {
                        Name = town,
                        SeatCount = seatCount,
                        Students = new List<StudentInfo>()
                    };
                    towns.Add(currentTown);


                }
                else if (studentExpression.IsMatch(input))
                {
                    Match m = studentExpression.Match(input);
                    string name = m.Groups[1].ToString().Trim();
                    string email = m.Groups[2].ToString().Trim();
                    string[] formats = new string[] { "d-MMM-yyyy", "dd-MMM-yyyy" };
                    DateTime registerDate = DateTime.ParseExact(m.Groups[3].ToString().Trim(), formats, null);
                    StudentInfo studentInfo = new StudentInfo(name, email)
                    {
                        RegisterDate = registerDate
                    };
                    
                    towns[towns.Count - 1].Students.Add(studentInfo);

                }
                input = Console.ReadLine();

            }
            return towns;
        }

        public static void ExerciseEight()
        {
            //Valid Input: 
/*
Plovdiv => 5 seats
Ani Kirilova   |ani88@abv.bg             |27-May-2016
Todor Nikolov  | tod92@mente.org         | 28-May-2016
Kiril Stoyanov |  kirtak@gmail.com       | 27-May-2016
Stefka Petrova |   st96@abv.bg           | 26-May-2016
Ani Kirilova   |     ani.k@yahoo.co.uk   | 27-May-2016
Ivan Ivanov    |  ivan.i.ivanov@gmail.com| 27-May-2016
Veliko Tarnovo => 3 seats
Petya Stoyanova | stoyanova_p@abv.bg    | 27-May-2016
Stoyan Kirilov  | 100yan@gmail.com      | 24-May-2016
Didi Miteva     | miteva_d@yahoo.co.uk  | 28-May-2016
Kiril Nikolov   | kiro@kiro.net         | 25-May-2016
Ivan Stefanov   | ivan.stef86@gmail.com | 27-May-2016
Maria Kirova    | maria.k@abv.bg        | 26-May-2016
Varna => 2 seats
Ivan Ivanov      | ivan.ivanov96@gmail.com| 29-May-2016
Stoyan Petrov    | sto.sto.sto@gmail.com  | 27-May-2016
Ivan Ivanov      | vankata@mail.bg        | 1-Jun-2016
Kiril Anev       | anev_k@yahoo.co.uk     | 27-May-2016
Ivan Ivanov      | vanyo98@abv.bg         | 29-May-2016
Petya Vladimirova|pete98@abv.bg           | 20-May-2016
Ivan Ivanov      | ivan.94.ivan@gmail.com | 29-May-2016
End
*/
            List<Town> towns = GetTowns();
            List<GroupOfStudents> groups = Groups(towns);
            Console.WriteLine();
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
            foreach (var group in groups.OrderBy(x => x.Town.Name))
            {
                string allStudentsPerGroup = string.Join(" ,",
                group.Students.Select(x => x.Email.ToString()));
                Console.Write($"{group.Town.Name} => {allStudentsPerGroup}");
                Console.WriteLine();
            }

            //Created 8 groups in 3 towns:
            //Plovdiv => st96@abv.bg, ani.k @yahoo.co.uk, ani88 @abv.bg, ivan.i.ivanov @gmail.com, kirtak @gmail.com

        }
        public static List<GroupOfStudents> Groups(List<Town> towns)
        {
            List<GroupOfStudents> groups = new List<GroupOfStudents>();
            foreach (var town in towns)
            {
                List<StudentInfo> studentInTown = town.Students.
                    OrderBy(x => x.RegisterDate).ThenBy(x=>x.Name).ThenBy(x=>x.Email).ToList();
                
                while(studentInTown.Any())
                {
                    List<StudentInfo> studentGroup = studentInTown.Take(town.SeatCount).ToList();
                    studentInTown = studentInTown.Skip(town.SeatCount).ToList();
                    GroupOfStudents group = new GroupOfStudents
                    {
                        Town = town,
                        Students = studentGroup
                    };
                    groups.Add(group);
                }

            }
            return groups;
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
