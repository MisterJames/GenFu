using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core.ValueGenerators.Internet
{
    public class NetworkAddress:BaseValueGenerator
    {
        public string IPAddress()
        {
            return String.Format("{0}.{1}.{2}.{3}", _random.Next(1, 255), _random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
        }

        public string MacAddress()
        {
            //TODO: 00-1C-42-E1-36-F7
            throw new NotImplementedException();
        }

        public string IPv6Address()
        {
            //TODO: fdb2:2c26:f4e4:0:c194:39ee:f3ab:3291
            throw new NotImplementedException();
        }
    }
}
