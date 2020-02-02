using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_1
{
    public class DatePeriod
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DatePeriod(DateTime StartDate, DateTime EndDate)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public DateTime[] Holidays(DateTime CurrentYear)
        {
            //Check Year better
            DateTime[] holidays = {
                new DateTime(CurrentYear.Year, 1, 1),
                new DateTime(CurrentYear.Year, 3, 3),
                new DateTime(CurrentYear.Year, 5, 1),
                new DateTime(CurrentYear.Year, 5, 1),
                new DateTime(CurrentYear.Year, 5, 24),
                new DateTime(CurrentYear.Year, 9, 6),
                new DateTime(CurrentYear.Year, 11, 1),
                new DateTime(CurrentYear.Year, 12, 24),
                new DateTime(CurrentYear.Year, 12, 25),
                new DateTime(CurrentYear.Year, 12, 26),
                
            };
            return holidays;
        }

        public int  CalculateWorkingDays(DatePeriod Period)
        {
            //Compare Dates
            int countOfWorkingDays = 0; 
            for (DateTime currentDate = Period.StartDate; currentDate <= Period.EndDate; currentDate = currentDate.AddDays(1))
            {
                bool isWorking = IsWorkingDay(currentDate);
                bool isNotWeekent = 
                    currentDate.DayOfWeek != DayOfWeek.Saturday 
                    && currentDate.DayOfWeek != DayOfWeek.Sunday
                    ? true : false;

                if (isWorking && isNotWeekent)
                {
                    countOfWorkingDays++;
                }


            }
            return countOfWorkingDays;
        }

        public bool IsWorkingDay(DateTime currentDate)
        {
            bool isWorking = true;
            DateTime[] holidays = Holidays(currentDate);
            for (int i = 0; i < holidays.Length; i++)
            {
                if (holidays[i] == currentDate)
                {
                    isWorking = false;
                }
            }
            return isWorking;
        }

    }
}
