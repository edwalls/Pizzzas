using Pizzzas.Helpers;
using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzzas.Implementation
{
    /// <summary>
    /// Pizza factory que create pizza objects
    /// </summary>
    public class PizzaFactory : IPizzaFactory
    {
        private List<IPizzaSettings> _pizzaBases;
        private IGeneralSettings _generalSettings;

        /// <summary>
        /// Constructoor of the factory
        /// </summary>
        /// <param name="generalSettings"></param>
        /// <param name="pizzaBases"></param>
        public PizzaFactory(IGeneralSettings generalSettings, List<IPizzaSettings> pizzaBases)
        {
            _generalSettings = generalSettings ?? throw new ArgumentException(string.Format($"General settings is null."));
            _pizzaBases = pizzaBases ?? throw new ArgumentException(string.Format($"Pizza bases list is null."));
            
            if (_pizzaBases.Count == 0)
            {
                throw new ArgumentException(string.Format($"{nameof(_pizzaBases)} no pizza bases found."));
            }
        }

        /// <summary>
        /// Create a StuffedCrustPizza 
        /// </summary>
        /// <returns></returns>
        public StuffedCrustPizza MakeStuffedCrustPizza()
        {
            var pizzaBaseSettings = GetBaseConfig(Constants.BASE_STUFFED_CRUST);
            if (pizzaBaseSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for: {Constants.BASE_STUFFED_CRUST}");
            }

            return new StuffedCrustPizza(
                _generalSettings.CookingTimeBase,                
                pizzaBaseSettings.Description,
                pizzaBaseSettings.CookingTimeMultiplier,
                pizzaBaseSettings.Price);
        }

        /// <summary>
        /// Create a ThinAndCrispyPizza
        /// </summary>
        /// <returns></returns>
        public ThinAndCrispyPizza MakeThinAndCrispyPizza()
        {
            var pizzaBaseSettings = GetBaseConfig(Constants.BASE_THIN_AND_CRISPY);
            if(pizzaBaseSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for: {Constants.BASE_THIN_AND_CRISPY}");
            }

            return new ThinAndCrispyPizza(
                _generalSettings.CookingTimeBase,                
                pizzaBaseSettings.Description,
                pizzaBaseSettings.CookingTimeMultiplier,
                pizzaBaseSettings.Price
            );

        }

        /// <summary>
        /// Create a DeepPanPizza
        /// </summary>
        /// <returns></returns>
        public DeepPanPizza MakeDeepPanPizza()
        {
            var pizzaBaseSettings = GetBaseConfig(Constants.BASE_DEEP_PAN);
            if (pizzaBaseSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for: {Constants.BASE_DEEP_PAN}");
            }

            return new DeepPanPizza(
                _generalSettings.CookingTimeBase,                
                pizzaBaseSettings.Description,
                pizzaBaseSettings.CookingTimeMultiplier,
                pizzaBaseSettings.Price);
        }

        /// <summary>
        /// private methos that returns the configuration for the pizza base
        /// </summary>
        /// <param name="pizzaBaseName"></param>
        /// <returns></returns>
        private IPizzaSettings GetBaseConfig(string pizzaBaseName)
        {
            return _pizzaBases.FirstOrDefault(b => b.Name == pizzaBaseName);
        }
    }
}
