using PizzaFactory.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Interfaces
{
    public interface IPizzaTopFactory
    {
        PeperoniTop GetPeperoniTop();
        HamAndMushroomsTop GetHamMushroomsTop();
        VegetableTop GetVegetableTop();
    }
}
