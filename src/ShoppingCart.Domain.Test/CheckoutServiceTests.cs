using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Domain.Test
{
    [TestClass]
    public class CheckoutServiceTests
    {
        [TestMethod]
        public void CanCalculatePriceForLaptop()
        {
            var checkoutService = new CheckoutService();
            var cart = new Cart();
            cart.Add("L312", 1);

            var order = checkoutService.Checkout(cart);

            Assert.AreEqual(13999, order.SubTotal);
        }
    }
}
