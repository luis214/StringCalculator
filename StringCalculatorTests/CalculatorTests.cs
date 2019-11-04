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
        [InlineData(55, "1,2,3,4,5,6,7,8,9,10")]
        [InlineData(6, "1,2\n3")]
        public void AddTest(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            int result = Calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8, "1,1001,7,2000")]
        public void AddTest_RemoveBigNumbers(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            numbers = SanitizeNumbers.RemoveBigNumbers(numbers);
            int result = Calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, "//#\n1,2\n3#4")]
        [InlineData(3, "//#\n1#2")]
        [InlineData(3, "//[!!]\n1!!2")]
        [InlineData(110, "//[#][!!][r9r]\n11r9r22#33!!44")]
        public void AddTest_WithCustomDelimeters(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            int result = Calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,xyz")]
        [InlineData("1,,3")]
        public void ThrowException_MaximumConstraintExceeded(string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            Assert.Throws<MaximumConstraintException>(() => Parser.ParseNumbers(input, delimeters));
        }

        [Theory]
        [InlineData(0, "8,4,4")]
        public void SubtractionTest(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            int result = Calculator.Subtract(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(128, "8,4,4")]
        public void MultiplicationTest(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            int result = Calculator.Multiply(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "16,4,4")]
        public void DivisonTest(int expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            float result = Calculator.Divison(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1+2+3 = ", "+", "1,2,3")]
        [InlineData("1-2-3 = ", "-", "1,2,3")]
        [InlineData("1*2*3 = ", "*", "1,2,3")]
        [InlineData("1/2/3 = ", "/", "1,2,3")]
        public void DisplayFormulaTest(string expected, string operation, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> numbers = Parser.ParseNumbers(input, delimeters);
            string result = Calculator.DisplayFormula(operation, numbers);
            Assert.Equal(expected, result);
        }

    }
}
