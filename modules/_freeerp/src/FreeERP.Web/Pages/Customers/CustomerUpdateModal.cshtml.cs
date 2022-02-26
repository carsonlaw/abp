using AutoMapper;
using FreeERP.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace FreeERP.Web.Pages;

public class CustomerUpdateModalModel : FreeERPPageModel
{
    protected ICustomerAppService CustomerAppService { get; }

    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CustomerUpdateViewModel ViewModel { get; set; }

    public CustomerUpdateModalModel(ICustomerAppService customerAppService)
    {
        CustomerAppService = customerAppService;
    }

    public async Task OnGetAsync()
    {
        var customer = await CustomerAppService.GetAsync(Id);

        ViewModel = ObjectMapper.Map<CustomerDto, CustomerUpdateViewModel>(customer);
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<CustomerUpdateViewModel, CustomerCreateUpdateDto>(ViewModel);

        await CustomerAppService.UpdateAsync(Id, dto);

        return NoContent();
    }

    [AutoMap(typeof(CustomerDto))]
    [AutoMap(typeof(CustomerCreateUpdateDto), ReverseMap = true)]
    public class CustomerUpdateViewModel : IHasConcurrencyStamp
    {

        [Required]
        [DynamicMaxLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxDescriptionLength))]

        public string Description { get; set; }



        [Required]
        public int Sort { get; set; }

        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
