    using System;
using System.Collections.Generic;
using System.Text;

namespace Human
{
    class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Apple", 200, false, true),
                new Food("Taco", 350, true, false),
                new Food("Cake", 1000, false, true),
                new Food("Yogurt", 120, false, true),
                new Food("Steak Slice", 375, true, false),
                new Food("Cereal", 280, false, true)
            };
        }

        public Food Serve()
        {
            var rand = new Random();
            return Menu[rand.Next(Menu.Count)];
        }
    }
}