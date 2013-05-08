using System;

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

        public AngieDefaulturator MaxShort(short max)
        {
            _maggie.SetMaxShort(max);
            return this;

        }

        public AngieDefaulturator MinShort(short min)
        {
            _maggie.SetMinShort(min);
            return this;
        }

        /// <summary>
        /// Sets the integer range
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns></returns>
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
        /// <summary>
        /// Sets the date range
        /// </summary>
        /// <param name="minDateTime">Starting date</param>
        /// <param name="maxDateTime">Ending date</param>
        /// <returns></returns>
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
