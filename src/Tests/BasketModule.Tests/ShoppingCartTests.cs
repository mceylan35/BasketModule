using BasketModule.Application.Services;

namespace BasketModule.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemToCart_ShouldAddItemToCart()
        {

            var userId = "1";
            var shoppingCartService = new ShoppingCartService(userId);
            var productId = "1";
            var productName = "Bardak";
            var price = 100.0m;
            var quantity = 10;
            var storeId = "1";


            shoppingCartService.AddItemToCart(productId, productName, price, quantity, storeId);
            var cartItems = shoppingCartService.GetCartItems();

            Assert.AreEqual(productId, cartItems.First().ProductId);
            Assert.AreEqual(productName, cartItems.First().ProductName);
            Assert.AreEqual(price, cartItems.First().Price);
            Assert.AreEqual(quantity, cartItems.First().Quantity);
            Assert.AreEqual(storeId, cartItems.First().StoreId);
            Assert.AreEqual(userId, cartItems.First().UserId);
        }


        [Test]
        public void RemoveItemFromCart_ShouldRemoveItemFromCart()
        {
            var userId = "1";
            var shoppingCartService = new  ShoppingCartService(userId);
            var productId = "1";
            var productName = "Kalem";
            var price = 50.0m;
            var quantity = 2;
            var storeId = "1";
            shoppingCartService.AddItemToCart(productId, productName, price, quantity, storeId);

            shoppingCartService.RemoveItemFromCart(productId, storeId);
            var cartItems = shoppingCartService.GetCartItems();

            Assert.AreEqual(0, cartItems.Count);
        }
        [Test]
        public void CalculateTotal_ShouldCalculateTotalCorrectly()
        {
            var userId = "1";
            var shoppingCartService = new ShoppingCartService(userId);
            var productId1 = "1";
            var productName1 = "Tabak";
            var price1 = 200.0m;
            var quantity1 = 2;
            var storeId1 = "1";
            var productId2 = "2";
            var productName2 = "Kaşık";
            var price2 = 15.0m;
            var quantity2 = 6;
            var storeId2 = "2";


            shoppingCartService.AddItemToCart(productId1, productName1, price1, quantity1, storeId1);
            shoppingCartService.AddItemToCart(productId2, productName2, price2, quantity2, storeId2);

            var total = shoppingCartService.GetCartTotal();

            Assert.AreEqual(490.0m, total);
        }

        [Test]
        public void RemoveItemFromCart_ShouldNotFailIfItemNotInCart()
        {
            var userId = "1";
            var shoppingCartService = new ShoppingCartService(userId);
            var productId = "1";
            var storeId = "1";
            shoppingCartService.RemoveItemFromCart(productId,storeId);
            var cartItems = shoppingCartService.GetCartItems();

            Assert.AreEqual(0, cartItems.Count);
        }

    }
}
