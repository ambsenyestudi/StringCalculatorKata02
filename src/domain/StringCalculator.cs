namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";
    private const string NEW_LINE = "\n";
    private readonly CustomSepatorService _customSeparatorService;

    public StringCalculator()
    {
        _customSeparatorService = new CustomSepatorService();
    }
    public int Add(string numberInput)
    {
        if(_customSeparatorService.StartsWithDefintion(numberInput))
        {
            return ParseInput(_customSeparatorService.Split(numberInput)).Sum();
        }
        if(numberInput.Contains(SEPARATOR) || numberInput.Contains(NEW_LINE))
        {
            var inputMembers = numberInput.Split(SEPARATOR).SelectMany(x => x.Split(NEW_LINE));
            return ParseInput(inputMembers).Sum();
        }
        return ParseInput(numberInput);
    }

    private static IEnumerable<int> ParseInput(IEnumerable<string> numberInput)
    {
        var result = numberInput.Select(x => ParseInput(x));
        return result.All(x => !IsNegative(x))
            ? result
            : throw new ArgumentException("error: negatives not allowed: -2 -3");
    }


    private static int ParseInput(string numberInput)
    {
        if (string.IsNullOrWhiteSpace(numberInput))
        {
            return 0;
        }
        return int.Parse(numberInput);
    }
    private static bool IsNegative(int number) =>
        number < 0;
}
