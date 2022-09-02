using System.Text.RegularExpressions;

namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";
    private const string NEW_LINE = "\n";
    private const string CHARATER_DEFINITION_STARTER = "//";
    private readonly Regex SeparatorDefinitionRegex = new Regex($"^{CHARATER_DEFINITION_STARTER}*{NEW_LINE}*");

    public int Add(string numberInput)
    {
        if(SeparatorDefinitionRegex.IsMatch(numberInput))
        {
            var separator = GetSepartor(numberInput);
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

    private string GetSepartor(string numberInput) =>
        numberInput.Substring(0, numberInput.IndexOf(NEW_LINE))
            .Replace(CHARATER_DEFINITION_STARTER, string.Empty);

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
