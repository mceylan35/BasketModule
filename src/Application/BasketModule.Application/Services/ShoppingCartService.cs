using BasketModule.Application.Contracts;
using BasketModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketModule.Application.Services
{
    public class ShoppingCartService 
    {
        private readonly ShoppingCart _shoppingCart;
        private string _userId;
        public ShoppingCartService(string userId)
        {
            _userId = userId;
            _shoppingCart = new ShoppingCart(userId);
        }

        public void AddItemToCart(string productId, string productName, decimal price, int quantity, string storeId)
        {
            var newItem = new CartItem(productId, productName, price, quantity,storeId, _userId);
            _shoppingCart.AddItem(newItem);
        }

        public void RemoveItemFromCart(string productId, string storeId)
        {
            _shoppingCart.RemoveItem(productId,storeId);
        }

        public List<CartItem> GetCartItems()
        {
          return  _shoppingCart.CartItems;
        }

        public decimal GetCartTotal()
        {
            return _shoppingCart.CalculateTotal();
        }
    }
}