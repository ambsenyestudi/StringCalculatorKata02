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
        //Add("")  0
        [Fact]
        public void return_0_when_input_empty()
        {
            var expected = 0;
            var result = sut.Add(string.Empty);
            Assert.Equal(expected, result);
        }
        //Add("4") 4
        [Theory]
        [InlineData("4",4)]
        [InlineData("6", 6)]
        [InlineData("100", 100)]
        public void return_number_when_input_is_number(string input, int expected)
        {
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
        //Add("1,2")  3
        [Fact]
        public void return_number_when_input_is_1_coma_2()
        {
            var expected = 3;
            var result = sut.Add("1,2");
            Assert.Equal(expected, result);
        }
    }
}
