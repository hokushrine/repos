using System;
using System.Collections.Generic;
using System.Text;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        // constructor
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }

        // attack override
        public override int Attack(Human target)
        {
            Random rnd = new Random();
            int dmg = 5 * Dexterity ;
            if(rnd.Next(100) <= 20)
                dmg += 10;
            return base.Attack(target, dmg);
        }

        // steal skill
        public void Steal(Human target)
        {
            Health += base.Attack(target, 10);
        }

    }
}
