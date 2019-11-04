using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(List<int> numbers)
        {
            return numbers.Sum();
        }

        public static string DisplayFormula(string operation, List<int> numbers)
        {
            return string.Join(operation, numbers) + " = ";
        }
    }
}
