using AutoMapper;
using FreeERP.Purchases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class PurchaseOrderUpdateModel : FreeERPPageModel
{
    protected IPurchaseOrderAppService PurchaseOrderAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public virtual Guid Id { get; set; }

    [BindProperty]
    public PurchaseOrderUpdateViewModel ViewModel { get; set; }

    public PurchaseOrderUpdateModel(IPurchaseOrderAppService categoryAppService)
    {
        PurchaseOrderAppService = categoryAppService;
    }

    public async Task OnGetAsync()
    {
        var product = await PurchaseOrderAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<PurchaseOrderDto, PurchaseOrderUpdateViewModel>(product);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ValidateModel();

        var dto = ObjectMapper.Map<PurchaseOrderUpdateViewModel, PurchaseOrderCreateUpdateDto>(ViewModel);

        await PurchaseOrderAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(PurchaseOrderDto))]
    [AutoMap(typeof(PurchaseOrderCreateUpdateDto), ReverseMap = true)]
    public class PurchaseOrderUpdateViewModel : IHasConcurrencyStamp
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
        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
