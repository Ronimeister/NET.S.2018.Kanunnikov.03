using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class NextIntFinderTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        public int FindNextBiggerNumber_IsCorrect(int number)
        {
            int result = NextIntFinder.FindNextBiggerNumber(number, out TimeSpan time);
            Debug.WriteLine($"{nameof(FindNextBiggerNumber_IsCorrect)}: time is {time}");

            return result;
        }

        [TestCase(-10)]
        [TestCase(int.MinValue)]
        public void FindNextBiggerNumber_NonPositiveValue(int number)
            => Assert.Throws<ArgumentException>(() => NextIntFinder.FindNextBiggerNumber(number, out _));

        [TestCase(int.MaxValue-1)]
        public void FindNextBiggerNumber_TooBigValue(int number)
            => Assert.Throws<OverflowException>(() => NextIntFinder.FindNextBiggerNumber(number, out _));
    }
}
