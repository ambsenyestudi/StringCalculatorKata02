using StringCalculatorKata.Domain.Separators;

namespace StringCalculatorKata.Domain.Operation
{
    public class CustomSeparatorOperationExpression: DefaultOperationExpression
    {
        public CustomSeparatorOperationExpression(string input, SeparatorExpressionDefinition definition)
        {
            var expression = new CustomSeparatorExpression(input, definition);
            SepartorList = expression.Value;
            var operationInput = input.Substring(FirstOccurranceOfDigit(input));
            Numbers = ExtractNumbers(operationInput, SepartorList);
        }
    }
}
