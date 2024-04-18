using System;
using System.Collections.Generic;

namespace Assignment3
{
    /// <summary>
    /// Provides a library of statistical functions using generics for various statistical calculations.
    /// Reference: <see href="http://www.calculator.net/standard-deviation-calculator.html">Standard Deviation Calculator</see>
    /// </summary>
    /// <remarks>
    /// Class names and method names use PascalCasing. Local variables use camelCasing. Predefined type names are used.
    /// </remarks>
    public class StatisticsLibrary
    {
        /// <summary>
        /// Calculates the average of the provided data.
        /// </summary>
        /// <param name="values">The list of double precision values.</param>
        /// <param name="includeNegative">Includes negative values in the calculation if set to true.</param>
        /// <returns>The average of the list.</returns>
        /// <exception cref="ArgumentException">Thrown when the list contains no non-negative values.</exception>
        public static double CalculateAverage(List<double> values, bool includeNegative)
        {
            double sum = CalculateSum(values, includeNegative);
            int count = 0;
            foreach (double value in values)
            {
                if (includeNegative || value >= 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                throw new ArgumentException("Input list contains no values that are greater than zero.");
            }
            return sum / count;
        }

        /// <summary>
        /// Sums the provided list of values.
        /// </summary>
        /// <param name="values">The list of double precision values.</param>
        /// <param name="includeNegative">Includes negative values in the sum if set to true.</param>
        /// <returns>The sum of the list.</returns>
        /// <exception cref="ArgumentException">Thrown when the list is empty.</exception>
        public static double CalculateSum(List<double> values, bool includeNegative)
        {
            if (values.Count == 0)
            {
                throw new ArgumentException("Input list cannot be empty.");
            }

            double total = 0.0;
            foreach (double value in values)
            {
                if (includeNegative || value >= 0)
                {
                    total += value;
                }
            }
            return total;
        }

        /// <summary>
        /// Calculates the median of the provided data.
        /// </summary>
        /// <param name="data">The list of double precision values, sorted in ascending order.</param>
        /// <returns>The median value.</returns>
        /// <exception cref="ArgumentException">Thrown when the data list is empty.</exception>
        public static double CalculateMedian(List<double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("Data cannot be empty.");
            }

            data.Sort();
            int middleIndex = data.Count / 2;

            return data.Count % 2 != 0 ? data[middleIndex] : (data[middleIndex - 1] + data[middleIndex]) / 2.0;
        }

        /// <summary>
        /// Calculates the standard deviation of the provided data.
        /// </summary>
        /// <param name="data">The list of double precision values.</param>
        /// <returns>The standard deviation.</returns>
        /// <exception cref="ArgumentException">Thrown when the data list is empty or has only one element.</exception>
        public static double CalculateStandardDeviation(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Data must contain more than one element.");
            }

            double mean = CalculateAverage(data, true);
            double sumOfSquares = 0.0;
            foreach (double value in data)
            {
                sumOfSquares += Math.Pow(value - mean, 2);
            }
            return Math.Sqrt(sumOfSquares / (data.Count - 1));
        }

        static void Main()
        {
            Console.WriteLine("Sample Output for Statistical Functions Library");
            List<double> testData = new List<double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };
            Console.WriteLine("The sum of the array = {0}", CalculateSum(testData, true));
            Console.WriteLine("The average of the array = {0}", CalculateAverage(testData, true));
            Console.WriteLine("The median value of the double data set = {0}", CalculateMedian(testData));
            Console.WriteLine("The sample standard deviation of the double test set = {0}\n", CalculateStandardDeviation(testData));
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
