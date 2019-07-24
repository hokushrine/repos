using System;
using System.Collections.Generic;
using System.Text;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Buffet buffet = new Buffet();
            SpiceHound spicyJack = new SpiceHound();
            SweetTooth sweetTom = new SweetTooth();

            while(!spicyJack.IsFull)
                spicyJack.Consume(buffet.Serve());
            
            while(!sweetTom.IsFull)
                sweetTom.Consume(buffet.Serve());

            Ninja victor;
            string title;
            if (spicyJack.ConsumptionHistory.Count > sweetTom.ConsumptionHistory.Count)
            {
                victor = spicyJack;
            }
            else
            {
                victor = sweetTom;
            }


            Console.WriteLine($"{victor} ate the most, with {victor.ConsumptionHistory.Count} items consumed!");
        }
    }
}
