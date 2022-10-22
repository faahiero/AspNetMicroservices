using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            _logger.LogInformation("GetProducts called");
            var products = await _repository.GetProducts();
            
            switch (products)
            {
                case null:
                    _logger.LogError("No products found");
                    return NotFound();
                default:
                    return Ok(products);
            }
        }
        
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            _logger.LogInformation("GetProductById called");
            var product = await _repository.GetProduct(id);
            
            switch (product)
            {
                case null:
                    _logger.LogError("No product found");
                    return NotFound();
                default:
                    return Ok(product);
            }
        }
        
        [HttpGet("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            _logger.LogInformation("GetProductByCategory called");
            var products = await _repository.GetProductByCategory(category);
            
            switch (products)
            {
                case null:
                    _logger.LogError("No products found");
                    return NotFound();
                default:
                    return Ok(products);
            }
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            _logger.LogInformation("CreateProduct called");
            await _repository.CreateProduct(product);
            return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            _logger.LogInformation("UpdateProduct called");
            return Ok(await _repository.UpdateProduct(product));
        }
        
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            _logger.LogInformation("DeleteProductById called");
            return Ok(await _repository.DeleteProduct(id));
        }



    }
}