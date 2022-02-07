using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Products;
using FreeERP.Web.Pages;
using System;

namespace FreeERP.Web.Pages;

public class ProductCreateModal : FreeERPPageModel
{
    protected IProductAppService ProductAppService { get; }

    [BindProperty]
    public CreateProductViewModel ViewModel { get; set; }

    public ProductCreateModal(IProductAppService AppService)
    {
        ProductAppService = AppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        //Guid.TryParse(Request.Form["Pid"], out var pid);
        //ViewModel.Pid = pid.Equals(Guid.Empty) ? null : pid;
        var dto = ObjectMapper.Map<CreateProductViewModel, ProductCreateUpdateDto>(ViewModel);

        await ProductAppService.CreateAsync(dto);

        return NoContent();
    }

    [AutoMap(typeof(ProductCreateUpdateDto), ReverseMap = true)]
    public class CreateProductViewModel
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
        //public string ConcurrencyStamp { get; set; }
    }
}
