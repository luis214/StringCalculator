using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class Parser
    {
        public static string[] ParseDelimiters(string input)
        {
            string[] delimeters = new string[1] { "," };

            return delimeters;
        }

        public static List<int> ParseNumbers(string input, string[] delimeters)
        {
            List<int> numbers = new List<int>();
            string[] numbers_string;
            numbers_string = input.Split(delimeters, StringSplitOptions.None);

            foreach (var value in numbers_string)
            {
                if (int.TryParse(value, out int number) && numbers.Count < 2)
                {
                    numbers.Add(number);
                }
                else if (numbers.Count < 2)
                {
                    // Empty field and invalid numbers are converted to 0.
                    numbers.Add(0);
                }
                else
                {
                    throw new MaximumConstraintException();
                }
            }

            return numbers;
        }
    }
}
