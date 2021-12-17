using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace FreeERP.Products
{
    public class CreateUpdateCategoryDto
    {
        public Guid Pid { get; set; }
        [Required]
        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxSlugLength))]
        public string Slug { get; set; }
    }
}