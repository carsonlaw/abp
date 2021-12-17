using System.ComponentModel.DataAnnotations;
using Volo.Abp.Content;
using Volo.Abp.Validation;

namespace FreeERP.MediaDescriptors
{
    public class CreateMediaInputWithStream
    {
        [Required]
        [DynamicMaxLength(typeof(MediaDescriptorConsts), nameof(MediaDescriptorConsts.MaxNameLength))]
        public string Name { get; set; }

        public IRemoteStreamContent File { get; set; }
    }
}