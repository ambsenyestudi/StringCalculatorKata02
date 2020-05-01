using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorKata.Domain
{
    public class SeparatorExpressionDefinition
    {
        public string Starting { get; }
        public string Ending { get; }

        public SeparatorExpressionDefinition(string starting, string ending)
        {
            Starting = starting;
            Ending = ending;
        }
        public bool IsExpressionMatch(string expression) =>
            expression.StartsWith(Starting) && 
            expression.EndsWith(Ending);
    }
}
