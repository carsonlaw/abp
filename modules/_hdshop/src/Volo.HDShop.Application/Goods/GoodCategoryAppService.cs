using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace Volo.HDShop.Goods
{
    public class GoodCategoryAppService : CrudAppService<GoodCategory,
            GoodCategoryDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting on getting a list of books
            GoodCategoryCreateUpdateDto, //Used to create a new book
            GoodCategoryCreateUpdateDto //Used to update a book
        >, IGoodCategoryAppService
    {
        private IDistributedCache<PagedResultDto<GoodCategoryDto>> cache;
        public GoodCategoryAppService(IRepository<GoodCategory,Guid> repository
            ,IDistributedCache<PagedResultDto<GoodCategoryDto>> Cache)
            :base(repository)
        {
            cache = Cache;
        }

        public override async Task<PagedResultDto<GoodCategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await cache.GetOrAddAsync("GoodCategory:List",
                async ()=> { return await base.GetListAsync(input); })
            ;
        }

    }
}
