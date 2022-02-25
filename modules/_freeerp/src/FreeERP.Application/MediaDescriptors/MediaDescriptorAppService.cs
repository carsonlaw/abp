using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;

namespace FreeERP.MediaDescriptors
{
    [RemoteService(false)]
    public class MediaDescriptorAppService : FreeERPAppService, IMediaDescriptorAppService
    {
        protected IBlobContainer<MediaContainer> MediaContainer { get; }
        protected IRepository<MediaDescriptor> MediaDescriptorRepository { get; }

        public MediaDescriptorAppService(
            IBlobContainer<MediaContainer> mediaContainer,
            IRepository<MediaDescriptor> mediaDescriptorRepository)
        {
            MediaContainer = mediaContainer;
            MediaDescriptorRepository = mediaDescriptorRepository;
        }

        public virtual async Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream)
        {

            var newEntity = new MediaDescriptor(
                GuidGenerator.Create(),
                entityType,
                inputStream.Name,
                inputStream.File.ContentType,
                inputStream.File.ContentLength ?? 0,
                CurrentTenant.Id);


            await MediaContainer.SaveAsync(newEntity.Id.ToString(), inputStream.File.GetStream());
            await MediaDescriptorRepository.InsertAsync(newEntity);

            return ObjectMapper.Map<MediaDescriptor, MediaDescriptorDto>(newEntity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var mediaDescriptor = await MediaDescriptorRepository.GetAsync(f => f.Id == id);

            await MediaContainer.DeleteAsync(id.ToString());
            await MediaDescriptorRepository.DeleteAsync(f => f.Id == id);
        }

        public virtual async Task<RemoteStreamContent> GetAsync(Guid id)
        {
            var entity = await MediaDescriptorRepository.GetAsync(f => f.Id == id);
            var stream = await MediaContainer.GetAsync(id.ToString());

            return new RemoteStreamContent(stream, entity.Name);
        }
    }
}