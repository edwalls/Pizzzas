using PizzaFactory.Helpers;
using PizzaFactory.Implementation;
using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var _config = ConfigurationManager.GetSection("FactorySettings") as FactoryConfigSection;
            var _pizzaFactory = new PizzaKingFactory(_config);
            var _pizzaTopFactory = new PizzaTopFactory(_config);
            var _pizzaKingStore = new PizzaKingStore(_config, _pizzaFactory, _pizzaTopFactory);
            _pizzaKingStore.StartProcess();
        }
    }
}
