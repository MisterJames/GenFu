using System;

namespace GenFu
{
    public class DateTimeNullableFiller : PropertyFiller<DateTime?>
    {
        private Random _random = new Random();

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }
        public double SeedPercentage { get; set; } = 1;

        public DateTimeNullableFiller() : this(A.GenFuInstance) { }

        public DateTimeNullableFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
        }

        public override object GetValue(object instance)
        {
            int totalDays = (Max - Min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return Min.AddDays(randomDays).AddSeconds(seconds);
        }
    }
}