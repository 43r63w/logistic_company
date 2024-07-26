using Application.DTOS;
using Application.DTOS.Product;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<DetailInfoAboutProductDTO>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok("work");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<DetailInfoAboutProductDTO>> GetProduct(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(policy:"EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> CreateProduct(CreateProductDTO createProductDto)
        {
            var result = await _productService.CreateProductAsync(createProductDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(policy:"EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> UpdateProduct(int id, UpdateProductDTO updateProductDto)
        {
            var result = await _productService.UpdateProductAsync(id, updateProductDto);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        [Authorize(policy:"EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return Ok(result);
        }

    }
}
