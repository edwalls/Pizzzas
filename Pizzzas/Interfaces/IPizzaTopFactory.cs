using Pizzzas.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzzas.Interfaces
{

    /// <summary>
    /// Interface for create a factory of tops.
    /// </summary>
    public interface IPizzaTopFactory
    {
        PeperoniTop GetPeperoniTop();
        HamAndMushroomsTop GetHamMushroomsTop();
        VegetableTop GetVegetableTop();
    }
}
