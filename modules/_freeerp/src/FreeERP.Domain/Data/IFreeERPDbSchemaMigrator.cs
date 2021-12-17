using System.Threading.Tasks;

namespace FreeERP.Data
{
    public interface IFreeERPDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
