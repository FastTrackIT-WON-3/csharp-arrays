using System;

namespace ArrayExercises
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
