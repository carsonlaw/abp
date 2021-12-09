using System;
using System.Collections.Generic;
using System.Text;

namespace Volo.HDShop.Orders
{
    public class OrderDeliverAddressMap
    {
        //public Order Order { get; set; }
        //public DeliverAddress DeliverAddress { get; set; }

        public Guid OrderId { get; set; }
        public Guid DeliverAddressId { get; set; }
    }
}
