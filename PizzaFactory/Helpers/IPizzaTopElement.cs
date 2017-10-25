namespace PizzaFactory.Interfaces
{
    public interface IPizzaTopElement
    {
        int CookingTime { get; set; }
        double Price { get; set; }
        string Top { get; set; }
    }
}