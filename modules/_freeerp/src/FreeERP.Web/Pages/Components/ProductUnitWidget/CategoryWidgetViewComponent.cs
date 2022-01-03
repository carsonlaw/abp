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
        ScriptFiles = new string[] { "/Pages/Components/ProductUnitWidget/Default.js" }
    )]
    public class ProductUnitWidgetViewComponent : AbpViewComponent
    {
        public bool IsSubMenuOpen { get; set; }
        private IProductUnitAppService _productUnitAPPService;
        public ProductUnitWidgetViewComponent(IProductUnitAppService productUnitAPPService)
        {
            _productUnitAPPService = productUnitAPPService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            ProductUnitWidgetModel model
            )
        {
            var items = await _productUnitAPPService.GetAllUnit();
            model.Items = items;
            if (!string.IsNullOrEmpty(model.Value))
            {
                findAddFormTree(model.Items, model.Breadcrumbs, model.Value);
            }
            return View(model);
        }

        private bool findAddFormTree(IList<ProductUnitDto> items, IList<string> breadcrumbs, string value)
        {
            var ret = false;
            foreach (var item in items)
            {
                if (item.Id == Guid.Parse(value))
                {
                    breadcrumbs.AddFirst(item.Name);
                    ret = true;
                }
                else if (findAddFormTree(item.BiggerUnits, breadcrumbs, value))
                {
                    breadcrumbs.AddFirst(item.Name);
                }
            }
            return ret;
        }

        private void ToggleSubMenu()
        {
            IsSubMenuOpen = !IsSubMenuOpen;
        }
    }
    public class ProductUnitWidgetModel
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string InputName { get; set; }
        public string SelectText { get; set; }
        public IList<ProductUnitDto> Items { get; set; } = new List<ProductUnitDto>();
        public IList<string> Breadcrumbs { get; set; } = new List<string>();
    }
}