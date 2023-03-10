using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoffeShopApi.Models;

public class Breakfast
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public long hashCode { get; set; }
    // public MealDTO[]? meals { get; set; }
    // public DrinkDTO[]? drinkId { get; set; }
    public string? mealId { get; set; }
    public string? drinkId { get; set; }
}