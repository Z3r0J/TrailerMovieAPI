using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Category;
using TrailerMovieAPI.Core.Application.Interfaces.Services;

namespace TrailerMovieAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MovieCategoryController : BaseAPIController
    {
        private readonly IMovieCategoryServices _movieCategoryServices;
        public MovieCategoryController(IMovieCategoryServices movieCategoryServices)
        {
            _movieCategoryServices = movieCategoryServices;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoryAsync() {

            try
            {
                var category = await _movieCategoryServices.GetAllViewModel();

                if (category == null || category.Count == 0)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var category = await _movieCategoryServices.GetByIdSaveViewModel(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(RegisterMovieCategoryRequest request) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var actor = await _movieCategoryServices.Add(request);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(RegisterMovieCategoryRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id,RegisterMovieCategoryRequest request) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.Id = id;

               await _movieCategoryServices.Update(request,id);

                return Ok(request);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id) {

            try
            {


               await _movieCategoryServices.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
