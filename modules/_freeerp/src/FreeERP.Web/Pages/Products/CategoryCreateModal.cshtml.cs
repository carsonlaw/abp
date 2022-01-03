using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Products;
using FreeERP.Web.Pages;
using System;

namespace FreeERP.Web.Pages;

public class CategoryCreateModalModel : FreeERPPageModel
{
    protected ICategoryAppService CategoryAppService { get; }

    [BindProperty]
    public CreateCategoryViewModel ViewModel { get; set; }

    public CategoryCreateModalModel(ICategoryAppService categoryAppService)
    {
        CategoryAppService = categoryAppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Guid.TryParse(Request.Form["Pid"], out var pid);
        ViewModel.Pid = pid.Equals(Guid.Empty) ? null : pid;
        var dto = ObjectMapper.Map<CreateCategoryViewModel, CategoryCreateUpdateDto>(ViewModel);

        await CategoryAppService.CreateAsync(dto);

        return NoContent();
    }

    [AutoMap(typeof(CategoryCreateUpdateDto), ReverseMap = true)]
    public class CreateCategoryViewModel
    {
        [HiddenInput]
        public Guid? Pid { get; set; }
        [Required]
        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxSlugLength))]
        [Required]
        public string Slug { get; set; }
        [Required]
        public int Sort { get; set; }
    }
}
