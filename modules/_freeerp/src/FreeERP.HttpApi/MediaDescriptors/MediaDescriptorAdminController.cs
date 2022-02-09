using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.GlobalFeatures;

namespace FreeERP.MediaDescriptors;


[Route("api/app/media")]
public class MediaDescriptorAdminController : IMediaDescriptorAppService
{
    protected readonly IMediaDescriptorAppService MediaDescriptorAppService;

    public MediaDescriptorAdminController(IMediaDescriptorAppService mediaDescriptorAppService)
    {
        MediaDescriptorAppService = mediaDescriptorAppService;
    }

    [HttpPost]
    [Route("{entityType}")]
    public virtual Task<MediaDescriptorDto> CreateAsync(string entityType, [FromForm] CreateMediaInputWithStream inputStream)
    {
        return MediaDescriptorAppService.CreateAsync(entityType, inputStream);
    }

    [HttpDelete]
    [Route("{id}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return MediaDescriptorAppService.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id}")]
    public virtual Task<RemoteStreamContent> DownloadAsync(Guid id)
    {
        return MediaDescriptorAppService.DownloadAsync(id);
    }
}
