using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FreeERP.Data;
using Volo.Abp.DependencyInjection;

namespace FreeERP.EntityFrameworkCore
{
    public class EntityFrameworkCoreFreeERPDbSchemaMigrator
        : IFreeERPDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreFreeERPDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the FreeERPDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<FreeERPDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
