using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using FreeERP.Customers;
using FreeERP.Web.Pages;
using System;

namespace FreeERP.Web.Pages;

public class CustomerCreateModalModel : FreeERPPageModel
{
    protected ICustomerAppService CustomerAppService { get; }

    [BindProperty]
    public CreateCustomerViewModel ViewModel { get; set; }

    public CustomerCreateModalModel(ICustomerAppService customerAppService)
    {
        CustomerAppService = customerAppService;
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var dto = ObjectMapper.Map<CreateCustomerViewModel, CustomerCreateUpdateDto>(ViewModel);

        await CustomerAppService.CreateAsync(dto);

        return NoContent();
    }

    [AutoMap(typeof(CustomerCreateUpdateDto), ReverseMap = true)]
    public class CreateCustomerViewModel
    {


        [Required]
        [DynamicMaxLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxNameLength))]
        public string Name { get; set; }

        [DynamicMaxLength(typeof(CustomerConsts), nameof(CustomerConsts.MaxDescriptionLength))]

        public string Description { get; set; }



        [Required]
        public int Sort { get; set; }
    }
}
