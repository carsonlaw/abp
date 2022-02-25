using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Suppliers
{
    public interface ISupplierAppService : ICrudAppService<SupplierDto, Guid, SupplierGetListInput, SupplierCreateUpdateDto, SupplierCreateUpdateDto>
    {

    }
}