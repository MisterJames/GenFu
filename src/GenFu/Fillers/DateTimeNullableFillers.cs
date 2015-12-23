using System;

namespace GenFu
{
    public class DateTimeNullableFiller : PropertyFiller<DateTime?>
    {
        private Random _random = new Random();

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }
        public int SeedMin { get; set; }
        public int SeedMax { get; set; }

        public DateTimeNullableFiller()
            : base(new[] { "object" }, new[] { "*" }, true)
        {
        }

        public override object GetValue(object instance)
        {
            var nullSeed = _random.Next(SeedMax);
            if (nullSeed < SeedMin)
            {
                return null;
            }

            int totalDays = (Max - Min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return Min.AddDays(randomDays).AddSeconds(seconds);
        }
    }
}