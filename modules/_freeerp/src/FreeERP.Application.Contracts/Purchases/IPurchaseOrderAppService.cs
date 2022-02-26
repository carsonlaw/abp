using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Purchases
{
    public interface IPurchaseOrderAppService : ICrudAppService<PurchaseOrderDto, Guid, PurchaseOrderGetListInput, PurchaseOrderCreateUpdateDto, PurchaseOrderCreateUpdateDto>
    {

    }
}