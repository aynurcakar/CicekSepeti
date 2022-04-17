
using System;

namespace Basket.Model
{
    public class AddBasketItemModel
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
