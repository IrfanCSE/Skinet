using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/basket")]
    public class BasketController : ControllerBase {
        private readonly IBasketRepository _repo;
        private readonly IMapper _mapper;
        public BasketController (IBasketRepository repo, IMapper mapper) {
            this._mapper = mapper;
            this._repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket ([FromQuery] string id) {
            var data = await _repo.GetBasket (id);
            return Ok (data ?? new Basket (id));
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> SetBasket (BasketDto basketDto) {
            var basket =_mapper.Map<BasketDto,Basket>(basketDto);
            var data = await _repo.SetBasket (basket);
            return Ok (data);
        }

        [HttpDelete]
        public async Task DeleteBasket ([FromQuery] string Id) {
            await _repo.DeleteBasket (Id);
        }

    }
}