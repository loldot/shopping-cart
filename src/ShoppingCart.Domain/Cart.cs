using System;
using System.Collections.Generic;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        public List<CartItem> Items { get;  } = new List<CartItem>();

        public void Add(string sku, int quantity = 1)
        {
            foreach (var item in Items)
            {
                if(item.Sku == sku)
                {
                    item.Quantity += quantity;
                    
                    return;
                }
            }

            Items.Add(new CartItem
            {
                Sku = sku,
                Quantity = quantity
            });
        }

        public void Remove (string sku, int quantity = 1)
        {
            foreach (var item in Items)
            {
                if (item.Sku == sku)
                {
                    item.Quantity -= quantity;

                    return;
                }
            }

            throw new InvalidOperationException($"Item with sku {sku} is not present in cart.");
        }
    }
}
