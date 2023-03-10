// using CoffeShopApi.Models;
// using Microsoft.Extensions.Options;
// using MongoDB.Driver;

// namespace CoffeShopApi.Services;

// public class SesionsService
// {
//     private readonly IMongoCollection<Sesion> _sesionsCollection;

//     public SesionsService(
//         IOptions<CoffeShopDatabaseSettings> coffeShopDatabaseSettings)
//     {
//         var mongoClient = new MongoClient(
//             coffeShopDatabaseSettings.Value.ConnectionString);

//         var mongoDatabase = mongoClient.GetDatabase(
//             coffeShopDatabaseSettings.Value.DatabaseName);

//         _sesionsCollection = mongoDatabase.GetCollection<Sesion>(
//             coffeShopDatabaseSettings.Value.SesionsCollectionName);
//     }

//     public async Task<List<Sesion>> GetAsync() =>
//         await _sesionsCollection.Find(_ => true).ToListAsync();

//     public async Task<List<Sesion>> GetAllAsync(long hashCode) =>
//         await _sesionsCollection.Find(x => x.hashCode == hashCode).ToListAsync();

//     public async Task<Sesion?> GetAsync(string id) =>
//         await _sesionsCollection.Find(x => x.id == id).FirstOrDefaultAsync();

//     public async Task CreateAsync(Sesion newSesion) =>
//         await _sesionsCollection.InsertOneAsync(newSesion);

//     public async Task UpdateAsync(string id, Sesion updatedSesion) =>
//         await _sesionsCollection.ReplaceOneAsync(x => x.id == id, updatedSesion);

//     public async Task RemoveAsync(string id) =>
//         await _sesionsCollection.DeleteOneAsync(x => x.id == id);
// }