using Basket.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Providers
{
    public class ProductProvider : IProductProvider
    {
        public async Task<bool> CheckExists(string productId)
        {
            return true;
        }
    }
}
