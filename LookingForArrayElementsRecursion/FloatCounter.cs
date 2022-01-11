﻿using System;

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Arrays of range starts and range ends contain different number of elements.");
            }

            if (rangeStart[0] > rangeEnd[0] || rangeStart[^1] > rangeEnd[^1])
            {
                throw new ArgumentException("The range start value is greater than the range end value.");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < rangeStart.Length; i++)
            {
                if (arrayToSearch[0] >= rangeStart[i] && arrayToSearch[0] <= rangeEnd[i])
                {
                    sum++;
                }
            }

            return sum + GetFloatsCount(arrayToSearch[1..], rangeStart, rangeEnd);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Arrays of range starts and range ends contain different number of elements.");
            }

            if (rangeStart[0] > rangeEnd[0] || rangeStart[^1] > rangeEnd[^1])
            {
                throw new ArgumentException("The range start value is greater than the range end value.");
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

            int sum = 0;
            for (int i = 0; i < rangeStart.Length; i++)
            {
                if (arrayToSearch[startIndex] >= rangeStart[i] && arrayToSearch[startIndex] <= rangeEnd[i])
                {
                    sum++;
                }
            }

            return sum + GetFloatsCount(arrayToSearch[1..], rangeStart, rangeEnd, startIndex, count - 1);
        }
    }
}
