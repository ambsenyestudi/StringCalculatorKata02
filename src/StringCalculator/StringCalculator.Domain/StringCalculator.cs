using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        private readonly IList<string> defaultSeparatorList;
        private const string CUSTOM_SEPARATORS_STARTER = "//";
        private const string NEW_LINE = "\n";

        public StringCalculator()
        {
            defaultSeparatorList = new string[] { ",", NEW_LINE };
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

        private string[] ExtractCustomSeparators(string numberInput)
        {

            var separatorExpression = GetSeparatorExpression(numberInput);
            var isAny = separatorExpression.Any();
            var separators = Separator.FromExpression(separatorExpression, CUSTOM_SEPARATORS_STARTER, NEW_LINE);
            return separators.Select(x=>x.Value).ToArray();
        }

        private bool ContainsDefaultSeparators(string numberInput) =>
            numberInput.Any(x => defaultSeparatorList.Contains(x.ToString()));

        //input processing
        private string GetSeparatorExpression(string numberInput)
        {
            return numberInput.Substring(0, FirstOccurranceOfDigit(numberInput));
        }
        private int FirstOccurranceOfDigit(string input) 
        {
            var indexedCharCollection = input.Select((x, i) => new { Index = i, Char = x });
            if(!indexedCharCollection.Any())
            {
                return -1;
            }
            return indexedCharCollection.First(x => char.IsDigit(x.Char)).Index;
        }
        

        private IList<string> SplitBySeparator(string input, string separator) =>
            input.Split(separator);

        private IList<string> BatchSplitBySeparator(IList<string> inputCollection, string separator) =>
            inputCollection
            .Select(inp => SplitBySeparator(inp, separator))
            .SelectMany(x=>x)
            .ToArray();

        private List<int> ToAdditionParts(string numberInput, IList<string> separatorCollection, int maxThreshold = 1000)
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

        //calculator business rules
        private List<int> IgnoreNumbersOverThreshold(IEnumerable<int> numbers, int maxThreshold) =>
            numbers.Where(x => x <= maxThreshold)
            .ToList();

        #region BusinessForce Enforcemente
        
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
