using AutoMapper;
using FreeERP.Purchases;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
