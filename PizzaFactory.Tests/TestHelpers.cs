using PizzaFactory.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Tests
{
    public static class TestHelpers
    {
        public static FactoryConfigSection GetPizzaFactoryConfig()
        {
            var settings = new FactoryConfigSection();
            settings.GeneralSettings = new GeneralSettings
            {
                CookingTimeBase = 3000,
                MaxNumTops = 3,
                NumTargetPizzas = 10
            };

            settings.PizzaBaseCollection = new PizzaBaseCollection();
            var listPizzaBases = new List<PizzaBaseElement>() {
                new PizzaBaseElement{ Name = "DeepPan", Description = "Deep Pan", CookingTimeMultiplier = 2, Price = 8.5 },
                new PizzaBaseElement{ Name = "StuffedCrust", Description = "Stuffed Crust", CookingTimeMultiplier = 1.5, Price = 7.5 },
                new PizzaBaseElement{ Name = "ThinAndCrispy", Description = "Thin and Crispy", CookingTimeMultiplier = 1, Price = 9.5 }
            };
            settings.PizzaBaseCollection.SetPizzaBaseList(listPizzaBases);

            settings.PizzaTopCollection = new PizzaTopCollection();
            var listPizzaTops = new List<PizzaTopElement>()
            {
                new PizzaTopElement{Top = "HamAndMushrooms", Description="Ham and Mushrooms", CookingTime= 100, Price = 1.5},
                new PizzaTopElement{Top = "Peperoni", Description="Pepperoni", CookingTime= 120, Price = 1.5},
                new PizzaTopElement{Top = "Vegetable", Description="Vegetable", CookingTime= 130, Price = 1.5},
            };
            settings.PizzaTopCollection.SetPizzaTopList(listPizzaTops);

            return settings;
        }
    }
}
