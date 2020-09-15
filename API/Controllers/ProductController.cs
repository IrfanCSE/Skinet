using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
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
        
        public ProductController (
            IMapper mapper,
            IGenericRepository<Product> productRepo
        )
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductForViewDto>>> GetProducts () {
            // var products = await _repository.GetProducts ();

            var spec = new ProductWithTypeAndBrandSpecification();
            var products = await _productRepo.GetEntityListWithSpec(spec);

            return Ok (_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductForViewDto>> (products));
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ProductForViewDto>> GetProduct (int id) {
            // var product = await _repository.GetProduct (id);

            var spec = new ProductWithTypeAndBrandSpecification();
            var products = await _productRepo.GetEntityWithSpec(spec);

            return Ok (_mapper.Map<Product, ProductForViewDto> (products));
        }
    }
}