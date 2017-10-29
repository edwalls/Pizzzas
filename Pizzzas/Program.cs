using Pizzzas.Helpers;
using Pizzzas.Implementation;
using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas
{
    class Program
    {
        static void Main(string[] args)
        {
            var _config = SettingsHelper.GetSettings();
            var _pizzaFactory = new PizzaFactory(_config.GeneralSettings, _config.PizzaBases);
            var _pizzaTopFactory = new PizzaTopFactory(_config.PizzaTops);
            var _pizzaStore = new PizzzasStore(_config, _pizzaFactory, _pizzaTopFactory);
            _pizzaStore.StartProcess();
        }
    }
}
