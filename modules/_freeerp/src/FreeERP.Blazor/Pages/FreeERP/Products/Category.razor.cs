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
    protected string CategoryName;
    protected string CategoryModelName;
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

    protected override Task OnInitializedAsync()
    {
        CategoryName = L["CategorySelect"];
        return base.OnInitializedAsync();
    }

    /// <summary>
    /// 重设Breadcrumb
    /// </summary>
    /// <returns></returns>
    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:ProductsGroupName"].Value));
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:Category"].Value));
        return base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<Category>()
            .AddRange(new EntityAction[]
            {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => await OpenEditModalAsync(data.As<CategoryDto>())
                    },

                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission, //&& CurrentUser.GetId() != data.As<CategoryDto>().Id,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<CategoryDto>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<CategoryDto>())
                    }
            });

        return base.SetEntityActionsAsync();
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
        return base.SetTableColumnsAsync();
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["CategoryNew"], OpenCreateModalAsync,
            IconName.Add,
            requiredPolicyName: CreatePolicyName);

        return base.SetToolbarItemsAsync();
    }

    protected override Task OpenCreateModalAsync()
    {
        CategoryModelName = L["CategoryParentSelect"];
        return base.OpenCreateModalAsync();
    }
    protected override async Task OpenEditModalAsync(CategoryDto entity)
    {
        CategoryModelName = await getCategoryNameById(entity.Pid);
        await base.OpenEditModalAsync(entity);
    }

    private async Task<string> getCategoryNameById(Guid? id)
    {
        if (!id.HasValue)
            return L["CategoryParentSelect"];
        var obj = await AppService.GetAsync(id.Value);
        return obj.Name;
    }

    protected override Task OnUpdatingEntityAsync()
    {
        return base.OnUpdatingEntityAsync();
    }

    protected override string GetDeleteConfirmationMessage(CategoryDto entity)
    {
        return base.GetDeleteConfirmationMessage(entity);
    }

    protected virtual async Task OnSearchTextChanged()
    {
        CurrentPage = 1;
        await GetEntitiesAsync();
    }

}