using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random random = new Random();

            //const int passwordLength = 10;
            //char[] buffer = new char[passwordLength];
            //for (var i = 0; i < passwordLength; i++)
            //{
            //   buffer[i] = ((char)('a' + random.Next(0, 26)));
            //}

            //string password = new string(buffer);
            //Console.WriteLine(buffer);

            // Exercises
            //ex01();
            //ex02();
            //ex03();
            //ex04();
            ex05();
        }

        // Displays the result of how many numbers between 1-100 are
        // divisible by 3 with no remainder
        public static void ex01()
        {
            int count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i%3 == 0)
                {
                    count++;
                }
                Console.WriteLine("There are {0} divisible by 3 between 1 and 100.", count);
            }
        }

        // Accept numbers from the user until the user enters "quit"
        // Returns the sum of all numbers entered
        public static void ex02()
        {
            var sum = 0;
            while(true)
            {
                Console.Write("Enter a number or \"quit\" to exit.");
                string input = Console.ReadLine();

                // check for exit
                if (input.ToLower() == "quit")
                {
                    break;
                }

                sum += Convert.ToInt32(input);
                Console.WriteLine("The sum of all numbers is: " + sum);
            }
            
        }

        // Computes the factorial of a single arg from the console
        public static void ex03()
        {
            Console.Write("Please enter a single number.");
            int number = Convert.ToInt32(Console.ReadLine()); // convert string input into int32

            int factorial = 1;
            for (var i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("{0}! = {1}", number, factorial);
        }

        // User picks a random number 1-10 and has 4 chances to guess
        // If the user guesses correctly, "you win"; else "you lose"
        public static void ex04()
        {
            var number = new Random().Next(1, 10);
            Console.WriteLine("The secret is " + number);
            for (var i = 5; i >= 0; i--)
            {
                Console.Write("Guess the number: ");
                var guess = Convert.ToInt32(Console.ReadLine());

                if (guess == number)
                {
                    Console.WriteLine("You win");
                    return;
                }
               
                Console.WriteLine("You lost! You have {0} chances left.", i);
            }
        }

        // Ask the user to enter numbers separated by comma
        // Find the maximum and display it on the result
        public static void ex05()
        {
            Console.Write("Enter numbers separated by commas: ");
            string input = Console.ReadLine(); // get user input and assign to input

            var numbers = input.Split(',');

            // assume first number is the max
            var max = Convert.ToInt32(numbers[0]);

            foreach (var str in numbers)
            {
                var number = Convert.ToInt32(str);
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine("Max is " + max);
        }
    }
}
