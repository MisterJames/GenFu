using System;

namespace Angela.Core.Fillers
{
    public class DateTimeFiller : IPropertyFiller
    {
        private Random _random = new Random();

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }

        public string[] PropertyNames { get { return new[] { "*" }; } }
        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(DateTime); } }
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
        public static AngieDateTimeConfigurator<T> AsPastDate<T>(this AngieDateTimeConfigurator<T> configurator)
            where T : new()
        {
            CustomFiller<DateTime> filler = new CustomFiller<DateTime>(configurator.PropertyInfo.Name, typeof (T),
                                                                   () => Jen.Date(DateRules.PastDate));
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }
}