using System;

namespace Basic13
{
    class Program
    {
        private const int Upper = 255;

        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 3, 5, 7, 9 };
            int[] array2 = new int[] { 4, 2, 90, -34, 5, -83 };
            int[] array3 = new int[] { 2,3 ,10 };
            int[] array4 = new int[] { 1, 3, 5, 7 };
            int[] array5 = new int[] { 1, 25, 100, 100 };
            int[] array6 = new int[] { 1, 5, 10, -2 };
            int[] array7 = new int[] { -1, -3, 2 };

            //Print255();
            //PrintOdds();
            //PrintSum();
            //LoopArray(array1);
            //FindMax(array2);
            //GetAverage(array3);
            //OddArray();
            //SquareArrayValues(array5);
            //EliminateNegatives(array6);
            //MinMaxAverage(array6);
            //ShiftArrayValues(array6);
            NumToString(array7);

        }

        // Print 1-255
        public static void Print255()
        {
            int i = 0;

            Console.WriteLine("Printing 1-255");
            while (i < Upper)
            {
                i++;
                Console.WriteLine(i);
            }

        }

        // Print odd numbers 1-255
        public static void PrintOdds()
        {
            for (int i = 0; i <= Upper; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Print sum of loop
        public static void PrintSum()
        {
            int sum = 0;

            for (int i = 0; i <= Upper; i++)
            {
                Console.Write($"Current sum: {sum}");
                sum = i + sum;
                Console.WriteLine($"\tNew sum: {sum}");

            }

            Console.WriteLine($"\nSum of 1-255: {sum}");
        }

        // Iterate through an array
        public static void LoopArray(int[] numbers)
        {
            // Write a function that would iterate through each item of the given integer array and 
            // print each value to the console. 

            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }

        }

        // Find the maximum value in an array
        public static int FindMax(int[] numbers)
        {
            /*
             * It would be better to assume that the first element is max
             * but that would only work if the list was sorted
             */

            int max = 0;

            foreach (var i in numbers)
            {
                if (i > max)
                {
                    max = i;
                }
            }

            Console.WriteLine("The max number of the array is: " + max);
            return max;
        }

        // Print the average of a given array
        public static void GetAverage(int[] numbers)
        {
            int sum = 0;
            int average = 0;

            foreach (var i in numbers)
            {
                sum = i + sum;
            }

            average = sum / numbers.Length;
            Console.WriteLine($"The average is: {average}");
        }

        // Return an odd array
        public static int[] OddArray()
        {
            // find the size of the array - returns 128
            int size = (255/2) + 1;

            // create array with size as the argument
            int[] odds = new int[size];

            int i = 0;
            for(int num = 1; num <= 255; num+=2)
            {
                odds[i] = num;
                i++;
            }
            return odds;
        }

        // Return an array that is greater than Y
        public static int GreaterThanY(int[] numbers, int y)
        {
            int total = 0;

            foreach (var i in numbers)
            {
                if (i > y) { total++;}
            }
            return total;
            
        }

        // Square the elements in a given array
        public static void SquareArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Unsquared number: {numbers[i]}\t");
                numbers[i] = numbers[i] * numbers[i];
                Console.WriteLine($"Squared number: {numbers[i]}");
            }
        }

        // Remove negative numbers from an array
        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0) { numbers[i] = 0; }
            }
        }

        // Prints out the min/max/avg of an array
        public static void MinMaxAverage(int[] numbers)
        {
            int min = Int32.MaxValue;

            foreach (var i in numbers)
            {
                if (i < min) { min = i; }
            }

            Console.WriteLine($"The min number of the array is: {min}");

            // because we already wrote max and average we can just call the functions
            FindMax(numbers);
            GetAverage(numbers);
        }


        // Shifts each number by one towards the front and add '0' to the end 
        public static void ShiftArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];
            }
            numbers[numbers.Length - 1] = 0;
        }

        // Takes an int array and returns an obj array where negatives are replaced with "Dojo"
        public static object[] NumToString(int[] numbers)
        {
            object[] newArr = new object[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    newArr[i] = "Dojo";
                else
                    newArr[i] = numbers[i];
            }
            return newArr;
        }
    }
}
