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

        public static int Subtract(List<int> numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Count; ++i)
                result -= numbers[i];
            return result;
        }

        public static int Multiply(List<int> numbers)
        {
            return numbers.Aggregate(1, (x, y) => x * y);
        }

        public static float Divison(List<int> numbers)
        {
            float result = numbers[0];
            for (int i = 1; i < numbers.Count; ++i)
            {
                try
                {
                    result /= numbers[i];
                }
                catch (DivideByZeroException)
                {
                    throw new DivideByZeroException();
                }
            }
            return result;
        }

        public static string DisplayFormula(string operation, List<int> numbers)
        {
            return string.Join(operation, numbers) + " = ";
        }
    }
}
