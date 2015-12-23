using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace GenFu
{
    public class GenericFillerDefaults
    {
        private FillerManager _fillerManager;
        public GenericFillerDefaults(FillerManager fillerManager)
        {
            _fillerManager = fillerManager;
        }
        public void SetMinInt(int min)
        {
            IntFiller intFiller = _fillerManager.GetGenericFiller<int, IntFiller>();
            intFiller.Min = min;
        }

        public void SetMaxInt(int max)
        {
            IntFiller intFiller = _fillerManager.GetGenericFiller<int, IntFiller>();
            intFiller.Max = max;
        }

        public void SetMinShort(short min)
        {
            ShortFiller shortFiller = _fillerManager.GetGenericFiller<short, ShortFiller>();
            shortFiller.Min = min;
        }

        public void SetMaxShort(short max)
        {
            ShortFiller shortFiller = _fillerManager.GetGenericFiller<short, ShortFiller>();
            shortFiller.Max = max;
        }

        public void SetMinDecimal(decimal min)
        {
            DecimalFiller decFiller = _fillerManager.GetGenericFiller<decimal, DecimalFiller>();
            decFiller.Min = min;
        }

        public void SetMaxDecimal(decimal max)
        {
            DecimalFiller decFiller = _fillerManager.GetGenericFiller<decimal, DecimalFiller>();
            decFiller.Max = max;
        }

        public void SetMinDateTime(DateTime minValue)
        {
            DateTimeFiller dateTimeFiller = _fillerManager.GetGenericFiller<DateTime, DateTimeFiller>();
            dateTimeFiller.Min = minValue;

            DateTimeNullableFiller dateTimeNullableFiller = _fillerManager.GetGenericFiller<DateTime?, DateTimeNullableFiller>();
            dateTimeNullableFiller.Min = minValue;
        }

        public void SetMaxDateTime(DateTime maxValue)
        {
            DateTimeFiller dateTimeFiller = _fillerManager.GetGenericFiller<DateTime, DateTimeFiller>();
            dateTimeFiller.Max = maxValue;

            DateTimeNullableFiller dateTimeNullableFiller = _fillerManager.GetGenericFiller<DateTime?, DateTimeNullableFiller>();
            dateTimeNullableFiller.Max = maxValue;
        }

        public void SetMinSeed(int minValue)
        {
            DateTimeNullableFiller dateTimeNullableFiller = _fillerManager.GetGenericFiller<DateTime?, DateTimeNullableFiller>();
            dateTimeNullableFiller.SeedMin = minValue;
        }

        public void SetMaxSeed(int maxValue)
        {
            DateTimeNullableFiller dateTimeNullableFiller = _fillerManager.GetGenericFiller<DateTime?, DateTimeNullableFiller>();
            dateTimeNullableFiller.SeedMax = maxValue;
        }

        public DateTime GetMinDateTime()
        {
            DateTimeFiller dateTimeFiller = _fillerManager.GetGenericFiller<DateTime, DateTimeFiller>();
            return dateTimeFiller.Min;
        }

        public DateTime GetMaxDateTime()
        {
            DateTimeFiller dateTimeFiller = _fillerManager.GetGenericFiller<DateTime, DateTimeFiller>();
            return dateTimeFiller.Max;
        }
    }
}
