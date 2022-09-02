using System.Text.RegularExpressions;

namespace StringCalculation.Domain
{
    public record SeparatorDefinition(string Value)
    {
        private const string DEFINITION_END = "\n";
        private const string DEFINITION_START = "//";
        private static Regex SeparatorDefinitionRegex = new Regex($"^{DEFINITION_START}*{DEFINITION_END}*");

        public static bool ContainsDefinition(string input) =>
            SeparatorDefinitionRegex.IsMatch(input);

        public static SeparatorDefinition GetDefinition(string input) =>
            new SeparatorDefinition(input.Substring(0, input.IndexOf(DEFINITION_END)));

        public string RemoveDefintionFrom(string input) =>
            input.Replace(Value, string.Empty);

        public Separator ToSeparator() =>
        new Separator(Value.Replace(DEFINITION_START,string.Empty).Replace(DEFINITION_END, string.Empty));
    }
}
