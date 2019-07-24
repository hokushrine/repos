using System;
using System.Collections.Generic;
using System.Text;

namespace Human
{
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();

        }

        // add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories
        public bool IsFullProp
        {
            get
            {
                return calorieIntake > 1200;
            }
        }

        // If the ninja is not full
                //adds calorie value to ninja's total calorie intake
                //adds the randomly selected Food object to the ninja's FoodHistory list
                //writes the Food's Name, and if it is spicy/sweet to the console
        public void Eat(Food meal)
        {

            if (!IsFullProp)
            {
                calorieIntake += meal.Calories;
                FoodHistory.Add(meal);
                Console.Write($"Ninja eats {meal.Name}. ");
                if (meal.IsSpicy) { Console.WriteLine($"The {meal.Name} was spicy."); }
                else
                    Console.WriteLine($"The meal was sweet.");
            }
            else
            {
                Console.WriteLine("The Ninja is full");
            }

            // writes the Food's Name - and if it is spicy/sweet to the console
            // three-tier if-else statement? Kind of messy. Can't use switch statement.
        }
    }
}