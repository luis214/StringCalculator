using System;
using System.Collections.Generic;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers;
            string[] delimeters;
            string string_input, alt_delimeter;
            int maximum_value;

            Console.WriteLine("STRING CALCULATOR\n");

            Console.Write("Enter string: ");
            string_input = Console.ReadLine().Replace("\\n", "\n");

            Console.Write("Enter alternate delimeter: ");
            alt_delimeter = Console.ReadLine().Replace("\\n", "\n");

            delimeters = Parser.ParseDelimiters(string_input, alt_delimeter);
            numbers = Parser.ParseNumbers(string_input, delimeters);

            Console.Write("Allow negative numbers (y/n)? ");
            if (Console.ReadLine() == "n")
                SanitizeNumbers.CheckForNegatives(numbers);

            Console.Write("Enter maximum value: ");
            maximum_value = Convert.ToInt32(Console.ReadLine());
            numbers = SanitizeNumbers.RemoveBigNumbers(numbers, maximum_value);

            Console.WriteLine(Calculator.DisplayFormula("+", numbers) + Calculator.Add(numbers));
            
        }
    }
}
