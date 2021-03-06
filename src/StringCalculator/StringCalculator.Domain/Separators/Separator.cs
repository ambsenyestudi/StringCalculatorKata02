﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata.Domain.Separators
{
    public class Separator
    {
        public string Value { get; }
        public Separator(string value)
        {
            Value = value;
        }

        public static bool IsAnyLengthFormat(string evaluated)=>
            evaluated.Contains("[") && evaluated.Contains("]");
        public static bool IsSingleLetter(string evaluated) =>
            !IsAnyLengthFormat(evaluated);
        public static bool IsCustomSeparatorExpresssion(
            string separatorExpression,
            string expressionStart, 
            string expressionEnd)=>
            separatorExpression
            .StartsWith(expressionStart) && 
            separatorExpression.EndsWith(expressionEnd);
        
        private static IList<Separator> ExtractSeparatorsFromExpression(string expression)
        {
            if(IsAnyLengthFormat(expression))
            {
                List<Separator> list = ProcessBrackets(expression);
                return list;
            }
            return expression.Select(x => new Separator(x.ToString())).ToList();
        }

        private static List<Separator> ProcessBrackets(string expression)=>
            expression.Split("]")
            .Where(x=>x.Contains("["))
            .Select(x=>new Separator(x.Replace("[",""))).ToList();

        public static IList<Separator> FromExpression(string separatorExpression, string expressionStart, string expressionEnd)
        {
            if(IsCustomSeparatorExpresssion(separatorExpression, expressionStart, expressionEnd))
            {
                var separatorsPart = separatorExpression.Replace(expressionStart, "").Replace(expressionEnd, "");
                return ExtractSeparatorsFromExpression(separatorsPart);
            }
            throw new ArgumentException($"{nameof(separatorExpression)}: {separatorExpression} does not meet custom serparator format requirements");
        }

        public static implicit operator string (Separator s)=>s.Value;
        
    }
}
