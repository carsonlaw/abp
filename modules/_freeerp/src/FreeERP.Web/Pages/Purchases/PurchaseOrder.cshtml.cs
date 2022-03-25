using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace FreeERP.Web.Pages;

public class PurchaseOrderModel : FreeERPPageModel
{
    [Placeholder("PHPurchaseOrderFilter")]
    public string Filter { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime OrderTimeBegin { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime OrderTimeEnd { get; set; }

    public PurchaseOrderModel()
    {
    }

    public async Task OnGetAsync()
    {
        await Task.CompletedTask;
        OrderTimeBegin = Clock.Now.AddDays(-1);
        OrderTimeEnd = Clock.Now;

    }

}
