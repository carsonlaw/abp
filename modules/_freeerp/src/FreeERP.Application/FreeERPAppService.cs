using System;
using System.Collections.Generic;
using System.Text;
using FreeERP.Localization;
using Volo.Abp.Application.Services;

namespace FreeERP
{
    /* Inherit your application services from this class.
     */
    public abstract class FreeERPAppService : ApplicationService
    {
        protected FreeERPAppService()
        {
            LocalizationResource = typeof(FreeERPResource);
        }
    }
}
