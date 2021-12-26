using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeERP.Products;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace FreeERP.Web.Components
{
    [Widget(
        ScriptFiles = new string[] { "/Pages/Components/CategoryWidget/Default.js" }
    )]
    public class CategoryWidgetViewComponent : AbpViewComponent
    {
        public bool IsSubMenuOpen { get; set; }
        private ICategoryAppService _categoryAPPService;
        public CategoryWidgetViewComponent(ICategoryAppService categoryAPPService)
        {
            _categoryAPPService = categoryAPPService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            CategoryWidgetModel model
            )
        {
            var categories = await _categoryAPPService.GetCategoryTree(new CategoryGetListInput());
            model.Items = categories;
            if (!string.IsNullOrEmpty(model.Value))
            {
                model.Breadcrumbs.Add("分类1");
            }
            return View(model);
        }
        private void ToggleSubMenu()
        {
            IsSubMenuOpen = !IsSubMenuOpen;
        }
    }
    public class CategoryWidgetModel
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string InputName { get; set; }
        public string SelectText { get; set; }
        public IList<CategoryDto> Items { get; set; } = new List<CategoryDto>();
        public IList<string> Breadcrumbs { get; set; } = new List<string>();
    }
}