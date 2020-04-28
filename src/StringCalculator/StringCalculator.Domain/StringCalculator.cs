using System;

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
                var numberParts = numberInput.Split(",");

                return int.Parse(numberParts[0]) + int.Parse(numberParts[1]);
            }

            return int.Parse(numberInput);
        }
    }
}
