
using Basket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Services
{
    public interface IBasketService
    {
       Task<BasketItemsModel> GetBasketsAsync();
       Task<bool> AddBasketAsync(AddBasketItemModel request);
    
    }
}
