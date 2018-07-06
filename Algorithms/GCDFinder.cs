using System;
using System.Diagnostics;

namespace Algorithms
{
    /// <summary>
    /// Class that allows to get GCD.
    /// </summary>
    public static class GCDFinder
    {
        #region Public API
        /// <summary>
        /// Public method that allows to get GCD value using Euclidean algorithm and to see how long it takes to does it.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <exception cref="OverflowException">Throws when one of the parametrs is equal to int.MinValue.</exception>
        /// <returns>A ValueTuple that contains "result" and "time" fields.</returns>
        public static (int, TimeSpan) EuclideanGCD(int firstNumber, int secondNumber)
        {
            if (firstNumber.Equals(int.MinValue) || secondNumber.Equals(int.MinValue))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            int result = GetClassicGCD(firstNumber, secondNumber);

            stopWatch.Stop();
            TimeSpan time = stopWatch.Elapsed;
            return (result, time);
        }

        /// <summary>
        /// Public method that allows to get GCD value using Euclidean algorithm and to see how long it takes to does it.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <exception cref="OverflowException">Throws when one of the parametrs is equal to int.MinValue.</exception>
        /// <returns>A ValueTuple that contains "result" and "time" fields.</returns>
        public static (int, TimeSpan) EuclideanGCD(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber.Equals(int.MinValue) || secondNumber.Equals(int.MinValue) || thirdNumber.Equals(int.MinValue))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            int result = GetExtendedGCD(GetClassicGCD, firstNumber, secondNumber, thirdNumber);

            stopWatch.Stop();
            TimeSpan time = stopWatch.Elapsed;
            return (result, time);
        }

        /// <summary>
        /// Public method that allows to get GCD value using Euclidean algorithm and to see how long it takes to does it.
        /// </summary>
        /// <param name="numbers">Any quantity of numbers.</param>
        /// <exception cref="OverflowException">Throws when one of the parametrs is equal to int.MinValue.</exception>
        /// <returns>A ValueTuple that contains "result" and "time" fields.</returns>
        public static (int, TimeSpan) EuclideanGCD(params int[] numbers)
        {
            if (IsContainsMinInt(numbers))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            int result = GetExtendedGCD(GetClassicGCD, numbers);

            stopWatch.Stop();
            TimeSpan time = stopWatch.Elapsed;
            return (result, time);
        }

        /// <summary>
        /// Public method that allows to get GCD value using Stein algorithm and to see how long it takes to does it.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <exception cref="OverflowException">Throws when one of the parametrs is equal to int.MinValue.</exception>
        /// <returns>A ValueTuple that contains "result" and "time" fields.</returns>
        public static (int, TimeSpan) SteinGCD(int firstNumber, int secondNumber)
        {
            if (firstNumber.Equals(int.MinValue) || secondNumber.Equals(int.MinValue))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            int result = GetBinaryGCD(firstNumber, secondNumber);

            stopWatch.Stop();
            TimeSpan time = stopWatch.Elapsed;
            return (result, time);
        }

        /// <summary>
        /// Public method that allows to get GCD value using Stein algorithm and to see how long it takes to does it.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="thirdNumber">Third number.</param>
        /// <exception cref="OverflowException">Throws when one of the parametrs is equal to int.MinValue.</exception>
        /// <returns>A ValueTuple that contains "result" and "time" fields.</returns>
        public static (int, TimeSpan) SteinGCD(int firstNumber, int secondNumber, int thirdNumber)
        {
            if (firstNumber.Equals(int.MinValue) || secondNumber.Equals(int.MinValue) || thirdNumber.Equals(int.MinValue))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            int result = GetExtendedGCD(GetBinaryGCD, firstNumber, secondNumber, thirdNumber);

            stopWatch.Stop();
            TimeSpan time = stopWatch.Elapsed;
            return (result, time);
        }

        /// <summary>
        /// Public method that allows to get GCD value using Stein algorithm and to see how long it takes to does it.
        /// </summary>
        /// <param name="numbers">Any quantity of numbers.</param>
        /// <exception cref="OverflowException">Throws when one of the parametrs is equal to int.MinValue.</exception>
        /// <returns>A ValueTuple that contains "result" and "time" fields.</returns>
        public static (int, TimeSpan) SteinGCD(params int[] numbers)
        {
            if (IsContainsMinInt(numbers))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();

            int result = GetExtendedGCD(GetBinaryGCD, numbers);

            stopWatch.Stop();
            TimeSpan time = stopWatch.Elapsed;
            return (result, time);
        }
        #endregion

        #region Private API
        /// <summary>
        /// Simple GCD method.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Needed GCD.</returns>
        private static int GetClassicGCD(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return Math.Abs(secondNumber);
            }

            return GetClassicGCD(secondNumber % firstNumber, firstNumber);
        }

        /// <summary>
        /// Method that finds GCD from any variety of numbers.
        /// </summary>
        /// <param name="GCD">GCDFinder method.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Additional numbers.</param>
        /// <returns>Needed GCD.</returns>
        private static int GetExtendedGCD(Func<int, int, int> GCD, params int[] extendedNumbers)
        {
            int result = extendedNumbers[0];
            for (int i = 1; i < extendedNumbers.Length; i++)
            {
                result = GCD(extendedNumbers[i], result);
            }

            return result;
        }

        /// <summary>
        /// Binary GCD method.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <returns>Needed GCD.</returns>
        private static int GetBinaryGCD(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0)
            {
                return Math.Abs(secondNumber);
            }

            if (secondNumber == 0 || firstNumber == secondNumber)
            {
                return Math.Abs(firstNumber);
            }

            return CalculateBinaryGCD(Math.Abs(firstNumber), Math.Abs(secondNumber));
        }

        /// <summary>
        /// Method that calculate GCD from any variety of numbers. Part of "GetBinaryGCD()" method.
        /// </summary>
        /// <param name="GCD">GCDFinder method.</param>
        /// <param name="array"></param>
        /// <returns>Needed GCD.</returns>
        private static int CalculateBinaryGCD(int first, int second)
        {
            if (first == second)
            {
                return first;
            }
                
            if (first == 0)
            {
                return second;
            }
                
            if (second == 0)
            {
                return first;
            }
                
            if ((~first & 1) != 0)
            {
                if ((second & 1) != 0)
                {
                    return CalculateBinaryGCD(first >> 1, second);
                }
                else
                {
                    return CalculateBinaryGCD(first >> 1, second >> 1) << 1;
                }
                    
            }
            if ((~second & 1) != 0)
            {
                return CalculateBinaryGCD(first, second >> 1);
            }
                
            if (first > second)
            {
                return CalculateBinaryGCD((first - second) >> 1, second);
            }
                
            return CalculateBinaryGCD((second - first) >> 1, first);
        }

        /// <summary>
        /// Method that check if there is int.MinValue in additional parametrs.
        /// </summary>
        /// <param name="numbers">Additional numbers.</param>
        /// <returns>Boolean result.</returns>
        private static bool IsContainsMinInt(params int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (i.Equals(int.MinValue))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
