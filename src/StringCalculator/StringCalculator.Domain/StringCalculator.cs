using StringCalculatorKata.Domain.Inputs;
using StringCalculatorKata.Domain.Separators;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        private readonly IList<string> defaultSeparatorList;
        private const string CUSTOM_SEPARATORS_STARTER = "//";
        private const string NEW_LINE = "\n";

        public StringCalculator()
        {
            defaultSeparatorList = new string[] { ",", NEW_LINE };
        }
        public int Add(string numberInput)
        {
            var operation = CreateOperationFromInput(numberInput);
            return operation.Numbers.Sum();
        }
        private OperationInput CreateOperationFromInput(string numberInput)
        {
            if (OperationInput.IsSingleOrNoDigit(numberInput))
            {
                return OperationInput
                    .CreateNoSeparatorInput(numberInput);
            }

            var definition = CustomSeparatorDefinition();
            if(definition.IsIn(numberInput))
            {
                return OperationInput.CreateCustomSeparatedOperationInput(
                    numberInput,
                    definition);
            }
            return OperationInput.CreateDefaultOperationInput(
                numberInput, 
                defaultSeparatorList);
        }

        private SeparatorExpressionDefinition CustomSeparatorDefinition() => 
            new SeparatorExpressionDefinition(
                     CUSTOM_SEPARATORS_STARTER,
                     NEW_LINE);
    }
}
