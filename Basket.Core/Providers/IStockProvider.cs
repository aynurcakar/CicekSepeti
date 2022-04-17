using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Data.Providers
{
    public interface IStockProvider
    {
        Task<bool> CheckStock(string productId, int quantity);
    }
}
