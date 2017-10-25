using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Implementation
{
    public class StuffedCrustPizza : AbstractPizza
    {
        public StuffedCrustPizza(int baseTimeCook, string baseName, string description, double cookingTimeMultiplier, double price) 
            : base(baseTimeCook, baseName, description, cookingTimeMultiplier, price)
        {
           
        }
        
        public override string GetDetails()
        {
            return base.GetDetails();
        }

    }
}
