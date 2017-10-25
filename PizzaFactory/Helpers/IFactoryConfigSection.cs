using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaFactory.Implementation;

namespace PizzaFactory.Helpers
{
    public interface IFactoryConfigSection
    {
        GeneralSettings GeneralSettings { get; set; }
        PizzaBaseCollection PizzaBaseCollection { get; set; }
        PizzaTopCollection PizzaTopCollection { get; set; }
    }
}
