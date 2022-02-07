using AutoMapper;
using FreeERP.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class ProductUpdateModalModel : FreeERPPageModel
{
    protected IProductAppService ProductAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public ProductUpdateViewModel ViewModel { get; set; }

    public ProductUpdateModalModel(IProductAppService categoryAppService)
    {
        ProductAppService = categoryAppService;
    }

    public async Task OnGetAsync()
    {
        var product = await ProductAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<ProductDto, ProductUpdateViewModel>(product);
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<ProductUpdateViewModel, ProductCreateUpdateDto>(ViewModel);

        await ProductAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(ProductDto))]
    [AutoMap(typeof(ProductCreateUpdateDto), ReverseMap = true)]
    public class ProductUpdateViewModel : IHasConcurrencyStamp
    {
        [HiddenInput]
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxCodeLength))]
        public string Code { get; set; }
        public Guid? MediaId { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxDescriptionLength))]
        public string Description { get; set; }
        [HiddenInput]
        [Required]
        public Guid UnitId { get; set; }
        //public List<ProductSKUCreateUpdateDto> Items { get; set; }
        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
