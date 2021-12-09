using System;
using System.Collections.Generic;
using System.Text;

namespace Volo.HDShop.Orders
{
    public class OrderCreateUpdateDto
    {
        public virtual IEnumerable<OrderLineDto> OrderLines { get; set; }

        public virtual DeliverAddressDto DeliverAddress { get; set; }

        public virtual PayOrderDto? PayOrder { get; set; }
        public virtual DeliverOrderDto? DeliverOrder { get; set; }
    }
}
