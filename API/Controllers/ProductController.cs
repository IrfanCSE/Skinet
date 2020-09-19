using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helper;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        // private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;

        public ProductController(IMapper mapper,
            IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> brandRepo,
            IGenericRepository<ProductType> typeRepo
            )
        {
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pageination<ProductForViewDto>>> GetProducts([FromQuery] ProductParams productParams)
        {
            // var products = await _repository.GetProducts ();

            var spec = new ProductWithTypeAndBrandSpecification(productParams);
            var countSpec = new ProductWithCountSpecification(productParams);

            var count = await _productRepo.GetCountAsync(countSpec);
            var products = await _productRepo.GetEntityListWithSpec(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductForViewDto>>(products);

            var result = new Pageination<ProductForViewDto>(productParams.PageIndex, productParams.PageSize, count, data);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductForViewDto>> GetProduct(int id)
        {
            // var product = await _repository.GetProduct (id);

            var spec = new ProductWithIncludeSpecification();
            var products = await _productRepo.GetEntityWithSpec(spec, id);

            return Ok(_mapper.Map<Product, ProductForViewDto>(products));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _brandRepo.GetEntityListWithOutSpec();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await _typeRepo.GetEntityListWithOutSpec();
            return Ok(types);
        }
    }
}