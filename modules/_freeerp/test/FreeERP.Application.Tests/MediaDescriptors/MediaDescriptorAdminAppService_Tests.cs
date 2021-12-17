using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Xunit;
namespace FreeERP.MediaDescriptors
{
    public class MediaDescriptorAdminAppService_Tests : FreeERPApplicationTestBase
    {
        private Guid mediaId;
        private readonly IMediaDescriptorAdminAppService _mediaDescriptorAdminAppService;
        private readonly IRepository<MediaDescriptor> _mediaDescriptorRepository;

        public MediaDescriptorAdminAppService_Tests()
        {
            _mediaDescriptorAdminAppService = GetRequiredService<IMediaDescriptorAdminAppService>();
            _mediaDescriptorRepository = GetRequiredService<IRepository<MediaDescriptor>>();
        }

        [Fact]
        public async Task Should_Create_Media()
        {
            var mediaName = "README.md";
            var mediaContent =
                "# ABP Framework\nABP Framework is a complete **infrastructure** based on the **ASP.NET Core** to create **modern web applications** and **APIs** by following the software development **best practices** and the **latest technologies**.";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(mediaContent));

            var media = await _mediaDescriptorAdminAppService.CreateAsync(nameof(Products.Product), new CreateMediaInputWithStream
            {
                Name = mediaName,
                File = new RemoteStreamContent(stream, mediaName)
            });
            mediaId = media.Id;
            media.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Delete_Media()
        {
            await _mediaDescriptorAdminAppService.DeleteAsync(mediaId);

            (await _mediaDescriptorRepository.FindAsync(f => f.Id == mediaId)).ShouldBeNull();
        }
    }
}