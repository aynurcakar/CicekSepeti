using Basket.Core.Context;
using Basket.Core.Repository.Base;
using Basket.Data.Entities;
using Basket.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Repository
{
    public class BasketRepository : Repository<BasketItem>, IBasketRepository
    {

        public BasketRepository(BasketDbContext _basketDbContext) : base(_basketDbContext) { }

        public async Task<List<BasketItemModel>> GetBasketsAsync()
        {
            var basketItems= await _basketDbContext.BasketItems.ToListAsync();
            return basketItems.Select(p => new BasketItemModel
            {
                Id = p.Id,
                UserId = p.UserId,
                ProductId = p.ProductId,
                ProductCode = p.ProductCode,
                Quantity = p.Quantity,
                Price = p.Price,
                TotalPrice = p.TotalPrice,
                IsActive=p.IsActive  
            }).ToList();
        }
   
    }
}
