using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.Stories
{
    public interface IStoreAppService : ICrudAppService<StoreDto, Guid, StoreGetListInput, StoreCreateUpdateDto, StoreCreateUpdateDto>
    {

        Task<IList<StoreDto>> GetAllListFromCache();
    }
}