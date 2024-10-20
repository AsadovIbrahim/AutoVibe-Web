using Car.Domain.DTO_s;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Car.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Car.Domain.Entities.Concretes;
using Car.Persistance.Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("AddCategory")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddCategory([FromBody]AddCategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Category is null!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _categoryService.AddCategoryAsync(categoryDTO,userId);
            return Ok("Category created succesfully...");
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories(int page,int size)
        {
           var categories= await _categoryService.GetCategoriesAsync(page, size);
           return Ok(categories);
        }
        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryDTO updateCategoryDTO)
        {
            if (updateCategoryDTO == null) return BadRequest("Category is null!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _categoryService.UpdateCategoryAsync(updateCategoryDTO, userId);
            return Ok($"Category with {updateCategoryDTO.Id} updated succesfully...");
        }
        [HttpDelete("RemoveCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveCategory([FromBody]string categoryId)
        {
            if (categoryId == null) return BadRequest("Vehicles Empty!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _categoryService.RemoveCategoryAsync(categoryId);
            return Ok($"Category with {categoryId} removed successfully!");
        }
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById([FromQuery]string categoryId)
        {
            if (categoryId == null) return BadRequest("Categories Empty!");
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);
            return Ok(category);
        }
    }
}
