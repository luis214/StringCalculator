using System;
using System.Collections.Generic;
using Xunit;
using StringCalculator;

namespace StringCalculatorTests
{
    public class SanitizeNumbersTests
    {
        [Fact]
        public void CheckForNegativeNumbersTests()
        {
            string input = "1,2,-3";
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            Assert.Throws<NegativeNumberException>(() => SanitizeNumbers.CheckForNegatives(numbers));
        }

        [Fact]
        public void RemoveBigNumbersTests()
        {
            string input = "1,1001,6,2000";
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            List<int> result = SanitizeNumbers.RemoveBigNumbers(numbers);
            List<int> expected = new List<int> { 1, 6 };
            Assert.Equal(expected, result);
        }
    }
}
