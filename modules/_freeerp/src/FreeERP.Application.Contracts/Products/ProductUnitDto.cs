using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{
    public class ProductUnitDto : EntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RatioCount { get; set; }
        //public ProductUnitDto? SmallerUnit { get; set; }
        public IList<ProductUnitDto> BiggerUnits { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}