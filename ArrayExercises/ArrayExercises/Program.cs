﻿using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = ReadNumber("N=", 2);

            long[] fibo = Fibonacci(n);

            PrintArrayLong("Fibonacci numbers", fibo);
        }

        static void Assignment1()
        {
            // Citire array
            int[] array = ReadArray("Array");

            PrintArray("Array", array);

            // calcul minim
            int min = Min(array);
            if (min == int.MinValue)
            {
                Console.WriteLine("Min cannot be calculated!");
            }
            else
            {
                Console.WriteLine($"Min={min}");
            }

            // calcul maxim
            int max = Max(array);
            if (min == int.MaxValue)
            {
                Console.WriteLine("Max cannot be calculated!");
            }
            else
            {
                Console.WriteLine($"Max={max}");
            }

            int element = ReadNumber("Element=", 0);
            int indexOfElement = IndexOf(array, element);
            if (indexOfElement == -1)
            {
                Console.WriteLine($"Element {element} was not found between the elements of the array");
            }
            else
            {
                Console.WriteLine($"Index of {element} = {indexOfElement}");
            }

            float avg = Average(array);
            Console.WriteLine($"Avg={avg}");
        }

        static void Assignment2()
        {
            // Citire array
            int[] array = ReadArray("Array");

            // asc
            // int[] array = { 5, 7, 1, 3 };
            // int[] array = { 9, 8, 7, 6, 5, 4, 3 };
            PrintArray("Array (original)=", array);

            int[] sortedArrayAsc = SelectionSort(array, SortOrder.Ascending);
            int[] sortedArrayDesc = SelectionSort(array, SortOrder.Descending);

            PrintArray("Array (asc)=", sortedArrayAsc);
            PrintArray("Array (desc)=", sortedArrayDesc);
        }

        static void Assignment3()
        {
            int n = ReadNumber("N=", 2);

            int[] primes = Primes(n);

            PrintArray("Prime numbers", primes);
        }

        static int ReadNumber(string label, int defaultValue)
        {
            Console.Write(label);
            string value = Console.ReadLine();
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return defaultValue;
        }

        static int[] ReadArray(string label)
        {
            Console.WriteLine(label);
            int nr = ReadNumber("Elements Count=", 0);
            int[] array = new int[nr];
            for (int i = 0; i < array.Length; i++)
            {
                int element = ReadNumber($"Element[{i}]=", 0);
                array[i] = element;
            }

            return array;
        }

        static void PrintArray(string label, int[] array)
        {
            Console.WriteLine();
            string elementsList = string.Join(", ", array);
            Console.WriteLine($"{label}={elementsList}");
        }

        static void PrintArrayLong(string label, long[] array)
        {
            Console.WriteLine();
            string elementsList = string.Join(", ", array);
            Console.WriteLine($"{label}={elementsList}");
        }

        /// <summary>
        /// Returns the minimum element from an array, 
        /// or int.MinValue if minimum cannot be calculated.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// The minimum element from an array, 
        /// or int.MinValue if minimum cannot be calculated.
        /// </returns>
        static int Min(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                // nu pot calcula minim
                return int.MinValue;
            }

            // pot calcula minim
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Returns the maximum element from an array, 
        /// or int.MaxValue if maximum cannot be calculated.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// The maximum element from an array, 
        /// or int.MaxValue if maximum cannot be calculated.
        /// </returns>
        static int Max(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                // nu pot calcula maxim
                return int.MaxValue;
            }

            // pot calcula maxim
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Returns the index of the specified element.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="element">The lookup element.</param>
        /// <returns>The zero based index of the specified element if found, -1 otherwise.</returns>
        static int IndexOf(int[] array, int element)
        {
            if (array is null || array.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                // element was found at index "i"
                if (array[i] == element)
                {
                    return i;
                }
            }

            // the element was not found in the array
            return -1;
        }

        static float Average(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return 0;
            }

            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum / array.Length;
        }

        static int[] Clone(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return new int[0];
            }

            int[] clone = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                clone[i] = array[i];
            }

            return clone;
        }

        static int[] BubbleSort(int[] array, SortOrder sortOrder)
        {
            int[] result = Clone(array);

            bool weHadSwaps;
            do
            {
                weHadSwaps = false;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    bool areElementsInCorrectOrder = true;
                    switch (sortOrder)
                    {
                        case SortOrder.Descending:
                            areElementsInCorrectOrder = result[i] > result[i + 1];
                            break;

                        case SortOrder.Ascending:
                        default:
                            areElementsInCorrectOrder = result[i] < result[i + 1];
                            break;
                    }

                    if (!areElementsInCorrectOrder)
                    {
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;

                        weHadSwaps = true;
                        break;
                    }
                }
            }
            while (weHadSwaps);

            return result;
        }

        static int[] SelectionSort(int[] array, SortOrder sortOrder)
        {
            int[] result = Clone(array);

            for (int i = 0; i < result.Length - 1; i++)
            {
                // sa aduc pe result[i] minimul din sub-sirul result[i+1] => capat
                for (int j = i + 1; j < result.Length; j++)
                {
                    bool areElementsInCorrectOrder = true;
                    switch (sortOrder)
                    {
                        case SortOrder.Descending:
                            areElementsInCorrectOrder = result[i] > result[j];
                            break;

                        case SortOrder.Ascending:
                        default:
                            areElementsInCorrectOrder = result[i] < result[j];
                            break;
                    }

                    if (!areElementsInCorrectOrder)
                    {
                        // swap: result[i] = result[j];
                        int temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }

            return result;
        }

        static int[] Primes(int n)
        {
            // 0 -> n
            // wasCut[i] = 0 (false): daca numarul "i" NU a fost taiat (este prim)
            // wasCut[i] = 1 (true): daca numarul "i" A fost taiat (nu este prim)

            bool[] wasCut = new bool[n + 1];
            int primesCount = 0;
            for (int i = 2; i <= n; i++)
            {
                if (!wasCut[i])
                {
                    // am un nr prim
                    primesCount++;

                    for (int factor = 2; factor * i <= n; factor++)
                    {
                        wasCut[i * factor] = true;
                    }
                }
            }

            int[] result = new int[primesCount];
            for (int i = 2, idxResult = 0; i < wasCut.Length; i++)
            {
                if (!wasCut[i])
                {
                    result[idxResult] = i;
                    idxResult++;
                }
            }

            return result;
        }

        static long[] Fibonacci(int n)
        {
            if (n == 0)
            {
                // Fib(0) = 0;
                return new long[] { 0 };
            }

            if (n == 1)
            {
                // Fib(1) = 1;
                return new long[] { 0, 1 };
            }

            long[] fibo = new long[n + 1];
            fibo[0] = 0;
            fibo[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
            }

            return fibo;
        }
    }
}
