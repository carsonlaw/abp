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
    public class PurchaseOrderCreateUpdateDto : IHasConcurrencyStamp
    {
        [NotNull]
        [Required]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxOrderNoLength))]
        public virtual string BatchNo { get; set; }
        [NotNull]
        public virtual DateTime OrderTime { get; set; }
        [CanBeNull]
        public virtual Guid? SupplierId { get; set; }
        [CanBeNull]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxDescriptionLength))]
        public virtual string Description { get; set; }

        public virtual IList<PurchaseOrderLineCreateUpdateDto> Lines { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}