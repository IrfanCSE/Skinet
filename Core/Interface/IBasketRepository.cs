using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(string id);
        Task<Basket> SetBasket(Basket basket);
        Task<bool> DeleteBasket(string id);
    }
}