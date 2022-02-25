using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FreeERP.Suppliers
{

    [Serializable]
    public class SupplierGetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}