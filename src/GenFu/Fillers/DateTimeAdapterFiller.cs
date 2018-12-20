using System;
using System.Reflection;

namespace GenFu.Fillers
{
    public class DateTimeAdapterFiller<T> : DateTimeNullableFiller
    {
        public DateTimeAdapterFiller(GenFuInstance genFu) : base(genFu)
        {

        }

        DateTimeFiller _dateTimeFiller = null;
        DateTimeFiller DateTimeFiller
        {
            get
            {
                _dateTimeFiller = _dateTimeFiller ?? new DateTimeFiller(this.GenFu);
                return _dateTimeFiller;
            }
        }
        private Random rand = new Random();

        public override object GetValue(object instance)
        {
            if (typeof(T).GetTypeInfo().IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (this.SeedPercentage < rand.NextDouble())
                {
                    //eturn null;
                }
                else
                {
                    return DateTimeFiller.GetValue(instance);
                }
            }

            return DateTimeFiller.GetValue(instance);
        }
    }
}
