using CoffeShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CoffeShopApi.Services;

public class MealsService
{
    private readonly IMongoCollection<Meal> _mealsCollection;

    public MealsService(
        IOptions<CoffeShopDatabaseSettings> coffeShopDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            coffeShopDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            coffeShopDatabaseSettings.Value.DatabaseName);

        _mealsCollection = mongoDatabase.GetCollection<Meal>(
            coffeShopDatabaseSettings.Value.MealsCollectionName);
    }

    public async Task<List<Meal>> GetAsync() =>
        await _mealsCollection.Find(_ => true).ToListAsync();

    public async Task<Meal?> GetAsync(string id) =>
        await _mealsCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Meal newMeal) =>
        await _mealsCollection.InsertOneAsync(newMeal);

    public async Task UpdateAsync(string id, Meal updatedMeal) =>
        await _mealsCollection.ReplaceOneAsync(x => x.id == id, updatedMeal);

    public async Task RemoveAsync(string id) =>
        await _mealsCollection.DeleteOneAsync(x => x.id == id);
}