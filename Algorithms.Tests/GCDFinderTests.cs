using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    public class GCDFinderTests
    {
        [TestCase(15, 20, ExpectedResult = 5)]
        [TestCase(15, 20, 30, ExpectedResult = 5)]
        [TestCase(-15, 20, -30, ExpectedResult = 5)]
        [TestCase(0, 20, -30, ExpectedResult = 10)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(13, 3, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int EuclideanGCD_IsCorrect(int firstNumber, int secondNumber, params int[] numbers)
            => GCDFinder.EuclideanGCD(firstNumber, secondNumber, numbers);

        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        public void EuclideanGCD_MinIntValue(int firstNumber, int secondNumber, params int[] numbers)
            => Assert.Throws<OverflowException>(() => GCDFinder.EuclideanGCD(firstNumber, secondNumber, numbers));

        [TestCase(15, 20, ExpectedResult = 5)]
        [TestCase(15, 20, 30, ExpectedResult = 5)]
        [TestCase(-15, 20, -30, ExpectedResult = 5)]
        [TestCase(0, 20, -30, ExpectedResult = 10)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(13, 3, ExpectedResult = 1)]
        public int SteinGCD_IsCorrect(int firstNumber, int secondNumber, params int[] numbers)
            => GCDFinder.SteinGCD(firstNumber, secondNumber, numbers);

        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        public void SteinGCD_MinIntValue(int firstNumber, int secondNumber, params int[] numbers)
            => Assert.Throws<OverflowException>(() => GCDFinder.SteinGCD(firstNumber, secondNumber, numbers));
    }
}
