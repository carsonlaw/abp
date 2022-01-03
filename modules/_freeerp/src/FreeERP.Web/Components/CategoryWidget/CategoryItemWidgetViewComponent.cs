using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeERP.Products;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace FreeERP.Web.Components
{
    [Widget]
    public class CategoryItemWidgetViewComponent : AbpViewComponent
    {
        private ICategoryAppService _categoryAPPService;
        public CategoryItemWidgetViewComponent(ICategoryAppService categoryAPPService)
        {
            _categoryAPPService = categoryAPPService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CategoryDto categoryDto
            )
        {
            return View("~/Components/CategoryWidget/Item.cshtml", categoryDto);
        }
    }
}