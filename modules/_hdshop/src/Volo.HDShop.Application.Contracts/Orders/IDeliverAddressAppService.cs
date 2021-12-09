using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.HDShop.Orders
{
    public interface IDeliverAddressAppService : ICrudAppService<
            DeliverAddressDto,
            Guid,
            PagedAndSortedResultRequestDto,
            DeliverAddressDto,
            DeliverAddressDto>
    {
    }
}
