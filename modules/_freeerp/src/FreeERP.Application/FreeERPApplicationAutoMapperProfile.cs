using AutoMapper;
using FreeERP.Customers;
using FreeERP.MediaDescriptors;
using FreeERP.Products;
using FreeERP.Purchases;
using FreeERP.Stories;
using FreeERP.Suppliers;
using System.Linq;

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
            CreateMap<CategoryDto, Category>();
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.StockNum, o => o.MapFrom(s => s.Stocks.Sum(st => st.StockNum)));

            CreateMap<ProductUnit, ProductUnitDto>()
                .ForMember(d => d.SmallerUnitId, o => o.MapFrom(s => s.SmallerUnit.Id));
            CreateMap<ProductUnitDto, ProductUnit>()
                .ForMember(d => d.SmallerUnit, o => o.MapFrom<ProductUnit>((s, d) =>
                {
                    if (s.SmallerUnitId == null)
                        return null;
                    var id = s.SmallerUnitId;
                    //return 0;
                    return new ProductUnit(s.SmallerUnitId.Value, "json", "json", 1, 0);
                }));

            CreateMap<ProductProperty, ProductPropertyDto>();
            //.ForMember(d => d.TypeName, o => o.MapFrom(s => s.Parent.Name));
            CreateMap<ProductProperty, ProductPropertyItemDto>()
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.Parent.Name));
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<PurchaseOrderLine, PurchaseOrderLineDto>();
        }
    }
    public class ProductUnitIdConverter : ITypeConverter<string, ProductUnit>
    {
        public ProductUnit Convert(string source, ProductUnit destination, ResolutionContext context)
        {
            return null;
        }
    }

}
