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
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.StockNum, o => o.MapFrom(s => s.Stocks.Sum(st => st.StockNum)));
            CreateMap<ProductUnit, ProductUnitDto>();
            CreateMap<ProductProperty, ProductPropertyDto>();
            //.ForMember(d => d.TypeName, o => o.MapFrom(s => s.Parent.Name));
            CreateMap<ProductProperty, ProductPropertyItemDto>()
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.Parent.Name));
            CreateMap<Store, StoreDto>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<PurchaseOrderLine, PurchaseOrderLineDto>();
        }
    }
}
