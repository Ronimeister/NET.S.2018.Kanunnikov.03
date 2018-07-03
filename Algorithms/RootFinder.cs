using System;

namespace Algorithms
{
    /// <summary>
    /// Class that allows to find Nth power root of double number with some accuracy.
    /// </summary>
    public static class RootFinder
    {
        #region Public API
        /// <summary>
        /// Public API of the class that check input data for the mistakes and return needed value.
        /// </summary>
        /// <param name="number">Number, which root we need to find.</param>
        /// <param name="power">Root degree.</param>
        /// <param name="accuracy">Accuracy of measurement.</param>
        /// <returns>Nth root in form of real number.</returns>
        public static double FindRoot(double number, int power, double accuracy)
        {
            if (accuracy <= 0 || accuracy >= 1)
            {
                throw new ArgumentException($"{nameof(accuracy)} must contains value in range: (0, 1).");
            }

            if (power % 2 == 0 && number < 0)
            {
                throw new ArgumentException($"{nameof(number)} will get invalid value through the current operation.");
            }

            if (power <= 0)
            {
                throw new ArgumentException($"{nameof(power)} must be positive.");
            }

            if (power == 1)
            {
                return number;
            }

            return FindNthRoot(number, power, accuracy);
        }
        #endregion

        #region Private API
        /// <summary>
        /// Method that finds Nth root of the number. Realization of FindRoot() method.
        /// </summary>
        /// <param name="number">Number, which root we need to find.</param>
        /// <param name="power">Root degree.</param>
        /// <param name="accuracy">Accuracy of measurement.</param>
        /// <returns>Nth root in form of real number.</returns>
        private static double FindNthRoot(double number, int power, double accuracy)
        {
            double current = 1;
            double next = SetNewIterationValue(current, power, number);

            while (Math.Abs(current - next) >= accuracy)
            {
                current = next;
                next = SetNewIterationValue(current, power, number);
            }

            return next;
        }

        /// <summary>
        /// Method that set new value for the Newton algorithm.
        /// </summary>
        /// <param name="current">Current value of needed root value.</param>
        /// <param name="power">Root degree.</param>
        /// <param name="accuracy">Accuracy of measurement.</param>
        /// <returns>New value for the Newton algorithm.</returns>
        private static double SetNewIterationValue(double current, int power, double number)
            => (((power - 1) * current) + (number / Math.Pow(current, power - 1))) / power;
        #endregion
    }
}
