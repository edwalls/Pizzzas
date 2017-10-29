using Pizzzas.Implementation;
using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Helpers
{
    public static class SettingsHelper
    {
        public static PizzaFactorySettings GetSettings()
        {
            var configSection = ConfigurationManager.GetSection("FactorySettings") as FactoryConfigSection;
            var settings = new PizzaFactorySettings()
            {
                GeneralSettings = configSection.GeneralSettings                
            };
            foreach (var pizza  in configSection.PizzaBaseCollection)
            {
                settings.PizzaBases.Add(pizza as IPizzaSettings);
            }

            foreach (var top in configSection.PizzaTopCollection)
            {
                settings.PizzaTops.Add(top as IPizzaTopSettings);
            }

            return settings;
        }
    }
}
