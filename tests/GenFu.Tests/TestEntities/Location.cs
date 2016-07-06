using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace GenFu.Tests
{
    class Location
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            // this will be fleshed out as properties are added
            result.AppendLine(Address);
            result.Append(string.IsNullOrEmpty(Address2) ? string.Empty : string.Format("{0}\n", Address2));
            result.AppendFormat("{0}, {1}\n", City, State);

            return result.ToString();
        }
    }

    class AmericanLocation
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    class CanadianLocation
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    class Country
    {

        public string CountryName { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }

    }

}
