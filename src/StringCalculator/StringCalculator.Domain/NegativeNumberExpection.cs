using System;

namespace StringCalculatorKata.Domain
{
    public class NegativeNumberExpection:Exception
    {
        public NegativeNumberExpection(string message):base(message)
        {

        }
    }
}
