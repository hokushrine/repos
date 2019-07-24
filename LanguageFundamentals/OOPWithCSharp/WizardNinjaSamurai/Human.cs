using System;
using System.Collections.Generic;
using System.Text;

namespace WizardNinjaSamurai
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected  int Health;

        // health property
        public int HealthProp
        {
            get { return Health; }
            set { Health = value; }
        }

        // constructor 1
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
           Health = 100;
        }

        // constructor 2
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Health = hp;
        }

        // attack method
        public virtual int  Attack(Human target)
        {
            int dmg = Strength * 3;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }

        public virtual int Attack(Human target, int dmg)
        {
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }

        public void PrintStats()
        {
            Console.WriteLine(
                "\t" + this.Name + "\n" +
                $"Class:\t{GetType()}\n" +
                $"Health:\t\t{Health}\n" +
                $"Strength:\t{Strength}\n" +
                $"Intelligence:\t{Intelligence}\n" +
                $"Dexterity:\t{Dexterity}\n"
                );
        }
    }

}
