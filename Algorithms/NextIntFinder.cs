using System;
using System.Diagnostics;

namespace Algorithms
{
    /// <summary>
    /// Class that allows to find next big Int32 value. 
    /// </summary>
    public static class NextIntFinder
    {
        #region Public API
        /// <summary>
        /// Public method that finds the next Int32 number that contains digits of <param name="number">.
        /// </summary>
        /// <param name="number">Number which digits should be used to find the result.</param>
        /// <exception cref="ArgumentException">Throws when the number is less than 0.</exception>
        /// <returns>Int32 value that bigger than <param name="number"> and contains <param name="number"> digits.</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} must be positive!");
            }

            if (number < 12)
            {
                return -1;
            }

            if (number.Equals(int.MaxValue))
            {
                return number;
            }

            return FindNextNumber(number);
        }

        /// <summary>
        /// Public method that finds the next Int32 number that contains digits of <param name="number">.
        /// </summary>
        /// <param name="number">Number which digits should be used to find the result.</param>
        /// <param name="delay">TimeSpan value that equals to method lead time.</param>
        /// <returns>Int32 value that bigger than <param name="number"> and contains <param name="number"> digits.</returns>
        public static int FindNextBiggerNumber(int number, out TimeSpan delay)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            stopWatch.Start();
            int result = FindNextBiggerNumber(number);
            stopWatch.Stop();

            delay = stopWatch.Elapsed;

            return result;
        }
        #endregion

        #region Private API
        /// <summary>
        /// Private realization of "FindNextBiggerNumber()" method.
        /// </summary>
        /// <param name="number">Number which digits should be used to find the result.</param>
        /// <returns>Int32 value that bigger than <param name="number"> and contains <param name="number"> digits.</returns>
        private static int FindNextNumber(int number)
        {
            int[] digits = IntToDigitsArray(number);
            int startPosition = FindStartPosition(digits);

            if (startPosition == 0 || startPosition == -1)
            {
                return -1;
            }

            return FindNumber(digits, startPosition);
        }

        /// <summary>
        /// Convert Int32 value to int[] array.
        /// </summary>
        /// <param name="number">Number which digits should be converted to int[] array.</param>
        /// <returns>int[] array</returns>
        private static int[] IntToDigitsArray(int number)
        {
            int[] result = new int[GetDigitArrayLength(number)];
            for (int i = 0; i < result.Length; i++)
            {
                result[result.Length - i - 1] = number % 10;
                number /= 10;
            }

            return result;
        }

        /// <summary>
        /// Get length to int[] array using <param name="n"> value.
        /// </summary>
        /// <param name="n">Number which value should be used to find int[] length.</param>
        /// <returns>int[] length.</returns>
        private static int GetDigitArrayLength(int n)
        {
            if (n == 0)
            {
                return 1;
            }
                
            return 1 + (int)Math.Log10(n);
        }

        /// <summary>
        /// Find position in <param name="digits"> array from which  we should start "FindNumber()" algorithm.
        /// </summary>
        /// <param name="digits">int[] array which should be used to find the needed position.</param>
        /// <returns>Index of <param name="digits"> array.</returns>
        private static int FindStartPosition(int[] digits)
        {
            for (int j = digits.Length - 1; j > 0; j--)
            {
                if (digits[j] > digits[j - 1])
                {
                    return j;
                }
            }

            return -1;
        }

        /// <summary>
        /// Swap values of two elements.
        /// </summary>
        /// <param name="firstEl">First element need to swap.</param>
        /// <param name="secondEl">Second element need to swap.</param>
        private static void Swap(ref int firstEl, ref int secondEl)
        {
            int temp = firstEl;

            firstEl = secondEl;
            secondEl = temp;
        }

        /// <summary>
        /// Find int that contains <param name="digits"> values using <param name="startPos"> in <param name="digits">.
        /// </summary>
        /// <param name="digits">int[] which values should be used to get the result number.</param>
        /// <param name="startPos">Position in <param name="digits">.</param>
        /// <returns>Int32 value that bigger than contains <param name="number"> digits.</returns>
        private static int FindNumber(int[] digits, int startPos)
        {
            Swap(ref digits[startPos], ref digits[startPos - 1]);
            Array.Sort(digits, startPos, digits.Length - startPos);

            return DigitsArrayToInt(digits);
        }

        /// <summary>
        /// Convert int[] to int.
        /// </summary>
        /// <param name="digits">int[] which should be used to get int value.</param>
        /// <exception cref="OverflowException">Throws when the int[] if bigger than int.MaxValue</exception>
        /// <returns>int value.</returns>
        private static int DigitsArrayToInt(int[] digits)
        {
            int result = 0;
            try
            {
                result = int.Parse(string.Join(string.Empty, digits));
                return result;
            }
            catch(OverflowException e)
            {
                throw new OverflowException(e.Message);
            }
        }
        #endregion
    }
}
