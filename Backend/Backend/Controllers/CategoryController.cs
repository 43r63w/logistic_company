using Application.DTOS.Category;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var result = await _categoryService.GetCategoriByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDTO)
        {
            var result = await _categoryService.CreateCategoryAsync(categoryDTO);

            if (!result.IsSucceded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("CreateCategory/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryDTO categoryDTO)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, categoryDTO);

            if (!result.IsSucceded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
