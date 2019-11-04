using System;

namespace StringCalculator
{
    public class MaximumConstraintException : Exception
    {
        public MaximumConstraintException()
           : base($"Exceeds 2 numbers")
        { }
    }
}