using System;
using System.Collections.Generic;
using System.Text;

namespace IronNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Drink("Milk", 20, false, true),
                new Drink("Pepper Juice", 75, true, false),
                new Drink("Pink Lemonade", 300, false, true),
                new Food("Cake", 400, false, true),
                new Food("Beef Jerky", 75, true, false),
                new Food("Ghost Pepper", 35, true, false),
                new Food("Scrambled Eggs", 120, false, false)
            };
        }

        // The type is IConsumable because we are returning 'Menu', which is a list of the type IConsumable
        public IConsumable Serve()
        {
            var rand = new Random();
            return Menu[rand.Next(Menu.Count)];
        }
    }
}
