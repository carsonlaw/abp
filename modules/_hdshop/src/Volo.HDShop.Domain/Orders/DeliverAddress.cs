using Volo.HDShop.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Volo.HDShop.Orders
{
    public class DeliverAddress : FullAuditedEntityWithUser<Guid, ShopUser>
    {
        [Required]
        [StringLength(AddressConsts.NameLength)]
        public virtual string Name { get; set; }
        [Required]
        [RegularExpression(AddressConsts.PhoneReg)]
        public virtual string Phone { get; set; }
        [Required]
        [StringLength(AddressConsts.AddressLength)]
        public virtual string Address { get; set; }
    }
}
