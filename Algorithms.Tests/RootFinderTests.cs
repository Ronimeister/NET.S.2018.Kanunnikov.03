using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    public class RootFinderTests
    {
        [TestCase(1, 5, 0.000_001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.041_006_25, 4, 0.0001, 0.45)]
        [TestCase(0.027_9936, 7, 0.0001, 0.6)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004_241_979, 9, 0.000_000_01, 0.545)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        public void FindRoot_IsCorrect(double number, int power, double accuracy, double expectedResult) =>
            Assert.AreEqual(RootFinder.FindRoot(number, power, accuracy), expectedResult, accuracy);

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindRoot_Throws_ArgumentException(double number, int power, double accuracy)
            => Assert.Throws<ArgumentException>(() => RootFinder.FindRoot(number, power, accuracy));
    }
}
