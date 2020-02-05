using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Exercises.Exercise_4
{
    public class Student
    {
        public string Name { get; set; }
        public double [] Grades { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, double[] grades)
        {
            Name = name;
            Grades = grades;
            AverageGrade = grades.Average();
        }
    }
}
