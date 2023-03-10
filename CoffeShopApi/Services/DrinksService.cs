using CoffeShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CoffeShopApi.Services;

public class DrinksService
{
    private readonly IMongoCollection<Drink> _drinksCollection;

    public DrinksService(
        IOptions<CoffeShopDatabaseSettings> coffeShopDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            coffeShopDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            coffeShopDatabaseSettings.Value.DatabaseName);

        _drinksCollection = mongoDatabase.GetCollection<Drink>(
            coffeShopDatabaseSettings.Value.DrinksCollectionName);
    }

    public async Task<List<Drink>> GetAsync() =>
        await _drinksCollection.Find(_ => true).ToListAsync();

    public async Task<Drink?> GetAsync(string id) =>
        await _drinksCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Drink newDrink) =>
        await _drinksCollection.InsertOneAsync(newDrink);

    public async Task UpdateAsync(string id, Drink updatedDrink) =>
        await _drinksCollection.ReplaceOneAsync(x => x.id == id, updatedDrink);

    public async Task RemoveAsync(string id) =>
        await _drinksCollection.DeleteOneAsync(x => x.id == id);
}