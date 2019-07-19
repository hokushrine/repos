using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Nokia elevenHundred = new Nokia("1100", "Sprint", "ring ring", 52);

            // elevenHundred.DisplayInfo();
            System.Console.WriteLine(elevenHundred.CarrierProp);
        }
    }
}
