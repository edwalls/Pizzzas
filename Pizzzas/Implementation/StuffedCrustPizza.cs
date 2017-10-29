using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    public class StuffedCrustPizza : AbstractPizza
    {
        public StuffedCrustPizza(int baseTimeCook, string description, double cookingTimeMultiplier, double price) 
            : base(baseTimeCook, Constants.BASE_STUFFED_CRUST, description, cookingTimeMultiplier, price)
        {
           
        }
        
        public override string GetDetails()
        {
            return base.GetDetails();
        }

    }
}
