using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core.ValueGenerators.Geospatial
{
    public class LatLong:BaseValueGenerator
    {
        public string LatitudeAndLongitude()
        {
            return String.Format("{0},{1}", _random.Next(-180, 180), _random.Next(-180, 180));
        }
    }
}
