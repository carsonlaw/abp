using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using FreeERP.Localization;
using FreeERP.Permissions;
using FreeERP.Products;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using Volo.Abp.ObjectExtending;

namespace FreeERP.Blazor.Pages.FreeERP.Products;

public partial class Category
{
    public Category()
    {
        ObjectMapperContext = typeof(FreeERPBlazorModule);
        LocalizationResource = typeof(FreeERPResource);

        CreatePolicyName = FreeERPPermissions.Categories.Create;
        UpdatePolicyName = FreeERPPermissions.Categories.Update;
        DeletePolicyName = FreeERPPermissions.Categories.Delete;

        //GetListInput.PidNullIsAll = true;
    }
    protected PageToolbar Toolbar { get; } = new();
    private List<TableColumn> ProductCategoryTableColumns => TableColumns.Get<Category>();

    /// <summary>
    /// 重设Breadcrumb
    /// </summary>
    /// <returns></returns>
    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:IdentityManagement"].Value));
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Users"].Value));
        return base.SetBreadcrumbItemsAsync();
    }
    protected virtual async Task OnSearchTextChanged(string value)
    {
        GetListInput.Filter = value;
        CurrentPage = 1;
        await GetEntitiesAsync();
    }

    protected override ValueTask SetTableColumnsAsync()
    {
        ProductCategoryTableColumns
            .AddRange(new TableColumn[]
            {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<Category>(),
                    },
                    new TableColumn
                    {
                        Title = L["Name"],
                        Data = nameof(CategoryDto.Name),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["Slug"],
                        Data = nameof(CategoryDto.Slug),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["Sort"],
                        Data = nameof(CategoryDto.Sort),
                        Sortable = true,
                    }
            });

        ProductCategoryTableColumns.AddRange(GetExtensionTableColumns("FreeERP",
        "ProductCategory"));
        return base.SetEntityActionsAsync();
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["NewUser"], OpenCreateModalAsync,
            IconName.Add,
            requiredPolicyName: CreatePolicyName);

        return base.SetToolbarItemsAsync();
    }


}