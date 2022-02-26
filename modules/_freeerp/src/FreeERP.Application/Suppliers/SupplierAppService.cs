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

namespace FreeERP.Suppliers
{
    [Authorize(FreeERPPermissions.Suppliers.Default)]
    public class SupplierAppService : CrudAppService<Supplier, SupplierDto, Guid, SupplierGetListInput, SupplierCreateUpdateDto, SupplierCreateUpdateDto>
    , ISupplierAppService
    {
        private readonly IDistributedCache<IList<SupplierDto>> _cache;
        ISupplierRepository _repository;
        SupplierManager _manager;

        public SupplierAppService(
            ISupplierRepository repository,
            SupplierManager manager,
            IDistributedCache<IList<SupplierDto>> cache)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.Suppliers.Create)]
        public override async Task<SupplierDto> CreateAsync(SupplierCreateUpdateDto input)
        {
            var entity = await _manager.CreateAsync(input.Name, input.Description, input.Sort);
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Suppliers.Update)]
        public override async Task<SupplierDto> UpdateAsync(Guid id, SupplierCreateUpdateDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity = await _manager.UpdateAsync(entity, input.Name, input.Description, input.Sort);
            await _repository.UpdateAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Suppliers.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }

        protected override async Task<Supplier> GetEntityByIdAsync(Guid id)
        {
            return await _repository.GetAsync(f => f.Id == id, true);
        }



        protected override async Task<IQueryable<Supplier>> CreateFilteredQueryAsync(SupplierGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));

            return ret;
        }



    }
}