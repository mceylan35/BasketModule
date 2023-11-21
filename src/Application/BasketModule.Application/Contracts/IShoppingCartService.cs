using BasketModule.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketModule.Application.Contracts
{
    public interface IShoppingCartService
    {
        void AddItemToCart(string productId, string productName, decimal price, int quantity);
        void RemoveItemFromCart(string productId);
        IReadOnlyList<CartItem> GetCartItems();
        decimal GetCartTotal();
    }
}
