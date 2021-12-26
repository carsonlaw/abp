using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{
    public class CategoryDto : EntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid? Pid { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ConcurrencyStamp { get; set; }
        public IList<CategoryDto> Items { get; set; } = new List<CategoryDto>();
    }
}