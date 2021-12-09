using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Volo.HDShop.Orders
{
    public interface IOrderAppService : ICrudAppService<
            OrderDto, 
            Guid,
            OrderQueryRequestDto, 
            OrderCreateUpdateDto, 
            OrderCreateUpdateDto> 
    {
    }
}
