using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {

            Ninja nin = new Ninja("Nin");
            Wizard wiz = new Wizard("Wiz");
            Samurai sam = new Samurai("Sam");

            sam.PrintStats();
            wiz.PrintStats();
            nin.PrintStats();
        }
    }
}