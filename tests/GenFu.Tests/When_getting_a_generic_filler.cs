using GenFu.Fillers;
using System;
using Xunit;

namespace GenFu.Tests
{

    public class When_getting_a_generic_filler
    {
        [Fact]
        public void An_int_filler_is_returned()
        {
            var manager = new global::GenFu.FillerManager();
            Assert.NotNull(manager.GetGenericFiller<int, IntFiller>());
        }

        [Fact]
        public void A_short_filler_is_returned()
        {
            var manager = new global::GenFu.FillerManager();
            Assert.NotNull(manager.GetGenericFiller<short, ShortFiller>());
        }

        [Fact]
        public void An_datetime_filler_is_returned()
        {
            var manager = new global::GenFu.FillerManager();
            Assert.NotNull(manager.GetGenericFiller<DateTime, DateTimeFiller>());
        }

        [Fact]
        public void A_decimal_filler_is_returned()
        {
            var manager = new global::GenFu.FillerManager();
            Assert.NotNull(manager.GetGenericFiller<decimal, DecimalFiller>());
        }

        [Fact]
        public void A_guid_filler_is_returned()
        {
            var manager = new global::GenFu.FillerManager();
            Assert.NotNull(manager.GetGenericFiller<Guid, GuidFiller>());
        }
    }
}
