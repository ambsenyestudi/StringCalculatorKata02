using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        private readonly string[] separatorList;

        public StringCalculator()
        {
            separatorList = new string[] { ",", "\n" };
        }
        public int Add(string numberInput)
        {
            if(string.IsNullOrEmpty(numberInput))
            {   
                return 0;
            }
            
            if(ContainsSeparator(numberInput))
            {
                var parts = ToAdditionParts(numberInput);
                
                return parts.Sum();
            }

            return int.Parse(numberInput);
        }

        private bool ContainsSeparator(string numberInput)
        {
            var isFound = false;
            int count = 0;
            while (!isFound && count < separatorList.Length)
            {
                isFound = numberInput.Contains(separatorList[count]);
                count++;
            }
            return isFound;
        }

        private List<int> ToAdditionParts(string numberInput)
        {
            var parts = new List<string> { numberInput };
            foreach (var separator in separatorList)
            {
                parts = SplitBySeparator(parts, separator).ToList();
            }
            return parts.Select(x => int.Parse(x)).ToList();
        }
        private IList<string> SplitBySeparator(string input, string separator) =>
            input.Split(separator);

        private IList<string> SplitBySeparator(IEnumerable<string> inputCollection, string separator) =>
            inputCollection
            .Select(inp => SplitBySeparator(inp, separator))
            .SelectMany(x=>x)
            .ToArray();
    }
}
