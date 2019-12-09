using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain
{
    public class CheckoutService
    {
        const decimal SHIPPING_PRICE_PER_KG = 40;
        const string LAPTOP_SKU = "L312";
        const decimal LAPTOP_PRICE = 13999;
        const decimal LAPTOP_WEIGTH = 1.3M;

        const string SCREEN_SKU = "LG4545";
        const decimal SCREEN_PRICE = 3459;
        const decimal SCREEN_WEIGHT = 3.725M;

        const string DESKTOP_SKU = "HW089";
        const decimal DESKTOP_PRICE = 24399;
        const decimal DESKTOP_WEIGHT = 7.9M;

        const string WIRELESS_MOUSE_AND_KBOARD_SKU = "LT7733";
        const decimal WIRELESS_MOUSE_AND_KBOARD_PRICE = 699;
        const decimal WIRELESS_MOUSE_AND_KBOARD_WEIGTH = 0.8M;

        public Order Checkout(Cart cart)
        {
            var order = new Order();
            bool desktopBought = false;
            bool screenPurchased = false;
            bool peripheralsPurchased = false;

            foreach (var item in cart.Items)
            {
                decimal price = 0;
                decimal weight = 0;
                if (item.Sku == LAPTOP_SKU)
                {
                    price = LAPTOP_PRICE;
                    weight = LAPTOP_WEIGTH;
                }
                else if (item.Sku == SCREEN_SKU)
                {
                    price = SCREEN_PRICE;
                    weight = SCREEN_WEIGHT;
                    screenPurchased = true;
                }
                else if (item.Sku == DESKTOP_SKU)
                {
                    price = DESKTOP_PRICE;
                    weight = DESKTOP_WEIGHT;
                    desktopBought = true;
                }
                else if (item.Sku == WIRELESS_MOUSE_AND_KBOARD_SKU)
                {
                    price = WIRELESS_MOUSE_AND_KBOARD_PRICE;
                    weight = WIRELESS_MOUSE_AND_KBOARD_WEIGTH;
                    peripheralsPurchased = true;
                }

                order.SubTotal += price * item.Quantity;
                order.ShippingCost += weight * item.Quantity * SHIPPING_PRICE_PER_KG;
                order.Total += price * item.Quantity;
            }

            order.Total += order.ShippingCost;

            if(desktopBought && screenPurchased && peripheralsPurchased) // Package deal
            {
                decimal discount = 0.15M * (DESKTOP_PRICE + SCREEN_PRICE + WIRELESS_MOUSE_AND_KBOARD_PRICE);
                order.SubTotal -= discount;
                order.Total -= discount;
            }

            return order;
        }
    }
}
