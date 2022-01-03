using AutoMapper;
using FreeERP.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class ProductUnitUpdateModalModel : FreeERPPageModel
{
    protected IProductUnitAppService ProductUnitAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public ProductUnitUpdateViewModel ViewModel { get; set; }

    public ProductUnitUpdateModalModel(IProductUnitAppService categoryAppService)
    {
        ProductUnitAppService = categoryAppService;
    }

    public async Task OnGetAsync()
    {
        var category = await ProductUnitAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<ProductUnitDto, ProductUnitUpdateViewModel>(category);
        ViewModel.Pid = category.SmallerUnit?.Id;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Guid.TryParse(Request.Form["Pid"], out var pid);
        ViewModel.Pid = pid.Equals(Guid.Empty) ? null : pid;

        var dto = ObjectMapper.Map<ProductUnitUpdateViewModel, ProductUnitCreateUpdateDto>(ViewModel);

        await ProductUnitAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(ProductUnitDto))]
    [AutoMap(typeof(ProductUnitCreateUpdateDto), ReverseMap = true)]
    public class ProductUnitUpdateViewModel : IHasConcurrencyStamp
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

        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
