using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Purchases;
using FreeERP.Web.Pages;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.Collections.Generic;

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
    public async Task OnGetAsync()
    {
        await Task.CompletedTask;
        if (ViewModel == null) ViewModel = new CreatePurchaseOrderViewModel();
        ViewModel.OrderTime = Clock.Now;
    }

    [AutoMap(typeof(PurchaseOrderCreateUpdateDto), ReverseMap = true)]
    public class CreatePurchaseOrderViewModel
    {
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxOrderNoLength))]
        public virtual string OrderNo { get; set; }
        [Required]
        public virtual DateTime OrderTime { get; set; }

        [DynamicFormIgnore]
        public virtual Guid? SupplierId { get; set; }

        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxDescriptionLength))]
        public virtual string Description { get; set; }

        [DynamicFormIgnore]
        public virtual IList<PurchaseOrderLineCreateUpdateDto> Lines { get; set; }
    }
}
