using Microsoft.AspNetCore.Mvc;
using ProductApi.Enetities;
using ProductApi.Services;

namespace ProductApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetProduct(string id)
    {
        var product = await _productService.GetProductAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName(string name)
    {
        var products = await _productService.GetProductsByNameAsync(name);
        return Ok(products);
    }

    [Route("[action]/{category}", Name = "GetProductsByCategory")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
    {
        var products = await _productService.GetProductsByCategoryAsync(category);
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _productService.AddProductAsync(product);

        return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }
        return Ok(await _productService.UpdateProductAsync(product));
    }

    [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        return Ok(await _productService.DeleteProductAsync(id));
    }
}
