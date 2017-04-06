using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFu.Fillers
{
    public class PersonFiller
    {
        public class SexFiller : PropertyFiller<string>
        {
            public SexFiller()
                : base(new[] { "object" }, new[] { "sex" })
            {
            }

            private static Random random = new Random();
            public override object GetValue(object instance)
            {
                return random.NextDouble() > 0.5 ? "M" : "F";
            }
        }

         public class GenderFiller : PropertyFiller<string>
        {
            public GenderFiller()
                : base(new[] { "object" }, new[] { "gender" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.People.Qualities.Gender();
            }
        }
    }
}
