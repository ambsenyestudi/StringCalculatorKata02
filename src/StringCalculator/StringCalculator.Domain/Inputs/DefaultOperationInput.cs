using StringCalculatorKata.Domain.Operation;
using StringCalculatorKata.Domain.Separators;
using System.Collections.Generic;

namespace StringCalculatorKata.Domain.Inputs
{
    public class DefaultOperationInput : OperationInput
    {
        public DefaultOperationInput(string input, IList<Separator> separatorList)
        {
            OperationExpression = new DefaultOperationExpression(input, separatorList);
        }
    }
}
