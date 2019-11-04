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
    }
}
