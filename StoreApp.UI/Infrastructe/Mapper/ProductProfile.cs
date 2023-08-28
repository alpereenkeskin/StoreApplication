using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entites;
using StoreApp.Entites.Dtos;

namespace StoreApp.UI.Infrastructe.Mapper
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductCreateDto, Product>().ReverseMap();
			CreateMap<ProductUpdateDto, Product>().ReverseMap();
			CreateMap<UserCreationDto, IdentityUser>().ReverseMap();
			CreateMap<UserUpdateDto, IdentityUser>().ReverseMap();
		}
	}
}

