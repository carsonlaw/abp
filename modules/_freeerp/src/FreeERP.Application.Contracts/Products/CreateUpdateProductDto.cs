using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace FreeERP.Products
{
    public class CreateUpdateProductDto
    {
        public Guid CategoryId { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxCodeLength))]
        public string Code { get; set; }
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxDescriptionLength))]
        public string Description { get; set; }
    }
}