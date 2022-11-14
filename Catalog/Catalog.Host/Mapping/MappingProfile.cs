using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Manufacture, ManufactureDto>();
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.PictureFileName, opt =>
                opt.MapFrom<ProductPictureResolver, string>(c => c.PictureFileName));
    }
}