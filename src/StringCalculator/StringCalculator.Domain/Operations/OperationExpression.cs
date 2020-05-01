using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain.Operation
{
    public class OperationExpression
    {
        public IList<int> Numbers { get; protected set; }
        public static int FirstOccurranceOfDigit(string input)
        {
            var indexedCharCollection = input.Select((x, i) => new { Index = i, Char = x });
            if (!indexedCharCollection.Any())
            {
                return -1;
            }
            return indexedCharCollection.First(x => char.IsDigit(x.Char)).Index;
        }
    }
}
