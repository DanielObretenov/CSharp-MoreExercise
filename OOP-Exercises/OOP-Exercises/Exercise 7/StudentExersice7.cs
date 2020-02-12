using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_7
{
    public class StudentExersice7
    {

        public string Name { get; set; }
        public List<DateTime> AttendaceDates { get; set; }
        public string Comments { get; set; }
        public StudentExersice7(string name, List<DateTime> attendaceDates)
        {
            Name = name;
            AttendaceDates = attendaceDates;
        }




    }
}
