using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;

namespace Infrastructure.Service
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Product> _prodRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IBasketRepository _basketRepo;
        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<Product> prodRepo, IGenericRepository<DeliveryMethod> dmRepo, IBasketRepository basketRepo)
        {
            _basketRepo = basketRepo;
            _dmRepo = dmRepo;
            _prodRepo = prodRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            //get basket from the repo.
            var basket = await _basketRepo.GetBasket(basketId);

            //get items from the product repo.
            var items = new List<OrderItem>();

            foreach (var item in basket.items)
            {
                var product = await _prodRepo.GetEntityWithOutSpec(item.Id);
                var productItemOrdered = new ProductItemOrdered(product.Id,product.Name,product.PictureUrl);
                var OrderItem = new OrderItem(productItemOrdered,product.Price,item.Quantity);
                items.Add(OrderItem);
            }

            //get delivery method form repo.
            var deliveryMethod = await _dmRepo.GetEntityWithOutSpec(deliveryMethodId);

            // calc subtotal.
            var subtotal = items.Sum(i=> i.Price*i.Quantity);

            // create order
            var order = new Order(buyerEmail,shippingAddress,deliveryMethod,items,subtotal);

            // TODO: save to db

            // return order
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}