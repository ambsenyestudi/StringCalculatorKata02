using System.Linq;

namespace StringCalculatorKata.Domain.Operation
{
    public class SingleNumberOperationExpression: OperationExpression
    {
        public SingleNumberOperationExpression(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                SetSingleNumber(0);
            }
            else
            {
                SetSingleNumber(int.Parse(input));
            }
        }
        public static bool IsAllDigits(string operationExpression) =>
            operationExpression.All(x => char.IsDigit(x));
        private void SetSingleNumber(int number) =>
            Numbers = new int[] { number };


    }
}
