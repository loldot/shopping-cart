using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Domain.Test
{
    [TestClass]
    public class CheckoutServiceTests
    {
        private readonly CheckoutService checkoutService;

        public CheckoutServiceTests()
        {
            this.checkoutService = new CheckoutService();
        }
        [TestMethod]
        public void CalculatesPriceForLaptop()
        {
            var cart = new Cart();
            cart.Add("L312", 1);

            var order = checkoutService.Checkout(cart);

            Assert.AreEqual(13999, order.SubTotal);
        }

        [TestMethod]
        public void CalculatesShippingCosts()
        {
            var cart = new Cart();
            cart.Add("LG4545", 1);

            var order = checkoutService.Checkout(cart);

            Assert.AreEqual(149, order.ShippingCost);
        }

        [TestMethod]
        public void IncludesShippingCostsInTotal()
        {
            var cart = new Cart();
            cart.Add("LG4545", 1);

            var order = checkoutService.Checkout(cart);

            Assert.AreEqual(3608, order.Total);
        }

        [TestMethod]
        public void IncludesPackageDeal()
        {
            var cart = new Cart();
            cart.Add("LG4545", 1);
            cart.Add("HW089", 1);
            cart.Add("LT7733", 1);

            var order = checkoutService.Checkout(cart);

            Assert.AreEqual(24273.45M, order.SubTotal);
        }

        [TestMethod]
        public void DoesNotApplyDiscountToEntireOrder()
        {
            var cart = new Cart();
            cart.Add("LG4545", 1);
            cart.Add("HW089", 1);
            cart.Add("LT7733", 1);
            cart.Add("L312", 2);

            var order = checkoutService.Checkout(cart);

            Assert.AreEqual(52271.45M, order.SubTotal);
            Assert.AreEqual(601, order.ShippingCost);
            Assert.AreEqual(52872.45M, order.Total);
        }
    }
}
