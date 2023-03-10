using CoffeShopApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CoffeShopApi.Services;

public class BreakfastsService
{
  private readonly IMongoCollection<Breakfast> _breakfastsCollection;

  public BreakfastsService(
      IOptions<CoffeShopDatabaseSettings> coffeshopDatabaseSettings)
  {
    var mongoClient = new MongoClient(
        coffeshopDatabaseSettings.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(
        coffeshopDatabaseSettings.Value.DatabaseName);

    _breakfastsCollection = mongoDatabase.GetCollection<Breakfast>(
        coffeshopDatabaseSettings.Value.BreakfastsCollectionName);
  }

  public async Task<List<Breakfast>> GetAsync() =>
      await _breakfastsCollection.Find(_ => true).ToListAsync();

  public async Task<List<Breakfast>> GetAllByIdsAsync(List<string> ids)
  {
    var filter = Builders<Breakfast>.Filter.In(x => x.id, ids);
    var cursor = await _breakfastsCollection.FindAsync(filter);
    return await cursor.ToListAsync();
  }

  public async Task<Breakfast?> GetAsync(string id) =>
      await _breakfastsCollection.Find(x => x.id == id).FirstOrDefaultAsync();

  public async Task<List<Breakfast>> GetAllByHashAsync(long hashCode) =>
    await _breakfastsCollection.Find(x => x.hashCode == hashCode).ToListAsync();

  public async Task CreateAsync(Breakfast newBreakfast) =>
      await _breakfastsCollection.InsertOneAsync(newBreakfast);

  public async Task UpdateAsync(string id, Breakfast updatedBreakfast) =>
      await _breakfastsCollection.ReplaceOneAsync(x => x.id == id, updatedBreakfast);

  public async Task RemoveAsync(string id) =>
      await _breakfastsCollection.DeleteOneAsync(x => x.id == id);
}