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
    public class ProductUnitItemWidgetViewComponent : AbpViewComponent
    {
        private IProductUnitAppService _productUnitAPPService;
        public ProductUnitItemWidgetViewComponent(IProductUnitAppService productUnitAPPService)
        {
            _productUnitAPPService = productUnitAPPService;
        }

        public async Task<IViewComponentResult> InvokeAsync(ProductUnitDto productUnitDto
            )
        {
            return View("~/Pages/Components/ProductUnitWidget/Item.cshtml", productUnitDto);
        }
    }
}