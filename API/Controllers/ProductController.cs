using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase {
        private readonly SkinetContext _context;
        public ProductController (SkinetContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct () {
            return await _context.Products.ToListAsync();
        }
    }
}