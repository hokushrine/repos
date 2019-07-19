using System;
using System.Collections.Generic;
using System.Text;

namespace IronNinja
{
    interface IConsumable
    {
        string Name { get; set; }
        int Calories { get; set; }
        bool IsSpicy { get; set; }
        bool IsSweet { get; set; }
        string GetInfo();
    }
}
