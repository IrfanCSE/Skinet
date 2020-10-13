using System.Collections.Generic;

namespace Core.Entities
{
    public class Basket
    {
        public Basket()
        {
        }

        public Basket(string id)
        {
            Id=id;
        }

        public string Id { get; set; }
        public List<BasketItem> items { get; set; } = new List<BasketItem>();
    }
}