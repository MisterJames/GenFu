using GenFu.Fillers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace GenFu.Tests.Fillers
{
    class Canadian
    {
        public string SIN { get; set; }
    }

    public class CanadianSocialInsuranceNumberFillerTests
    {
        [Fact]
        public void Matches_a_field()
        {
            var canadian = A.New<Canadian>();
            Assert.Equal(11, canadian.SIN.Length);
        }


        [Fact]
        public void Filler_fills()
        {
            var sut = new CanadianSocialInsuranceNumberFiller();
            Assert.NotNull(sut.GetValue(null) as string);
            Assert.NotEmpty(sut.GetValue(null) as string);
        }

        [Fact]
        public void Filler_give_valid_numbers()
        {
            var sut = new CanadianSocialInsuranceNumberFiller();
            var result = sut.GetValue(null) as string;

            //adding up the digits of a social insurance number and modding by 10 should give 0
            int runningTotal = result.ToCharArray().Where(x => Char.IsDigit(x)).Sum(x => Int32.Parse(x.ToString()));
            Assert.True(runningTotal % 10 == 0);
        }
    }
}
