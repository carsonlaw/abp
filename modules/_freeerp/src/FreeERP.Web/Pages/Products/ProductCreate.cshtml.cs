using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Products;
using FreeERP.Web.Pages;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace FreeERP.Web.Pages;

public class ProductCreateModel : FreeERPPageModel
{
    protected IProductAppService ProductAppService { get; }

    [BindProperty]
    public CreateProductViewModel ViewModel { get; set; }

    public ProductCreateModel(IProductAppService AppService)
    {
        ProductAppService = AppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ValidateModel();

        var dto = ObjectMapper.Map<CreateProductViewModel, ProductCreateUpdateDto>(ViewModel);
        await ProductAppService.CreateAsync(dto);
        return NoContent();
    }

    [AutoMap(typeof(ProductCreateUpdateDto), ReverseMap = true)]
    public class CreateProductViewModel
    {
        [Required]
        [DynamicFormIgnore]
        public Guid CategoryId { get; set; }

        [Required]
        [DynamicFormIgnore]
        public Guid UnitId { get; set; }

        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxNameLength))]
        public string Name { get; set; }
        [Required]
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxCodeLength))]
        public string Code { get; set; }

        [HiddenInput]
        public Guid? MediaId { get; set; }
        [DynamicMaxLength(typeof(ProductConsts), nameof(ProductConsts.MaxDescriptionLength))]
        public string Description { get; set; }

        //public List<ProductSKUCreateUpdateDto> Items { get; set; }
        //public string ConcurrencyStamp { get; set; }
    }
}
