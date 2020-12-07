using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderWithIncludeSpecification : BaseSpecifications<Order>
    {
        public OrderWithIncludeSpecification(string email):base(o=>o.BuyerEmail==email)
        {
            AddInclude(o=>o.DeliveryMethod);
            AddInclude(o=>o.OrderItems);
            AddOrderByDesc(o=>o.OrderDate);
        }

        public OrderWithIncludeSpecification(int id, string email) : base(o=> o.Id==id && o.BuyerEmail==email)
        {
            AddInclude(o=>o.DeliveryMethod);
            AddInclude(o=>o.OrderItems);
        }
    }
}