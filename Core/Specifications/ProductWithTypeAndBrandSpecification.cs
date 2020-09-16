using System;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecifications<Product>
    {
        public ProductWithTypeAndBrandSpecification(ProductParams productParams) :
            base(x=>
                (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId)
            )
        {
            AddPagination((productParams.PageSize*(productParams.PageIndex-1)),productParams.PageSize);
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);

            if(!String.IsNullOrWhiteSpace(productParams.Sort)){
                switch(productParams.Sort){
                    case "priceAsc":
                        AddOrderBy(x=>x.Price);
                        break;
                    
                    case "priceDesc":
                        AddOrderByDesc(x=>x.Price);
                        break;
                    
                    default:
                        AddOrderBy(x=>x.Name);
                        break;
                }
            }
        }
    }
}