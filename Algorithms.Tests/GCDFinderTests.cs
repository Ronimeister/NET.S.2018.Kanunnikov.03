using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Algorithms.Tests
{
    [TestFixture]
    public class GCDFinderTests
    {
        #region Euclidian method tests
        [TestCase(15, 20, ExpectedResult = 5)]
        [TestCase(16, 35, ExpectedResult = 1)]
        [TestCase(0, 7, ExpectedResult = 7)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-6, 7, ExpectedResult = 1)]
        [TestCase(-6, -7, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int EuclideanGCD_2Args_IsCorrect(int firstNumber, int secondNumber)
        {
            (int result, _) = GCDFinder.EuclideanGCD(firstNumber, secondNumber);
            return result;
        }

        [TestCase(15, 20, 30, ExpectedResult = 5)]
        [TestCase(15, 17, 19, ExpectedResult = 1)]
        [TestCase(-15, 20, -30, ExpectedResult = 5)]
        [TestCase(0, 20, -30, ExpectedResult = 10)]
        [TestCase(0, -20, 0, ExpectedResult = 20)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int EuclideanGCD_3Args_IsCorrect(int firstNumber, int secondNumber, int thirdNumber)
        {
            (int result, _) = GCDFinder.EuclideanGCD(firstNumber, secondNumber, thirdNumber);
            return result;
        }

        [TestCase(15, 20, 30, 40, ExpectedResult = 5)]
        [TestCase(13, 15, 17, 19, ExpectedResult = 1)]
        [TestCase(-15, 20, 30, -40, ExpectedResult = 5)]
        [TestCase(-15, -20, -30, -40, ExpectedResult = 5)]
        [TestCase(0, 20, 0, -40, ExpectedResult = 20)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int EuclideanGCD_ManyArgs_IsCorrect(params int[] numbers)
        {
            (int result, _) = GCDFinder.EuclideanGCD(numbers);
            return result;
        }

        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int EuclideanGCD_ManyArgs_TimeTest(params int[] numbers)
        {
            (int result, TimeSpan time) = GCDFinder.EuclideanGCD(numbers);
            Debug.WriteLine("Time required: " + time.Ticks); //Time required: 4602
            return result;
        }

        [TestCase(int.MinValue, int.MinValue)]
        public void EuclideanGCD_2Args_MinIntValue(int firstNumber, int secondNumber)
            => Assert.Throws<OverflowException>(() => GCDFinder.EuclideanGCD(firstNumber, secondNumber));

        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        public void EuclideanGCD_3Args_MinIntValue(int firstNumber, int secondNumber, int thirdNumber)
            => Assert.Throws<OverflowException>(() => GCDFinder.EuclideanGCD(firstNumber, secondNumber, thirdNumber));

        [TestCase(int.MinValue, int.MinValue, int.MinValue, int.MinValue)]
        public void EuclideanGCD_ManyArgs_MinIntValue(params int[] numbers)
            => Assert.Throws<OverflowException>(() => GCDFinder.EuclideanGCD(numbers));
        #endregion

        #region Stein method tests
        [TestCase(15, 20, ExpectedResult = 5)]
        [TestCase(16, 35, ExpectedResult = 1)]
        [TestCase(0, 7, ExpectedResult = 7)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-6, 7, ExpectedResult = 1)]
        [TestCase(-6, -7, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int SteinGCD_2Args_IsCorrect(int firstNumber, int secondNumber)
        {
            (int result, _) = GCDFinder.SteinGCD(firstNumber, secondNumber);
            return result;
        }

        [TestCase(15, 20, 30, ExpectedResult = 5)]
        [TestCase(15, 17, 19, ExpectedResult = 1)]
        [TestCase(-15, 20, -30, ExpectedResult = 5)]
        [TestCase(0, 20, -30, ExpectedResult = 10)]
        [TestCase(0, -20, 0, ExpectedResult = 20)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int SteinGCD_3Args_IsCorrect(int firstNumber, int secondNumber, int thirdNumber)
        {
            (int result, _) = GCDFinder.SteinGCD(firstNumber, secondNumber, thirdNumber);
            return result;
        }

        [TestCase( 15, 20, 30, 40, ExpectedResult = 5)]
        [TestCase( 13, 15, 17, 19, ExpectedResult = 1)]
        [TestCase( -15, 20, 30, -40, ExpectedResult = 5)]
        [TestCase( -15, -20, -30, -40, ExpectedResult = 5)]
        [TestCase( 0, 20, 0, -40, ExpectedResult = 20)]
        [TestCase( 0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase( int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int SteinGCD_ManyArgs_IsCorrect(params int[] numbers)
        {
            (int result, _) = GCDFinder.SteinGCD(numbers);
            return result;
        }

        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int SteinGCD_ManyArgs_TimeTest(params int[] numbers)
        {
            (int result, TimeSpan time) = GCDFinder.SteinGCD(numbers);
            Debug.WriteLine("Time required: " + time.Ticks); //Time required: 5131
            return result;
        }

        [TestCase(int.MinValue, int.MinValue)]
        public void SteinGCD_2Args_MinIntValue(int firstNumber, int secondNumber)
            => Assert.Throws<OverflowException>(() => GCDFinder.SteinGCD(firstNumber, secondNumber));

        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        public void SteinGCD_3Args_MinIntValue(int firstNumber, int secondNumber, int thirdNumber)
            => Assert.Throws<OverflowException>(() => GCDFinder.SteinGCD(firstNumber, secondNumber, thirdNumber));

        [TestCase( int.MinValue, int.MinValue, int.MinValue, int.MinValue )]
        public void SteinGCD_ManyArgs_MinIntValue(params int[] numbers)
            => Assert.Throws<OverflowException>(() => GCDFinder.SteinGCD(numbers));
        #endregion
    }
}