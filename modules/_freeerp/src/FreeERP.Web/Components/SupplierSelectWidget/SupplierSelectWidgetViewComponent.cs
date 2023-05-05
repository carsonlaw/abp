using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreeERP.Suppliers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace FreeERP.Web.Components
{
    [Widget(
        ScriptFiles = new string[] { "/Components/SupplierSelectWidget/Default.js" }
    )]
    public class SupplierSelectWidget : AbpViewComponent
    {
        private ISupplierAppService _supplierAPPService;
        public SupplierSelectWidget(ISupplierAppService supplierAPPService)
        {
            _supplierAPPService = supplierAPPService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            SupplierSelectWidgetModel model
            )
        {

            return View("~/Components/SupplierSelectWidget/Default.cshtml", model);
        }


    }
    public class SupplierSelectWidgetModel
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string InputName { get; set; }
    }
}