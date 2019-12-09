using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain
{
    public class CheckoutService
    {
        const string LAPTOP_SKU = "L312";
        const string SCREEN_SKU = "LG4545";

        public Order Checkout(Cart cart)
        {
            var order = new Order();
            bool laptopPurchased = false;
            bool screenPurchased = false;
            bool mousePurchased = false;

            foreach(var item in cart.Items)
            {
                decimal price = 0;
                if (item.Sku == LAPTOP_SKU)
                {
                    price = 13999;
                    laptopPurchased = true;
                }
                else if(item.Sku == SCREEN_SKU)
                {
                    price = 3459;
                    screenPurchased = true;
                }
                
                order.SubTotal += price * item.Quantity;
                order.Total += price * item.Quantity;
            }

            return order;
        }
    }
}
