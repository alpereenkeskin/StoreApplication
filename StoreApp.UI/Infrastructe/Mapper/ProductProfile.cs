using AutoMapper;
using StoreApp.Entites;

namespace StoreApp.UI.Infrastructe.Mapper
{
    public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductCreateDto, Product>().ReverseMap();
			CreateMap<ProductUpdateDto, Product>().ReverseMap();
		}
	}
}

