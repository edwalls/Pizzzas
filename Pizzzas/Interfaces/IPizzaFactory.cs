using Pizzzas.Implementation;

namespace Pizzzas.Interfaces
{
    /// <summary>
    /// Interface of a factory of pizzas
    /// </summary>
    public interface IPizzaFactory
    {
        DeepPanPizza MakeDeepPanPizza();
        StuffedCrustPizza MakeStuffedCrustPizza();
        ThinAndCrispyPizza MakeThinAndCrispyPizza();        
    }
}
