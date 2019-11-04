using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Parser
    {
        public static string[] ParseDelimiters(string input)
        {
            List<string> delimeters = new List<string>() { ",", "\n" };

            //Extract content in between // and \n
            string pattern = @"(?<=//)(.*?)\n";
            string delimeter_string = Regex.Match(input, pattern).ToString().Trim();
            if (!String.IsNullOrEmpty(delimeter_string))
            {
                delimeters.Add(delimeter_string);
            }

            return delimeters.ToArray();
        }

        public static List<int> ParseNumbers(string input, string[] delimeters)
        {
            List<int> numbers = new List<int>();
            string[] numbers_string;
            if (input.StartsWith("//"))
            {
                int firstNewLineIndex = input.IndexOf('\n');
                numbers_string = input.Substring(firstNewLineIndex + 1).Split(delimeters, StringSplitOptions.None);
            }
            else
            {
                numbers_string = input.Split(delimeters, StringSplitOptions.None);
            }

            bool maximum_reached = false;
            foreach (var value in numbers_string)
            {
                if (int.TryParse(value, out int number) && !maximum_reached)
                {
                    numbers.Add(number);
                }
                else if (numbers.Count < 2)
                {
                    // Empty field and invalid numbers are converted to 0.
                    // Maximum constraint is ONLY ignored/removed when all values in the list are valid numbers
                    numbers.Add(0);
                    if (numbers.Count == 2)
                        maximum_reached = true;
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
