namespace PizzaFactory.Helpers
{
    public interface IGeneralSettings
    {
        int CookingTimeBase { get; set; }
        int NumTargetPizzas { get; set; }
        int MaxNumTops { get; set; }
    }
}