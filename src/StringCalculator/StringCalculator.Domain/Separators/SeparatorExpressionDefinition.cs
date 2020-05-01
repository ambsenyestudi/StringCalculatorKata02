namespace StringCalculatorKata.Domain.Separators
{
    public class SeparatorExpressionDefinition
    {
        public string Starting { get; }
        public string Ending { get; }

        public SeparatorExpressionDefinition(string starting, string ending)
        {
            Starting = starting;
            Ending = ending;
        }
        public bool IsExpressionMatch(string expression) =>
            expression.StartsWith(Starting) && 
            expression.EndsWith(Ending);
        public bool IsIn(string expression)
        {
            var containsBoth = ContainsStaring(expression) && ContainsEnding(expression);
            if(!containsBoth)
            {
                return false;
            }

            var startingIndex = expression.IndexOf(Starting);
            var endingIndex = expression.LastIndexOf(Ending);
            
            if(startingIndex > 0)
            {
                return IsExpressionMatch(expression.Substring(startingIndex, endingIndex + 1));
            }
            return IsExpressionMatch(expression.Substring(0, endingIndex + 1));
        }
        public bool ContainsStaring(string input) =>
            input.Contains(Starting);
        public bool ContainsEnding(string input) =>
            input.Contains(Ending);
    }
}
