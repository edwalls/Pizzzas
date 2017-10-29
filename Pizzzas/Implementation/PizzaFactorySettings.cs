using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    /// <summary>
    /// Object for the Store Settings
    /// </summary>
    public class PizzaFactorySettings : IPizzaFactorySettings
    {
        public PizzaFactorySettings()
        {
            PizzaBases = new List<IPizzaSettings>();
            PizzaTops = new List<IPizzaTopSettings>();
        }
        public IGeneralSettings GeneralSettings { get; set; }
        public List<IPizzaSettings> PizzaBases { get; set; }
        public List<IPizzaTopSettings> PizzaTops { get; set; }
    }
}
