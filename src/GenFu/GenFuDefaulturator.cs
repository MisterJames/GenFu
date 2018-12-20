using System;

namespace GenFu
{
    public class GenFuDefaulturator
    {
        protected GenFuInstance _genfu;
        protected FillerManager _fillerManager;

        public GenFuDefaulturator(GenFuInstance genfu, FillerManager maggie)
        {
            _genfu = genfu;
            _fillerManager = maggie;
        }


        public GenFuDefaulturator MaxInt(int max)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMaxInt(max);
            return this;

        }

        public GenFuDefaulturator MinInt(int min)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMinInt(min);
            return this;
        }

        public GenFuDefaulturator MaxShort(short max)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMaxShort(max);
            return this;

        }

        public GenFuDefaulturator MinShort(short min)
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
        public GenFuDefaulturator IntRange(int min, int max)
        {
            MinInt(min);
            MaxInt(max);

            return this;
        }

        public GenFuDefaulturator ListCount(int count)
        {
            _genfu.ListCount(count);
            return this;
        }
        /// <summary>
        /// Sets the date range
        /// </summary>
        /// <param name="minDateTime">Starting date</param>
        /// <param name="maxDateTime">Ending date</param>
        /// <returns></returns>
        public GenFuDefaulturator DateRange(DateTime minDateTime, DateTime maxDateTime)
        {
            var defaults = new GenericFillerDefaults(_fillerManager);
            defaults.SetMinDateTime(minDateTime);
            defaults.SetMaxDateTime(maxDateTime);
            return this;
        }

        public GenFuInstance GenFu
        {
            get { return _genfu; }
        }

        public FillerManager FillerManager
        {
            get { return _fillerManager; }
        }
    }
}
