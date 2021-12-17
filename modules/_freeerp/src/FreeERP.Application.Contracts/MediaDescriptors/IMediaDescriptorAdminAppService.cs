using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.MediaDescriptors
{
    public interface IMediaDescriptorAdminAppService : IApplicationService
    {
        Task<RemoteStreamContent> DownloadAsync(Guid id);
        Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream);
        Task DeleteAsync(Guid id);
    }
}