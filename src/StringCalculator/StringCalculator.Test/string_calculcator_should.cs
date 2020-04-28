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
        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("2,8", 10)]
        public void add_two_coma_separated_numbers(string input, int expected)
        {
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
        //Add("1,2,3,4,5,6,7,8,9") 45
        [Fact]
        public void add_many_coma_separated_numbers()
        {
            string input = "1,2,3,4,5,6,7,8,9";
            int expected = 45;
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
    }
}
