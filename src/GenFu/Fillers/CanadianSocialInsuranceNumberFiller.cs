using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Fillers
{

    class CanadianSocialInsuranceNumberFiller : PropertyFiller<String>
    {
        public CanadianSocialInsuranceNumberFiller()
            : base(new[] { "object" }, new[] { "SIN", "SocialInsuranceNumber" })
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
            number.Append(RandomDigit());
            number.Append("-");
            number.Append(RandomDigit());
            number.Append(RandomDigit());
            number.Append(GetFinalDigit(number.ToString()));
            return number.ToString();

        }
        private static Random _random = new Random();
        protected internal string RandomDigit()
        {
            return (_random.Next() % 10).ToString();
        }

        protected internal string GetFinalDigit(string numberSoFar)
        {
            int runningTotal = 0;
            foreach (var character in numberSoFar.ToCharArray())
            {
                if (Char.IsDigit(character))
                    runningTotal += Int32.Parse(character.ToString());
            }
            return (10 - (runningTotal % 10)).ToString();
        }
    }
}
