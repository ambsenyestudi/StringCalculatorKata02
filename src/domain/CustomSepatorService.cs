using System.Text.RegularExpressions;

namespace StringCalculation.Domain
{
    public class CustomSepatorService
    {
        private const string DEFINITION_PATTERN = "//.\n";
        private readonly Regex _separatorRegex = new Regex($"^{DEFINITION_PATTERN}*");
        public bool StartsWithDefintion(string input) =>
            _separatorRegex.IsMatch(input);

        public IEnumerable<string> Split(string rawInput)
        {
            var processedInput = Regex.Replace(rawInput, DEFINITION_PATTERN, string.Empty);
            var separator = GetSeparator(rawInput.Replace(processedInput, string.Empty));
            return processedInput.Split(separator);
        }

        private string GetSeparator(string definition) =>
            ";";
    }
}