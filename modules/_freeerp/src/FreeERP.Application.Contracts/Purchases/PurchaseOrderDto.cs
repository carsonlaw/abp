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
    public class PurchaseOrderDto : EntityDto<Guid>, IHasConcurrencyStamp
    {
        // public string Name { get; set; }
        // public string Description { get; set; }
        [Required]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxOrderNoLength))]
        public virtual string OrderNo { get; protected set; }
        [Required]
        public virtual DateTime OrderTime { get; protected set; }
        [CanBeNull]
        public virtual Guid? SupplierId { get; protected set; }
        [CanBeNull]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxDescriptionLength))]
        public virtual string Description { get; protected set; }
        [CanBeNull]
        public virtual decimal? Price { get; protected set; }

        public virtual IList<PurchaseOrderLineDto> Lines { get; protected set; }
        public string ConcurrencyStamp { get; set; }
    }


}