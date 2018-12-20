using GenFu.ValueGenerators.Temporal;
using System;

namespace GenFu
{
    public class DateTimeFiller : PropertyFiller<DateTime>
    {
        private Random _random = new Random();

        public DateTime Min { get; set; } = new DateTime(1900, 01, 01);
        public DateTime Max { get; set; } = new DateTime(2020, 12, 31);

        public DateTimeFiller() : this(A.GenFuInstance) { }

        public DateTimeFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {

        }


        public override object GetValue(object instance)
        {
            return GetRandomDate();
        }

        public DateTime GetRandomDate()
        {
            int totalDays = (Max - Min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return Min.AddDays(randomDays).AddSeconds(seconds);
        }
    }

    public class DateTimeOffsetFiller : PropertyFiller<DateTimeOffset>
    {
        private Random _random = new Random();

        public DateTimeOffsetFiller() : this(A.GenFuInstance) { }

        public DateTimeOffsetFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {

        }

        public override object GetValue(object instance)
        {

            return new DateTimeOffset(new DateTimeFiller(GenFu).GetRandomDate());
        }
    }

    public class BirthDateFiller : PropertyFiller<DateTime>
    {
        public BirthDateFiller() : this(A.GenFuInstance) { }

        public BirthDateFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "birthdate", "birth_date" })
        {
        }

        public override object GetValue(object instance)
        {
            return new CalendarDate(GenFu).Date(DateTime.Today.AddYears(-110), DateTime.Today);
        }
    }

    public static class DateTimeFillerExtensions
    {
        /// <summary>
        /// Populate the specified property with a date in the past
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static GenFuConfigurator<T> AsPastDate<T>(this GenFuDateTimeConfigurator<T> configurator)
            where T : new()
        {
            CustomFiller<DateTime> filler = new CustomFiller<DateTime>(configurator.GenFu, configurator.PropertyInfo.Name, typeof(T),
                                                                   () => new CalendarDate(configurator.GenFu).Date(DateRules.PastDate));
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a date in the future
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static GenFuConfigurator<T> AsFutureDate<T>(this GenFuDateTimeConfigurator<T> configurator)
            where T : new()
        {
            CustomFiller<DateTime> filler = new CustomFiller<DateTime>(configurator.GenFu, configurator.PropertyInfo.Name, typeof(T),
                                                                   () => new CalendarDate(configurator.GenFu).Date(DateRules.FutureDates));
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }
}