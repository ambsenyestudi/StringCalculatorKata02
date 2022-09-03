using System.Text.RegularExpressions;

namespace StringCalculation.Domain
{
    public class CustomSepatorService
    {
        private const string DEFINITION_START = "//";
        private const string DEFINITION_END = "\n";
        private readonly string DEFINITION_PATTERN = $"{DEFINITION_START}.{DEFINITION_END}";
        private readonly Regex _separatorRegex; 
        public CustomSepatorService()
        {
            _separatorRegex = new Regex($"^{DEFINITION_PATTERN}*");
        }
        public bool StartsWithDefintion(string input) =>
            _separatorRegex.IsMatch(input);

        public IEnumerable<string> Split(string rawInput)
        {
            var processedInput = Regex.Replace(rawInput, DEFINITION_PATTERN, string.Empty);
            var separator = GetSeparator(rawInput.Replace(processedInput, string.Empty));
            return processedInput.Split(separator);
        }

        private string GetSeparator(string definition) =>
            Regex.Replace(definition, "[\\//\n]", string.Empty);
    }
}