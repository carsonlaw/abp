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

namespace FreeERP.Customers
{
    [Authorize(FreeERPPermissions.Customers.Default)]
    public class CustomerAppService : CrudAppService<Customer, CustomerDto, Guid, CustomerGetListInput, CustomerCreateUpdateDto, CustomerCreateUpdateDto>
    , ICustomerAppService
    {
        private readonly IDistributedCache<IList<CustomerDto>> _cache;
        ICustomerRepository _repository;
        CustomerManager _manager;

        public CustomerAppService(
            ICustomerRepository repository,
            CustomerManager manager,
            IDistributedCache<IList<CustomerDto>> cache)
        : base(repository)
        {
            _repository = repository;
            _manager = manager;
            _cache = cache;
        }

        [Authorize(FreeERPPermissions.Customers.Create)]
        public override async Task<CustomerDto> CreateAsync(CustomerCreateUpdateDto input)
        {
            var entity = await _manager.CreateAsync(input.Name, input.Description, input.Sort);
            await _repository.InsertAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Customers.Update)]
        public override async Task<CustomerDto> UpdateAsync(Guid id, CustomerCreateUpdateDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity = await _manager.UpdateAsync(entity, input.Name, input.Description, input.Sort);
            await _repository.UpdateAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(FreeERPPermissions.Customers.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }

        protected override async Task<Customer> GetEntityByIdAsync(Guid id)
        {
            return await _repository.GetAsync(f => f.Id == id, true);
        }


        protected override async Task<IQueryable<Customer>> CreateFilteredQueryAsync(CustomerGetListInput input)
        {
            var ret = await base.CreateFilteredQueryAsync(input);
            ret = ret.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), f => f.Name.Contains(input.Filter));

            return ret;
        }




    }
}