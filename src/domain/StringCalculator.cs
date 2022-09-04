namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";
    private const string NEW_LINE = "\n";
    private const string ERROR_TEMPLATE = "error: negatives not allowed: {0}";
    private readonly CustomSepatorService _customSeparatorService;
    private const int MAX = 1000;

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
            return Sum(ParseInput(inputMembers));
        }
        return ParseInput(numberInput);
    }

    private static int Sum(IEnumerable<int> inputMembers)
    {
        return inputMembers.Where(x => x < MAX).Sum();
    }

    private static IEnumerable<int> ParseInput(IEnumerable<string> numberInput)
    {
        var result = numberInput.Select(x => ParseInput(x));
        var negatives = result.Where(x => IsNegative(x));
        return negatives.Any()
            ? throw new ArgumentException(string.Format(ERROR_TEMPLATE, string.Join(" ", negatives)))
            : result;
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
        Math.Abs(number) != number;
}
