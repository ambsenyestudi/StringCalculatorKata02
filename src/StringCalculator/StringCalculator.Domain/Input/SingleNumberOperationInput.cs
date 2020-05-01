using StringCalculatorKata.Domain.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorKata.Domain.Input
{
    public class SingleNumberOperationInput: OperationInput
    {
        public SingleNumberOperationInput(string input)
        {
            OperationExpression = new SingleNumberOperationExpression(input);
        }
    }
}
