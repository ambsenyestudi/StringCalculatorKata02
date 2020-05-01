using StringCalculatorKata.Domain.Operation;

namespace StringCalculatorKata.Domain.Inputs
{
    public class SingleNumberOperationInput: OperationInput
    {
        public SingleNumberOperationInput(string input)
        {
            OperationExpression = new SingleNumberOperationExpression(input);
        }
    }
}
