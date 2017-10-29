using System.Collections.Generic;

namespace Pizzzas.Interfaces
{

    /// <summary>
    /// Interface to implements pizza
    /// </summary>
    public interface IPizza
    {
        void AddTop(ITop top);        
        string GetDetails();
        int GetCookTime();
        double GetPrice();
        string GetPizzaBaseName();
    }
}
