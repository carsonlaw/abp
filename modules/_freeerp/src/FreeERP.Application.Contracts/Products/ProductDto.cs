using System;
using Volo.Abp.Application.Dtos;

namespace FreeERP.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? MediaId { get; set; }
        public string Description { get; set; }
        public string StockNum { get; set; }
    }
}