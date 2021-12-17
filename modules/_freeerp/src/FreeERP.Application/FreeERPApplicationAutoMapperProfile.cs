using AutoMapper;
using FreeERP.MediaDescriptors;
using FreeERP.Products;

namespace FreeERP
{
    public class FreeERPApplicationAutoMapperProfile : Profile
    {
        public FreeERPApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<MediaDescriptor, MediaDescriptorDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateUpdateCategoryDto, Category>();
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.StockNum, o => o.MapFrom(s => s.Stock.StockNum));
            CreateMap<CreateUpdateProductDto, Product>();
        }
    }
}
