using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Volo.HDShop.Goods
{
    public class QueryByCate : PagedAndSortedResultRequestDto
    {
        public string CateCode { get; set; }
    }
}
