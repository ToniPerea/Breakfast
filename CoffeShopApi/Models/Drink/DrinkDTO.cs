using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoffeShopApi.Models;

public class DrinkDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public string? drink { get; set; }
}