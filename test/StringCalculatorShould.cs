using StringCalculation.Domain;

namespace StringCalculation.Test;

public class StringCalculatorShould
{
    private readonly StringCalculator _stringCalculator;

    public StringCalculatorShould()
    {
        _stringCalculator = new StringCalculator();
    }
    [Fact]
    public void Add()
    {
        var result = _stringCalculator.Add("");
        Assert.Equal(0, result);
    }
}