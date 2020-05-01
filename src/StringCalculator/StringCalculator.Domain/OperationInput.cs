﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain
{
    public class OperationInput
    {
        private readonly CustomSeparatorExpression customSeparatorExpression;

        public IList<string> DefaultSeparators { get; }
        
        public IList<int> Numbers { get; private set; }
        public OperationInput(
            string operationExpression, 
            IList<string> defaultSeparators,
            SeparatorExpressionDefinition separatorDefinition)
        {
            
            DefaultSeparators = defaultSeparators;
            customSeparatorExpression = new CustomSeparatorExpression(operationExpression, separatorDefinition);
            Numbers = ProcessOperation(operationExpression);
            
        }
        public IList<int> ProcessOperation(string operationExpression)
        {
            if(IsAllDigits(operationExpression))
            {
                return new int[] { int.Parse(operationExpression) };
            }
            else if(customSeparatorExpression.HasValue)
            {
                var operationExpressionPart = ExtractOperationPart(operationExpression);
                return ExtractNumbers(operationExpressionPart, customSeparatorExpression.Value);
            }
            else if(ContainsSepartors(operationExpression, DefaultSeparators))
            {
                return ExtractNumbers(operationExpression, DefaultSeparators);
            }
            return new int []{ 0 };
        }
        public static bool IsAllDigits(string operationExpression) =>
            !string.IsNullOrWhiteSpace(operationExpression) &&
            operationExpression.All(x => char.IsDigit(x));

        private static bool ContainsSepartors(string operationExpression, IList<string> separators) =>
            operationExpression.Any(x => separators.Contains(x.ToString()));
        
        public string ExtractOperationPart(string input) =>
            input.Substring(FirstOccurranceOfDigit(input));
        public int FirstOccurranceOfDigit(string input)
        {
            var indexedCharCollection = input.Select((x, i) => new { Index = i, Char = x });
            if (!indexedCharCollection.Any())
            {
                return -1;
            }
            return indexedCharCollection.First(x => char.IsDigit(x.Char)).Index;
        }
        public string GetSeparatorExpression(string numberInput, SeparatorExpressionDefinition definition)
        {
            if(string.IsNullOrWhiteSpace(numberInput))
            {
                return string.Empty;
            }
            var beforeDigits = numberInput.Substring(0, FirstOccurranceOfDigit(numberInput));
            if(!definition.IsExpressionMatch(beforeDigits))
            {
                return string.Empty;
            }
            return beforeDigits;
        }
        
        public IList<int> ExtractNumbers(string operationExpression, IList<string> separators)
        {
            var splitOperators = operationExpression
                    .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var splitNumbers = splitOperators
                .Select(x => int.Parse(x))
                .Where(x=>x<=1000)
                .ToList();
            if(splitNumbers.Any(x=> x < 0))
            { 
                throw new NegativeNumberExpection("Add can not operate negative numbers");
            }
            return splitNumbers;
        }
        public IList<int> ExtractNumbers(string operationExpression, IList<Separator> separators) =>
            ExtractNumbers(operationExpression, separators.Select(x => x.Value).ToArray());

    }
}
