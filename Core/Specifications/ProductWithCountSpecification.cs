using System;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithCountSpecification : BaseSpecifications<Product>
    {
        public ProductWithCountSpecification(ProductParams productParams) :
            base(x=>
                (String.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId)
            )
        {
            IsPagingEnable = false;
        }
    }
}