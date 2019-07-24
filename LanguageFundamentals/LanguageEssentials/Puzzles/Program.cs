using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayRandomArray();
            CoinToss();
            TossMultiple(5);
            Names();
        }

        // ========================================
        //         RANDOM ARRAY GENERATOR
        // ========================================

        // Generate a random array with elements ranging from 5-25
        public static int[] RandomArray()
        {
            var rand = new Random();
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(5, 25);

            }

            return arr;
        }

        public static int GetMax(int[] numbers)
        {
            int max = Int32.MinValue;

            foreach (var i in numbers)
            {
                if (i > max) { max = i; }
            }

            return max;
        }

        public static int GetMin(int[] numbers)
        {
            int min = Int32.MaxValue;

            foreach (var i in numbers)
            {
                if (i < min) { min = i; }
            }

            return min;
        }

        public static int GetSum(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += i;
            }

            return sum;
        }

        public static void DisplayRandomArray()
        {
            var x = RandomArray();

            Console.Write("The random array: ");
            foreach (var i in x)
            {
                Console.Write(i + " ");
            }

            Console.Write(
                $"\nMin of the array: {GetMin(x)}\n" +
                $"Max of the array: {GetMax(x)}\n" +
                $"Sum of the array: {GetSum(x)}\n"
            );
        }


        // ========================================
        //               COIN FLIP
        // ========================================

        
        

        public static string CoinToss()
        {
            var rand = new Random();
            string result;

            result = rand.Next(2) == 0 ? "Heads" : "Tails";

            Console.WriteLine($"The result is: {result}");
            return result;
        }
        
        public static double TossMultiple(int numTimes)
        {
            var rand = new Random();
            int numHeads = 0;
            for (var i = 0; i < numTimes; i++)
            {
                if (rand.Next(2) == 0)
                    numHeads++;
            }
            return (double)numHeads / numTimes;
        }


        // ========================================
        //                 NAMES
        // ========================================

        // Shuffle a string list of names and return the values
        public static List<string> Names()
        {
            List<string> names = new List<string>()
            {
                "Todd", "Tiffany", "Charlie", "Geneva", "Sydney"
            };

            Random rand = new Random();

            // shuffle names
            for (var i = 0; i < names.Count / 2; i++)
            {
                // swap names[i] with names[randomIndex]
                int randomIndex = rand.Next(names.Count);
                string temp = names[randomIndex];
                names[randomIndex] = names[i];
                names[i] = temp;
            }

            // print new order of names
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            // remove names that are less than 5 characters
            for (var i = 0; i < names.Count; i++)
            {
                if (names[i].Length <= 5)
                    names.RemoveAt(i);
            }

            return names;
        }


    }
}
