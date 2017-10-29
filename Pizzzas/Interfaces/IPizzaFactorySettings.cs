using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzzas.Implementation;

namespace Pizzzas.Interfaces
{
    /// <summary>
    /// Interface to configure the component of factory
    /// </summary>
    public interface IPizzaFactorySettings
    {
        IGeneralSettings GeneralSettings { get; set; }
        List<IPizzaSettings> PizzaBases { get; set; }
        List<IPizzaTopSettings> PizzaTops { get; set; }
    }
}
