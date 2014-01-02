using System;

namespace Angela.Core
{
    public class AngieDefaulturator
    {
        protected Angie _angie;
        protected FillerManager _fillerManager;

        public AngieDefaulturator(Angie angie, FillerManager maggie)
        {
            _angie = angie;
            _fillerManager = maggie;
        }


        public AngieDefaulturator MaxInt(int max)
        {
            _fillerManager.SetMaxInt(max);
            return this;

        }

        public AngieDefaulturator MinInt(int min)
        {
            _fillerManager.SetMinInt(min);
            return this;
        }

        public AngieDefaulturator MaxShort(short max)
        {
            _fillerManager.SetMaxShort(max);
            return this;

        }

        public AngieDefaulturator MinShort(short min)
        {
            _fillerManager.SetMinShort(min);
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
            _fillerManager.SetMinDateTime(minDateTime);
            _fillerManager.SetMaxDateTime(maxDateTime);
            return this;
        }

        public Angie Angie
        {
            get { return _angie; }
        }

        public FillerManager Maggie
        {
            get { return _fillerManager; }
        }
    }
}
