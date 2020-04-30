using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        private readonly char[] defaultSeparatorList;
        private const string CUSTOM_SEPARATORS_STARTER = "//";
        private const char NEW_LINE = '\n';

        public StringCalculator()
        {
            defaultSeparatorList = new char[] { ',', NEW_LINE };
        }
        public int Add(string numberInput)
        {
            if(string.IsNullOrEmpty(numberInput))
            {   
                return 0;
            }
            try
            {
                var customSeparatorCollection = ExtractCustomSeparators(numberInput);
                var operationInput = ExtractOperation(numberInput);
                var parts = ToAdditionParts(operationInput, customSeparatorCollection);
                return parts.Sum();
            }
            catch(Exception ex)
            {
                //persist exception somewhere
            }
            
            if (ContainsDefaultSeparators(numberInput))
            {
                var parts = ToAdditionParts(numberInput, defaultSeparatorList);
                return parts.Sum();
            }

            return int.Parse(numberInput);
        }

        private string ExtractOperation(string numberInput) =>
            numberInput.Substring(FirstOccurranceOfDigit(numberInput));

        private char[] ExtractCustomSeparators(string numberInput)
        {

            var separatorExpression = GetSeparatorExpression(numberInput);
            var isAny = separatorExpression.Any();
            EnsureCustomSeparatorFormat(separatorExpression);

            var separators = numberInput.Skip(CUSTOM_SEPARATORS_STARTER.Length).Take(numberInput.IndexOf(NEW_LINE) - CUSTOM_SEPARATORS_STARTER.Length);
            return ExtractCustomSepartorPart(numberInput).ToCharArray();
        }

        private string GetSeparatorExpression(string numberInput)
        {
            
            return numberInput.Substring(0,FirstOccurranceOfDigit(numberInput));
        }

        private string ExtractCustomSepartorPart(string numberInput) =>
            numberInput
            .Replace(CUSTOM_SEPARATORS_STARTER, "")
            .Split(NEW_LINE)
            .First();

        private int FirstOccurranceOfDigit(string input) 
        {
            var indexedCharCollection = input.Select((x, i) => new { Index = i, Char = x });
            if(!indexedCharCollection.Any())
            {
                return -1;
            }
            return indexedCharCollection.First(x => char.IsDigit(x.Char)).Index;
        }
        private bool ContainsDefaultSeparators(string numberInput) =>
            numberInput.Any(x => defaultSeparatorList.Contains(x));

        private List<int> ToAdditionParts(string numberInput, IList<char> separatorCollection, int maxThreshold = 1000)
        {
            var parts = new List<string> { numberInput };
            foreach (var separator in separatorCollection)
            {
                parts = BatchSplitBySeparator(parts, separator).ToList();
            }
            var numbers = parts.Select(x => int.Parse(x));
            EnsureNoNegativeNumbers(numbers);
            return IgnoreNumbersOverThreshold(numbers, maxThreshold);
        }

        private IList<string> SplitBySeparator(string input, char separator) =>
            input.Split(separator);

        private IList<string> BatchSplitBySeparator(IList<string> inputCollection, char separator) =>
            inputCollection
            .Select(inp => SplitBySeparator(inp, separator))
            .SelectMany(x=>x)
            .ToArray();

        private List<int> IgnoreNumbersOverThreshold(IEnumerable<int> numbers, int maxThreshold) =>
            numbers.Where(x => x <= maxThreshold)
            .ToList();

        #region BusinessForce Enforcemente
        private void EnsureCustomSeparatorFormat(string separatorExpression)
        {
            var isSeparatorFormat = separatorExpression.StartsWith(CUSTOM_SEPARATORS_STARTER) && separatorExpression.EndsWith(NEW_LINE);
            if (!isSeparatorFormat)
            {
                throw new ArgumentException($"{nameof(separatorExpression)}: {separatorExpression} does not meet custom serparator format requirements");
            }
        }
        private void EnsureNoNegativeNumbers(IEnumerable<int> numbers)
        {
            
            if (numbers.Any(x => x < 0))
            {
                throw new NegativeNumberExpection("Add can not operate negative numbers");
            }
        }
        #endregion BusinessForce Enforcemente
    }
}
