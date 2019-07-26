using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] multiplicationTableInts = new int[11,11] ;


            //for (var row = 0; row < size; row++)
            //for (var col = 0; col < size; col++)
            //    table[row, col] = (row + 1) * (col + 1);

            // assign to table
            for(int col = 0; col < multiplicationTableInts.GetLength(0); col++)
            {
                multiplicationTableInts[col, 0] = col;
            }
            for(int row = 0; row < multiplicationTableInts.GetLength(1); row++)
            {
                // multiplicationTableInts[0, row] = row;
                
                for(int subRow = 0; subRow < multiplicationTableInts.GetLength(1); subRow++)
                {
                    multiplicationTableInts[1, row] = row;
                }
            }


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
