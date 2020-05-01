using StringCalculatorKata.Domain.Operation;
using StringCalculatorKata.Domain.Separators;

namespace StringCalculatorKata.Domain.Inputs
{
    internal class CustomSeparatorOperationInput : OperationInput
    {
        public CustomSeparatorOperationInput(string numberInput, SeparatorExpressionDefinition customSeparatorDefinition)
        {
            OperationExpression = new CustomSeparatorOperationExpression(numberInput, customSeparatorDefinition);
        }
    }
}