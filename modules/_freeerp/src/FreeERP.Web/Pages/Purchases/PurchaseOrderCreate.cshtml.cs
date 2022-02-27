using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Purchases;
using FreeERP.Web.Pages;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace FreeERP.Web.Pages;

public class PurchaseOrderCreateModel : FreeERPPageModel
{
    protected IPurchaseOrderAppService PurchaseOrderAppService { get; }

    [BindProperty]
    public CreatePurchaseOrderViewModel ViewModel { get; set; }

    public PurchaseOrderCreateModel(IPurchaseOrderAppService AppService)
    {
        PurchaseOrderAppService = AppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ValidateModel();

        var dto = ObjectMapper.Map<CreatePurchaseOrderViewModel, PurchaseOrderCreateUpdateDto>(ViewModel);
        await PurchaseOrderAppService.CreateAsync(dto);
        return NoContent();
    }

    [AutoMap(typeof(PurchaseOrderCreateUpdateDto), ReverseMap = true)]
    public class CreatePurchaseOrderViewModel
    {
        [Required]
        [DynamicFormIgnore]
        public Guid CategoryId { get; set; }

        [Required]
        [DynamicFormIgnore]
        public Guid UnitId { get; set; }

        [Required]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxNameLength))]
        public string Code { get; set; }

        [HiddenInput]
        public Guid? MediaId { get; set; }
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxNameLength))]
        public string Description { get; set; }

        //public List<PurchaseOrderSKUCreateUpdateDto> Items { get; set; }
        //public string ConcurrencyStamp { get; set; }
    }
}
