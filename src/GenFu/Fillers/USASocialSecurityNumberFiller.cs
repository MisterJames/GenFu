using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Fillers
{
    public class USASocialSecurityNumberFiller : PropertyFiller<String>
    {

        public USASocialSecurityNumberFiller()
            : base(new[] { "object" }, new[] { "SSN", "SocialSecurityNumber" })
        { }

        public override object GetValue(object instance)
        {
            var number = new StringBuilder();
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            number.Append("-");
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            number.Append("-");
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            return number.ToString();

        }

        static Random random = new Random();
        protected internal string RandomDigit()
        {
            return (random.Next() % 10).ToString();
        }
    }
}
