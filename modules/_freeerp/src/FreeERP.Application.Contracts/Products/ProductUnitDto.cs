using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{

    [Serializable]
    public class ProductUnitDto : EntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RatioCount { get; set; }
        [JsonIgnore]
        public ProductUnitDto SmallerUnit { get; set; }
        public IList<ProductUnitDto> BiggerUnits { get; set; }
        public int Sort { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}