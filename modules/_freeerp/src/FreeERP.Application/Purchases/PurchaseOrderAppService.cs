using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using FreeERP.Permissions;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Microsoft.Extensions.Logging;

namespace FreeERP.Purchases
{
    [Authorize(FreeERPPermissions.PurchaseOrders.Default)]
    public class PurchaseOrderAppService : CrudAppService<PurchaseOrder, PurchaseOrderDto, Guid, PurchaseOrderGetListInput, PurchaseOrderCreateUpdateDto, PurchaseOrderCreateUpdateDto>
    , IPurchaseOrderAppService
    {
        private readonly IDistributedCache<IList<PurchaseOrderDto>> _cache;
        IPurchaseOrderRepository _repository;
        PurchaseOrderManager _manager;

        public PurchaseOrderAppService(
            IPurchaseOrderRepository repository,
            PurchaseOrderManager manager,
            IDistributedCache<IList<PurchaseOrderDto>> cache)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.PurchaseOrders.Create)]
        public override async Task<PurchaseOrderDto> CreateAsync(PurchaseOrderCreateUpdateDto input)
        {
            var entity = await _manager.CreateAsync(input.Name, input.Description, 0);
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.PurchaseOrders.Update)]
        public override async Task<PurchaseOrderDto> UpdateAsync(Guid id, PurchaseOrderCreateUpdateDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity = await _manager.UpdateAsync(entity, input.Name, input.Description, 0);
            await _repository.UpdateAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.PurchaseOrders.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }

        protected override async Task<PurchaseOrder> GetEntityByIdAsync(Guid id)
        {
            return await _repository.GetAsync(f => f.Id == id, true);
        }



        protected override async Task<IQueryable<PurchaseOrder>> CreateFilteredQueryAsync(PurchaseOrderGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            //ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));

            return ret;
        }



    }
}