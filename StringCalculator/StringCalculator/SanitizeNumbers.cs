using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class SanitizeNumbers
    {
        public static void CheckForNegatives(List<int> numbers)
        {
            List<int> negativeNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }
            }

            if (negativeNumbers.Count > 0)
            {
                throw new NegativeNumberException(negativeNumbers);
            }
        }

        public static List<int> RemoveBigNumbers(List<int> numbers, int maximum_value = 1000)
        {
            numbers.RemoveAll(value => value > maximum_value);
            return numbers;
        }
    }
}
