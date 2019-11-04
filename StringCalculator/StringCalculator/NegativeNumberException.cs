using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(IEnumerable<int> negativeNumbers)
            : base($"Negatives numbers: {string.Join(",", negativeNumbers)}")
        { }
    }
}
