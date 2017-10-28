using GenFu.Tests.TestEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GenFu.Tests
{
    public class When_filling_nullables
    {
        [Fact]
        void A_nullable_date_time_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableDateTime.HasValue); 
        }

        [Fact]
        void A_nullable_int_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableInt.HasValue);
        }

        [Fact]
        void A_nullable_uint_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableUInt.HasValue);
        }

        [Fact]
        void A_nullable_short_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableShort.HasValue);
        }

        [Fact]
        void A_nullable_decimal_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableDecimal.HasValue);
        }

        [Fact]
        void A_nullable_long_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableLong.HasValue);
        }

        [Fact]
        void A_nullable_ulong_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableULong.HasValue);
        }

        [Fact]
        void A_nullable_boolean_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableBoolean.HasValue);
        }

        [Fact]
        void A_nullable_char_should_be_filled()
        {
            Assert.True(A.New<Nullables>().NullableChar.HasValue);
        }
    }
}
