using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Customers
{

    [Serializable]
    public class CustomerGetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}