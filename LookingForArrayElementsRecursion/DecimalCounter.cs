using System;

#pragma warning disable S2368

namespace LookingForArrayElementsRecursion
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }

                if (ranges[i].Length != 0 && ranges[i].Length != 2)
                {
                    throw new ArgumentException(" The length of one of the ranges is less or greater than 2 or not equal to zero  ");
                }
            }

            if (arrayToSearch.Length == 0 || ranges.Length == 0)
            {
                return 0;
            }

            decimal[] suitable = Array.Empty<decimal>();

            for (int j = 0; j < ranges.Length; j++)
            {
                FindSuitableElements(ref suitable, ranges, arrayToSearch, 0);
            }

            return suitable.Length + GetDecimalsCount(arrayToSearch[1..], ranges);
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }

                if (ranges[i].Length != 0 && ranges[i].Length != 2)
                {
                    throw new ArgumentException(" The length of one of the ranges is less or greater than 2 or not equal to zero");
                }
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            if (count == 0)
            {
                return 0;
            }

            decimal[] suitable = Array.Empty<decimal>();

            for (int j = 0; j < ranges.Length; j++)
            {
                FindSuitableElements(ref suitable, ranges, arrayToSearch, startIndex);
            }

            return suitable.Length + GetDecimalsCount(arrayToSearch[1..], ranges, startIndex, count - 1);
        }

        private static bool HasDublicates(decimal[] array, decimal value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindSuitableElements(ref decimal[] suitable, decimal[][] ranges, decimal[] arrayToSearch, int index)
        {
            for (int j = 0; j < ranges.Length; j++)
            {
                bool rangeCriteria = ranges[j].Length != 0 && arrayToSearch[index] >= ranges[j][0] && arrayToSearch[index] <= ranges[j][1];
                if (rangeCriteria && !HasDublicates(suitable, arrayToSearch[index]))
                {
                    Array.Resize(ref suitable, suitable.Length + 1);
                    suitable[^1] = arrayToSearch[index];
                }
            }
        }
    }
}
