using StringCalculatorKata.Domain.Operation;
using System.Collections.Generic;

namespace StringCalculatorKata.Domain.Input
{
    public class DefaultOperationInput : OperationInput
    {
        public DefaultOperationInput(string input, IList<Separator> separatorList)
        {
            OperationExpression = new DefaultOperationExpression(input, separatorList);
        }
    }
}
