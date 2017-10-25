using PizzaFactory.Helpers;
using PizzaFactory.Interfaces;
using PizzaFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Implementation
{
    public class PizzaKingFactory : IPizzaFactory
    {
        private IFactoryConfigSection _settings;        

        public PizzaKingFactory(IFactoryConfigSection settings)
        {
            _settings = settings ?? throw new ArgumentException(string.Format($"Settings is null."));
            if (settings.PizzaBaseCollection == null)
            {
                throw new ArgumentException(string.Format($"{nameof(settings.PizzaBaseCollection)} is null."));
            }

            if (settings.PizzaBaseCollection.Count == 0)
            {
                throw new ArgumentException(string.Format($"{nameof(settings.PizzaBaseCollection)} no pizza bases found."));
            }
        }       

        public StuffedCrustPizza MakeStuffedCrustPizza()
        {
            var pizzaBaseSettings = GetBaseConfig(PizzaBaseConstants.STUFFED_CRUST);
            if (pizzaBaseSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for: {PizzaBaseConstants.STUFFED_CRUST}");
            }

            return new StuffedCrustPizza(
                _settings.GeneralSettings.CookingTimeBase,
                pizzaBaseSettings.Name,
                pizzaBaseSettings.Description,
                pizzaBaseSettings.CookingTimeMultiplier,
                pizzaBaseSettings.Price);
        }

        public ThinAndCrispyPizza MakeThinAndCrispyPizza()
        {
            var pizzaBaseSettings = GetBaseConfig(PizzaBaseConstants.THIN_AND_CRISPY);
            if(pizzaBaseSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for: {PizzaBaseConstants.THIN_AND_CRISPY}");
            }

            return new ThinAndCrispyPizza(
                _settings.GeneralSettings.CookingTimeBase,
                pizzaBaseSettings.Name,
                pizzaBaseSettings.Description,
                pizzaBaseSettings.CookingTimeMultiplier,
                pizzaBaseSettings.Price
            );

        }

        public DeepPanPizza MakeDeepPanPizza()
        {
            var pizzaBaseSettings = GetBaseConfig(PizzaBaseConstants.DEEP_PAN);
            if (pizzaBaseSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for: {PizzaBaseConstants.DEEP_PAN}");
            }

            return new DeepPanPizza(
                _settings.GeneralSettings.CookingTimeBase,
                pizzaBaseSettings.Name,
                pizzaBaseSettings.Description,
                pizzaBaseSettings.CookingTimeMultiplier,
                pizzaBaseSettings.Price);
        }

        private PizzaBaseElement GetBaseConfig(string pizzaBaseName)
        {
            return _settings.PizzaBaseCollection.FirstOrDefault(b => b.Name == pizzaBaseName);
        }
    }
}
