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

public partial class Product
{
    protected string? ProductName;
    protected string? ProductModelName;
    public Product()
    {
        ObjectMapperContext = typeof(FreeERPBlazorModule);
        LocalizationResource = typeof(FreeERPResource);

        CreatePolicyName = FreeERPPermissions.Categories.Create;
        UpdatePolicyName = FreeERPPermissions.Categories.Update;
        DeletePolicyName = FreeERPPermissions.Categories.Delete;

    }
    protected PageToolbar Toolbar { get; } = new();
    private List<TableColumn> ProductProductTableColumns => TableColumns.Get<Product>();

    protected override Task OnInitializedAsync()
    {
        ProductName = L["ProductSelect"];
        return base.OnInitializedAsync();
    }
    protected override Task SearchEntitiesAsync()
    {
        return base.SearchEntitiesAsync();
    }

    /// <summary>
    /// 重设Breadcrumb
    /// </summary>
    /// <returns></returns>
    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:ProductsGroupName"].Value));
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:Product"].Value));
        return base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<Product>()
            .AddRange(new EntityAction[]
            {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => await OpenEditModalAsync(data.As<ProductDto>())
                    },

                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission, //&& CurrentUser.GetId() != data.As<ProductDto>().Id,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<ProductDto>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<ProductDto>())
                    }
            });

        return base.SetEntityActionsAsync();
    }

    protected override ValueTask SetTableColumnsAsync()
    {
        ProductProductTableColumns
            .AddRange(new TableColumn[]
            {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<Product>(),
                    },
                    new TableColumn
                    {
                        Title = L["Name"],
                        Data = nameof(ProductDto.Name),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["Description"],
                        Data = nameof(ProductDto.Description),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["UnitName"],
                        PropertyName = nameof(ProductDto.UnitId),
                        Data = nameof(ProductDto.UnitName),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["CategoryName"],
                        PropertyName = nameof(ProductDto.CategoryId),
                        Data = nameof(ProductDto.CategoryName),
                        Sortable = true,
                    }
            });

        ProductProductTableColumns.AddRange(GetExtensionTableColumns("FreeERP",
        "Product"));
        return base.SetTableColumnsAsync();
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["ProductNew"], OpenCreateModalAsync,
            IconName.Add,
            requiredPolicyName: CreatePolicyName);

        return base.SetToolbarItemsAsync();
    }

    protected override Task OpenCreateModalAsync()
    {
        ProductModelName = L["ProductParentSelect"];
        return base.OpenCreateModalAsync();
    }
    protected override async Task OpenEditModalAsync(ProductDto entity)
    {
        ProductModelName = await getProductNameById(entity.CategoryId);
        await base.OpenEditModalAsync(entity);
    }

    private async Task<string> getProductNameById(Guid? id)
    {
        if (!id.HasValue)
            return L["ProductParentSelect"];
        var obj = await AppService.GetAsync(id.Value);
        return obj.Name;
    }

    protected override Task OnUpdatingEntityAsync()
    {
        return base.OnUpdatingEntityAsync();
    }
    protected override async Task OnUpdatedEntityAsync()
    {
        await InvokeAsync(StateHasChanged);
        await base.OnUpdatedEntityAsync();
    }

    protected override string GetDeleteConfirmationMessage(ProductDto entity)
    {
        return base.GetDeleteConfirmationMessage(entity);
    }

    protected virtual async Task OnSearchTextChanged()
    {
        CurrentPage = 1;
        await GetEntitiesAsync();
    }

}