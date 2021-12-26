using AutoMapper;
using FreeERP.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class CategoryUpdateModalModel : FreeERPPageModel
{
    protected ICategoryAppService CategoryAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CategoryUpdateViewModel ViewModel { get; set; }

    public CategoryUpdateModalModel(ICategoryAppService categoryAppService)
    {
        CategoryAppService = categoryAppService;
    }

    public async Task OnGetAsync()
    {
        var category = await CategoryAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<CategoryDto, CategoryUpdateViewModel>(category);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Guid.TryParse(Request.Form["Pid"], out var pid);
        ViewModel.Pid = pid.Equals(Guid.Empty) ? null : pid;

        var dto = ObjectMapper.Map<CategoryUpdateViewModel, CategoryCreateUpdateDto>(ViewModel);

        await CategoryAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(CategoryDto))]
    [AutoMap(typeof(CategoryCreateUpdateDto), ReverseMap = true)]
    public class CategoryUpdateViewModel : IHasConcurrencyStamp
    {
        [HiddenInput]
        public Guid? Pid { get; set; }
        [Required]
        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(CategoryConsts), nameof(CategoryConsts.MaxSlugLength))]
        [Required]
        public string Slug { get; set; }

        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
