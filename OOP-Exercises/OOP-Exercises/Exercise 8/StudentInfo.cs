using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_8
{
    public class StudentInfo
    {
        public string Name { get; set; }
        public string Email  { get; set; }
        public DateTime RegisterDate { get; set; }
        public StudentInfo(string name , string email)
        {
            Name = name;
            Email = email;
        }
    }
}
