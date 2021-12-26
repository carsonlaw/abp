using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Products
{
    public class CategoryCreateUpdateDto : IHasConcurrencyStamp
    {
        public Guid? Pid { get; set; }
        [Required]
        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxSlugLength))]
        public string Slug { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}