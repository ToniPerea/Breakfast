using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoffeShopApi.Models;

public class DrinkCreationDTO
{
    public string? drink { get; set; }
}