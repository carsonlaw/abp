using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Products
{
    public class ProductUnitCreateUpdateDto : IHasConcurrencyStamp
    {
        public Guid? Pid { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductUnitConsts), nameof(ProductUnitConsts.MaxNameLength))]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int RatioCount { get; set; }
        [Required]
        public int Sort { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}