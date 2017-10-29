namespace Pizzzas.Interfaces
{
    /// <summary>
    /// Interfaces to congure the pizza types
    /// </summary>
    public interface IPizzaSettings
    {
        double CookingTimeMultiplier { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Description { get; set; }        
    }
}