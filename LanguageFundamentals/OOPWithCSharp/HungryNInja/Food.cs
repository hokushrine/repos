using System;
using System.Collections.Generic;
using System.Text;

namespace Human
{
    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string name, int cal, bool spiciness, bool sweetness)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spiciness;
            IsSweet = sweetness;
        }
    }
}