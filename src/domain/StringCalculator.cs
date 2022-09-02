namespace StringCalculation.Domain;
public class StringCalculator
{
    private const string SEPARATOR = ",";

    public int Add(string numberInput)
    {
        
        if(numberInput.Contains(SEPARATOR))
        {
            return numberInput.Split(SEPARATOR).Select(x => int.Parse(x)).Sum();
        }
        return ParseInput(numberInput);
    }

    private int ParseInput(string numberInput)
    {
        if (string.IsNullOrWhiteSpace(numberInput))
        {
            return 0;
        }
        return int.Parse(numberInput);
    }
}
