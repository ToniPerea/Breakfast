namespace CoffeShopApi.Models;

public class CoffeShopDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    // public string SesionsCollectionName { get; set; } = null!;
    
    public string BreakfastsCollectionName { get; set; } = null!;

    public string MealsCollectionName { get; set; } = null!;

    public string DrinksCollectionName { get; set; } = null!;

    // public string SesionsBreakfastsCollectionName { get; set; } = null!;
}