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
        /// Public method that allows to get GCD value using Euclidean algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Additional numbers.</param>
        /// <returns>Needed GCD.</returns>
        public static int EuclideanGCD(int firstNumber, int secondNumber, params int[] numbers)
        {
            if(firstNumber.Equals(int.MinValue) || secondNumber.Equals(int.MinValue) || IsContainsMinInt(numbers))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            int classicGCD = GetClassicGCD(firstNumber, secondNumber);
            if (numbers.Length == 0)
            {
                return classicGCD;
            }

            return GetExtendedGCD(GetClassicGCD, firstNumber, secondNumber, numbers);
        }

        /// <summary>
        /// Public method that allows to get GCD value using Stein algorithm.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Additional numbers.</param>
        /// <returns>Needed GCD.</returns>
        public static int SteinGCD(int firstNumber, int secondNumber, params int[] numbers)
        {
            if (firstNumber.Equals(int.MinValue) || secondNumber.Equals(int.MinValue) || IsContainsMinInt(numbers))
            {
                throw new OverflowException($"Parametrs must not be equal to int.MinValue!");
            }

            int binaryGCD = GetBinaryGCD(firstNumber, secondNumber);
            if (numbers.Length == 0)
            {
                return binaryGCD;
            }

            return GetExtendedGCD(GetBinaryGCD, firstNumber, secondNumber, numbers);
        }

        /// <summary>
        /// Public method that allows to see how long does it take to execute needed GCDFinder method.
        /// </summary>
        /// <param name="GCD">GCDFinder method.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="numbers">Additional numbers.</param>
        /// <returns>Execution time.</returns>
        public static TimeSpan GetExecutionTime(Func<int, int, int[], int> GCD, int firstNumber, int secondNumber, params int[] numbers)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            stopWatch.Start();
            int result = GCD(firstNumber, secondNumber, numbers);
            stopWatch.Stop();

            TimeSpan timer = stopWatch.Elapsed;

            return timer;
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
        private static int GetExtendedGCD(Func<int, int, int> GCD, int firstNumber, int secondNumber, params int[] extendedNumbers)
        {
            int[] numbers = new int[extendedNumbers.Length + 2];
            InitializeExtendedGCDArray(numbers, firstNumber, secondNumber, extendedNumbers);

            return CalculateExtendedGCD(GCD, numbers);
        }

        /// <summary>
        /// Method that calculate GCD from any variety of numbers. Part of "GetExtendedGCD()" method.
        /// </summary>
        /// <param name="GCD">GCDFinder method.</param>
        /// <param name="array"></param>
        /// <returns>Needed GCD.</returns>
        private static int CalculateExtendedGCD(Func<int, int, int> GCD, params int[] array)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                result = GCD(array[i], result);
            }

            return result;
        }

        /// <summary>
        /// Method that initialize int[] from couple of arguments.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="extended">Additional numbers.</param>
        private static void InitializeExtendedGCDArray(int[] array, int first, int second, params int[] extended)
        {
            array[0] = first;
            array[1] = second;
            Array.Copy(extended, 0, array, 2, extended.Length);
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
                return secondNumber;
            }

            if (secondNumber == 0 || firstNumber == secondNumber)
            {
                return firstNumber;
            }

            return CalculateBinaryGCD(firstNumber, secondNumber);
        }

        /// <summary>
        /// Method that calculate GCD from any variety of numbers. Part of "GetBinaryGCD()" method.
        /// </summary>
        /// <param name="GCD">GCDFinder method.</param>
        /// <param name="array"></param>
        /// <returns>Needed GCD.</returns>
        private static int CalculateBinaryGCD(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);

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
