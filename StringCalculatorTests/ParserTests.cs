using System.Collections.Generic;
using Xunit;
using StringCalculator;

namespace StringCalculatorTests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(new string[] { ",", "\n"}, "1,2")]
        [InlineData(new string[] { ",", "\n", "#" }, "//#\n1,2#3")]
        public void ParseDelimeterTest(string[] expected, string input)
        {
            string[] result = Parser.ParseDelimiters(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, "1,2", new string[] { "," })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, "1,2,3,4,5,6", new string[] { "," })]
        [InlineData(new int[] { 1, 2, 3, 4 }, "1,2\n3,4", new string[] { ",", "\n" })]
        public void ParseNumbersTest(IEnumerable<int> expected, string input, string[] delimeters)
        {
            List<int> result = Parser.ParseNumbers(input, delimeters);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4}, "//#\n1,2\n3#4")]
        public void Parse_Delimeters_And_Numbers_Test(IEnumerable<int> expected, string input)
        {
            string[] delimeters = Parser.ParseDelimiters(input);
            List<int> result = Parser.ParseNumbers(input, delimeters);
            Assert.Equal(expected, result);
        }
    }
}
