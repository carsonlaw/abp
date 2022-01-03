using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Products;
using FreeERP.Web.Pages;
using System;

namespace FreeERP.Web.Pages;

public class ProductUnitCreateModalModel : FreeERPPageModel
{
    protected IProductUnitAppService ProductUnitAppService { get; }

    [BindProperty]
    public CreateProductUnitViewModel ViewModel { get; set; }

    public ProductUnitCreateModalModel(IProductUnitAppService categoryAppService)
    {
        ProductUnitAppService = categoryAppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Guid.TryParse(Request.Form["Pid"], out var pid);
        ViewModel.Pid = pid.Equals(Guid.Empty) ? null : pid;
        var dto = ObjectMapper.Map<CreateProductUnitViewModel, ProductUnitCreateUpdateDto>(ViewModel);

        await ProductUnitAppService.CreateAsync(dto);

        return NoContent();
    }

    [AutoMap(typeof(ProductUnitCreateUpdateDto), ReverseMap = true)]
    public class CreateProductUnitViewModel
    {
        [HiddenInput]
        public Guid? Pid { get; set; }

        [Required]
        [DynamicMaxLength(typeof(ProductUnitConsts), nameof(ProductUnitConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(ProductUnitConsts), nameof(ProductUnitConsts.MaxDescriptionLength))]

        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        public int RatioCount { get; set; }

        [Required]
        public int Sort { get; set; }
    }
}
