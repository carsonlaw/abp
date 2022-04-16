using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Stories
{

    [Serializable]
    public class StoreSelectDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}