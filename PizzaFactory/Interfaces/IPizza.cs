using System.Collections.Generic;

namespace PizzaFactory.Interfaces
{
    public interface IPizza
    {
        void AddTop(ITop top);        
        string GetDetails();
        int GetCookTime();
        double GetPrice();
    }
}
