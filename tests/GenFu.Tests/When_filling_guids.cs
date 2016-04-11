using GenFu.Tests.TestEntities;
using System;
using Xunit;

namespace GenFu.Tests
{
    public class When_filling_guids
    {
        [Fact]
        public void FillGuidWithNonDefault()
        {
            var guid = A.New<Guid>().ToString();
            var guidDefault = new Guid().ToString();

            Assert.NotEqual(guidDefault, guid);

        }

        [Fact]
        public void FillGuidAsPropertyWithNonDefault()
        {
            var guid = A.New<AuditEntry>().AuditId.ToString();
            var guidDefault = new Guid().ToString();

            Assert.NotEqual(guidDefault, guid);

        }

    }
}
