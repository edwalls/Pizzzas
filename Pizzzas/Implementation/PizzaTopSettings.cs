using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{

    /// <summary>
    /// Implementation for top settings
    /// </summary>
    public class PizzaTopSettings : IPizzaTopSettings
    {
        public int CookingTime { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
