using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }
        public List<ShoppingCartItems> shoppingCartItems { set; get; } = new List<ShoppingCartItems>();

        public ShoppingCart()
        {

        }
        public ShoppingCart(string username)
        {
            Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in shoppingCartItems)
                {
                    totalPrice += item.Quantity * item.Price;
                }
                return totalPrice;
            }
        }



    }
}
