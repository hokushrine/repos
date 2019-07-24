using System;

namespace Fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            string separator = new string('=', 10);

            void LoopTo255()
            {
                const int upper = 255;

                Console.WriteLine("Printing 0-255");
                for (int i = 0; i <= upper; i++)
                {
                    Console.WriteLine(i);
                }
            }

            void LoopDivisibles()
            {
                const int upper = 100;

                Console.WriteLine("Printing divisibles of 3 or 5");
                for (int i = 0; i < upper; i++)
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }

            void FizzBuzz()
            {
                const int upper = 100;

                Console.WriteLine("Printing FizzBuzz");
                for (int i = 0; i < upper; i++)
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine(i + " :Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine(i + " :Buzz");
                    }
                    else
                    {
                        Console.WriteLine(i + " :FizzBuzz");
                    }
                }
            }

            LoopTo255();
            Console.WriteLine(separator + "\n");
            LoopDivisibles();
            Console.WriteLine(separator + "\n");
            FizzBuzz();
        }
    }
}