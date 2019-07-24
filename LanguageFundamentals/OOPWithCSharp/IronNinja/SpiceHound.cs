using System;
using System.Collections.Generic;
using System.Text;

namespace IronNinja
{
    class SpiceHound : Ninja
    {
        // provide override for IsFull (Full at 1200 Calories)
        public override bool IsFull
        {
            get { return calorieIntake > 1200; }
        }

        public override void Consume(IConsumable item)
        {
            if (!IsFull)
            {
                calorieIntake += item.Calories;
                if (item.IsSpicy)
                {
                    calorieIntake -= 5;
                }
                ConsumptionHistory.Add(item);
                item.GetInfo();

            }
        }
    }

}
