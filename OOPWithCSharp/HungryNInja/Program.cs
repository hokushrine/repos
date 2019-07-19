using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja ninja = new Ninja();
            Buffet buffet = new Buffet();

            while (!ninja.IsFullProp)
            {
                ninja.Eat(buffet.Serve());
            }
        }
    }
}