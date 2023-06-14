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

public partial class ProductUnit
{
    protected string? ProductUnitName;
    protected string? ProductUnitModelName;
    public ProductUnit()
    {
        ObjectMapperContext = typeof(FreeERPBlazorModule);
        LocalizationResource = typeof(FreeERPResource);

        CreatePolicyName = FreeERPPermissions.Categories.Create;
        UpdatePolicyName = FreeERPPermissions.Categories.Update;
        DeletePolicyName = FreeERPPermissions.Categories.Delete;

        //GetListInput.PidNullIsAll = true;
    }
    protected PageToolbar Toolbar { get; } = new();
    private List<TableColumn> ProductProductUnitTableColumns => TableColumns.Get<ProductUnit>();

    protected override Task OnInitializedAsync()
    {
        ProductUnitName = L["ProductUnitSelect"];
        return base.OnInitializedAsync();
    }

    /// <summary>
    /// 重设Breadcrumb
    /// </summary>
    /// <returns></returns>
    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:ProductsGroupName"].Value));
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:ProductUnit"].Value));
        return base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<ProductUnit>()
            .AddRange(new EntityAction[]
            {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => await OpenEditModalAsync(data.As<ProductUnitDto>())
                    },

                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission, //&& CurrentUser.GetId() != data.As<ProductUnitDto>().Id,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<ProductUnitDto>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<ProductUnitDto>())
                    }
            });

        return base.SetEntityActionsAsync();
    }

    protected override ValueTask SetTableColumnsAsync()
    {
        ProductProductUnitTableColumns
            .AddRange(new TableColumn[]
            {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<ProductUnit>(),
                    },
                    new TableColumn
                    {
                        Title = L["Name"],
                        Data = nameof(ProductUnitDto.Name),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["Description"],
                        Data = nameof(ProductUnitDto.Description),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["RatioCount"],
                        Data = nameof(ProductUnitDto.RatioCount),
                        Sortable = true,
                    },
                    new TableColumn
                    {
                        Title = L["Sort"],
                        Data = nameof(ProductUnitDto.Sort),
                        Sortable = true,
                    }
            });

        ProductProductUnitTableColumns.AddRange(GetExtensionTableColumns("FreeERP",
        "ProductUnit"));
        return base.SetTableColumnsAsync();
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["ProductUnitNew"], OpenCreateModalAsync,
            IconName.Add,
            requiredPolicyName: CreatePolicyName);

        return base.SetToolbarItemsAsync();
    }

    protected override Task OpenCreateModalAsync()
    {
        ProductUnitModelName = L["ProductUnitParentSelect"];
        return base.OpenCreateModalAsync();
    }
    protected override async Task OpenEditModalAsync(ProductUnitDto entity)
    {
        ProductUnitModelName = await getProductUnitNameById(entity.SmallerUnitId);
        await base.OpenEditModalAsync(entity);
    }

    private async Task<string> getProductUnitNameById(Guid? id)
    {
        if (!id.HasValue)
            return L["ProductUnitParentSelect"];
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

    protected override string GetDeleteConfirmationMessage(ProductUnitDto entity)
    {
        return base.GetDeleteConfirmationMessage(entity);
    }

    protected virtual async Task OnSearchTextChanged()
    {
        CurrentPage = 1;
        await GetEntitiesAsync();
    }

}