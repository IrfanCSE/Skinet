using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repo;
        public BasketController(IBasketRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket([FromQuery]string id)
        {
            var data = await _repo.GetBasket(id);
            return Ok(data ?? new Basket(id));
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> SetBasket(Basket basket)
        {
            var data = await _repo.SetBasket(basket);
            return Ok(data);
        }

        [HttpDelete]
        public async Task DeleteBasket([FromQuery]string Id)
        {
            await _repo.DeleteBasket(Id);
        }

    }
}