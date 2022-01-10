using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Products
{

    [Serializable]
    public class ProductPropertyDto : EntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        //public string TypeName { get; set; }
        public string Description { get; set; }
        public IList<ProductPropertyItemDto> Items { get; set; }
        public string ConcurrencyStamp { get; set; }
    }

    public class ProductPropertyItemDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
    }
}