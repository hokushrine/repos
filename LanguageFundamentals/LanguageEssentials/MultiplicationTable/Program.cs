using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            const int max = 100;
            int[,] multiplicationTableInts = new int[10,10] ;


            //for (var row = 0; row < size; row++)
            //for (var col = 0; col < size; col++)
            //    table[row, col] = (row + 1) * (col + 1);

            // Display the table in a friendly manner
            for (int i = 0; i < multiplicationTableInts.GetLength(0); i++)
            {
                for (int j = 0; j < multiplicationTableInts.GetLength(1); j++)
                {
                    Console.Write("{0}\t", multiplicationTableInts[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
