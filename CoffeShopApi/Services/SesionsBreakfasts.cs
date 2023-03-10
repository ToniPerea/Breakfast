// using CoffeShopApi.Models;
// using Microsoft.Extensions.Options;
// using MongoDB.Driver;

// namespace CoffeShopApi.Services;

// public class SesionsBreakfastsService
// {
//     private readonly IMongoCollection<SesionBreakfast> _SesionsBreakfastsCollection;

//     public SesionsBreakfastsService(
//         IOptions<CoffeShopDatabaseSettings> coffeShopDatabaseSettings)
//     {
//         var mongoClient = new MongoClient(
//             coffeShopDatabaseSettings.Value.ConnectionString);

//         var mongoDatabase = mongoClient.GetDatabase(
//             coffeShopDatabaseSettings.Value.DatabaseName);

//         _SesionsBreakfastsCollection = mongoDatabase.GetCollection<SesionBreakfast>(
//             coffeShopDatabaseSettings.Value.SesionsBreakfastsCollectionName);
//     }

//     public async Task<List<SesionBreakfast>> GetAsync() =>
//         await _SesionsBreakfastsCollection.Find(_ => true).ToListAsync();

//     public async Task<List<SesionBreakfast>> GetAllAsync(long sesionHashCode) =>
//         await _SesionsBreakfastsCollection.Find(x => x.sesionHashCode == sesionHashCode).ToListAsync();

//     public async Task<SesionBreakfast?> GetAsync(string id) =>
//         await _SesionsBreakfastsCollection.Find(x => x.id == id).FirstOrDefaultAsync();

//     public async Task CreateAsync(SesionBreakfast newSesion) =>
//         await _SesionsBreakfastsCollection.InsertOneAsync(newSesion);

//     public async Task UpdateAsync(string id, SesionBreakfast updatedSesion) =>
//         await _SesionsBreakfastsCollection.ReplaceOneAsync(x => x.id == id, updatedSesion);

//     public async Task RemoveAsync(string id) =>
//         await _SesionsBreakfastsCollection.DeleteOneAsync(x => x.id == id);
// }