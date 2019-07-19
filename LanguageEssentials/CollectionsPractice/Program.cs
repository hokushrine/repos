using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // ARRAY EXERCISE
            int[] iValues = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string[] sNames = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] bAlternatingBools = {true, false, true, false, true, false, true, false, true, false};


            // GENERIC EXERCISE
            List<string> sIceCreamFlavorsList = new List<string>
            {
                "Mint",
                "Chocolate",
                "Lemon",
                "Raspberry",
                "Vanilla"
            };
            List<string> sModifiedList = new List<string>(sIceCreamFlavorsList);


            Console.WriteLine("Count of the original list: " + sIceCreamFlavorsList.Count);
            Console.WriteLine("Flavor at the third Index: " + sModifiedList[3] +"\n");
            sModifiedList.RemoveAt(3);
            Console.WriteLine("Flavors of the modified list: ");
            foreach (var flavor in sModifiedList)
                Console.WriteLine("\t" + flavor);

            Console.WriteLine("\nCount of the modified list: " + sModifiedList.Count);
            Console.WriteLine();


            // DICTIONARY EXERCISE
            Dictionary<string, string> preferences = new Dictionary<string, string>();

            // Add a new key, then set the value later
            foreach (var name in sNames)
                preferences.Add(name, null);

            // Get a random element from the ice cream list and assign it to a key
            var rand = new Random();
            foreach (var name in sNames)
                preferences[name] = (sIceCreamFlavorsList[rand.Next(sIceCreamFlavorsList.Count)]);

            foreach (var kp in preferences)
                Console.WriteLine($"{kp.Key} prefers {kp.Value}");
        }
    }
}
