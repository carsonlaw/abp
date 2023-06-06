using System.Threading.Tasks;
using FreeERP.Products;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System;
using Blazorise;

namespace FreeERP.Blazor.components.products;

public partial class CategorySelect : FreeERPComponentBase
{
    readonly ICategoryAppService _categoryService;
    public CategorySelect(ICategoryAppService appService)
    {
        _categoryService = appService;
    }
    [Parameter]
    public string? cssClass { get; set; }
    private Guid? _CurrentId;
    [Parameter]
    public Guid? CurrentId {
        get { return _CurrentId; }
        set {
            if (_CurrentId != value)
                CurrentIdChanged.InvokeAsync(value);
            _CurrentId = value;
        }
    }
    private string _CurrentName = "";
    [Parameter]
    public string CurrentName {
        get { return _CurrentName; }
        set {
            if (_CurrentName != value)
                CurrentNameChanged.InvokeAsync(value);
            _CurrentName = value;
        }
    }
    [Parameter]
    public EventCallback<string> CurrentNameChanged { get; set; }
    [Parameter]
    public EventCallback<Guid?> CurrentIdChanged { get; set; }
    public IList<CategoryDto>? Categorys { get; set; }

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Categorys = await _categoryService.GetCategoryTree();
    }
}