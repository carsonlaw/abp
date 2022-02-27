using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Purchases
{

    [Serializable]
    public class PurchaseOrderLineDto : EntityDto<Guid>
    {
        [NotNull]
        public virtual Guid ProductId { get; set; }
        [CanBeNull]
        public virtual Guid? ProductSkuId { get; set; }
        [NotNull]
        public virtual Guid StoreId { get; set; }
        [NotNull]
        public virtual long Number { get; set; }
        [CanBeNull]
        public virtual decimal? UnitPrice { get; set; }
    }

}