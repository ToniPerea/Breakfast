using AutoMapper;
using CoffeShopApi.Models;
using MongoDB.Bson;

namespace CoffeShopApi.Profiles;

public class DrinkProfile : Profile
{
  public DrinkProfile()
  {
    CreateMap<DrinkCreationDTO, Drink>()
      .ForMember(
        dest => dest.id,
        opt => opt.MapFrom(src => ObjectId.GenerateNewId())
      )
      .ForMember(
        dest => dest.drink,
        opt => opt.MapFrom(src => src.drink)
      );
    CreateMap<Drink, DrinkDTO>()
      .ForMember(
        dest => dest.id,
        opt => opt.MapFrom(src => src.id)
      )
      .ForMember(
        dest => dest.drink,
        opt => opt.MapFrom(src => src.drink)
      );
  }
}