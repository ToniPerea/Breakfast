using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoffeShopApi.Models;

public class Drink
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public string? drink { get; set; }
}