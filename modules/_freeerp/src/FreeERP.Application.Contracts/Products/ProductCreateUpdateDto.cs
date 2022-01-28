using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Products
{
    public class ProductCreateUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxCodeLength))]
        public string Code { get; set; }
        public Guid? MediaId { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxDescriptionLength))]
        public string Description { get; set; }
        [Required]
        public Guid UnitId { get; set; }
        public List<ProductSKUCreateUpdateDto> Items { get; set; }
        public string ConcurrencyStamp { get; set; }
    }




}