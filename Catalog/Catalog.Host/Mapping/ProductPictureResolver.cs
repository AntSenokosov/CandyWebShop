using AutoMapper;
using Catalog.Host.Configs;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping;

public class ProductPictureResolver : IMemberValueResolver<Product, ProductDto, string, string>
{
    private readonly Config _config;

    public ProductPictureResolver(IOptionsSnapshot<Config> config)
    {
        _config = config.Value;
    }

    public string Resolve(Product source, ProductDto destination, string sourceMember, string destMember, ResolutionContext context)
    {
        return $"{_config.CdnHost}/{_config.ImgUrl}/{sourceMember}";
    }
}