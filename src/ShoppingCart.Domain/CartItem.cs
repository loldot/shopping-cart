using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain
{
    public class CartItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
    }
}
