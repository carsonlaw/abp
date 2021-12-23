using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace FreeERP.Web.Pages;

public class CategoryModel : FreeERPPageModel
{
    [Placeholder("分类名称")]
    public string Filter { get; set; }

}
