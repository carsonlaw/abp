using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Purchases
{

    [Serializable]
    public class PurchaseOrderDto : EntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}