using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
   /// <summary>
   /// Implementation of Pizza
   /// </summary>
    public class PizzaSettings : IPizzaSettings
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }        
        public double CookingTimeMultiplier { get; set; }
    }
}
