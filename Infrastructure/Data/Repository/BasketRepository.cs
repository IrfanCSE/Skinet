using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Infrastructure.Data.Repository
{
    public class BasketRepository : IBasketRepository
    {
        public readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database=redis.GetDatabase();
        }

        public async Task<bool> DeleteBasket(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<Basket> GetBasket(string id)
        {
            var data = await _database.StringGetAsync(id);
            return data.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<Basket>(data);
        }

        public async Task<Basket> SetBasket(Basket basket)
        {
            var basketSet = await _database.StringSetAsync(basket.Id,JsonConvert.SerializeObject(basket),TimeSpan.FromDays(30));
            if(!basketSet){
                return null;
            }
            return await GetBasket(basket.Id);
        }
    }
}