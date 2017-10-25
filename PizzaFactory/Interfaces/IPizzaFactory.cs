using PizzaFactory.Implementation;

namespace PizzaFactory.Interfaces
{
    public interface IPizzaFactory
    {
        DeepPanPizza MakeDeepPanPizza();
        StuffedCrustPizza MakeStuffedCrustPizza();
        ThinAndCrispyPizza MakeThinAndCrispyPizza();        
    }
}
