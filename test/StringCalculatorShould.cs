using StringCalculation.Domain;

namespace StringCalculation.Test;

public class StringCalculatorShould
{
    private readonly StringCalculator _stringCalculator;

    public StringCalculatorShould()
    {
        _stringCalculator = new StringCalculator();
    }
    [Theory]
    [InlineData("",0)]
    [InlineData("4", 4)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45 )]
    [InlineData("1\n2,3", 6)]
    [InlineData("//;\n1;2", 3)]
    [InlineData("1001,2", 2)]
    public void Add(string input, int expected)
    {
        var result = _stringCalculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Reject_Negatives()
    {
        var input = "1,-2,-3";
        var expected = "error: negatives not allowed: -2 -3";
        var exception = Assert.Throws<ArgumentException>(() => _stringCalculator.Add(input));
        Assert.Equal(expected, exception.Message);
    }
}