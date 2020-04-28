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

        private string ExtractOperation(string numberInput)
        {
            return numberInput.Split(NEW_LINE)[1];
        }

        private char[] ExtractCustomSeparators(string numberInput)
        {
            EnsureCustomSeparatorFormat(numberInput);
            return ExtractCustomSepartorPart(numberInput).ToCharArray();            
        }

        private string ExtractCustomSepartorPart(string numberInput) =>
            numberInput
            .Replace(CUSTOM_SEPARATORS_STARTER, "")
            .Split(NEW_LINE)
            .First();


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
        private void EnsureCustomSeparatorFormat(string numberInput)
        {
            var isSeparatorFormat = numberInput.StartsWith(CUSTOM_SEPARATORS_STARTER) && numberInput.Contains(NEW_LINE);
            if (!isSeparatorFormat)
            {
                throw new ArgumentException($"{nameof(numberInput)}: {numberInput} does not meet custom serparator format requirements");
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
