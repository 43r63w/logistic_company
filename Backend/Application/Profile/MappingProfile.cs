using Application.DTOS.Customer;
using Application.DTOS.Product;

namespace Application.Profile
{
    using Application.DTOS.Category;
    using AutoMapper;
    using Domain.DbSets;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<DetailInfoAboutProductDTO, Product>()
                .ForPath(dest => dest.SubCategory.SubCategoryName, opt => opt.MapFrom(src => src.SubCategoryName))
                .ReverseMap();
            CreateMap<CreateProductDTO, Product>().ReverseMap();

            




        }
    }
}
