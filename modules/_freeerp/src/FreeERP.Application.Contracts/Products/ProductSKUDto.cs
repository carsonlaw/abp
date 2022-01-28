using System;
using Volo.Abp.Application.Dtos;

namespace FreeERP.Products
{
    public class ProductSKUDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? MediaId { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public string StockNum { get; set; }
    }
}