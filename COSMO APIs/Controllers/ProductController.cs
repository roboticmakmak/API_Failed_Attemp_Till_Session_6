using AutoMapper;
using cosmo.core2.Entities;
using cosmo.core2.Reposatries;
using cosmo.core2.spesification;
using cosmo.repro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COSMO_APIs.Controllers
{
    public class ProductController : APIsBaseController
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> productRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            ._mapper = mapper;
        }

        // Get all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var spec = new ProductWithBrandAndTypeSpecification<Product>();
            return Ok(await _productRepo.GetAllWithSpecAsync(spec));
        }

        // Get product by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return Ok(product);
        }
    }

    
}
