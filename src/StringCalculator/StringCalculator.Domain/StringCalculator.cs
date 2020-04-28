using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        public int Add(string numberInput)
        {
            if(string.IsNullOrEmpty(numberInput))
            {   
                return 0;
            }
            
            if(numberInput.Contains(","))
            {
                var parts = ToAdditionParts(numberInput);
                return AddParts(parts);
            }

            return int.Parse(numberInput);
        }
        private List<int> ToAdditionParts(string numberInput)
        {
            var parts = numberInput
                .Split(",")
                .Select(x => int.Parse(x))
                .ToList();
            return parts;
        }
        private int AddParts(IList<int> partCollection)
        {
            var total = 0;
            foreach (var part in partCollection)
            {
                total += part;
            }
            return total;
        }
    }
}
