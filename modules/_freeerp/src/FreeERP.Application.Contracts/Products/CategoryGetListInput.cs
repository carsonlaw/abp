using System;
using Volo.Abp.Application.Dtos;


namespace FreeERP.Products
{
    [Serializable]
    public class CategoryGetListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid? Pid { get; set; }
    }
}
