namespace GenFu.Fillers;

using System;
using System.Reflection;

public class DateTimeAdapterFiller<T> : DateTimeNullableFiller
{
    DateTimeFiller dateTimeFiller = new DateTimeFiller();
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
                return dateTimeFiller.GetValue(instance);
            }
        }

        return dateTimeFiller.GetValue(instance);
    }
}
