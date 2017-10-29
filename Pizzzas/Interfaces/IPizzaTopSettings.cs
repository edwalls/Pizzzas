namespace Pizzzas.Interfaces
{

    /// <summary>
    /// Interface to configure all pizza tops
    /// </summary>
    public interface IPizzaTopSettings
    {
        int CookingTime { get; set; }
        double Price { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}