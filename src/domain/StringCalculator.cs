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
            var inputMembers = definition.ToSeparator()
                .Split(definition.RemoveDefintionFrom(numberInput));
            return ParseInput(inputMembers).Sum();
        }
        if(numberInput.Contains(SEPARATOR) || numberInput.Contains(NEW_LINE))
        {
            var inputMembers = numberInput.Split(SEPARATOR).SelectMany(x => x.Split(NEW_LINE));
            return ParseInput(inputMembers).Sum();
        }
        return ParseInput(numberInput);
    }


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
