using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OOP_Exercises.Exercise_1
{
    public  class ReadDate
    {

        public DateTime Read(string date)
        {
            string format = "dd-MM-yyyy";
            DateTime dateTime = DateTime.ParseExact(date, format,
                                           CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}
