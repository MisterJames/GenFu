using System;

namespace GenFu
{
    public class DateTimeNullableFiller : PropertyFiller<DateTime?>
    {
        private Random _random = new Random();

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }
        public double SeedPercentage { get; set; }

        public DateTimeNullableFiller()
            : base(new[] { "object" }, new[] { "*" }, true)
        {
        }

        public override object GetValue(object instance)
        {
            return null;
        }
    }
}