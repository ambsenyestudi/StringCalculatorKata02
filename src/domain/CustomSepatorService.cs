namespace StringCalculation.Domain
{
    public class CustomSepatorService
    {

        public bool StartsWithDefintion(string input) =>
                input.StartsWith("//;\n");

    }
}