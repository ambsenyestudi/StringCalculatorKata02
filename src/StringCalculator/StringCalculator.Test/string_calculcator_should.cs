using StringCalculatorKata.Domain;
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
        //Add("1,2,3,4,5,6,7,8,9") 45
        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("2,8", 10)]
        [InlineData("1,2,3,4,5,6,7,8,9", 45)]
        public void add_many_coma_separated_numbers(string input, int expected)
        {
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
        //Add("1\n2,3") 6
        [Fact]
        public void add_many_coma_or_new_line_separated_numbers()
        {
            string input = "1\n2,3";
            int expected = 6;
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
        //Add("//;\n1;2") // 3
        [Fact]
        public void add_many_cutstom_separated_numbers()
        {
            string input = "//;\n1;2";
            int expected = 3;
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
        //Add("1,-2,-3") // error: negatives not allowed: -2 -3
        [Fact]
        public void error_when_negative_numbers()
        {
            string input = "1,-2,-3";
            Assert.Throws<NegativeNumberExpection>(()=>sut.Add(input));
        }
        //Add("1001, 2") // 2
        [Fact]
        public void ignore_numbers_greater_than_1000()
        {
            string input = "1001,2";
            int expected = 2;
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
        //Separators can be of any length if surrounded by square brackets.
        [Fact]
        public void add_numbers_with_custom_separators_of_any_length()
        {
            string input = "//[***]\n1***2***3";
            int expected = 6;
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }

        //Handle multiple separators with any character length.
        [Theory]
        [InlineData("//[foo][bar]\n1foo2bar3", 6)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void add_numbers_with_many_custom_separators_of_any_length(string input, int expected)
        {
            //string input = "//[foo][bar]\n1foo2bar3";
            //int expected = 6;
            var result = sut.Add(input);
            Assert.Equal(expected, result);
        }
    }
}
