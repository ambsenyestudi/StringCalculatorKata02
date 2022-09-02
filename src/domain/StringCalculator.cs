namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";
    private const string NEW_LINE = "\n";
    private const string CHARATER_DEFINITION_STARTER = "//";

    public int Add(string numberInput)
    {
        if(TryGetSepartor(numberInput, out string separator))
        {
            var inputMembers = RemoveSeparatorDefinition(numberInput).Split(separator);
            return ParseInput(inputMembers).Sum();
        }
        if(numberInput.Contains(SEPARATOR) || numberInput.Contains(NEW_LINE))
        {
            var inputMembers = numberInput.Split(SEPARATOR).SelectMany(x => x.Split(NEW_LINE));
            return ParseInput(inputMembers).Sum();
        }
        return ParseInput(numberInput);
    }

    private static bool TryGetSepartor(string numberInput, out string separator)
    {
        
        if(!numberInput.StartsWith(CHARATER_DEFINITION_STARTER))
        {
            separator = string.Empty;
            return false;
        }
        separator = numberInput.Split(NEW_LINE).First().Replace(CHARATER_DEFINITION_STARTER, string.Empty);
        return true;
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
