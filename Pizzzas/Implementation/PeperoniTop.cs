using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    public class PeperoniTop : AbstractTop
    {
        public PeperoniTop(string description, int cookingTime, double price) 
            : base(Constants.TOP_PEPERONI, description, cookingTime, price)
        {
        }

        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
