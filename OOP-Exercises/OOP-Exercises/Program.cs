using OOP_Exercises.Exercise_1;
using OOP_Exercises.Exercise_3;
using System;
using System.Globalization;
using System.Linq;

namespace OOP_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1 
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            ReadDate readDate = new ReadDate();
            DatePeriod datePeriod = new DatePeriod(readDate.Read(startDate), readDate.Read(endDate));
            Console.WriteLine(datePeriod.CalculateWorkingDays(datePeriod));


            // Exercise 3 
            double[] firstInput = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] secondInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Circle first = new Circle(firstInput[0], firstInput[1], firstInput[2]);
            Circle second = new Circle(secondInput[0], secondInput[1], secondInput[2]);
            string areIntersected = first.AreIntersecting(first, second) ? "Yes" : "No";
            Console.WriteLine(areIntersected);
        }

    }
}
