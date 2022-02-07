using System;
using Volo.Abp.Application.Dtos;


namespace FreeERP.Products
{
    [Serializable]
    public class ProductGetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
