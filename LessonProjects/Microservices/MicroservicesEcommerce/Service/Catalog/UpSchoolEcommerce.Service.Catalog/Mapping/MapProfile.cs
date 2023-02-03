using AutoMapper;
using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Service.Catalog.Models;

namespace UpSchoolEcommerce.Service.Catalog.Mapping;
public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    }
}
