using System.Threading.Tasks;
using Basket.Model;
using Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("Baskets")]
        public async Task<ActionResult<BasketItemsModel>> Baskets()
        {
            var response = await _service.GetBasketsAsync();
            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddBasket([FromBody] AddBasketItemModel request)
        {
            var response = await _service.AddBasketAsync(request);
            return Ok(response);
        }
    }
}
