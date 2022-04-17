using Basket.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Providers
{
    public class StockProvider : IStockProvider
    {
        public async Task<bool> CheckStock(string productId, int quantity)
        {
            return true;
        }
    }
}
