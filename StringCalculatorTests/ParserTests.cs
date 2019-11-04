using System.Collections.Generic;
using Xunit;
using StringCalculator;
namespace StringCalculatorTests
{
    public class ParserTests
    {
        [Theory]
        [InlineData(new string[] { ","}, "1,2")]
        public void ParseDelimeterTest(string[] expected, string input)
        {
            string[] result = Parser.ParseDelimiters(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, "1,2", new string[] { "," })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, "1,2,3,4,5,6", new string[] { "," })]
        public void ParseNumbersTest(IEnumerable<int> expected, string input, string[] delimeters)
        {
            List<int> result = Parser.ParseNumbers(input, delimeters);
            Assert.Equal(expected, result);
        }
    }
}
