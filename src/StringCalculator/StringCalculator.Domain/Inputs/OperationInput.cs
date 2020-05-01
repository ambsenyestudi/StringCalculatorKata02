using StringCalculatorKata.Domain.Operation;
using StringCalculatorKata.Domain.Separators;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain.Inputs
{
    public abstract class OperationInput
    {
        public IList<int> Numbers { get => OperationExpression.Numbers; }
        public OperationExpression OperationExpression { get; protected set; }
        public static bool IsSingleOrNoDigit(string input) => 
            SingleNumberOperationExpression.IsAllDigits(input);
        public static bool ContainsDefinition(string input, SeparatorExpressionDefinition separatorDefinition)
        {
            var expresssion = new CustomSeparatorExpression(input, separatorDefinition);
            return expresssion.HasValue;
        }
        public static OperationInput CreateNoSeparatorInput(string input)=>
            new SingleNumberOperationInput(input);
        public static OperationInput CreateDefaultOperationInput(string input, IList<string> rawSeparatorCollection)
        {
            var separatorList = rawSeparatorCollection.Select(x => new Separator(x)).ToArray();
            return new DefaultOperationInput(input, separatorList);
        }

        public static OperationInput CreateCustomSeparatedOperationInput(string numberInput, SeparatorExpressionDefinition customSeparatorDefinition)
        {
            return new CustomSeparatorOperationInput(numberInput, customSeparatorDefinition);
        }
    }
}
