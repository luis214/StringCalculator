using System;
using System.Collections.Generic;
using Xunit;
using StringCalculator;

namespace StringCalculatorTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "1,2")]
        [InlineData(4, "4,")]
        [InlineData(5, "5,xyz")]
        public void AddTest(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            int result = Calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3")]
        [InlineData("1,2,xyz")]
        [InlineData("1,,3")]
        public void ThrowException_MaximumConstraintExceeded(string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            Assert.Throws<MaximumConstraintException>(() => Parser.ParseNumbers(input, delimeters));
        }
    }
}
