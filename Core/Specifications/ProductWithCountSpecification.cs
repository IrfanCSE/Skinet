using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithCountSpecification : BaseSpecifications<Product>
    {
        public ProductWithCountSpecification(ProductParams productParams) :
            base(x=>
                (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId)
            )
        {
            IsPagingEnable = false;
        }
    }
}