using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain.Separators
{
    public class CustomSeparatorExpression
    {
        public SeparatorExpressionDefinition Definition { get; }
        public IList<Separator> Value { get; }
        public bool HasValue 
        { 
            get => Value.Any(); 
        }
        public CustomSeparatorExpression(string expression, SeparatorExpressionDefinition definition)
        {
            Definition = definition;
            Value = ProcessExpression(expression);
        }

        private IList<Separator> ProcessExpression(string expression)
        {
            if(string.IsNullOrWhiteSpace(expression) || !expression.Contains(Definition.Ending))
            {
                return new List<Separator>();
            }
            var customSeparatorPart = expression.Substring(0, expression.LastIndexOf(Definition.Ending)+1);
            if(!Definition.IsExpressionMatch(customSeparatorPart))
            {
                return new List<Separator>();
            }
            return Separator.FromExpression(customSeparatorPart, Definition.Starting, Definition.Ending);
        }

    }
}
