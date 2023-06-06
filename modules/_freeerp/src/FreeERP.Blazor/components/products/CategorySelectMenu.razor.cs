using System.Threading.Tasks;
using FreeERP.Products;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System;
using Blazorise;

namespace FreeERP.Blazor.components.products;

public partial class CategorySelectMenu : FreeERPComponentBase
{
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
    [Parameter]
    public EventCallback<Guid?> CurrentIdChanged { get; set; }

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
    public IList<CategoryDto>? Categorys { get; set; }

    public async Task CategoryClicked(FreeERP.Products.CategoryDto category)
    {
        CurrentId = (category.Id);
        CurrentName = category.Name;
        await Task.CompletedTask;
    }
}