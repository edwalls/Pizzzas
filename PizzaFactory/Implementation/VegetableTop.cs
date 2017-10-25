using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Implementation
{
    public class VegetableTop : AbstractTop
    {
        public VegetableTop(string topName, string description, int cookingTime, double price) : base(topName, description, cookingTime, price)
        {
        }

        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
