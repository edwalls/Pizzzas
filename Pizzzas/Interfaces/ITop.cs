using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Interfaces
{
    /// <summary>
    /// Interfrace that defines tops for pizzas
    /// </summary>
    public interface ITop
    {
        string GetDetails();
        int GetCookTime();
        double GetPrice();
        string GetTopName();
    }
}
