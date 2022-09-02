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
    public void Add(string input, int expected)
    {
        var result = _stringCalculator.Add(input);
        Assert.Equal(expected, result);
    }
}