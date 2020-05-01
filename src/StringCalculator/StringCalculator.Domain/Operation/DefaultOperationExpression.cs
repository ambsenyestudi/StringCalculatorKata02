using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain.Operation
{
    public class DefaultOperationExpression: OperationExpression
    {
        public IList<Separator> SepartorList { get; protected set; }
        protected DefaultOperationExpression()
        {

        }
        public DefaultOperationExpression(string input, IList<Separator> separatorList)
        {
            SepartorList = separatorList;
            Numbers = ExtractNumbers(input, separatorList);
        }

        public IList<int> ExtractNumbers(string operationExpression, IList<string> separatorList)
        {
            var splitOperators = operationExpression
                    .Split(separatorList.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var splitNumbers = splitOperators
                .Select(x => int.Parse(x))
                .Where(x => x <= 1000)
                .ToList();
            if (splitNumbers.Any(x => x < 0))
            {
                throw new NegativeNumberExpection("Add can not operate negative numbers");
            }
            return splitNumbers;
        }
        public IList<int> ExtractNumbers(string operationExpression, IList<Separator> separators) =>
            ExtractNumbers(operationExpression, separators.Select(x => x.Value).ToArray());
    }
}
