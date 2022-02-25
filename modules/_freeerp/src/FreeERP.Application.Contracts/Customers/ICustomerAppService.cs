using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Customers
{
    public interface ICustomerAppService : ICrudAppService<CustomerDto, Guid, CustomerGetListInput, CustomerCreateUpdateDto, CustomerCreateUpdateDto>
    {

    }
}