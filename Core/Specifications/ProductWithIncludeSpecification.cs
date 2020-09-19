using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithIncludeSpecification : BaseSpecifications<Product>
    {
        public ProductWithIncludeSpecification()
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
            IsPagingEnable = false;
        }
    }
}