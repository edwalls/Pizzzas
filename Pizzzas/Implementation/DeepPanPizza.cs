using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    public class DeepPanPizza : AbstractPizza
    {
        public DeepPanPizza(int baseTimeCook, string description, double cookingTimeMultiplier, double price)
            : base(baseTimeCook, Constants.BASE_DEEP_PAN, description, cookingTimeMultiplier, price)
        {

        }
        
        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
