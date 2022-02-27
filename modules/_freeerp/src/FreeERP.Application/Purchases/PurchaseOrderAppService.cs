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
            var entity = await _manager.CreateAsync(input.BatchNo, input.OrderTime, input.SupplierId, input.Description);
            foreach (var line in input.Lines)
            {
                entity.AddLine(GuidGenerator.Create(), line.ProductId, line.ProductSkuId, line.StoreId, line.Number, line.UnitPrice);
            }
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.PurchaseOrders.Update)]
        public override async Task<PurchaseOrderDto> UpdateAsync(Guid id, PurchaseOrderCreateUpdateDto input)
        {
            var entity = await _repository.GetAsync(id, true);
            entity = await _manager.UpdateAsync(entity, input.BatchNo, input.OrderTime, input.SupplierId, input.Description);
            entity.Lines.Clear();
            foreach (var line in input.Lines)
            {
                entity.AddLine(GuidGenerator.Create(), line.ProductId, line.ProductSkuId, line.StoreId, line.Number, line.UnitPrice);
            }

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
            ret = ret.Where(f => f.OrderTime >= input.OrderTimeBegin && f.OrderTime <= input.OrderTimeEnd);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
             f => f.OrderNo.Contains(input.Filter)
             || f.Description.Contains(input.Filter));

            return ret;
        }



    }
}