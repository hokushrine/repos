using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Nokia elevenHundred = new Nokia("1100", "Sprint", "tuturuuu", 52);
            Galaxy s8 = new Galaxy("Galaxy S8", "T-Mobile", "Doo do doo dooo", 87);

            elevenHundred.DisplayInfo();
            Console.WriteLine($"\t...{elevenHundred.Ring()}...\t");
            Console.WriteLine(elevenHundred.Unlock());
            Console.WriteLine();

            s8.DisplayInfo();
            Console.WriteLine($"\t...{s8.Ring()}...\t");
            Console.WriteLine(s8.Unlock());
        }
    }
}
