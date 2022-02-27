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

    [AutoMap(typeof(PurchaseOrderCreateUpdateDto), ReverseMap = true)]
    public class CreatePurchaseOrderViewModel
    {
        [Required]
        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxOrderNoLength))]
        public virtual string OrderNo { get; protected set; }
        [Required]
        public virtual DateTime OrderTime { get; protected set; }

        public virtual Guid? SupplierId { get; protected set; }

        [DynamicMaxLength(typeof(PurchaseOrderConsts), nameof(PurchaseOrderConsts.MaxDescriptionLength))]
        public virtual string Description { get; protected set; }


        public virtual IList<PurchaseOrderLineCreateUpdateDto> Lines { get; protected set; }
    }
}
