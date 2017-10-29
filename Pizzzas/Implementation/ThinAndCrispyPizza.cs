using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    /// <summary>
    /// Class for Thin and Crispy Pizza
    /// </summary>
    public class ThinAndCrispyPizza : AbstractPizza
    {
        public ThinAndCrispyPizza (int baseTimeCook, string description, double cookingTimeMultiplier, double price) 
            : base(baseTimeCook, Constants.BASE_THIN_AND_CRISPY, description, cookingTimeMultiplier, price)
        {
           
        }

        public override string GetDetails()
        {
            return base.GetDetails();

        }
    }
}
