using StringCalculatorKata.Domain;
using System;
using Xunit;

namespace StringCalculatorKata.Test
{
    public class string_calculcator_should
    {
        private readonly StringCalculator sut;

        public string_calculcator_should()
        {
            sut = new StringCalculator();
        }
        [Fact]
        public void be_true()
        {
            Assert.True(true);
        }
        [Fact]
        public void return_0_when_empty()
        {
            var expected = 0;
            var result = sut.Add(string.Empty);
            Assert.Equal(expected, result);
        }
    }
}
