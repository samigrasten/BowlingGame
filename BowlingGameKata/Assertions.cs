using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGameKata
{
    public static class Assertions
    {
        public static void AssertIsPositive(this int value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Value must be positive");
        }

        public static void AssertIsLessOrEqual(this int value, int maxValue)
        {
            if (value > maxValue) throw new ArgumentOutOfRangeException(nameof(value), $"Value must be less than {maxValue}");
        }
    }
}
