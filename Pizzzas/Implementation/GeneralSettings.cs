using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    /// <summary>
    /// Implements the general config for the pizza store
    /// </summary>
    public class GeneralSettings : IGeneralSettings
    {
        public int CookingTimeBase { get; set; }
        public int NumTargetPizzas { get; set; }
        public int NumPizzaBases { get; set; }
        public int NumPizzaTops { get; set; }
        public int MaxNumTops { get; set; }
    }
}
