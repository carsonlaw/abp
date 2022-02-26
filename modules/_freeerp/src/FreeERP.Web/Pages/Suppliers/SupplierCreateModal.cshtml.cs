using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Suppliers;
using FreeERP.Web.Pages;
using System;

namespace FreeERP.Web.Pages;

public class SupplierCreateModalModel : FreeERPPageModel
{
    protected ISupplierAppService SupplierAppService { get; }

    [BindProperty]
    public CreateSupplierViewModel ViewModel { get; set; }

    public SupplierCreateModalModel(ISupplierAppService supplierAppService)
    {
        SupplierAppService = supplierAppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<CreateSupplierViewModel, SupplierCreateUpdateDto>(ViewModel);

        await SupplierAppService.CreateAsync(dto);

        return NoContent();
    }

    [AutoMap(typeof(SupplierCreateUpdateDto), ReverseMap = true)]
    public class CreateSupplierViewModel
    {


        [Required]
        [DynamicMaxLength(typeof(SupplierConsts), nameof(SupplierConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(SupplierConsts), nameof(SupplierConsts.MaxDescriptionLength))]

        public string Description { get; set; }



        [Required]
        public int Sort { get; set; }
    }
}
