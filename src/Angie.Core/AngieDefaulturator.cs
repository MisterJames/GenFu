using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Core
{
    public class AngieDefaulturator
    {
        protected Angie _angie;
        protected Maggie _maggie;

        public AngieDefaulturator(Angie angie, Maggie maggie)
        {
            _angie = angie;
            _maggie = maggie;
        }


        public AngieDefaulturator MaxInt(int max)
        {
            _maggie.SetMaxInt(max);
            return this;

        }

        public AngieDefaulturator MinInt(int min)
        {
            _maggie.SetMinInt(min);
            return this;
        }

        public AngieDefaulturator IntRange(int min, int max)
        {
            MinInt(min);
            MaxInt(max);

            return this;
        }

        public AngieDefaulturator ListCount(int count)
        {
            _angie.ListCount(count);
            return this;
        }

        public AngieDefaulturator DateRange(DateTime minDateTime, DateTime maxDateTime)
        {
            _maggie.SetMinDateTime(minDateTime);
            _maggie.SetMaxDateTime(maxDateTime);
            return this;
        }

        public Angie Angie
        {
            get { return _angie; }
        }

        public Maggie Maggie
        {
            get { return _maggie; }
        }
    }
}
