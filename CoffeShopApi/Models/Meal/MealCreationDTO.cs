using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoffeShopApi.Models;

public class MealCreationDTO
{
    public string? meal { get; set; }
}