using Application.Interfaces;
using Application.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [SwaggerOperation(Summary = "Retrieves all products")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll([FromQuery]string query)
        {
            var products = await _productService.GetAllProducts(query);

            return Ok(products);
        }

        [SwaggerOperation(Summary = "Retrieves a specific product by unique id")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Get([FromRoute]int id)
        {
            var products = await _productService.GetProductById(id);

            return Ok(products);
        }

        [SwaggerOperation(Summary = "Create a new product")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateProductDto productDto)
        {
            await _productService.CreateProduct(productDto);
            return Ok();
        }

        [SwaggerOperation(Summary = "Update a existing product")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody]UpdateProductDto productDto, [FromRoute]int id)
        {
            await _productService.UpdateProduct(productDto, id);
            return Ok();
        }

        [SwaggerOperation(Summary = "Delete a specific product by unique id")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
