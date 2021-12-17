using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FreeERP.Data
{
    /* This is used if database provider does't define
     * IFreeERPDbSchemaMigrator implementation.
     */
    public class NullFreeERPDbSchemaMigrator : IFreeERPDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}