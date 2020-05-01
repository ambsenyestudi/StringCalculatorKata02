using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class OperationInput
    {
        private CustomSeparatorExpression CustomSeparatorExpression;
        private OperationExpression OperationExpression { get; }
        public IList<Separator> DefaultSeparators { get; }
        
        public IList<int> Numbers { get => OperationExpression.Numbers; }
        public OperationInput(
            string operationExpression, 
            IList<string> defaultSeparators,
            SeparatorExpressionDefinition separatorDefinition)
        {
            
            DefaultSeparators = defaultSeparators.Select(x=>new Separator(x)).ToList();
            CustomSeparatorExpression = new CustomSeparatorExpression(operationExpression, separatorDefinition);
            var separatos = CustomSeparatorExpression.HasValue ? CustomSeparatorExpression.Value : DefaultSeparators;
            operationExpression = ExtractOperationPart(operationExpression);
            OperationExpression = new OperationExpression(operationExpression, separatos);
            
        }
        public string ExtractOperationPart(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            return input.Substring(OperationExpression.FirstOccurranceOfDigit(input));
        }

            

    }
}
