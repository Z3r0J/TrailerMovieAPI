using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrailerMovieAPI.Core.Application.DTOS.Director;
using TrailerMovieAPI.Core.Application.Interfaces.Services;

namespace TrailerMovieAPI.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DirectorController : BaseAPIController
    {
        private readonly IDirectorServices _directorServices;
        public DirectorController(IDirectorServices directorServices)
        {
            _directorServices = directorServices;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DirectorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDirectorAsync() {

            try
            {
                var director = await _directorServices.GetAllViewModel();

                if (director == null || director.Count == 0)
                {
                    return NotFound();
                }

                return Ok(director);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DirectorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var director = await _directorServices.GetByIdSaveViewModel(id);

                if (director == null)
                {
                    return NotFound();
                }

                return Ok(director);
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
        public async Task<IActionResult> CreateAsync(RegisterDirectorRequest request) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _directorServices.Add(request);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(RegisterDirectorRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id,RegisterDirectorRequest request) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.Id = id;

               await _directorServices.Update(request,id);

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


               await _directorServices.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
