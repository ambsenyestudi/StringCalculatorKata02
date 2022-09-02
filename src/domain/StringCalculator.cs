namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";

    public int Add(string numberInput)
    {
        
        if(numberInput.Contains(SEPARATOR))
        {
            return ParseInput(numberInput.Split(SEPARATOR)).Sum();
        }
        return ParseInput(numberInput);
    }

    private static IEnumerable<int> ParseInput(string[] numberInput) =>
        numberInput.Select(x => ParseInput(x));

    private static int ParseInput(string numberInput)
    {
        if (string.IsNullOrWhiteSpace(numberInput))
        {
            return 0;
        }
        return int.Parse(numberInput);
    }
}
