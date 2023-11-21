using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketModule.Domain.Models
{
    public class CartItem
    {
        public string UserId { get; }
        public string ProductId { get; }
        public string ProductName { get; }
        public decimal Price { get; }
        public int Quantity { get; set; }
        public string StoreId { get; }

        public CartItem(string productId, string productName, decimal price, int quantity, string storeId,string userId)
        {
            UserId = userId;
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            StoreId=storeId;
        } 
        
    }
}