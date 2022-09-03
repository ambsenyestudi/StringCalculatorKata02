using System.Text.RegularExpressions;

namespace StringCalculation.Domain
{
    public class CustomSepatorService
    {
        private const string DEFINITION_PATTERN = "^[//].[\n]";
        private readonly Regex _separatorRegex = new Regex(DEFINITION_PATTERN + "*");
        public bool StartsWithDefintion(string input) =>
            _separatorRegex.IsMatch(input);

        public int Split(string numberInput)
        {
            return 3;
        }
    }
}