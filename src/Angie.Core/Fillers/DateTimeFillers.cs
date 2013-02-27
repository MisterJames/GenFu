using System;

namespace Angela.Core
{
    public class DateTimeFiller : IPropertyFiller
    {
        private Random _random = new Random();

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }

        public string[] PropertyNames { get { return new[] { "*" }; } }

        public string[] ObjectTypeNames { get { return new[] { "object" }; } }

        public Type PropertyType { get { return typeof(DateTime); } }
        public bool IsGenericFiller { get { return true; } }

        public object GetValue()
        {
            int totalDays = (Max - Min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return Min.AddDays(randomDays).AddSeconds(seconds);
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
        public static AngieConfigurator<T> AsPastDate<T>(this AngieDateTimeConfigurator<T> configurator)
            where T : new()
        {
            CustomFiller<DateTime> filler = new CustomFiller<DateTime>(configurator.PropertyInfo.Name, typeof (T),
                                                                   () => Jen.Date(DateRules.PastDate));
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        /// <summary>
        /// Populate the specified property with a date in the future
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="configurator"></param>
        /// <returns>A configurator for the specified object type</returns>
        public static AngieConfigurator<T> AsFutureDate<T>(this AngieDateTimeConfigurator<T> configurator)
            where T: new ()
        {
            CustomFiller<DateTime> filler = new CustomFiller<DateTime>(configurator.PropertyInfo.Name, typeof(T),
                                                                   () => Jen.Date(DateRules.FutureDates));
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }
}