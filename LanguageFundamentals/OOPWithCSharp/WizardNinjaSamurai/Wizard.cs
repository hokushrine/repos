using System;
using System.Collections.Generic;
using System.Text;

namespace WizardNinjaSamurai
{
    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            
            Health = 50;
            Intelligence = 25;
        }

        // attack override
        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            target.HealthProp -= dmg;
            // restore wizard's hp by damage dealt

            return target.HealthProp;
        }

        // heal skill
        public int Heal(Human target)
        {
            target.HealthProp = 10 * Intelligence;
            return Health;
        }
    }
}
