using AutoMapper;
using FreeERP.Stories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class StoreUpdateModalModel : FreeERPPageModel
{
    protected IStoreAppService StoreAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public StoreUpdateViewModel ViewModel { get; set; }

    public StoreUpdateModalModel(IStoreAppService storeAppService)
    {
        StoreAppService = storeAppService;
    }

    public async Task OnGetAsync()
    {
        var store = await StoreAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<StoreDto, StoreUpdateViewModel>(store);
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<StoreUpdateViewModel, StoreCreateUpdateDto>(ViewModel);

        await StoreAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(StoreDto))]
    [AutoMap(typeof(StoreCreateUpdateDto), ReverseMap = true)]
    public class StoreUpdateViewModel : IHasConcurrencyStamp
    {

        [Required]
        [DynamicMaxLength(typeof(StoreConsts), nameof(StoreConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(StoreConsts), nameof(StoreConsts.MaxDescriptionLength))]

        public string Description { get; set; }



        [Required]
        public int Sort { get; set; }

        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
