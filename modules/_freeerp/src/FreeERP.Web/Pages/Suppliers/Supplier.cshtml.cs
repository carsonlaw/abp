using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace FreeERP.Web.Pages;

public class SupplierModel : FreeERPPageModel
{
    [Placeholder("Name")]
    public string Filter { get; set; }
}
