using PizzaFactory.Helpers;
using PizzaFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Implementation
{
    public class PizzaTopFactory : IPizzaTopFactory
    {
        IFactoryConfigSection _settings;

        public PizzaTopFactory(IFactoryConfigSection config)
        {
            _settings = config;
        }

        public HamAndMushroomsTop GetHamMushroomsTop()
        {
            var pizzatopSettings = GetBaseConfig(PizzaTopConstants.HAM_AND_MUSHROOMS);
            if (pizzatopSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for this top:{PizzaTopConstants.HAM_AND_MUSHROOMS}");
            }

            return new HamAndMushroomsTop(
                pizzatopSettings.Top,
                pizzatopSettings.Description,
                pizzatopSettings.CookingTime,
                pizzatopSettings.Price);            
        }

        public PeperoniTop GetPeperoniTop()
        {
            var pizzatopSettings = GetBaseConfig(PizzaTopConstants.PEPERONI);
            if (pizzatopSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for this top:{PizzaTopConstants.PEPERONI}");
            }

            return new PeperoniTop(
                pizzatopSettings.Top,
                pizzatopSettings.Description,
                pizzatopSettings.CookingTime,
                pizzatopSettings.Price);
        }

        public VegetableTop GetVegetableTop()
        {
            var pizzatopSettings = GetBaseConfig(PizzaTopConstants.VEGETABLE);
            if (pizzatopSettings == null)
            {
                throw new NotImplementedException($"Not found config settings for this top:{PizzaTopConstants.VEGETABLE}");
            }

            return new VegetableTop(
                pizzatopSettings.Top,
                pizzatopSettings.Description,
                pizzatopSettings.CookingTime,
                pizzatopSettings.Price);
        }

        private PizzaTopElement GetBaseConfig(string pizzaTopName)
        {
            return _settings.PizzaTopCollection.Where(b => b.Top == pizzaTopName).FirstOrDefault();
        }
    }
}
