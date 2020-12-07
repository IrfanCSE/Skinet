using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;

namespace Infrastructure.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepo)
        {
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {

            //get basket from the repo.
            var basket = await _basketRepo.GetBasket(basketId);

            //get items from the product repo.
            var items = new List<OrderItem>();

            foreach (var item in basket.items)
            {
                var product = await _unitOfWork.Repository<Product>().GetEntityWithOutSpec(item.Id);
                var productItemOrdered = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);
                var OrderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);
                items.Add(OrderItem);
            }

            //get delivery method form repo.
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetEntityWithOutSpec(deliveryMethodId);

            // calc subtotal.
            var subtotal = items.Sum(i => i.Price * i.Quantity);

            // create order
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, items, subtotal);
            _unitOfWork.Repository<Order>().Add(order);

            // save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // delete basket
            await _basketRepo.DeleteBasket(basketId);

            // return order
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return _unitOfWork.Repository<DeliveryMethod>().GetEntityListWithOutSpec();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrderWithIncludeSpecification(id, buyerEmail);
            return _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithIncludeSpecification(buyerEmail);
            return _unitOfWork.Repository<Order>().GetEntityListWithSpec(spec);
        }
    }
}