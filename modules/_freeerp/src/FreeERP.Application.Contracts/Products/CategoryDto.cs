using System;
using Volo.Abp.Application.Dtos;

namespace FreeERP.Products
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}