using System;
using System.Collections.Generic;
using System.Text;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        // constructor
        public Samurai(string name) : base(name)
        {
            Health = 200;
        }

        // attack overrride
        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.HealthProp < 50)
            {
                Console.WriteLine($"{target.Name}'s health is less than 50!\n" +
                                    $"The samurai deals a fatal blow and finishes ${target.Name} off");
                target.HealthProp = 0;
            }
            return target.HealthProp;
        }

        public void Meditate()
        {
            // set current health to original health
            Health = 200;
        }
    }
}