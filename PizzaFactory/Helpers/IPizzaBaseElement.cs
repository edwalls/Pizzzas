namespace PizzaFactory.Interfaces
{
    public interface IPizzaBaseElement
    {
        double CookingTimeMultiplier { get; set; }
        string Name { get; set; }
        double Price { get; set; }
    }
}