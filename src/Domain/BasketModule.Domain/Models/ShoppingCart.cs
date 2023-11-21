using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketModule.Domain.Models
{
    public class ShoppingCart
    {
        public string UserId { get; }  
        private List<CartItem> cartItems; 
        public List<CartItem> CartItems { get { return cartItems; } }

        public ShoppingCart(string userId)
        {
            UserId = userId;
            cartItems = new List<CartItem>();
        }

        public void AddItem(CartItem cartItem)
        {
            var existingItem = cartItems
                                        .FirstOrDefault(item => item.ProductId == cartItem.ProductId
                                                             && item.StoreId == cartItem.StoreId
                                                             && item.UserId == UserId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            { 
                cartItems.Add(cartItem);
            }
        }

        public void RemoveItem(string productId,string storeId)
        {
            var itemToRemove = cartItems
                                        .SingleOrDefault(item => item.ProductId == productId
                                                              && item.StoreId == storeId
                                                              && item.UserId==UserId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
        }

        public decimal CalculateTotal()
        {
            return cartItems
                            .Where(item => item.UserId == UserId)
                            .Sum(item => item.Price * item.Quantity);
        }
    }
}
