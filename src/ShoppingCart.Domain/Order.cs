using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain
{
    public class Order
    {
        public decimal SubTotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total { get; set; }
    }
}
