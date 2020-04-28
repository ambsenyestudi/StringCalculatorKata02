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

            if (TryExtractCustomSeparators(numberInput, out char[] cutstomeSeparatorCollection))
            {
                numberInput = ExtractOperation(numberInput);
                var parts = ToAdditionParts(numberInput, cutstomeSeparatorCollection);
                return parts.Sum();
            }
            if (ContainsSeparator(numberInput))
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

        private bool TryExtractCustomSeparators(string numberInput, out char[] customSeparatorCollection)
        {
            var isSeparatorFormat = numberInput.StartsWith("//") && numberInput.Contains("\n");
            if(!isSeparatorFormat)
            {
                customSeparatorCollection = null;
                return false;
                
            }
            numberInput = numberInput.Replace("//", "");
            customSeparatorCollection = numberInput.Split(NEW_LINE).First().ToCharArray();
            return true;
        }


        private bool ContainsSeparator(string numberInput)
        {
            var isFound = false;
            int count = 0;
            while (!isFound && count < defaultSeparatorList.Length)
            {
                isFound = numberInput.Contains(defaultSeparatorList[count]);
                count++;
            }
            return isFound;
        }

        private List<int> ToAdditionParts(string numberInput, IList<char> separatorCollection)
        {
            var parts = new List<string> { numberInput };
            foreach (var separator in separatorCollection)
            {
                parts = BatchSplitBySeparator(parts, separator).ToList();
            }
            var numbers = parts.Select(x => int.Parse(x));
            if(numbers.Any(x=>x<0))
            {
                throw new NegativeNumberExpection("Add can not operate negative numbers");
            }
            return numbers.ToList();
        }
        private IList<string> SplitBySeparator(string input, char separator) =>
            input.Split(separator);

        private IList<string> BatchSplitBySeparator(IList<string> inputCollection, char separator) =>
            inputCollection
            .Select(inp => SplitBySeparator(inp, separator))
            .SelectMany(x=>x)
            .ToArray();
    }
}
