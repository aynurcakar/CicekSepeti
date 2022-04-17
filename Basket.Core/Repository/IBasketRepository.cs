using Basket.Core.Repository.Base;
using Basket.Data.Entities;
using Basket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Repository
{
    public interface IBasketRepository : IRepository<BasketItem>
    {
        Task<List<BasketItemModel>> GetBasketsAsync();
    }
}
