using Application.DTOS.Customer;
using Application.DTOS.Product;

namespace Application.Configuring.Profile
{
    using Application.DTOS;
    using Application.DTOS.Category;
    using AutoMapper;
    using Domain.DbSets;
    using System.Runtime.ConstrainedExecution;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<DetailInfoAboutProductDTO, Product>()
                .ForPath(dest => dest.SubCategory.SubCategoryName, opt => opt.MapFrom(src => src.SubCategoryName))
                .ReverseMap();
            CreateMap<CreateProductDTO, Product>().ReverseMap();





            CreateMap<User, UserDTO>().ReverseMap()
                .ForMember(dest=>dest.Customer,opt=>opt.MapFrom(src=>src.CustomerDTO))
                .ReverseMap();


        }
    }
}
