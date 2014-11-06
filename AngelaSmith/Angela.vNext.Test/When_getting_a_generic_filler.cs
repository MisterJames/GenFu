using System;
using GenFu;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Angela.Tests
{
    [TestFixture]
    class When_getting_a_generic_filler
    {
        [Test]
        public void An_int_filler_is_returned()
        {
            var manager = new GenFu.FillerManager();
            Assert.IsNotNull(manager.GetGenericFiller<int, IntFiller>());
        }

        [Test]
        public void A_short_filler_is_returned()
        {
            var manager = new GenFu.FillerManager();
            Assert.IsNotNull(manager.GetGenericFiller<short, ShortFiller>());
        }

        [Test]
        public void An_datetime_filler_is_returned()
        {
            var manager = new GenFu.FillerManager();
            Assert.IsNotNull(manager.GetGenericFiller<DateTime, DateTimeFiller>());
        }

        [Test]
        public void A_decimal_filler_is_returned()
        {
            var manager = new GenFu.FillerManager();
            Assert.IsNotNull(manager.GetGenericFiller<decimal, DecimalFiller>());
        }
    }
}
