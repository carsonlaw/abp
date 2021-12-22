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
        private ICategoryAppService _categoryAPPService;
        public CategoryWidgetViewComponent(ICategoryAppService categoryAPPService)
        {
            _categoryAPPService = categoryAPPService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            )
        {

            var categories = await _categoryAPPService.GetCategoryTree(new CategoryGetListInput());
            return View(categories);
        }
    }
}