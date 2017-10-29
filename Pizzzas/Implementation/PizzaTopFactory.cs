using Pizzzas.Helpers;
using Pizzzas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Implementation
{
    /// <summary>
    /// Implementation of the pizza tops factory
    /// </summary>
    public class PizzaTopFactory : IPizzaTopFactory
    {
        List<IPizzaTopSettings> _pizzaTopConfigs;

        /// <summary>
        /// Factory constructor
        /// </summary>
        /// <param name="pizzaTopsConfigs"></param>
        public PizzaTopFactory(List<IPizzaTopSettings> pizzaTopsConfigs)
        {
            if (pizzaTopsConfigs == null)
            {
                throw new ArgumentException(string.Format($"{nameof(pizzaTopsConfigs)} is null or empty"));
            }
            _pizzaTopConfigs = pizzaTopsConfigs;
        }


        /// <summary>
        /// Create a HamAndMushroomsTop
        /// </summary>
        /// <returns></returns>
        public HamAndMushroomsTop GetHamMushroomsTop()
        {
            var pizzatopSettings = GetBaseConfig(Constants.TOP_HAM_AND_MUSHROOMS);
            if (pizzatopSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for this top:{Constants.TOP_HAM_AND_MUSHROOMS}");
            }

            return new HamAndMushroomsTop(pizzatopSettings.Description,pizzatopSettings.CookingTime,pizzatopSettings.Price);            
        }

        /// <summary>
        /// Create a PeperoniTop
        /// </summary>
        /// <returns></returns>
        public PeperoniTop GetPeperoniTop()
        {
            var pizzatopSettings = GetBaseConfig(Constants.TOP_PEPERONI);
            if (pizzatopSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for this top:{Constants.TOP_PEPERONI}");
            }

            return new PeperoniTop(pizzatopSettings.Description, pizzatopSettings.CookingTime, pizzatopSettings.Price);
        }

        /// <summary>
        /// Create a VegetableTop
        /// </summary>
        /// <returns></returns>
        public VegetableTop GetVegetableTop()
        {
            var pizzatopSettings = GetBaseConfig(Constants.TOP_VEGETABLE);
            if (pizzatopSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for this top:{Constants.TOP_VEGETABLE}");
            }

            return new VegetableTop(pizzatopSettings.Description, pizzatopSettings.CookingTime, pizzatopSettings.Price);
        }

        /// <summary>
        /// Private methos that return the configuration for the to name
        /// </summary>
        /// <param name="pizzaTopName"></param>
        /// <returns></returns>
        private IPizzaTopSettings GetBaseConfig(string pizzaTopName)
        {
            return _pizzaTopConfigs.FirstOrDefault(b => b.Name == pizzaTopName);
        }
    }
}
