using OOP_Exercises.Exercise_1;
using System;
using System.Globalization;

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

            //Exercise 2


            // Exercise 3 



        }
        
    }
}
