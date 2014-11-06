using System;

namespace GenFu
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
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMaxInt(max);
            return this;

        }

        public AngieDefaulturator MinInt(int min)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMinInt(min);
            return this;
        }

        public AngieDefaulturator MaxShort(short max)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMaxShort(max);
            return this;

        }

        public AngieDefaulturator MinShort(short min)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMinShort(min);
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
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMinDateTime(minDateTime);
            defaults.SetMaxDateTime(maxDateTime);
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
