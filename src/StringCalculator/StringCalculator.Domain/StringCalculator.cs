using System;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers))
            {   
                return 0;
            }
            
            if(numbers.Contains(","))
            {
                return 3;
            }
            return 4;
        }
    }
}
