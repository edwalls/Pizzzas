namespace Pizzzas.Interfaces
{
    /// <summary>
    /// Interface to configure the pizza factory
    /// </summary>
    public interface IGeneralSettings
    {
        int CookingTimeBase { get; set; }
        int NumTargetPizzas { get; set; }
        int NumPizzaBases { get; set; }
        int NumPizzaTops { get; set; }
        int MaxNumTops { get; set; }
    }
}