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
            // Exercise 1 - Get Working days for a period of time
            // Expected Input - 11-04-2016 /r  14-04-2016
            // Expected Output - (Number of days)
            ExerciseOne();

            // Exercise 2 - Intersecting Circles ( True - False )
            // Expected Input - 4 4 2 / r  8 8 1
            // Expected Output - (Yes - No)
            ExerciseTwo();

            // Exercise 3 - Get Average Student Grade - 
            // {Number of Students} /r {Name} {Grade} {Grade}..
            ExerciseThree();
        }

        public static void ExerciseOne()
        {
           
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            ReadDate readDate = new ReadDate();
            DatePeriod datePeriod = new DatePeriod(Read(startDate), Read(endDate));
            Console.WriteLine(datePeriod.CalculateWorkingDays(datePeriod));
        }

        public static void ExerciseTwo()
        {
          
            double[] firstInput = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] secondInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Circle first = new Circle(firstInput[0], firstInput[1], firstInput[2]);
            Circle second = new Circle(secondInput[0], secondInput[1], secondInput[2]);
            string areIntersected = first.AreIntersecting(first, second) ? "Yes" : "No";
            Console.WriteLine(areIntersected);
        }
        public static void ExerciseThree()
        {

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

        //Exercise 4 - Read Students
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
                    allStudents.Add(new Student(name, grades));
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
