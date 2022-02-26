using AutoMapper;
using FreeERP.Suppliers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class SupplierUpdateModalModel : FreeERPPageModel
{
    protected ISupplierAppService SupplierAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public SupplierUpdateViewModel ViewModel { get; set; }

    public SupplierUpdateModalModel(ISupplierAppService supplierAppService)
    {
        SupplierAppService = supplierAppService;
    }

    public async Task OnGetAsync()
    {
        var supplier = await SupplierAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<SupplierDto, SupplierUpdateViewModel>(supplier);
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<SupplierUpdateViewModel, SupplierCreateUpdateDto>(ViewModel);

        await SupplierAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(SupplierDto))]
    [AutoMap(typeof(SupplierCreateUpdateDto), ReverseMap = true)]
    public class SupplierUpdateViewModel : IHasConcurrencyStamp
    {

        [Required]
        [DynamicMaxLength(typeof(SupplierConsts), nameof(SupplierConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(SupplierConsts), nameof(SupplierConsts.MaxDescriptionLength))]

        public string Description { get; set; }



        [Required]
        public int Sort { get; set; }

        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
