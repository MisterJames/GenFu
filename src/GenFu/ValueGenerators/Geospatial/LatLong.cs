namespace GenFu.ValueGenerators.Geospatial;

using System;

public class LatLong : BaseValueGenerator
{
    public static string LatitudeAndLongitude()
    {
        return String.Format("{0},{1}", _random.Next(-180, 180), _random.Next(-180, 180));
    }
}
