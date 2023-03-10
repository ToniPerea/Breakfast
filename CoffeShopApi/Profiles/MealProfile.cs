using AutoMapper;
using CoffeShopApi.Models;
using MongoDB.Bson;

namespace CoffeShopApi.Profiles;

public class MealProfile : Profile
{
  public MealProfile()
  {
    CreateMap<MealCreationDTO, Meal>()
      .ForMember(
        dest => dest.id,
        opt => opt.MapFrom(src => ObjectId.GenerateNewId())
      )
      .ForMember(
        dest => dest.meal,
        opt => opt.MapFrom(src => src.meal)
      );
    CreateMap<Meal, MealDTO>()
      .ForMember(
        dest => dest.id,
        opt => opt.MapFrom(src => src.id)
      )
      .ForMember(
        dest => dest.meal,
        opt => opt.MapFrom(src => src.meal)
      );
  }
}