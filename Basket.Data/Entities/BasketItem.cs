using Basket.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Data.Entities
{
    public class BasketItem : BaseEntity<int>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public BasketItem()
        {

        }
        public BasketItem(string userId, string productId, string productCode, int quantity, decimal price)
        {
            UserId = userId;
            ProductId = productId;
            ProductCode = productCode;
            Quantity = quantity;
            Price = price;
        }
        public void Update(string productCode, int quantity, decimal price)
        {
            ProductCode = productCode;
            Quantity = quantity;
            Price = price;
        }
    }
}
