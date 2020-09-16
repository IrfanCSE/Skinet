using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helper;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/products")]
    public class ProductController : ControllerBase {
        // private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepo;
        
        public ProductController (IMapper mapper,
            IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pageination<ProductForViewDto>>> GetProducts ([FromQuery]ProductParams productParams) {
            // var products = await _repository.GetProducts ();

            var spec = new ProductWithTypeAndBrandSpecification(productParams);
            var countSpec = new ProductWithCountSpecification(productParams);

            var count = await _productRepo.GetCountAsync(countSpec);
            var products = await _productRepo.GetEntityListWithSpec(spec);
            
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductForViewDto>> (products);

            var result = new Pageination<ProductForViewDto>(productParams.PageIndex,productParams.PageSize,count,data);

            return Ok (result);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ProductForViewDto>> GetProduct ([FromQuery]ProductParams productParams) {
            // var product = await _repository.GetProduct (id);

            var spec = new ProductWithTypeAndBrandSpecification(productParams);
            var products = await _productRepo.GetEntityWithSpec(spec);

            return Ok (_mapper.Map<Product, ProductForViewDto> (products));
        }
    }
}