using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Stories;
using FreeERP.Web.Pages;
using System;

namespace FreeERP.Web.Pages;

public class StoreCreateModalModel : FreeERPPageModel
{
    protected IStoreAppService StoreAppService { get; }

    [BindProperty]
    public CreateStoreViewModel ViewModel { get; set; }

    public StoreCreateModalModel(IStoreAppService storeAppService)
    {
        StoreAppService = storeAppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<CreateStoreViewModel, StoreCreateUpdateDto>(ViewModel);

        await StoreAppService.CreateAsync(dto);

        return NoContent();
    }

    [AutoMap(typeof(StoreCreateUpdateDto), ReverseMap = true)]
    public class CreateStoreViewModel
    {


        [Required]
        [DynamicMaxLength(typeof(StoreConsts), nameof(StoreConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(StoreConsts), nameof(StoreConsts.MaxDescriptionLength))]

        public string Description { get; set; }



        [Required]
        public int Sort { get; set; }
    }
}
