using StringCalculatorKata.Domain.Operation;

namespace StringCalculatorKata.Domain.Input
{
    internal class CustomSeparatorOperationInput : OperationInput
    {
        public CustomSeparatorOperationInput(string numberInput, SeparatorExpressionDefinition customSeparatorDefinition)
        {
            OperationExpression = new CustomSeparatorOperationExpression(numberInput, customSeparatorDefinition);
        }
    }
}