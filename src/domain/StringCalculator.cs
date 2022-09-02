namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";
    private const string NEW_LINE = "\n";
   
    

    public int Add(string numberInput)
    {
        if(SeparatorDefinition.ContainsDefinition(numberInput))
        {
            var definition = SeparatorDefinition.GetDefinition(numberInput);
            var inputMembers = SplitMembers(definition.RemoveDefintionFrom(numberInput), definition.ToSeparator());
            return ParseInput(inputMembers).Sum();
        }
        if(numberInput.Contains(SEPARATOR) || numberInput.Contains(NEW_LINE))
        {
            var inputMembers = numberInput.Split(SEPARATOR).SelectMany(x => x.Split(NEW_LINE));
            return ParseInput(inputMembers).Sum();
        }
        return ParseInput(numberInput);
    }

    private IEnumerable<string> SplitMembers(string input, Separator separator)
    {
        return input.Split(separator.Value);
    }

    private static string RemoveSeparatorDefinition(string numberInput) =>
        numberInput.Split(NEW_LINE).Last();

    private static IEnumerable<int> ParseInput(IEnumerable<string> numberInput) =>
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
