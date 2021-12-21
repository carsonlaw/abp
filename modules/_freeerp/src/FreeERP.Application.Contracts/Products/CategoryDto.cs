using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FreeERP.Products
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<CategoryDto> Items { get; set; } = new List<CategoryDto>();
    }
}