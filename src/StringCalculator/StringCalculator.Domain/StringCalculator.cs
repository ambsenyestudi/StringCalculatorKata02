using StringCalculatorKata.Domain.Input;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class StringCalculator
    {
        private readonly IList<string> defaultSeparatorList;
        private readonly SeparatorExpressionDefinition CustomSeparatorDefinition;
        private const string CUSTOM_SEPARATORS_STARTER = "//";
        private const string NEW_LINE = "\n";

        public StringCalculator()
        {
            CustomSeparatorDefinition = new SeparatorExpressionDefinition(
                CUSTOM_SEPARATORS_STARTER,
                NEW_LINE);
            defaultSeparatorList = new string[] { ",", NEW_LINE };
        }
        public int Add(string numberInput)
        {
            //var operationInput = new BasicOperationInput(numberInput, defaultSeparatorList, CustomSeparatorDefinition);
            if(OperationInput.IsSingleOrNoDigit(numberInput))
            {
                return OperationInput
                    .CreateNoSeparatorInput(numberInput).Numbers
                    .Sum();
            }
            else if(OperationInput.IsCustomSeparatorDefinition(numberInput, CustomSeparatorDefinition))
            {
                return OperationInput
                    .CreateCustomSeparatedOperationInput(numberInput, CustomSeparatorDefinition).Numbers
                    .Sum();
            }
            return OperationInput
                .CreateDefaultOperationInput(numberInput, defaultSeparatorList).Numbers
                .Sum();
        }


    }
}
