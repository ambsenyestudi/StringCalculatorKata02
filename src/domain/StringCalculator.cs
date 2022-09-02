namespace StringCalculation.Domain;
public class StringCalculator
{
    public int Add(string numberInput)
    {
        if (string.IsNullOrWhiteSpace(numberInput))
        {
            return 0;
        }
        if(numberInput.Contains(","))
        {
            return numberInput.Split(",").Select(x => int.Parse(x)).Sum();
        }
        return int.Parse(numberInput);
    }
}
