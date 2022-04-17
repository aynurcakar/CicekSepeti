using Basket.Core.Repository;
using Basket.Data.Entities;
using Basket.Data.Providers;
using Basket.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductProvider _productProvider;
        private readonly IStockProvider _stockProvider;


        public BasketService(IBasketRepository basketRepository, IProductProvider productProvider,IStockProvider stockProvider)
        {

            _basketRepository = basketRepository;
            _productProvider = productProvider;
            _stockProvider = stockProvider;
        }

        public async Task<bool> AddBasketAsync(AddBasketItemModel request)
        {
            try
            {
                var productExists = await _productProvider.CheckExists(request.ProductId);
                if (!productExists)
                    throw new ApplicationException("Product not found.");

                var isEnoughStock = await _stockProvider.CheckStock(request.ProductId, request.Quantity);

                if (!isEnoughStock)
                    throw new ApplicationException("There is not enough stock.");

                var existsBasketItem = await _basketRepository.GetSingleAsync(p => p.UserId == request.UserId && p.ProductId == request.ProductId);
                if (existsBasketItem != null)
                {
                    existsBasketItem.TotalPrice = (existsBasketItem.Quantity + request.Quantity) * request.Price;
                    existsBasketItem.Quantity += request.Quantity;  
                    existsBasketItem.ModifiedOn = DateTime.Now;
                    return await _basketRepository.UpdateAsync(existsBasketItem);
                }
                else
                {
                    BasketItem entity = new BasketItem()
                    {
                        UserId = request.UserId,
                        Quantity = request.Quantity,
                        Price = request.Price,
                        ProductId = request.ProductId,
                        ProductCode = request.ProductCode,
                        TotalPrice = request.Price * request.Quantity
                    };
                    var inserted = await _basketRepository.AddAsync(entity);
                    return  inserted !=null ? true:false;
                }
                 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BasketItemsModel> GetBasketsAsync()
        {
            try
            {
                var response = new BasketItemsModel();
                response.BasketItems = await _basketRepository.GetBasketsAsync();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
