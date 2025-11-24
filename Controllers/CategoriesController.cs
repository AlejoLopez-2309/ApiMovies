using ApiMovies.DAL.Models;
using ApiMovies.DAL.Models.Dtos;
using ApiMovies.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryDtos>>> GetCategoriesAsync()
        {
            var categoriesDto = await _categoryServices.GetCategoriesAsync();
            return Ok(categoriesDto); //http status code 200
        }

        [HttpGet("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDtos>> GetCategoryAsync(int id)
        {
            try
            {
                var categoryDto = await _categoryServices.GetCategoryAsync(id);
                return Ok(categoryDto);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No se encontro"))
            {
                return NotFound(new { ex.Message });
            }
        }

        [HttpPost(Name = "CreateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CategoryDtos>> CreateCategoryAsync([FromBody] CategoryCreateUpdateDtos categoryCreateDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCategory = await _categoryServices.CreateCategoryAsync(categoryCreateDtos);

                return CreatedAtRoute("GetCategoryAsync", new { id = createdCategory.Id }, createdCategory);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe la categoría"))
            {
                return Conflict(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}