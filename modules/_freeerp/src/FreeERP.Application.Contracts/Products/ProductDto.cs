using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{
    public class ProductDto : AuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? MediaId { get; set; }
        public string Description { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public string StockNum { get; set; }
        public List<ProductSKUDto> Items { get; set; }
        public string ConcurrencyStamp { get; set; }
    }




}