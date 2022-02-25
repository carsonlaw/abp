using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace FreeERP.MediaDescriptors
{
    public interface IMediaDescriptorAppService : IApplicationService
    {
        Task<RemoteStreamContent> GetAsync(Guid id);
        Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream);
        Task DeleteAsync(Guid id);
    }
}