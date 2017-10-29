using Pizzzas.Helpers;
using Pizzzas.Implementation;
using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Tests
{
    public static class TestHelpers
    {
        public static PizzaFactorySettings GetPizzaSettings()
        {
            var settings = new PizzaFactorySettings();
            settings.GeneralSettings = new GeneralSettings
            {
                CookingTimeBase = 3000,
                MaxNumTops = 3,
                NumTargetPizzas = 10,
                NumPizzaBases = 3,
                NumPizzaTops = 3
            };

            settings.PizzaBases = new List<IPizzaSettings>()
            {
                new PizzaBaseElement{ Name = "DeepPan", Description = "Deep Pan", CookingTimeMultiplier = 2, Price = 8.5 },
                new PizzaBaseElement{ Name = "StuffedCrust", Description = "Stuffed Crust", CookingTimeMultiplier = 1.5, Price = 7.5 },
                new PizzaBaseElement{ Name = "ThinAndCrispy", Description = "Thin and Crispy", CookingTimeMultiplier = 1, Price = 9.5 }
            };
              
            settings.PizzaTops = new List<IPizzaTopSettings>()
            {
                new PizzaTopElement{ Name = "HamAndMushrooms", Description="Ham and Mushrooms", CookingTime= 100, Price = 1.5},
                new PizzaTopElement{ Name = "Peperoni", Description="Pepperoni", CookingTime= 120, Price = 1.5},
                new PizzaTopElement{ Name = "Vegetable", Description="Vegetable", CookingTime= 130, Price = 1.5},
            };           

            return settings;
        }
    }
}
