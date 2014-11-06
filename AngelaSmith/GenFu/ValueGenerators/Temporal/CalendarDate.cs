using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFu.ValueGenerators.Temporal
{
    public class CalendarDate : BaseValueGenerator
    {

        public static DateTime Date(DateTime earliestDate, DateTime latestDate)
        {
            return DateTimeFill(earliestDate, latestDate);
        }

        public static DateTime Date(DateRules rules)
        {
            // apply rule restrictions
            if (rules == DateRules.Within1Year)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-1);
                Angie.MaxDateTime = DateTime.Now.AddYears(1);
            }

            if (rules == DateRules.Within10Years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-10);
                Angie.MaxDateTime = DateTime.Now.AddYears(10);
            }

            if (rules == DateRules.Within25years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-25);
                Angie.MaxDateTime = DateTime.Now.AddYears(25);
            }

            if (rules == DateRules.Within50Years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-50);
                Angie.MaxDateTime = DateTime.Now.AddYears(50);
            }

            if (rules == DateRules.Within100Years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-100);
                Angie.MaxDateTime = DateTime.Now.AddYears(100);
            }

            if (rules == DateRules.FutureDates)
                Angie.MinDateTime = DateTime.Now;

            if (rules == DateRules.PastDate)
                Angie.MaxDateTime = DateTime.Now;

            return DateTimeFill(Angie.MinDateTime, Angie.MaxDateTime);
        }

        private static DateTime DateTimeFill(DateTime min, DateTime max)
        {
            int totalDays = (max - min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);

            return min.AddDays(randomDays).AddSeconds(seconds);
        }
    }
}
