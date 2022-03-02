using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Purchases
{

    [Serializable]
    public class PurchaseOrderGetListInput : PagedAndSortedResultRequestDto, IValidatableObject
    {
        public string Filter { get; set; }
        public DateTime OrderTimeBegin { get; set; }
        public DateTime OrderTimeEnd { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var ret = base.Validate(validationContext);
            var months = (OrderTimeEnd.Year - OrderTimeBegin.Year) * 12 + OrderTimeEnd.Month - OrderTimeBegin.Month;
            if (OrderTimeBegin > OrderTimeEnd || months > 60)
            {
                yield return new ValidationResult(
                    $"您的输入有误 ", new[] { nameof(OrderTimeBegin), nameof(OrderTimeEnd) });
            }
            foreach (var i in ret)
            {
                yield return i;
            }
        }
    }

}