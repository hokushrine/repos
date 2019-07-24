using System;
using System.Collections.Generic;
using System.Text;

namespace IronNinja
{
    class SweetTooth : Ninja
    {
        // provide override for IsFull (Full at 1500 Calories)
         public override bool IsFull
        {
            get { return calorieIntake > 1500; }
        }
        public override void Consume(IConsumable item)
        {
            if(!IsFull)
            {
                calorieIntake += item.Calories;
                if(item.IsSweet)
                {
                    calorieIntake += 10;
                }
                ConsumptionHistory.Add(item);
                item.GetInfo();

            }
        }

        // if not full
            //adds calorie value to SweetTooth's total calorieIntake (+10 additional calories if the consumable item is "Sweet")
            //adds the randomly selected IConsumable object to SweetTooth's ConsumptionHistory list
            //calls the IConsumable object's GetInfo() method
        // else
            //issues a warning to the console that the SweetTooth is full and cannot eat anymore

    }
}
